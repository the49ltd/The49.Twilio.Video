using Twilio.Video;
using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public partial class DataTrack : PlatformWrapper<TwilioVideo.DataTrack>, IDataTrack
{
    public DataTrack(TwilioVideo.DataTrack platform) : base(platform)
    {
    }

    public string Name => _platform.Name;

    public bool IsEnabled => _platform.IsEnabled;
}

public partial class LocalDataTrack : DataTrack, ILocalDataTrack
{
    public LocalDataTrack(TwilioVideo.LocalDataTrack platform) : base(platform)
    {
    }
}

public partial class RemoteDataTrack : DataTrack, IRemoteDataTrack
{
    public RemoteDataTrack(TwilioVideo.RemoteDataTrack platform) : base(platform)
    {
    }
}
public partial class LocalParticipant
{
    TwilioVideo.LocalParticipant _platform;
    public LocalParticipant(TwilioVideo.LocalParticipant platform)
    {
        _platform = platform;
    }
}

public partial class RemoteAudioTrackPublication : PlatformWrapper<TwilioVideo.RemoteAudioTrackPublication>, IRemoteAudioTrackPublication
{
    public RemoteAudioTrackPublication(TwilioVideo.RemoteAudioTrackPublication platform) : base(platform)
    {
    }

    public RemoteAudioTrack RemoteAudioTrack => new RemoteAudioTrack(_platform.RemoteAudioTrack);
}

public partial class RemoteVideoTrackPublication : PlatformWrapper<TwilioVideo.RemoteVideoTrackPublication>, IRemoteVideoTrackPublication
{
    public RemoteVideoTrackPublication(TwilioVideo.RemoteVideoTrackPublication platform) : base(platform)
    {
    }
    public RemoteVideoTrack RemoteVideoTrack => RemoteVideoTrack.FromPlatform(_platform.RemoteVideoTrack);
}

public partial class RemoteDataTrackPublication : PlatformWrapper<TwilioVideo.RemoteDataTrackPublication>, IRemoteDataTrackPublication
{
    public RemoteDataTrackPublication(TwilioVideo.RemoteDataTrackPublication platform) : base(platform)
    {
    }
    public RemoteDataTrack RemoteDataTrack => new RemoteDataTrack(_platform.RemoteDataTrack);
}

public partial class RemoteAudioTrack: AudioTrack, IRemoteAudioTrack
{
    new TwilioVideo.RemoteAudioTrack _platform;

    internal RemoteAudioTrack(TwilioVideo.RemoteAudioTrack platform): base(platform)
    {
        _platform = platform;
    }
}

public partial class RemoteVideoTrack : VideoTrack, IRemoteVideoTrack
{
    new TwilioVideo.RemoteVideoTrack _platform;

    internal RemoteVideoTrack(TwilioVideo.RemoteVideoTrack platform) : base(platform)
    {
        _platform = platform;
    }

    public static RemoteVideoTrack FromPlatform(TwilioVideo.RemoteVideoTrack platform) => platform is null ? null : new RemoteVideoTrack(platform);
}

public partial class RemoteParticipant: Java.Lang.Object, IRemoteParticipant, TwilioVideo.RemoteParticipant.IListener
{
    TwilioVideo.RemoteParticipant _platform;
    public RemoteParticipant(TwilioVideo.RemoteParticipant platform)
    {
        _platform = platform;
        platform.SetListener(this);
    }

    public IList<RemoteAudioTrackPublication> RemoteAudioTracks => _platform.RemoteAudioTracks.Select(r => new RemoteAudioTrackPublication(r)).ToList();
    public IList<RemoteVideoTrackPublication> RemoteVideoTracks => _platform.RemoteVideoTracks.Select(r => new RemoteVideoTrackPublication(r)).ToList();
    public IList<RemoteDataTrackPublication> RemoteDataTracks => _platform.RemoteDataTracks.Select(r => new RemoteDataTrackPublication(r)).ToList();

