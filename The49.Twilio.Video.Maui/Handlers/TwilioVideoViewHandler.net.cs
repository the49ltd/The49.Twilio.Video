using Microsoft.Maui.Handlers;
using The49.Twilio.Video.Maui.Views;

namespace The49.Twilio.Video.Maui.Handlers;

public partial class TwilioVideoViewHandler : ViewHandler<ITwilioVideoView, object>
{
    protected override object CreatePlatformView() => throw new NotImplementedException();
}

