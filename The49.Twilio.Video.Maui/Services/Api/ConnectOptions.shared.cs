namespace The49.Twilio.Video.Maui;

public partial class ConnectOptions
{
    public interface IBuilder
    {

        public IBuilder AudioTracks(IList<LocalAudioTrack> audioTracks);
        public IBuilder BandwidthProfile(BandwidthProfileOptions profileOptions);
        public ConnectOptions Build();
        public IBuilder DataTracks(IList<LocalDataTrack> dataTracks);
        public IBuilder EnableAutomaticSubscription(bool enableAutomaticSubscription);
        public IBuilder EnableDominantSpeaker(bool enableDominantSpeaker);
        public IBuilder EnableIceGatheringOnAnyAddressPorts(bool enableIceGatheringOnAnyAddressPorts);
        public IBuilder EnableInsights(bool enableInsights);
        public IBuilder EnableNetworkQuality(bool enableNetworkQuality);
        public IBuilder EncodingParameters(bool encodingParameters);
        public IBuilder IceOptions(IceOptions iceOptions);
        public IBuilder NetworkQualityConfiguration(NetworkQualityConfiguration networkQualityConfiguration);
        public IBuilder PreferAudioCodecs(IList<AudioCodec> preferredAudioCodecs);
        public IBuilder PreferVideoCodecs(IList<VideoCodec> preferredVideoCodecs);
        public IBuilder Region(string region);
        public IBuilder RoomName(string name);
        public IBuilder VideoEncodingMode(VideoEncodingMode videoEncodingMode);
        public IBuilder VideoTracks(List<LocalVideoTrack> videoTracks);
    }

    public partial class Builder { }
}
