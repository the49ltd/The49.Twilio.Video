//
//  TVIVideoCodec.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * `TVIVideoCodec` is the base class for all supported video codecs.
 */
NS_SWIFT_NAME(VideoCodec)
@interface TVIVideoCodec : NSObject

/**
 *  @brief The name of the video codec.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *name;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion `TVIVideoCodec` can not be created with init. To use an video codec, use one of the `TVIVideoCodec` subclasses.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIVideoCodec can not be created explicitly. Use a TVIVideoCodec subclass")));

@end
