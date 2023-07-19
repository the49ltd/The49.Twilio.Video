using Twilio.Video;

namespace The49.Twilio.Video.Maui.Views;

public partial class TwilioVideoView : IVideoSink
{
    public Tvi.Webrtc.IVideoSink Platform => Handler.PlatformView as VideoView;
}