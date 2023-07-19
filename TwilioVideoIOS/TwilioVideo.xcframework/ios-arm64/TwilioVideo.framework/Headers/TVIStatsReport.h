//
//  TVIStatsReport.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

@class TVILocalAudioTrackStats;
@class TVILocalVideoTrackStats;
@class TVIRemoteAudioTrackStats;
@class TVIRemoteVideoTrackStats;
@class TVIIceCandidateStats;
@class TVIIceCandidatePairStats;

/**
 * `TVIStatsReport` contains stats for all tracks associated with a single peer connection.
 */
NS_SWIFT_NAME(StatsReport)
@interface TVIStatsReport : NSObject

/**
 * @brief The id of peer connection related to this report.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *peerConnectionId;

/**
 * @brief The stats for all local audio tracks in the peer connection.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<TVILocalAudioTrackStats *> *localAudioTrackStats;

/**
 * @brief The stats for all local video tracks in the peer connection.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<TVILocalVideoTrackStats *> *localVideoTrackStats;

/**
 * @brief The stats for all remote audio tracks in the peer connection.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<TVIRemoteAudioTrackStats *> *remoteAudioTrackStats;

/**
 * @brief The stats for all remote video tracks in the peer connection.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<TVIRemoteVideoTrackStats *> *remoteVideoTrackStats;

/**
 * @brief The stats for all Ice candidates.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<TVIIceCandidateStats *> *iceCandidateStats;

/**
 * @brief The stats for all Ice candidates pairs.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<TVIIceCandidatePairStats *> *iceCandidatePairStats;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Stats report cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIStatsReport cannot be created explicitly.")));

@end
