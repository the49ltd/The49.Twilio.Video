using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public partial interface IAudioSink
{
    TwilioVideo.IAudioSink Platform { get; }
}
