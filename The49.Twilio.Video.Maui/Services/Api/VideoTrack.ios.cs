using Twilio;

namespace The49.Twilio.Video.Maui;

public partial class VideoTrack : PlatformWrapper<TVIVideoTrack>, IVideoTrack
{
    internal VideoTrack(TVIVideoTrack platform) : base(platform) { }
    public IList<IVideoSink> Sinks => _platform.Renderers.Select(s => new VideoSink(s) as IVideoSink).ToList();

    public string Name => _platform.Name;

    public bool IsEnabled => _platform.Enabled;
    public virtual void AddSink(IVideoSink videoSink)
    {
        _platform.AddRenderer(videoSink.Platform);
    }

    public virtual void RemoveSink(IVideoSink videoSink)
    {
        _platform.RemoveRenderer(videoSink.Platform);
    }
}
