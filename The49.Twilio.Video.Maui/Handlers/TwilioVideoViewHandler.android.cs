using Twilio.Video;
using Microsoft.Maui.Handlers;
using The49.Twilio.Video.Maui.Views;

namespace The49.Twilio.Video.Maui.Handlers;

public partial class TwilioVideoViewHandler : ViewHandler<ITwilioVideoView, VideoView>
{
    protected override VideoView CreatePlatformView()
    {
        return new VideoView(Context);
    }
}