    public event EventHandler<AudioTrackEventArgs> AudioTrackDisabled;
    public event EventHandler<AudioTrackEventArgs> AudioTrackEnabled;
    public event EventHandler<AudioTrackEventArgs> AudioTrackPublished;
    public event EventHandler<AudioTrackPublishPriorityChangedEventArgs> AudioTrackPublishPriorityChanged;
    public event EventHandler<AudioTrackSubscriptionEventArgs> AudioTrackSubscribed;
    public event EventHandler<AudioTrackSubscriptionFailedEventArgs> AudioTrackSubscriptionFailed;
    public event EventHandler<AudioTrackEventArgs> AudioTrackUnpublished;
    public event EventHandler<AudioTrackSubscriptionEventArgs> AudioTrackUnsubscribed;
    public event EventHandler<DataTrackPublishPriorityChangedEventArgs> DataTrackPublishPriorityChanged;
    public event EventHandler<DataTrackEventArgs> DataTrackPublished;
    public event EventHandler<DataTrackSubscriptionEventArgs> DataTrackSubscribed;
    public event EventHandler<DataTrackSubscriptionFailedEventArgs> DataTrackSubscriptionFailed;
    public event EventHandler<DataTrackEventArgs> DataTrackUnpublished;
    public event EventHandler<DataTrackSubscriptionEventArgs> DataTrackUnsubscribed;
    public event EventHandler<NetworkQualityLevel> NetworkQualityLevelChanged;
    public event EventHandler<VideoTrackEventArgs> VideoTrackDisabled;
    public event EventHandler<VideoTrackEventArgs> VideoTrackEnabled;
    public event EventHandler<VideoTrackPublishPriorityChangedEventArgs> VideoTrackPublishPriorityChanged;
    public event EventHandler<VideoTrackEventArgs> VideoTrackPublished;
    public event EventHandler<VideoTrackSubscriptionEventArgs> VideoTrackSubscribed;
    public event EventHandler<VideoTrackSubscriptionFailedEventArgs> VideoTrackSubscriptionFailed;
    public event EventHandler<RemoteVideoTrack> VideoTrackSwitchedOff;
    public event EventHandler<RemoteVideoTrack> VideoTrackSwitchedOn;
    public event EventHandler<VideoTrackEventArgs> VideoTrackUnpublished;
    public event EventHandler<VideoTrackSubscriptionEventArgs> VideoTrackUnsubscribed;

