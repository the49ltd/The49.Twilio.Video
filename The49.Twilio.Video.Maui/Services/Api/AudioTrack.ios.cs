using Twilio;

namespace The49.Twilio.Video.Maui;

public partial class AudioTrack : PlatformWrapper<TVIAudioTrack>, IAudioTrack
{
    public AudioTrack(TVIAudioTrack platform) : base(platform)
    { }

    public string Name => _platform.Name;

    public bool IsEnabled => _platform.Enabled;

    public void AddSink(IAudioSink audioSink)
    {
        _platform.AddSink(audioSink.Platform);
    }

    public void RemoveSink(IAudioSink audioSink)
    {
        _platform.RemoveSink(audioSink.Platform);
    }
}

