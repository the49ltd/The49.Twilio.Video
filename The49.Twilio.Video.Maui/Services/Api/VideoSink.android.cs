namespace The49.Twilio.Video.Maui;

public partial class VideoSink : PlatformWrapper<Tvi.Webrtc.IVideoSink> , IVideoSink
{
    public VideoSink(Tvi.Webrtc.IVideoSink platform): base(platform) {}
}