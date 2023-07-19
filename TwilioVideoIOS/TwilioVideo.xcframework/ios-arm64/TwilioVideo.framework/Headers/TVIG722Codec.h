//
//  TVIG722Codec.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import "TVIAudioCodec.h"

/**
 * @brief ITU-T standard 7 kHz Wideband audio codec.
 *
 * @see [G.722](https://en.wikipedia.org/wiki/G.722)
 */
NS_SWIFT_NAME(G722Codec)
@interface TVIG722Codec : TVIAudioCodec

/**
 * Initialzes an instance of the `TVIG722Codec` codec.
 */
- (null_unspecified instancetype)init;

@end
