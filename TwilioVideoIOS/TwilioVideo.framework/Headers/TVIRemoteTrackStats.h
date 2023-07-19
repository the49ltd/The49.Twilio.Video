//
//  TVIRemoteTrackStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIBaseTrackStats.h"

/**
 * `TVIRemoteTrackStats` represents stats common to remote tracks.
 */
NS_SWIFT_NAME(RemoteTrackStats)
@interface TVIRemoteTrackStats : TVIBaseTrackStats

/**
 * @brief Total number of bytes received.
 */
@property (nonatomic, assign, readonly) int64_t bytesReceived;

/**
 * @brief Total number of packets received.
 */
@property (nonatomic, assign, readonly) NSUInteger packetsReceived;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Remote track stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIRemoteTrackStats cannot be created explicitly.")));

@end
