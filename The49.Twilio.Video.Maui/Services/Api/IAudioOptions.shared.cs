namespace The49.Twilio.Video.Maui;

public interface IAudioOptions
{
    public interface IBuilder
    {
        public IAudioOptions Build();
        public IBuilder AudioJitterBufferFastAccelerate(bool audioJitterBufferFastAccelerate);
        public IBuilder AutoGainControl(bool autoGainControl);
        public IBuilder EchoCancellation(bool echoCancellation);
        public IBuilder HighpassFilter(bool highpassFilter);
        public IBuilder NoiseSuppression(bool noiseSuppression);
        public IBuilder StereoSwapping(bool stereoSwapping);
        public IBuilder TypingDetection(bool typingDetection);
    }
}
