using Tvi.Webrtc;
using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public partial class LocalVideoTrack: VideoTrack, ILocalVideoTrack
{
    new TwilioVideo.LocalVideoTrack _platform;

    new public TwilioVideo.LocalVideoTrack Platform => _platform;
    public VideoFormat VideoFormat => VideoFormatExtensions.FromPlatform(_platform.VideoFormat);

    CameraCapturer _cameraCapturer;

    internal LocalVideoTrack(TwilioVideo.LocalVideoTrack platform): base(platform)
    {
        _platform = platform;
    }
    public static LocalVideoTrack Create(bool enabled, CameraCapturer cameraCapturer)
    {
        var track = new LocalVideoTrack(TwilioVideo.LocalVideoTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, cameraCapturer.Platform));
        track._cameraCapturer = cameraCapturer;
        return track;
    }
    public static LocalVideoTrack Create(bool enabled, IVideoCapturer videoCapturer)
    {
        return new LocalVideoTrack(TwilioVideo.LocalVideoTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, videoCapturer));
    }
    public static LocalVideoTrack Create(bool enabled, IVideoCapturer videoCapturer, VideoFormat videoFormat)
    {
        return new LocalVideoTrack(TwilioVideo.LocalVideoTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, videoCapturer, videoFormat.ToPlatform()));
    }
    public static LocalVideoTrack Create(bool enabled, IVideoCapturer videoCapturer, VideoFormat videoFormat, string name)
    {
        return new LocalVideoTrack(TwilioVideo.LocalVideoTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, videoCapturer, videoFormat.ToPlatform(), name));
    }
    public static LocalVideoTrack Create(bool enabled, IVideoCapturer videoCapturer, string name)
    {
        return new LocalVideoTrack(TwilioVideo.LocalVideoTrack.Create(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, enabled, videoCapturer, name));
    }

    public override void AddSink(IVideoSink videoSink)
    {
        base.AddSink(videoSink);
        if (_cameraCapturer is not null)
        {
            _cameraCapturer.OnAddedToSink();
        }
    }

    public void Release() => _platform.Release();

    public new bool IsEnabled
    {
        get { return _platform.IsEnabled; }
        set { _platform.Enable( value ); }
    }
}
