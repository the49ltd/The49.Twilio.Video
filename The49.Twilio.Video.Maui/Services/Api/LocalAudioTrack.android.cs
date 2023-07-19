using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;


public partial class LocalAudioTrack : AudioTrack, ILocalAudioTrack
{
    new TwilioVideo.LocalAudioTrack _platform;
    new public TwilioVideo.LocalAudioTrack Platform => _platform;
    public LocalAudioTrack(TwilioVideo.LocalAudioTrack platform) : base(platform)
    {
        _platform = platform;
    }

    public static LocalAudioTrack Create(bool enabled)
    {
        return new LocalAudioTrack(TwilioVideo.LocalAudioTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled));
    }

    public static LocalAudioTrack Create(bool enabled, AudioOptions options)
    {
        return new LocalAudioTrack(TwilioVideo.LocalAudioTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, options.Platform));
    }

    public static LocalAudioTrack Create(bool enabled, AudioOptions options, string name)
    {
        return new LocalAudioTrack(TwilioVideo.LocalAudioTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, options.Platform, name));
    }

    public static LocalAudioTrack Create(bool enabled, string name)
    {
        return new LocalAudioTrack(TwilioVideo.LocalAudioTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, name));
    }

    public void Release() => _platform.Release();

    public new bool IsEnabled
    {
        get { return _platform.IsEnabled; }
        set { _platform.Enable( value ); }
    }
}

