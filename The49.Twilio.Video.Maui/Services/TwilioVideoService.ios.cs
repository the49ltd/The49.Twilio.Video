using Foundation;
using Twilio;

namespace The49.Twilio.Video.Maui;

public partial class DataTrack : PlatformWrapper<TVIDataTrack>, IDataTrack
{
    public DataTrack(TVIDataTrack platform) : base(platform)
    {
    }

    public string Name => _platform.Name;

    public bool IsEnabled => _platform.Enabled;
}

public partial class LocalDataTrack : DataTrack, ILocalDataTrack
{
    public LocalDataTrack(TVILocalDataTrack platform) : base(platform)
    {
    }
}

public partial class RemoteDataTrack : DataTrack, IRemoteDataTrack
{
    public RemoteDataTrack(TVIRemoteDataTrack platform) : base(platform)
    {
    }
}
public partial class LocalParticipant
{
    TVILocalParticipant _platform;
    public LocalParticipant(TVILocalParticipant platform)
    {
        _platform = platform;
    }
}

public partial class RemoteAudioTrackPublication : PlatformWrapper<TVIRemoteAudioTrackPublication>, IRemoteAudioTrackPublication
{
    public RemoteAudioTrackPublication(TVIRemoteAudioTrackPublication platform) : base(platform)
    {
    }

    public RemoteAudioTrack RemoteAudioTrack => new RemoteAudioTrack(_platform.RemoteTrack);
}

public partial class RemoteVideoTrackPublication : PlatformWrapper<TVIRemoteVideoTrackPublication>, IRemoteVideoTrackPublication
{
    public RemoteVideoTrackPublication(TVIRemoteVideoTrackPublication platform) : base(platform)
    {
    }
    public RemoteVideoTrack RemoteVideoTrack => RemoteVideoTrack.FromPlatform(_platform.RemoteTrack);
}

public partial class RemoteDataTrackPublication : PlatformWrapper<TVIRemoteDataTrackPublication>, IRemoteDataTrackPublication
{
    public RemoteDataTrackPublication(TVIRemoteDataTrackPublication platform) : base(platform)
    {
    }
    public RemoteDataTrack RemoteDataTrack => new RemoteDataTrack(_platform.RemoteTrack);
}

public partial class RemoteAudioTrack : AudioTrack, IRemoteAudioTrack
{
    TVIRemoteAudioTrack _platform;

    internal RemoteAudioTrack(TVIRemoteAudioTrack platform) : base(platform)
    {
        _platform = platform;
    }
}

public partial class RemoteVideoTrack : VideoTrack, IRemoteVideoTrack
{
    new TVIRemoteVideoTrack _platform;

    internal RemoteVideoTrack(TVIRemoteVideoTrack platform) : base(platform)
    {
        _platform = platform;
    }

    public static RemoteVideoTrack FromPlatform(TVIRemoteVideoTrack platform) => platform is null ? null : new RemoteVideoTrack(platform);
}