    public void OnAudioTrackDisabled(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteAudioTrackPublication remoteAudioTrackPublication)
    {
        AudioTrackDisabled?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(remoteAudioTrackPublication) });
    }

    public void OnAudioTrackEnabled(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteAudioTrackPublication remoteAudioTrackPublication)
    {
        AudioTrackEnabled?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(remoteAudioTrackPublication) });
    }

    public void OnAudioTrackPublished(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteAudioTrackPublication remoteAudioTrackPublication)
    {
        AudioTrackPublished?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(remoteAudioTrackPublication) });
    }

    public void OnAudioTrackSubscribed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteAudioTrackPublication remoteAudioTrackPublication, TwilioVideo.RemoteAudioTrack remoteAudioTrack)
    {
        AudioTrackSubscribed?.Invoke(this, new AudioTrackSubscriptionEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(remoteAudioTrackPublication), RemoteAudioTrack = new RemoteAudioTrack(remoteAudioTrack) });
    }

    public void OnAudioTrackSubscriptionFailed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteAudioTrackPublication remoteAudioTrackPublication, TwilioVideo.TwilioException exception)
    {
        AudioTrackSubscriptionFailed?.Invoke(this, new AudioTrackSubscriptionFailedEventArgs
        {
            RemoteAudioTrackPublication = new RemoteAudioTrackPublication(remoteAudioTrackPublication),
            Exception = new TwilioException(exception),
        });
    }

    public void OnAudioTrackUnpublished(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteAudioTrackPublication remoteAudioTrackPublication)
    {
        AudioTrackUnpublished?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(remoteAudioTrackPublication) });
    }

    public void OnAudioTrackUnsubscribed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteAudioTrackPublication remoteAudioTrackPublication, TwilioVideo.RemoteAudioTrack remoteAudioTrack)
    {
        AudioTrackUnsubscribed?.Invoke(this, new AudioTrackSubscriptionEventArgs
        {
            RemoteAudioTrackPublication = new RemoteAudioTrackPublication(remoteAudioTrackPublication),
            RemoteAudioTrack = new RemoteAudioTrack(remoteAudioTrack),
        });
    }

    public void OnDataTrackPublished(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteDataTrackPublication remoteDataTrackPublication)
    {
        DataTrackPublished?.Invoke(this, new DataTrackEventArgs { RemoteDataTrackPublication = new RemoteDataTrackPublication(remoteDataTrackPublication) });
    }

    public void OnDataTrackSubscribed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteDataTrackPublication remoteDataTrackPublication, TwilioVideo.RemoteDataTrack remoteDataTrack)
    {
        DataTrackSubscribed?.Invoke(this, new DataTrackSubscriptionEventArgs
        {
            RemoteDataTrackPublication = new RemoteDataTrackPublication(remoteDataTrackPublication),
            RemoteDataTrack = new RemoteDataTrack(remoteDataTrack),
        });
    }

    public void OnDataTrackSubscriptionFailed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteDataTrackPublication remoteDataTrackPublication, TwilioVideo.TwilioException exception)
    {
        DataTrackSubscriptionFailed?.Invoke(this, new DataTrackSubscriptionFailedEventArgs
        {
            RemoteDataTrackPublication = new RemoteDataTrackPublication(remoteDataTrackPublication),
            Exception = new TwilioException(exception),
        });
    }

    public void OnDataTrackUnpublished(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteDataTrackPublication remoteDataTrackPublication)
    {
        DataTrackUnpublished?.Invoke(this, new DataTrackEventArgs { RemoteDataTrackPublication = new RemoteDataTrackPublication(remoteDataTrackPublication) });
    }

    public void OnDataTrackUnsubscribed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteDataTrackPublication remoteDataTrackPublication, TwilioVideo.RemoteDataTrack remoteDataTrack)
    {
        DataTrackUnsubscribed?.Invoke(this, new DataTrackSubscriptionEventArgs
        {
            RemoteDataTrackPublication = new RemoteDataTrackPublication(remoteDataTrackPublication),
            RemoteDataTrack = new RemoteDataTrack(remoteDataTrack),
        });
    }

    public void OnVideoTrackDisabled(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteVideoTrackPublication remoteVideoTrackPublication)
    {
        VideoTrackDisabled?.Invoke(this, new VideoTrackEventArgs { RemoteVideoTrackPublication = new RemoteVideoTrackPublication(remoteVideoTrackPublication) });
    }

    public void OnVideoTrackEnabled(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteVideoTrackPublication remoteVideoTrackPublication)
    {
        VideoTrackEnabled?.Invoke(this, new VideoTrackEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(remoteVideoTrackPublication)
        });
    }

    public void OnVideoTrackPublished(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteVideoTrackPublication remoteVideoTrackPublication)
    {
        VideoTrackPublished?.Invoke(this, new VideoTrackEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(remoteVideoTrackPublication)
        });
    }

    public void OnVideoTrackSubscribed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteVideoTrackPublication remoteVideoTrackPublication, TwilioVideo.RemoteVideoTrack remoteVideoTrack)
    {
        VideoTrackSubscribed?.Invoke(this, new VideoTrackSubscriptionEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(remoteVideoTrackPublication),
            RemoteVideoTrack = new RemoteVideoTrack(remoteVideoTrack)
        });
    }

    public void OnVideoTrackSubscriptionFailed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteVideoTrackPublication remoteVideoTrackPublication, TwilioVideo.TwilioException exception)
    {
        VideoTrackSubscriptionFailed?.Invoke(this, new VideoTrackSubscriptionFailedEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(remoteVideoTrackPublication),
            Exception = new TwilioException(exception)
        });
    }

    public void OnVideoTrackUnpublished(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteVideoTrackPublication remoteVideoTrackPublication)
    {
        VideoTrackUnpublished?.Invoke(this, new VideoTrackEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(remoteVideoTrackPublication)
        });
    }

    public void OnVideoTrackUnsubscribed(TwilioVideo.RemoteParticipant remoteParticipant, TwilioVideo.RemoteVideoTrackPublication remoteVideoTrackPublication, TwilioVideo.RemoteVideoTrack remoteVideoTrack)
    {
        VideoTrackUnsubscribed?.Invoke(this, new VideoTrackSubscriptionEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(remoteVideoTrackPublication),
            RemoteVideoTrack = new RemoteVideoTrack(remoteVideoTrack)
        });
    }
}

public partial class TwilioException
{
    TwilioVideo.TwilioException _platform;
    public string Message => _platform.Message;
    public string LocalizedMessage => _platform.LocalizedMessage;
    public string StackTrace => _platform.StackTrace;
    public TwilioException(TwilioVideo.TwilioException platform)
    {
        _platform = platform;
    }
}

public partial class Room : Java.Lang.Object, IRoom, TwilioVideo.Room.IListener
{
    private TwilioVideo.Room _platform;

