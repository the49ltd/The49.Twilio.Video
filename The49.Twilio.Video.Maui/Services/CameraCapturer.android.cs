using TwilioVideo = Twilio.Video;
using MauiPlatform = Microsoft.Maui.ApplicationModel.Platform;

namespace The49.Twilio.Video.Maui;
public partial class CameraCapturer
{
    TwilioVideo.Camera2Capturer _platform;

    public TwilioVideo.Camera2Capturer Platform => _platform;

    public CameraCapturer(TwilioVideo.Camera2Capturer platform)
    {
        _platform = platform;
    }
    public static CameraCapturer Create(CameraPosition position = CameraPosition.Front)
    {
        var enumerator = new Tvi.Webrtc.Camera2Enumerator(MauiPlatform.CurrentActivity);

        var names = enumerator.GetDeviceNames();

        var cameraId = names.FirstOrDefault(n =>
        {
            return position switch
            {
                CameraPosition.Back => enumerator.IsBackFacing(n),
                CameraPosition.Front or _ => enumerator.IsFrontFacing(n),
            };
        });

        if (cameraId is null)
        {
            return null;
        }

        var p = new TwilioVideo.Camera2Capturer(MauiPlatform.CurrentActivity, cameraId);

        return new CameraCapturer(p);
    }

    internal void OnAddedToSink() { }
}