public partial class RemoteParticipant : TVIRemoteParticipantDelegate, IRemoteParticipant
{
    TVIRemoteParticipant _platform;
    public RemoteParticipant(TVIRemoteParticipant platform)
    {
        _platform = platform;
        platform.Delegate = this;
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

    public override void DidDisableAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
    {
        AudioTrackDisabled?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(publication) });
    }


    public override void DidEnableAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
    {
        AudioTrackEnabled?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(publication) });
    }

    public override void DidPublishAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
    {
        AudioTrackPublished?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(publication) });
    }

    public override void DidSubscribeToAudioTrack(TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant)
    {
        AudioTrackSubscribed?.Invoke(this, new AudioTrackSubscriptionEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(publication), RemoteAudioTrack = new RemoteAudioTrack(audioTrack) });
    }

    public override void DidFailToSubscribeToAudioTrack(TVIRemoteAudioTrackPublication publication, NSError error, TVIRemoteParticipant participant)
    {
        AudioTrackSubscriptionFailed?.Invoke(this, new AudioTrackSubscriptionFailedEventArgs
        {
            RemoteAudioTrackPublication = new RemoteAudioTrackPublication(publication),
            Exception = new TwilioException(error),
        });
    }

    public override void DidUnpublishAudioTrack(TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication)
    {
        AudioTrackUnpublished?.Invoke(this, new AudioTrackEventArgs { RemoteAudioTrackPublication = new RemoteAudioTrackPublication(publication) });
    }

    public override void DidUnsubscribeFromAudioTrack(TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant)
    {
        AudioTrackUnsubscribed?.Invoke(this, new AudioTrackSubscriptionEventArgs
        {
            RemoteAudioTrackPublication = new RemoteAudioTrackPublication(publication),
            RemoteAudioTrack = new RemoteAudioTrack(audioTrack),
        });
    }

    public override void DidPublishDataTrack(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication)
    {
        DataTrackPublished?.Invoke(this, new DataTrackEventArgs { RemoteDataTrackPublication = new RemoteDataTrackPublication(publication) });
    }



    public override void DidSubscribeToDataTrack(TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant)
    {
        DataTrackSubscribed?.Invoke(this, new DataTrackSubscriptionEventArgs
        {
            RemoteDataTrackPublication = new RemoteDataTrackPublication(publication),
            RemoteDataTrack = new RemoteDataTrack(dataTrack),
        });
    }

    public override void DidFailToSubscribeToDataTrack(TVIRemoteDataTrackPublication publication, NSError error, TVIRemoteParticipant participant)
    {
        DataTrackSubscriptionFailed?.Invoke(this, new DataTrackSubscriptionFailedEventArgs
        {
            RemoteDataTrackPublication = new RemoteDataTrackPublication(publication),
            Exception = new TwilioException(error),
        });
    }


    public override void DidUnpublishDataTrack(TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication)
    {
        DataTrackUnpublished?.Invoke(this, new DataTrackEventArgs { RemoteDataTrackPublication = new RemoteDataTrackPublication(publication) });
    }

    public override void DidUnsubscribeFromDataTrack(TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant)
    {
        DataTrackUnsubscribed?.Invoke(this, new DataTrackSubscriptionEventArgs
        {
            RemoteDataTrackPublication = new RemoteDataTrackPublication(publication),
            RemoteDataTrack = new RemoteDataTrack(dataTrack),
        });
    }

    public override void DidDisableVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
    {
        VideoTrackDisabled?.Invoke(this, new VideoTrackEventArgs { RemoteVideoTrackPublication = new RemoteVideoTrackPublication(publication) });
    }

    public override void DidEnableVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
    {
        VideoTrackEnabled?.Invoke(this, new VideoTrackEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(publication)
        });
    }

    public override void DidPublishVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
    {
        VideoTrackPublished?.Invoke(this, new VideoTrackEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(publication)
        });
    }

    public override void DidSubscribeToVideoTrack(TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant)
    {
        VideoTrackSubscribed?.Invoke(this, new VideoTrackSubscriptionEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(publication),
            RemoteVideoTrack = new RemoteVideoTrack(videoTrack)
        });
    }

    public override void DidFailToSubscribeToVideoTrack(TVIRemoteVideoTrackPublication publication, NSError error, TVIRemoteParticipant participant)
    {
        VideoTrackSubscriptionFailed?.Invoke(this, new VideoTrackSubscriptionFailedEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(publication),
            Exception = new TwilioException(error)
        });
    }

    public override void DidUnpublishVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication)
    {
        VideoTrackUnpublished?.Invoke(this, new VideoTrackEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(publication)
        });
    }

    public override void DidUnsubscribeFromVideoTrack(TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant)
    {
        VideoTrackUnsubscribed?.Invoke(this, new VideoTrackSubscriptionEventArgs
        {
            RemoteVideoTrackPublication = new RemoteVideoTrackPublication(publication),
            RemoteVideoTrack = new RemoteVideoTrack(videoTrack)
        });
    }

    public override void NetworkQualityLevelDidChange(TVIRemoteParticipant participant, TVINetworkQualityLevel networkQualityLevel)
    {
        NetworkQualityLevelChanged?.Invoke(this, networkQualityLevel switch
        {
            TVINetworkQualityLevel.Zero => NetworkQualityLevel.Zero,
            TVINetworkQualityLevel.One => NetworkQualityLevel.One,
            TVINetworkQualityLevel.Two => NetworkQualityLevel.Two,
            TVINetworkQualityLevel.Three => NetworkQualityLevel.Three,
            TVINetworkQualityLevel.Four => NetworkQualityLevel.Four,
            TVINetworkQualityLevel.Five => NetworkQualityLevel.Five,
            TVINetworkQualityLevel.Unknown or _ => NetworkQualityLevel.Unknown,
        });
    }

    public override void SwitchedOffVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrack track)
    {
        VideoTrackSwitchedOff?.Invoke(this, RemoteVideoTrack.FromPlatform(track));
    }

    public override void SwitchedOnVideoTrack(TVIRemoteParticipant participant, TVIRemoteVideoTrack track)
    {
        VideoTrackSwitchedOn?.Invoke(this, RemoteVideoTrack.FromPlatform(track));
    }
}

