using Twilio;

namespace The49.Twilio.Video.Maui;

public partial class AudioOptions: PlatformWrapper<TVIAudioOptions>, IAudioOptions
{
    public AudioOptions(TVIAudioOptions platform) : base(platform)
    {
    }

    public partial class Builder : IAudioOptions.IBuilder
    {
        List<Action<TVIAudioOptionsBuilder>> _funcs = new List<Action<TVIAudioOptionsBuilder>>();

        public IAudioOptions.IBuilder AudioJitterBufferFastAccelerate(bool audioJitterBufferFastAccelerate)
        {
            _funcs.Add((builder) => builder.AudioJitterBufferFastAccelerate = audioJitterBufferFastAccelerate);
            return this;
        }

        public IAudioOptions.IBuilder AutoGainControl(bool autoGainControl)
        {
            return this;
        }

        public IAudioOptions Build()
        {
            var platform = TVIAudioOptions.OptionsWithBlock((builder) =>
            {
                foreach (var f in _funcs)
                {
                    f(builder);
                }
            });

            return new AudioOptions(platform);
        }

        public IAudioOptions.IBuilder EchoCancellation(bool echoCancellation)
        {
            return this;
        }

        public IAudioOptions.IBuilder HighpassFilter(bool highpassFilter)
        {
            _funcs.Add((builder) => builder.HighpassFilter = highpassFilter);
            return this;
        }

        public IAudioOptions.IBuilder NoiseSuppression(bool noiseSuppression)
        {
            return this;
        }

        public IAudioOptions.IBuilder StereoSwapping(bool stereoSwapping)
        {
            return this;
        }

        public IAudioOptions.IBuilder TypingDetection(bool typingDetection)
        {
            return this;
        }
    }
}
