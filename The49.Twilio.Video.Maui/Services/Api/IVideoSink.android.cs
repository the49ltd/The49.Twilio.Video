namespace The49.Twilio.Video.Maui;

public partial interface IVideoSink
{
    Tvi.Webrtc.IVideoSink Platform { get; }
}
