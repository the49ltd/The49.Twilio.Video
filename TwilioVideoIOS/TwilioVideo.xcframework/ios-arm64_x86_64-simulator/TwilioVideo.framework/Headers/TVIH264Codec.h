//
//  TVIH264Codec.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import "TVIVideoCodec.h"

/**
 * @brief Block-oriented motion-compensation-based video compression standard.
 *
 * @discussion The SDK supports Constrained Baseline Profile @ Level 3.1. The H.264 codec is hardware
 * accelerated on all iOS devices, whereas the VP8 & VP9 codecs are software implementations.
 *
 * @see [H.264](https://en.wikipedia.org/wiki/H.264/MPEG-4_AVC)
 */
NS_SWIFT_NAME(H264Codec)
@interface TVIH264Codec : TVIVideoCodec

/**
 * Initialzes an instance of the `TVIH264Codec` codec.
 */
- (null_unspecified instancetype)init;

@end
