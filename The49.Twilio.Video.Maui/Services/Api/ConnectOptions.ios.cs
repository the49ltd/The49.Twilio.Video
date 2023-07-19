using Twilio;

namespace The49.Twilio.Video.Maui;

public partial class ConnectOptions
{
    TVIConnectOptions _options;

    public TVIConnectOptions Options => _options;

    public ConnectOptions(TVIConnectOptions options)
    {
        _options = options;
    }
    public partial class Builder : IBuilder
    {
        string _token;

        List<Action<TVIConnectOptionsBuilder>> _funcs = new List<Action<TVIConnectOptionsBuilder>>();

        public Builder(string accessToken)
        {
            _token = accessToken;
        }
        public IBuilder AudioTracks(IList<LocalAudioTrack> audioTracks)
        {
            _funcs.Add((builder) => builder.AudioTracks = audioTracks.Select(t => t.Platform).ToArray());
            return this;
        }

        public IBuilder BandwidthProfile(BandwidthProfileOptions profileOptions)
        {
            //_builder.BandwidthProfile();
            return this;
        }

        public ConnectOptions Build()
        {
            var options = TVIConnectOptions.OptionsWithToken(_token, (builder) =>
            {
                foreach (var f in _funcs)
                {
                    f(builder);
                }
            });
            return new ConnectOptions(options);
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
            _funcs.Add((builder) => builder.Region = region);
            return this;
        }

        public IBuilder RoomName(string name)
        {
            _funcs.Add((builder) => builder.RoomName = name);
            return this;
        }

        public IBuilder VideoEncodingMode(VideoEncodingMode videoEncodingMode)
        {
            _funcs.Add((builder) => builder.VideoEncodingMode = videoEncodingMode switch
            {
                Maui.VideoEncodingMode.Auto or _ => TVIVideoEncodingMode.Auto,
            });
            return this;
        }

        public IBuilder VideoTracks(List<LocalVideoTrack> videoTracks)
        {
            _funcs.Add((builder) => builder.VideoTracks = videoTracks.Select(t => t.Platform).ToArray());
            return this;
        }
    }
}
