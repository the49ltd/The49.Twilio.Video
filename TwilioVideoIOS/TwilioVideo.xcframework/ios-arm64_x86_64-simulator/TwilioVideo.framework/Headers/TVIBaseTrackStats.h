//
//  TVIBaseTrackStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * `TVIBaseTrackStats` represents stats common to both local and remote tracks.
 */
NS_SWIFT_NAME(BaseTrackStats)
@interface TVIBaseTrackStats : NSObject

/**
 * @brief The Tracks's server identifier. This value uniquely identifies the Track within the scope of a Room.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *trackSid;

/**
 * @brief Total number of RTP packets lost for this SSRC since the beginning of the reception.
 */
@property (nonatomic, assign, readonly) NSUInteger packetsLost;

/**
 * @brief Name of codec used for this track.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *codec;

/**
 * @brief The SSRC identifier of the source.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *ssrc;

/**
 * @brief Unix timestamp in milliseconds
 */
@property (nonatomic, assign, readonly) CFTimeInterval timestamp;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Base track stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIBaseTrackStats cannot be created explicitly.")));

@end
