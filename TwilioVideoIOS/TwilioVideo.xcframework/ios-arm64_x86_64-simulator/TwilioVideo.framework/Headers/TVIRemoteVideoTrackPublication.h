//
//  TVIRemoteVideoTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIVideoTrackPublication.h"

@class TVIRemoteVideoTrack;

/**
 * `TVIRemoteVideoTrackPublication` contains the mapping between a published `TVIRemoteVideoTrack` and its server generated `sid`.
 */
NS_SWIFT_NAME(RemoteVideoTrackPublication)
@interface TVIRemoteVideoTrackPublication : TVIVideoTrackPublication

/**
 *  @brief Returns whether the Local Participant has subscribed to this track.
 */
@property (nonatomic, assign, readonly, getter = isTrackSubscribed) BOOL trackSubscribed;

/**
 *  @brief The remote video track associated with the track publication.
 *
 *  @discussion This property will return `nil` unless the Local Participant is subscribed to this track.
 */
@property (nonatomic, strong, readonly, nullable) TVIRemoteVideoTrack *remoteTrack;

/**
 *  @brief Get the `TVITrackPriority` set by the publisher for the corresponding `TVIRemoteVideoTrack`.
 *
 *  @discussion This property will return `TVITrackPriorityStandard` if no priority was specified by the publisher.
 */
@property (nonatomic, copy, readonly, nonnull) TVITrackPriority publishPriority;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Track publications cannot be created explicitly
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Track publications cannot be created explicitly.")));

@end
