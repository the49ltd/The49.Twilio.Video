using Twilio;
using AVFoundation;

namespace The49.Twilio.Video.Maui;
public partial class CameraCapturer
{
    public class CameraSourceDelegate : TVICameraSourceDelegate { }

    TVICameraSource _cameraCapturer;

    AVCaptureDevice _cameraSource;

    public TVICameraSource Platform => _cameraCapturer;

    public CameraCapturer(TVICameraSource platform, AVCaptureDevice source)
    {
        _cameraCapturer = platform;
        _cameraSource = source;
    }
    public static CameraCapturer Create(CameraPosition position = CameraPosition.Front)
    {
        var cameraSource = TVICameraSource.CaptureDeviceForPosition(position switch
        {
            CameraPosition.Back => AVCaptureDevicePosition.Back,
            CameraPosition.Front or _ => AVCaptureDevicePosition.Front,
        });

        var cameraCapturer = new TVICameraSource(new CameraSourceDelegate());

        return new CameraCapturer(cameraCapturer, cameraSource);
    }

    internal void OnAddedToSink()
    {
        _cameraCapturer.StartCaptureWithDevice(_cameraSource);
    }
}