public partial class TwilioException
{
    NSError _platform;

    public string Message => _platform.Description;
    public string LocalizedMessage => _platform.DebugDescription;
    public string StackTrace => string.Empty;
    public TwilioException(NSError platform)
    {
        _platform = platform;
    }
}

public partial class Room : TVIRoomDelegate, IRoom
{
    private TVIRoom _platform;

    public RemoteParticipant DominantSpeaker => new RemoteParticipant(_platform.DominantSpeaker);

    public LocalParticipant LocalParticipant => new LocalParticipant(_platform.LocalParticipant);

    public string MediaRegion => _platform.MediaRegion;

    public string Name => _platform.Name;

    public IList<RemoteParticipant> RemoteParticipants => _platform.RemoteParticipants.Select(p => new RemoteParticipant(p)).ToList();

    public string Sid => _platform.Sid;

    public IRoom.State GetState()
    {
        var state = _platform.State;
        if (state == TVIRoomState.Connected) return IRoom.State.Connected;
        if (state == TVIRoomState.Connecting) return IRoom.State.Connecting;
        if (state == TVIRoomState.Disconnected) return IRoom.State.Disconnected;
        if (state == TVIRoomState.Reconnecting) return IRoom.State.Reconnecting;
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

    public bool IsRecording => _platform.Recording;

    internal void SetPlatform(TVIRoom platform)
    {
        _platform = platform;
    }


    public override void DidConnectToRoom(TVIRoom room)
    {
        Connected?.Invoke(this, EventArgs.Empty);
    }
    
    public override void DidFailToConnectWithError(TVIRoom room, NSError error)
    {
        ConnectFailure?.Invoke(this, new TwilioException(error));
    }
    
    public override void DidDisconnectWithError(TVIRoom room, NSError error)
    {
        Disconnected?.Invoke(this, new TwilioException(error));
    }
    
    public override void IsReconnectingWithError(TVIRoom room, NSError error)
    {
        Reconnecting?.Invoke(this, new TwilioException(error));
    }
    
    public override void DidReconnectToRoom(TVIRoom room)
    {
        Reconnected?.Invoke(this, EventArgs.Empty);
    }
    
    public override void ParticipantDidConnect(TVIRoom room, TVIRemoteParticipant participant)
    {
        ParticipantConnected?.Invoke(this, new RemoteParticipant(participant));
    }
    
    public override void ParticipantDidDisconnect(TVIRoom room, TVIRemoteParticipant participant)
    {
        ParticipantDisconnected?.Invoke(this, new RemoteParticipant(participant));
    }
    
    public override void ParticipantIsReconnecting(TVIRoom room, TVIRemoteParticipant participant)
    {
        ParticipantReconnecting?.Invoke(this, new RemoteParticipant(participant));
    }
    
    public override void ParticipantDidReconnect(TVIRoom room, TVIRemoteParticipant participant)
    {
        ParticipantReconnected?.Invoke(this, new RemoteParticipant(participant));
    }
    
    public override void RoomDidStartRecording(TVIRoom room)
    {
        RecordingStarted?.Invoke(this, EventArgs.Empty);
    }
    
    public override void RoomDidStopRecording(TVIRoom room)
    {
        RecordingStopped?.Invoke(this, EventArgs.Empty);
    }
    
    public override void DominantSpeakerDidChange(TVIRoom room, TVIRemoteParticipant participant)
    {
        //TODO: fire when event is added to shared
    }
}

public partial class TwilioVideoService : ITwilioVideoService
{
    public Room Connect(ConnectOptions options)
    {
        var room = new Room();

        var platformRoom = TwilioVideoSDK.ConnectWithOptions(options.Options, room);

        room.SetPlatform(platformRoom);

        return room;
    }
}