    public RemoteParticipant DominantSpeaker => new RemoteParticipant(_platform.DominantSpeaker);

    public LocalParticipant LocalParticipant => new LocalParticipant(_platform.LocalParticipant);

    public string MediaRegion => _platform.MediaRegion;

    public string Name => _platform.Name;

    public IList<RemoteParticipant> RemoteParticipants => _platform.RemoteParticipants.Select(p => new RemoteParticipant(p)).ToList();

    public string Sid => _platform.Sid;

    public IRoom.State GetState()
    {
        var state = _platform.GetState();
        if (state == TwilioVideo.Room.State.Connected) return IRoom.State.Connected;
        if (state == TwilioVideo.Room.State.Connecting) return IRoom.State.Connecting;
        if (state == TwilioVideo.Room.State.Disconnected) return IRoom.State.Disconnected;
        if (state == TwilioVideo.Room.State.Reconnecting) return IRoom.State.Reconnecting;
        return IRoom.State.Connected;
    }

    public event EventHandler<TwilioException> ConnectFailure;
    public event EventHandler Connected;
    public event EventHandler<TwilioException> Disconnected;
    public event EventHandler<RemoteParticipant> ParticipantConnected;
    public event EventHandler<RemoteParticipant> ParticipantDisconnected;
    public event EventHandler<RemoteParticipant> ParticipantReconnected;
    public event EventHandler<RemoteParticipant> ParticipantReconnecting;
    public event EventHandler Reconnected;
    public event EventHandler<TwilioException> Reconnecting;
    public event EventHandler RecordingStarted;
    public event EventHandler RecordingStopped;

    public void Disconnect()
    {
        _platform.Disconnect();
    }

    public void GetStats(IStatsListener statsListener)
    {
        throw new NotImplementedException();
    }

    public bool IsAudioProcessorSupported(string audioProcessorName)
    {
        return _platform.IsAudioProcessorSupported(audioProcessorName);
    }

    public bool IsRecording => _platform.IsRecording;

    internal void SetPlatform(TwilioVideo.Room platformRoom)
    {
        _platform = platformRoom;
    }

    public void OnConnectFailure(TwilioVideo.Room room, TwilioVideo.TwilioException exception)
    {
        ConnectFailure?.Invoke(this, new TwilioException(exception));
    }

    public void OnConnected(TwilioVideo.Room room)
    {
        Connected?.Invoke(this, EventArgs.Empty);
    }

    public void OnDisconnected(TwilioVideo.Room room, TwilioVideo.TwilioException exception)
    {
        Disconnected?.Invoke(this, new TwilioException(exception));
    }

    public void OnParticipantConnected(TwilioVideo.Room room, TwilioVideo.RemoteParticipant participant)
    {
        ParticipantConnected?.Invoke(this, new RemoteParticipant(participant));
    }

    public void OnParticipantDisconnected(TwilioVideo.Room room, TwilioVideo.RemoteParticipant participant)
    {
        ParticipantDisconnected?.Invoke(this, new RemoteParticipant(participant));
    }

    public void OnParticipantReconnected(TwilioVideo.Room room, TwilioVideo.RemoteParticipant participant)
    {
        ParticipantReconnected?.Invoke(this, new RemoteParticipant(participant));
    }

    public void OnParticipantReconnecting(TwilioVideo.Room room, TwilioVideo.RemoteParticipant participant)
    {
        ParticipantReconnecting?.Invoke(this, new RemoteParticipant(participant));
    }

    public void OnReconnected(TwilioVideo.Room room)
    {
        Reconnected?.Invoke(this, EventArgs.Empty);
    }

    public void OnReconnecting(TwilioVideo.Room room, TwilioVideo.TwilioException exception)
    {
        Reconnecting?.Invoke(this, new TwilioException(exception));
    }

    public void OnRecordingStarted(TwilioVideo.Room room)
    {
        RecordingStarted?.Invoke(this, EventArgs.Empty);
    }

    public void OnRecordingStopped(TwilioVideo.Room room)
    {
        RecordingStopped?.Invoke(this, EventArgs.Empty);
    }
}

public partial class TwilioVideoService : ITwilioVideoService
{
    public Room Connect(ConnectOptions options)
    {
        var room = new Room();

        var platformRoom = TwilioVideo.TwilioVideo.Connect(Platform.CurrentActivity, options.Options, room);

        room.SetPlatform(platformRoom);

        return room;
    }
}