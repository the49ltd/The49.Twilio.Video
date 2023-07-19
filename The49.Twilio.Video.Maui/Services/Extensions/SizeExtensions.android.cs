using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public static class SizeExtensions
{
    public static TwilioVideo.VideoDimensions ToTwilioVideoDimensions(this Size size)
    {
        return new TwilioVideo.VideoDimensions((int)size.Width, (int)size.Height);
    }
}
