using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public static class VideoFormatExtensions
{
    public static TwilioVideo.VideoFormat ToPlatform(this VideoFormat videoFormat)
    {
        return new TwilioVideo.VideoFormat(videoFormat.Dimensions.ToTwilioVideoDimensions(), videoFormat.Framerate);
    }
    public static VideoFormat FromPlatform(TwilioVideo.VideoFormat platformVideoFormat)
    {
        return new VideoFormat(new Size(platformVideoFormat.Dimensions.Width, platformVideoFormat.Dimensions.Height), platformVideoFormat.Framerate);
    }
}
