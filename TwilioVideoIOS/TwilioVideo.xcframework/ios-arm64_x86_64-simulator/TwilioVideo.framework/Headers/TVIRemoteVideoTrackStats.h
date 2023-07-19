//
//  TVIRemoteVideoTrackStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIRemoteTrackStats.h"
#import <CoreMedia/CoreMedia.h>

/**
 * `TVIRemoteVideoTrackStats` represents stats about a remote video track.
 */
NS_SWIFT_NAME(RemoteVideoTrackStats)
@interface TVIRemoteVideoTrackStats : TVIRemoteTrackStats

/**
 * @brief Received frame dimensions. 
 */
@property (nonatomic, assign, readonly) CMVideoDimensions dimensions;

/**
 * @brief Received frame rate.
 */
@property (nonatomic, assign, readonly) NSUInteger frameRate;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Remote video track stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIRemoteVideoTrackStats cannot be created explicitly.")));

@end
