using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public partial class AudioOptions: PlatformWrapper<TwilioVideo.AudioOptions>, IAudioOptions
{
    public AudioOptions(TwilioVideo.AudioOptions platform) : base(platform)
    {
    }

    public partial class Builder : IAudioOptions.IBuilder
    {
        TwilioVideo.AudioOptions.Builder _builder;

        public Builder()
        {
            _builder = new TwilioVideo.AudioOptions.Builder();
        }
        public IAudioOptions.IBuilder AudioJitterBufferFastAccelerate(bool audioJitterBufferFastAccelerate)
        {
            _builder.AudioJitterBufferFastAccelerate(audioJitterBufferFastAccelerate);
            return this;
        }

        public IAudioOptions.IBuilder AutoGainControl(bool autoGainControl)
        {
            _builder.AutoGainControl(autoGainControl);
            return this;
        }

        public IAudioOptions Build()
        {
            return new AudioOptions(_builder.Build());
        }

        public IAudioOptions.IBuilder EchoCancellation(bool echoCancellation)
        {
            _builder.EchoCancellation(echoCancellation);
            return this;
        }

        public IAudioOptions.IBuilder HighpassFilter(bool highpassFilter)
        {
            _builder.HighpassFilter(highpassFilter);
            return this;
        }

        public IAudioOptions.IBuilder NoiseSuppression(bool noiseSuppression)
        {
            _builder.NoiseSuppression(noiseSuppression);
            return this;
        }

        public IAudioOptions.IBuilder StereoSwapping(bool stereoSwapping)
        {
            _builder.StereoSwapping(stereoSwapping);
            return this;
        }

        public IAudioOptions.IBuilder TypingDetection(bool typingDetection)
        {
            _builder.TypingDetection(typingDetection);
            return this;
        }
    }
}
