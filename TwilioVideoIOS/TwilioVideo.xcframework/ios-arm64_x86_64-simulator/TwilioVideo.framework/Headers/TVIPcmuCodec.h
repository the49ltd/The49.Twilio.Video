//
//  TVIPcmuCodec.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import "TVIAudioCodec.h"

/**
 * @brief ITU-T standard for audio companding.
 *
 * @see [PCMU](https://en.wikipedia.org/wiki/G.711)
 */
NS_SWIFT_NAME(PcmuCodec)
@interface TVIPcmuCodec : TVIAudioCodec

/**
 * Initialzes an instance of the `TVIPcmuCodec` codec.
 */
- (null_unspecified instancetype)init;

@end
