using Twilio;

namespace The49.Twilio.Video.Maui;

public partial interface IVideoSink
{
    ITVIVideoRenderer Platform { get; }
}
