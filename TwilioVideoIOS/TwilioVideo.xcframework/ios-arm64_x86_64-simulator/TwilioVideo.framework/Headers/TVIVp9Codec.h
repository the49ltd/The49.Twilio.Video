//
//  TVIVp9Codec.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import "TVIVideoCodec.h"

/**
 * @brief Traditional block-based transform coding format similar to MPEG's High Efficiency Video
 * Coding (HEVC/H.265).
 *
 * @see [VP9](https://en.wikipedia.org/wiki/VP9)
 */
NS_SWIFT_NAME(Vp9Codec)
@interface TVIVp9Codec : TVIVideoCodec

/**
 * Initialzes an instance of the `TVIVp9Codec` codec.
 */
- (null_unspecified instancetype)init;

@end
