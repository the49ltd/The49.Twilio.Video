using The49.Twilio.Video.Maui;

namespace The49.Twilio.Video.Sample;

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