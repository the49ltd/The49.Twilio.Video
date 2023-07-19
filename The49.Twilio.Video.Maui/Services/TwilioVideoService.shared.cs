namespace The49.Twilio.Video.Maui;

public partial class PlatformWrapper<T>
{
    protected T _platform;

    public T Platform => _platform;

    internal PlatformWrapper(T platform)
    {
        _platform = platform;
    }
}

public partial class AudioOptions { }

#region Track
public interface ITrack
{
    public string Name { get; }
    public bool IsEnabled { get; }
}

public interface IAudioTrack : ITrack
{
    public void AddSink(IAudioSink audioSink);
    public void RemoveSink(IAudioSink audioSink);
}

public interface IVideoTrack : ITrack
{
    public void AddSink(IVideoSink videoSink);
    public void RemoveSink(IVideoSink videoSink);
    public IList<IVideoSink> Sinks { get; }
}

public interface IDataTrack : ITrack
{

}

public interface ILocalAudioTrack : IAudioTrack
{
    void Release();
}

public interface ILocalVideoTrack : IVideoTrack
{
    public VideoFormat VideoFormat { get; }
    void Release();
}

public interface ILocalDataTrack : IDataTrack
{
}

public interface IRemoteAudioTrack : IAudioTrack { }
public interface IRemoteVideoTrack : IVideoTrack { }
public interface IRemoteDataTrack : IDataTrack { }

public partial class DataTrack { }
public partial class AudioTrack { }
public partial class VideoTrack { }

public partial class LocalAudioTrack : AudioTrack { }
public partial class LocalVideoTrack : VideoTrack { }
public partial class LocalDataTrack : DataTrack { }

public partial class RemoteAudioTrack : AudioTrack { }
public partial class RemoteVideoTrack : VideoTrack { }
public partial class RemoteDataTrack : DataTrack { }

#endregion

#region TrackPublication

public interface ITrackPublication { }

public interface IAudioTrackPublication : ITrackPublication { }
public interface ILocalAudioTrackPublication : IAudioTrackPublication { }
public interface IRemoteAudioTrackPublication : IAudioTrackPublication
{
    RemoteAudioTrack RemoteAudioTrack { get; }
}

public interface IVideoTrackPublication : ITrackPublication { }
public interface ILocalVideoTrackPublication : IVideoTrackPublication { }
public interface IRemoteVideoTrackPublication : IVideoTrackPublication
{
    RemoteVideoTrack RemoteVideoTrack { get; }
}

public interface IDataTrackPublication : ITrackPublication { }
public interface ILocalDataTrackPublication : IDataTrackPublication { }
public interface IRemoteDataTrackPublication : IDataTrackPublication
{
    RemoteDataTrack RemoteDataTrack { get; }
}

public partial class LocalAudioTrackPublication { }
public partial class RemoteAudioTrackPublication { }

public partial class LocalVideoTrackPublication { }
public partial class RemoteVideoTrackPublication { }

public partial class LocalDataTrackPublication { }
public partial class RemoteDataTrackPublication { }

#endregion

public interface IIceOptions
{
}

public partial class IceOptions { }

public interface INetworkQualityConfiguration
{
}

public partial class NetworkQualityConfiguration { }

public interface IVideoCodec
{
}

public partial class VideoCodec { }

public interface IAudioCodec
{
}

public partial class AudioCodec { }

public interface IBandwidthProfileOptions
{
}

public partial class BandwidthProfileOptions { }

public partial interface IAudioSink
{

}

public partial interface IVideoSink { }

public enum TrackPriority
{
    High,
    Low,
    Standard,
}

#region Participant

