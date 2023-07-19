using Microsoft.Extensions.Logging;
using The49.Twilio.Video.Maui;

namespace The49.Twilio.Video.Sample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseTwilioVideo()
            ;

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}