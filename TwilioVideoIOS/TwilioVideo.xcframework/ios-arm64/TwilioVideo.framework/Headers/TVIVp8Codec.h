//
//  TVIVp8Codec.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import "TVIVideoCodec.h"

/**
 * @brief Traditional block-based transform coding format similar to H.264.
 *
 * @see [VP8](https://en.wikipedia.org/wiki/VP8)
 */
NS_SWIFT_NAME(Vp8Codec)
@interface TVIVp8Codec : TVIVideoCodec

/**
 * @brief Whether simulcast is enabled.
 *
 * @discussion Enabling simulcast causes the encoder to generate multiple spatial and temporal
 * layers for the video that is published. This feature should only be enabled in a Group Room.
 * Simulcast is disabled by default.
 */
@property (nonatomic, readonly, getter=isSimulcast) BOOL simulcast;

/**
 * Initialzes an instance of the `TVIVp8Codec` codec.
 */
- (null_unspecified instancetype)init;

/**
 * @brief Initialzes an instance of the `TVIVp8Codec` codec.
 *
 * @param simulcast A boolean to indicate if simulcast is enabled.
 *
 * @return A `TVIVp8Codec` object.
 */
- (nonnull instancetype)initWithSimulcast:(BOOL)simulcast;

@end
