namespace The49.Twilio.Video.Maui;

public partial class VideoFormat
{
    public VideoFormat(Size dimensions, int framerate)
    {
        Framerate = framerate;
        Dimensions = dimensions;
    }

    public int Framerate { get; }
    public Size Dimensions { get; }
}
