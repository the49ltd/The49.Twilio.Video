using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public partial class VideoTrack : PlatformWrapper<TwilioVideo.VideoTrack>, IVideoTrack
{
    internal VideoTrack(TwilioVideo.VideoTrack platform) : base(platform) { }
    public IList<IVideoSink> Sinks => _platform.Sinks.Select(s => new VideoSink(s) as IVideoSink).ToList();

    public string Name => _platform.Name;

    public bool IsEnabled => _platform.IsEnabled;
    public virtual void AddSink(IVideoSink videoSink)
    {
        _platform.AddSink(videoSink.Platform);
    }

    public virtual void RemoveSink(IVideoSink videoSink)
    {
        _platform.RemoveSink(videoSink.Platform);
    }
}
