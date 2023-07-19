using Twilio;

namespace The49.Twilio.Video.Maui;


public partial class LocalAudioTrack : AudioTrack, ILocalAudioTrack
{
    new TVILocalAudioTrack _platform;
    new public TVILocalAudioTrack Platform => _platform;
    public LocalAudioTrack(TVILocalAudioTrack platform) : base(platform)
    {
        _platform = platform;
    }

    public static LocalAudioTrack Create(bool enabled)
    {
        return new LocalAudioTrack(TVILocalAudioTrack.TrackWithOptions(null, enabled, null));
    }

    public static LocalAudioTrack Create(bool enabled, AudioOptions options)
    {
        return new LocalAudioTrack(TVILocalAudioTrack.TrackWithOptions(options.Platform, enabled, null));
    }

    public static LocalAudioTrack Create(bool enabled, AudioOptions options, string name)
    {
        return new LocalAudioTrack(TVILocalAudioTrack.TrackWithOptions(options.Platform, enabled, name));
    }

    public static LocalAudioTrack Create(bool enabled, string name)
    {
        return new LocalAudioTrack(TVILocalAudioTrack.TrackWithOptions(null, enabled, name));
    }

    public void Release() { }

    public new bool IsEnabled
    {
        get { return _platform.Enabled; }
        set { _platform.Enabled = value; }
    }
}

