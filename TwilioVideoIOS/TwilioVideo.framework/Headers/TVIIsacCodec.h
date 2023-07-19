//
//  TVIIsacCodec.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import "TVIAudioCodec.h"

/**
 *  `TVIIsacCodecSampleRate` specifies the possible sample rates supported by the `TVIIsacCodec`/
 *
 *  @see [Mapping to SDP Parameters](https://tools.ietf.org/html/draft-ietf-avt-rtp-isac-04#section-6)
 */
typedef NS_ENUM(uint16_t, TVIIsacCodecSampleRate) {
    /**
     * iSAC Wideband Payload Format
     */
    TVIIsacCodecSampleRateWideband = 16000,
    /**
     * iSAC Superwideband Payload Format
     */
    TVIIsacCodecSampleRateSuperWideband = 32000,
}
NS_SWIFT_NAME(IsacCodec.SampleRate);

/**
 * @brief Internet speech audio codec.
 *
 * @see [iSAC](https://en.wikipedia.org/wiki/Internet_Speech_Audio_Codec)
 */
NS_SWIFT_NAME(IsacCodec)
@interface TVIIsacCodec : TVIAudioCodec

/**
 * @brief The sample rate.
 */
@property (nonatomic, readonly) TVIIsacCodecSampleRate sampleRate;

/**
 * Initialzes an instance of the `TVIIsacCodec` codec.
 */
- (null_unspecified instancetype)init;

@end
