using Twilio;

namespace The49.Twilio.Video.Maui.Views;

public partial class TwilioVideoView : IVideoSink
{
    public ITVIVideoRenderer Platform => Handler.PlatformView as TVIVideoView;
}