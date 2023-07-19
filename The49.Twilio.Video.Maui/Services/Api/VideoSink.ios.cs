using Twilio;

namespace The49.Twilio.Video.Maui;

public partial class VideoSink : PlatformWrapper<ITVIVideoRenderer>, IVideoSink
{
    public VideoSink(ITVIVideoRenderer platform): base(platform)
    {}
}