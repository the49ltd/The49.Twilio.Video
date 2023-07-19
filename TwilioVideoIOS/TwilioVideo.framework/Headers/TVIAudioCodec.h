//
//  TVIAudioCodec.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * `TVIAudioCodec` is the base class for all supported audio codecs.
 */
NS_SWIFT_NAME(AudioCodec)
@interface TVIAudioCodec : NSObject

/**
 *  @brief The name of the audio codec.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *name;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion `TVIAudioCodec` can not be created with init. To use an audio codec, use one of the `TVIAudioCodec` subclasses.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIAudioCodec can not be created explicitly. Use a TVIAudioCodec subclass")));

@end
