using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public partial class AudioTrack : PlatformWrapper<TwilioVideo.AudioTrack> , IAudioTrack
{
    public AudioTrack(TwilioVideo.AudioTrack platform) : base(platform)
    {}

    public string Name => _platform.Name;

    public bool IsEnabled => _platform.IsEnabled;

    public void AddSink(IAudioSink audioSink)
    {
        _platform.AddSink(audioSink.Platform);
    }

    public void RemoveSink(IAudioSink audioSink)
    {
        _platform.RemoveSink(audioSink.Platform);
    }
}

