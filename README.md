# What is The49.Twilio.Video.Maui?

Twilio.Video.Maui is a .NET MAUI library used to build in-app video calling
solutions using Twilio Video service.

# Setup

```cs
using The49.Twilio.Video.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        // Initialise the plugin
        builder
            .UseMauiApp<App>()
            .UseTwilioVideo()

        // the rest of your logic...
    }
}
```

# XAML usage

In order to make use of the plugin within XAML you can use this namespace:

```
xmlns:twilio="https://schemas.twilio.com/dotnet/2023/maui"
```

# Setup

Setup your project as you would an Android or iOS project according to the
Twilio Video SDK. You can follow this
[guide](https://www.twilio.com/docs/video/overview) for the Overview.

The Android guide is a great starting point, all Java code has its C# equivalent
through this package, listeners are replaced with events for convenience.

When displaying a remote of local video track, you can use the
`TwilioVideoView`.

# Example

We'll walk through how to setup a one to one chat app using this package.

In any page you want the video chat, create your layout. For example here we'll
put the remote video fullscreen and have the local video in the corner.

```xaml
<Grid>
    <twilio:TwilioVideoView x:Name="remoteVideoView" Margin="0,-50" />
    <Border Stroke="Transparent"
            StrokeShape="RoundRectangle 20"
            VerticalOptions="End"
            HorizontalOptions="End"
            Margin="10">
        <Grid HeightRequest="200"
            WidthRequest="130">
            <twilio:TwilioVideoView x:Name="localVideoView" />
        </Grid>
    </Border>
</Grid>
```

In the code behind we'll follow the Twilio documentation to connect to a room:


```cs
public partial class VideoChatPage : ContentPage
{
    Room _room;
    LocalVideoTrack _localVideoTrack;
    LocalAudioTrack _localAudioTrack;

    public string RoomName { get; set; }

    public VideoChatPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        // Fetch the token from our backend (see https://www.twilio.com/docs/video/overview#1-create-an-access-token-server)
        using var httpClient = new HttpClient();

        var response = await httpClient.GetAsync($"https://cheap-bobcat-95.deno.dev?identity={DeviceInfo.Name}");

        var token = await response.Content.ReadAsStringAsync();


        // Ask for the Microphone + video permission
        var status = await Permissions.RequestAsync<Permissions.Microphone>();

        if (status is not PermissionStatus.Granted)
        {
            return;
        }

        status = await Permissions.RequestAsync<Permissions.Camera>();

        if (status is not PermissionStatus.Granted)
        {
            return;
        }

        // Create the local audio track
        _localAudioTrack = LocalAudioTrack.Create(true);

        // Capture the video from the camera. We pick the front facing camera for now
        var cameraCapturer = CameraCapturer.Create(CameraPosition.Front);

        // Create the local video track from the camera capturer
        _localVideoTrack = LocalVideoTrack.Create(true, cameraCapturer);

        // Display the local video in the video view
        _localVideoTrack.AddSink(localVideoView);

        // Configure the connection options. Pass the token and the tracks we want to send to remote participants
        var options = new ConnectOptions.Builder(token)
            .RoomName(RoomName)
            .VideoTracks(new List<LocalVideoTrack> { _localVideoTrack })
            .AudioTracks(new List<LocalAudioTrack> { _localAudioTrack })
            .Build();

        _room = TwilioVideoService.Default.Connect(options);

        // Listen to the room events
        _room.ConnectFailure += OnRoomConnectFailure;
        _room.Connected += OnRoomConnected;
        _room.ParticipantConnected += OnParticipantConnected;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _localVideoTrack.Release();
        _localAudioTrack.Release();
        _room.Disconnect();
    }

    void OnRoomConnectFailure(object sender, TwilioException e)
    {
        DisplayAlert("Connection error", e.ToString(), "Ok");
    }

    void OnParticipantConnected(object sender, RemoteParticipant participant)
    {
        // Someone joined the room, listen to their video track subscriptions
        participant.VideoTrackSubscribed += OnParticipantVideoTrackSubscribed;
    }

    void OnRoomConnected(object sender, EventArgs e)
    {
        // We just connected to a room, check if there are anyone there already
        var room = sender as Room;
        foreach (var participant in room.RemoteParticipants)
        {
            var remoteTrack = participant.RemoteVideoTracks.FirstOrDefault();

            // THe participant has a video, display it
            if (remoteTrack is not null && remoteTrack.RemoteVideoTrack is not null)
            {
                remoteTrack.RemoteVideoTrack.AddSink(remoteVideoView);
            }
            // Otherwise listen to the video subscription event
            participant.VideoTrackSubscribed += OnParticipantVideoTrackSubscribed;
        }
    }

    void OnParticipantVideoTrackSubscribed(object sender, RemoteParticipant.VideoTrackSubscriptionEventArgs e)
    {
        e.RemoteVideoTrack.AddSink(remoteVideoView);
    }
}
```

# Common questions

## How do I show/hide my video or mute my audio?

The local video tracks and local audio tracks have a IsEnabled bool property:

```cs
localVideoTrack.IsEnabled = true; // Show video.
localVideoTrack.IsEnabled = false; // Hide video.

localAudioTrack.IsEnabled = false; // Mute.
localAudioTrack.IsEnabled = true; // Unmute.
```

## When I join a room already in progress, how do I gather the remote participants?

After connecting to the room, use the Connected event

```cs
// Connect to the room with local video and audio tracks.
room = TwilioVideoService.Default.Connect( options );
room.Connected += OnRoomConnected;

void OnRoomConnected( object sender, EventArgs e )
{
    // Sender is the room.
    var theRoom = sender as Room;
    // This holds the participants already connected
    var remoteParticipants = theRoom.RemoteParticipants; 
}
```
