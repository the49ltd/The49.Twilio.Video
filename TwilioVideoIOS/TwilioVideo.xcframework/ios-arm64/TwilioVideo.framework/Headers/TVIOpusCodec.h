//
//  TVIOpusCodec.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import "TVIAudioCodec.h"

/**
 * @brief Lossy audio coding format.
 *
 * @see [Opus](https://en.wikipedia.org/wiki/Opus_(audio_format))
 */
NS_SWIFT_NAME(OpusCodec)
@interface TVIOpusCodec : TVIAudioCodec

/**
 *  @brief Indicates if discontinuous transmission (DTX) is enabled.
 *
 *  @discussion Discontinuous transmission (DTX) in the Opus audio codec is enabled by default,
 *  which will result in bandwidth and CPU savings during silence and background noise.
 */
@property (nonatomic, readonly, getter=isDtxEnabled) BOOL dtxEnabled;

/**
 *  Initialzes an instance of the `TVIOpusCodec` codec.
 *
 *  @discussion Discontinuous transmission (DTX) in the Opus audio codec is enabled by default,
 *  which will result in bandwidth and CPU savings during silence and background noise.
 */
- (null_unspecified instancetype)init;

/**
 *  @brief Initializes an instance of the `TVIOpusCodec` with specified discontinuous transmission (DTX) state.
 *
 *  @param dtxEnabled  Indicates if dtx is enabled or not.
 *
 *  @return An instance of `TVIOpusCodec`.
 */
- (null_unspecified instancetype)initWithDtxEnabled:(BOOL)dtxEnabled;

@end
