//
//  TVILocalTrackStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIBaseTrackStats.h"

/**
 * `TVILocalTrackStats` represents stats common to local tracks.
 */
NS_SWIFT_NAME(LocalTrackStats)
@interface TVILocalTrackStats : TVIBaseTrackStats

/**
 * @brief Total number of bytes sent for this SSRC.
 */
@property (nonatomic, assign, readonly) int64_t bytesSent;

/**
 * @brief Total number of RTP packets sent for this SSRC.
 */
@property (nonatomic, assign, readonly) NSUInteger packetsSent;

/**
 * @brief Estimated round trip time for this SSRC based on the RTCP timestamps. Measured in milliseconds.
 */
@property (nonatomic, assign, readonly) int64_t roundTripTime;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Local track stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVILocalTrackStats cannot be created explicitly.")));

@end
