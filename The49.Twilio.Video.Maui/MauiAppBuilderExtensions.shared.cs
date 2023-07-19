using The49.Twilio.Video.Maui.Handlers;
using The49.Twilio.Video.Maui.Views;

[assembly: XmlnsDefinition("https://schemas.twilio.com/dotnet/2023/maui", "The49.Twilio.Video.Maui.Views")]

namespace The49.Twilio.Video.Maui;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseTwilioVideo(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton(TwilioVideoService.Default);
        builder.ConfigureMauiHandlers(cfg =>
        {
            cfg.AddHandler<TwilioVideoView, TwilioVideoViewHandler>();
        });
        return builder;
    }
}

