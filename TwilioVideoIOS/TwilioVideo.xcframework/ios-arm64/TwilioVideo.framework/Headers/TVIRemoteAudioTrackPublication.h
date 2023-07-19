//
//  TVIRemoteAudioTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIAudioTrackPublication.h"

@class TVIRemoteAudioTrack;

/**
 * `TVIRemoteAudioTrackPublication` contains the mapping between a published `TVIRemoteAudioTrack` and its server generated `sid`.
 */
NS_SWIFT_NAME(RemoteAudioTrackPublication)
@interface TVIRemoteAudioTrackPublication : TVIAudioTrackPublication

/**
 *  @brief Returns whether the Local Participant has subscribed to this track.
 */
@property (nonatomic, assign, readonly, getter= isTrackSubscribed) BOOL trackSubscribed;

/**
 *  @brief The remote audio track associated with the track publication.
 *
 *  @discussion This property will return `nil` unless the Local Participant is subscribed to this track.
 */
@property (nonatomic, strong, readonly, nullable) TVIRemoteAudioTrack *remoteTrack;

/**
 *  @brief Get the `TVITrackPriority` set by the publisher for the corresponding `TVIRemoteAudioTrack`.
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
