using System;
using Microsoft.Maui.Handlers;
using The49.Twilio.Video.Maui.Views;

#if IOS
using PlatformView = Twilio.TVIVideoView;
#elif ANDROID
using PlatformView = Twilio.Video.VideoView;
#else
using PlatformView = System.Object;
#endif

namespace The49.Twilio.Video.Maui.Handlers;

public interface ITwilioVideoViewHandler : IViewHandler
{
    new ITwilioVideoView VirtualView { get; }
    new PlatformView PlatformView { get; }
}

public partial class TwilioVideoViewHandler: ITwilioVideoViewHandler
{
    public static IPropertyMapper<ITwilioVideoView, ITwilioVideoViewHandler> Mapper = new PropertyMapper<TwilioVideoView, ITwilioVideoViewHandler>(ViewHandler.ViewMapper)
    { };

    public static CommandMapper<ITwilioVideoView, ITwilioVideoViewHandler> CommandMapper = new(ViewCommandMapper);
    public TwilioVideoViewHandler() : base(Mapper, CommandMapper)
    {

    }
    public TwilioVideoViewHandler(IPropertyMapper mapper, CommandMapper commandMapper = null) : base(mapper, commandMapper)
    {
    }

    ITwilioVideoView ITwilioVideoViewHandler.VirtualView => VirtualView;
    PlatformView ITwilioVideoViewHandler.PlatformView => PlatformView;

}