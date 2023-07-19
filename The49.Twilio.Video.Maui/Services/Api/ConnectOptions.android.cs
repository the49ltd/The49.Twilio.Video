using TwilioVideo = Twilio.Video;

namespace The49.Twilio.Video.Maui;

public partial class ConnectOptions
{
    TwilioVideo.ConnectOptions _options;

    public TwilioVideo.ConnectOptions Options => _options;

    public ConnectOptions(TwilioVideo.ConnectOptions options)
    {
        _options = options;
    }
    public partial class Builder : IBuilder
    {
        private TwilioVideo.ConnectOptions.Builder _builder;

        public Builder(string accessToken) {
            _builder = new TwilioVideo.ConnectOptions.Builder(accessToken);
        }
        public IBuilder AudioTracks(IList<LocalAudioTrack> audioTracks)
        {
            _builder.AudioTracks(audioTracks.Select(t => t.Platform).ToList());
            return this;
        }

        public IBuilder BandwidthProfile(BandwidthProfileOptions profileOptions)
        {
            //_builder.BandwidthProfile();
            return this;
        }

        public ConnectOptions Build()
        {
            return new ConnectOptions(_builder.Build());
        }

        public IBuilder DataTracks(IList<LocalDataTrack> dataTracks)
        {
            //_builder.DataTracks();
            return this;
        }

        public IBuilder EnableAutomaticSubscription(bool enableAutomaticSubscription)
        {
            //_builder.EnableAutomaticSubscription();
            return this;
        }

        public IBuilder EnableDominantSpeaker(bool enableDominantSpeaker)
        {
            //_builder.EnableDominantSpeaker();
            return this;
        }

        public IBuilder EnableIceGatheringOnAnyAddressPorts(bool enableIceGatheringOnAnyAddressPorts)
        {
            //_builder.EnableIceGatheringOnAnyAddressPorts();
            return this;
        }

        public IBuilder EnableInsights(bool enableInsights)
        {
            //_builder.EnableInsights();
            return this;
        }

        public IBuilder EnableNetworkQuality(bool enableNetworkQuality)
        {
            //_builder.EnableNetworkQuality();
            return this;
        }

        public IBuilder EncodingParameters(bool encodingParameters)
        {
            //_builder.EncodingParameters();
            return this;
        }

        public IBuilder IceOptions(IceOptions iceOptions)
        {
            //_builder.IceOptions();
            return this;
        }

        public IBuilder NetworkQualityConfiguration(NetworkQualityConfiguration networkQualityConfiguration)
        {
            //_builder.NetworkQualityConfiguration();
            return this;
        }

        public IBuilder PreferAudioCodecs(IList<AudioCodec> preferredAudioCodecs)
        {
            //_builder.PreferAudioCodecs();
            return this;
        }

        public IBuilder PreferVideoCodecs(IList<VideoCodec> preferredVideoCodecs)
        {
            //_builder.PreferVideoCodecs();
            return this;
        }

        public IBuilder Region(string region)
        {
            _builder.Region(region);
            return this;
        }

        public IBuilder RoomName(string name)
        {
            _builder.RoomName(name);
            return this;
        }

        public IBuilder VideoEncodingMode(VideoEncodingMode videoEncodingMode)
        {
            _builder.VideoEncodingMode(videoEncodingMode switch
            {
                Maui.VideoEncodingMode.Auto or _ => TwilioVideo.VideoEncodingMode.Auto,
            });
            return this;
        }

        public IBuilder VideoTracks(List<LocalVideoTrack> videoTracks)
        {
            _builder.VideoTracks(videoTracks.Select(t => t.Platform).ToList());
            return this;
        }
    }
}
