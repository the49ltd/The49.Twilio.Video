using Twilio;
using Microsoft.Maui.Handlers;
using The49.Twilio.Video.Maui.Views;

namespace The49.Twilio.Video.Maui.Handlers;

public partial class TwilioVideoViewHandler : ViewHandler<ITwilioVideoView, TVIVideoView>
{
    protected override TVIVideoView CreatePlatformView()
    {
        return new TVIVideoView
        {
            ContentMode = UIKit.UIViewContentMode.ScaleAspectFill,
        };
    }
}
