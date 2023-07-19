//
//  TVIRemoteAudioTrackStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIRemoteTrackStats.h"

/**
 * `TVIRemoteAudioTrackStats` represents stats about a remote audio track.
 */
NS_SWIFT_NAME(RemoteAudioTrackStats)
@interface TVIRemoteAudioTrackStats : TVIRemoteTrackStats

/**
 * @brief Audio output level.
 *
 * @discussion The output level is an amplitude within the range of 0 to 32,767.
 */
@property (nonatomic, assign, readonly) NSUInteger audioLevel;

/**
 * @brief Packet jitter measured in milliseconds.
 */
@property (nonatomic, assign, readonly) NSUInteger jitter;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Remote audio track stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIRemoteAudioTrackStats cannot be created explicitly.")));

@end
