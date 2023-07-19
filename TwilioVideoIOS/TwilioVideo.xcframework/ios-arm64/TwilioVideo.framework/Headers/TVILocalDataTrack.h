//
//  TVILocalDataTrack.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIDataTrack.h"

@class TVIDataTrackOptions;

/**
 * A data track represents a unidirectional data source that can be used to send messages to
 * participants of a Room.
 */
NS_SWIFT_NAME(LocalDataTrack)
@interface TVILocalDataTrack : TVIDataTrack

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use `track` or `trackWithOptions:name:` to create a `TVILocalDataTrack`.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use `track` or `trackWithOptions:name:` to create a `TVILocalDataTrack`.")));

/**
 * @brief Send a string message.
 *
 * @param message The string message.
 */
- (void)sendString:(nonnull NSString *)message;

/**
 * @brief Send a binary message.
 *
 * @param message The binary message.
 */
- (void)sendData:(nonnull NSData *)message;

/**
 *  @brief Creates a `TVILocalDataTrack` with the default settings.
 *
 *  @discussion This method uses the default `TVIDataTrackOptions`, and produces an enabled Track.
 *
 *  @return A Track which is ready to be shared with Participants in a Room, or `nil` if an error occurs.
 */
+ (nullable instancetype)track;

/**
 *  @brief Creates a `TVILocalDataTrack` with `TVIDataTrackOptions`.
 *
 *  @discussion This method allows you to provide specific `TVIDataTrackOptions`.
 *
 *  @param options An instance of `TVIDataTrackOptions` to configure the Track.
  *
 *  @return A Track which is ready to be shared with Participants in a Room, or `nil` if an error occurs.
 */
+ (nullable instancetype)trackWithOptions:(nullable TVIDataTrackOptions *)options;

@end
