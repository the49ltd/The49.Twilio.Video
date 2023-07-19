//
//  TVILocalVideoTrackStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVILocalTrackStats.h"
#import <CoreMedia/CoreMedia.h>

/**
 * `TVILocalVideoTrackStats` represents stats about a local video track.
 */
NS_SWIFT_NAME(LocalVideoTrackStats)
@interface TVILocalVideoTrackStats : TVILocalTrackStats

/**
 * @brief Captured frame dimensions.
 */
@property (nonatomic, assign, readonly) CMVideoDimensions captureDimensions;

/**
 * @brief Captured frame rate.
 */
@property (nonatomic, assign, readonly) NSUInteger captureFrameRate;

/**
 * @brief Sent frame dimensions.
 */
@property (nonatomic, assign, readonly) CMVideoDimensions dimensions;

/**
 * @brief Sent frame rate.
 */
@property (nonatomic, assign, readonly) NSUInteger frameRate;

/**
 * @brief The number of frames encoded.
 */
@property (nonatomic, assign, readonly) uint32_t framesEncoded;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Local video track stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVILocalVideoTrackStats cannot be created explicitly.")));

@end