public interface IParticipant { }
public interface ILocalParticipant : IParticipant { }
public interface IRemoteParticipant : IParticipant
{
    public event EventHandler<RemoteParticipant.AudioTrackEventArgs> AudioTrackDisabled;
    public event EventHandler<RemoteParticipant.AudioTrackEventArgs> AudioTrackEnabled;
    public event EventHandler<RemoteParticipant.AudioTrackEventArgs> AudioTrackPublished;
    public event EventHandler<RemoteParticipant.AudioTrackPublishPriorityChangedEventArgs> AudioTrackPublishPriorityChanged;
    public event EventHandler<RemoteParticipant.AudioTrackSubscriptionEventArgs> AudioTrackSubscribed;
    public event EventHandler<RemoteParticipant.AudioTrackSubscriptionFailedEventArgs> AudioTrackSubscriptionFailed;
    public event EventHandler<RemoteParticipant.AudioTrackEventArgs> AudioTrackUnpublished;
    public event EventHandler<RemoteParticipant.AudioTrackSubscriptionEventArgs> AudioTrackUnsubscribed;
    public event EventHandler<RemoteParticipant.DataTrackPublishPriorityChangedEventArgs> DataTrackPublishPriorityChanged;
    public event EventHandler<RemoteParticipant.DataTrackEventArgs> DataTrackPublished;
    public event EventHandler<RemoteParticipant.DataTrackSubscriptionEventArgs> DataTrackSubscribed;
    public event EventHandler<RemoteParticipant.DataTrackSubscriptionFailedEventArgs> DataTrackSubscriptionFailed;
    public event EventHandler<RemoteParticipant.DataTrackEventArgs> DataTrackUnpublished;
    public event EventHandler<RemoteParticipant.DataTrackSubscriptionEventArgs> DataTrackUnsubscribed;
    public event EventHandler<NetworkQualityLevel> NetworkQualityLevelChanged;
    public event EventHandler<RemoteParticipant.VideoTrackEventArgs> VideoTrackDisabled;
    public event EventHandler<RemoteParticipant.VideoTrackEventArgs> VideoTrackEnabled;
    public event EventHandler<RemoteParticipant.VideoTrackPublishPriorityChangedEventArgs> VideoTrackPublishPriorityChanged;
    public event EventHandler<RemoteParticipant.VideoTrackEventArgs> VideoTrackPublished;
    public event EventHandler<RemoteParticipant.VideoTrackSubscriptionEventArgs> VideoTrackSubscribed;
    public event EventHandler<RemoteParticipant.VideoTrackSubscriptionFailedEventArgs> VideoTrackSubscriptionFailed;
    public event EventHandler<RemoteVideoTrack> VideoTrackSwitchedOff;
    public event EventHandler<RemoteVideoTrack> VideoTrackSwitchedOn;
    public event EventHandler<RemoteParticipant.VideoTrackEventArgs> VideoTrackUnpublished;
    public event EventHandler<RemoteParticipant.VideoTrackSubscriptionEventArgs> VideoTrackUnsubscribed;

    public IList<RemoteAudioTrackPublication> RemoteAudioTracks { get; }
    public IList<RemoteVideoTrackPublication> RemoteVideoTracks { get; }
    public IList<RemoteDataTrackPublication> RemoteDataTracks { get; }
}

public partial class RemoteParticipant
{
    public class AudioTrackEventArgs : EventArgs
    {
        public RemoteAudioTrackPublication RemoteAudioTrackPublication { get; set; }
    }
    public class AudioTrackPublishPriorityChangedEventArgs : AudioTrackEventArgs
    {
        public TrackPriority TrackPriority { get; set; }
    }

    public class AudioTrackSubscriptionEventArgs : AudioTrackEventArgs
    {
        public RemoteAudioTrack RemoteAudioTrack { get; set; }
    }

    public class AudioTrackSubscriptionFailedEventArgs : AudioTrackEventArgs
    {
        public TwilioException Exception { get; set; }
    }

    public class DataTrackEventArgs : EventArgs
    {
        public RemoteDataTrackPublication RemoteDataTrackPublication { get; set; }
    }

    public class DataTrackPublishPriorityChangedEventArgs : DataTrackEventArgs
    {
        public TrackPriority TrackPriority { get; set; }
    }

    public class DataTrackSubscriptionEventArgs : DataTrackEventArgs
    {
        public RemoteDataTrack RemoteDataTrack { get; set; }
    }

    public class DataTrackSubscriptionFailedEventArgs : DataTrackEventArgs
    {
        public TwilioException Exception { get; set; }
    }

    public class VideoTrackEventArgs : EventArgs
    {
        public RemoteVideoTrackPublication RemoteVideoTrackPublication { get; set; }
    }

    public class VideoTrackPublishPriorityChangedEventArgs : VideoTrackEventArgs
    {
        public TrackPriority TrackPriority { get; set; }
    }

    public class VideoTrackSubscriptionEventArgs : VideoTrackEventArgs
    {
        public RemoteVideoTrack RemoteVideoTrack { get; set; }
    }

    public class VideoTrackSubscriptionFailedEventArgs : VideoTrackEventArgs
    {
        public TwilioException Exception { get; set; }
    }
}
public partial class LocalParticipant { }

#endregion



public interface IRoom
{
    public enum State
    {
        Connected,
        Connecting,
        Disconnected,
        Reconnecting,
    }
    public void Disconnect();
    public RemoteParticipant DominantSpeaker { get; }
    public LocalParticipant LocalParticipant { get; }
    public string MediaRegion { get; }
    public string Name { get; }
    public IList<RemoteParticipant> RemoteParticipants { get; }
    public string Sid { get; }
    public State GetState();
    public void GetStats(IStatsListener statsListener);
    public bool IsRecording { get; }

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
}
public partial class Room { }

public interface IStatsListener
{
}

public partial class TwilioException { }

public interface ITwilioVideoService
{
    public Room Connect(ConnectOptions options);
}

public partial class TwilioVideoService
{
    static TwilioVideoService instance = null;

    public static ITwilioVideoService Default
    {
        get
        {
            if (instance is null)
            {
                instance = new TwilioVideoService();
            }
            return (ITwilioVideoService)instance;
        }
    }
}
