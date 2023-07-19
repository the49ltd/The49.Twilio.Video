using Twilio;

namespace The49.Twilio.Video.Maui;

public partial class LocalVideoTrack: VideoTrack, ILocalVideoTrack
{
    new TVILocalVideoTrack _platform;

    new public TVILocalVideoTrack Platform => _platform;
    public VideoFormat VideoFormat => new VideoFormat(new Size(0), 0);

    CameraCapturer _cameraCapturer;

    internal LocalVideoTrack(TVILocalVideoTrack platform): base(platform)
    {
        _platform = platform;
    }
    public static LocalVideoTrack Create(bool enabled, CameraCapturer capturer)
    {
        var track = new LocalVideoTrack(TVILocalVideoTrack.TrackWithSource(capturer.Platform, enabled, null));
        track._cameraCapturer = capturer;
        return track;
    }
    public static LocalVideoTrack Create(bool enabled, TVIVideoSource videoSource)
    {
        return new LocalVideoTrack(TVILocalVideoTrack.TrackWithSource(videoSource, enabled, null));
    }
    public static LocalVideoTrack Create(bool enabled, TVIVideoSource videoSource, VideoFormat videoFormat)
    {
        return new LocalVideoTrack(TVILocalVideoTrack.TrackWithSource(videoSource, enabled, null));
    }
    public static LocalVideoTrack Create(bool enabled, TVIVideoSource videoSource, VideoFormat videoFormat, string name)
    {
        return new LocalVideoTrack(TVILocalVideoTrack.TrackWithSource(videoSource, enabled, name));
    }
    public static LocalVideoTrack Create(bool enabled, TVIVideoSource videoSource, string name)
    {
        return new LocalVideoTrack(TVILocalVideoTrack.TrackWithSource(videoSource, enabled, name));
    }

    public override void AddSink(IVideoSink videoSink)
    {
        base.AddSink(videoSink);
        if (_cameraCapturer is not null)
        {
            _cameraCapturer.OnAddedToSink();
        }
    }

    public void Release() { }

    public new bool IsEnabled
    {
        get { return _platform.Enabled; }
        set { _platform.Enabled = value; }
    }
}
