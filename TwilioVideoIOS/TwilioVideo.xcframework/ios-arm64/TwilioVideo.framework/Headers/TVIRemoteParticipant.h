//
//  TVIRemoteParticipant.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TVIParticipant.h"
#import "TVITrackPriority.h"

@protocol TVIRemoteParticipantDelegate;
@class TVIRemoteAudioTrackPublication;
@class TVIRemoteDataTrackPublication;
@class TVIRemoteVideoTrackPublication;
@class TVIRemoteAudioTrack;
@class TVIRemoteDataTrack;
@class TVIRemoteVideoTrack;

/**
 *  `TVIRemoteParticipant` represents a remote Participant in a Room which you are connected to.
 */
NS_SWIFT_NAME(RemoteParticipant)
@interface TVIRemoteParticipant : TVIParticipant

/**
 *  @brief The Remote Participant's delegate. Set this property to be notified about Participant events such as tracks being
 *  added or removed.
 */
@property (atomic, weak, nullable) id<TVIRemoteParticipantDelegate> delegate;

/**
 *  @brief The collection of Remote Audio Tracks.
 */
@property (nonatomic, copy, readonly, nonnull) NSArray<TVIRemoteAudioTrackPublication *> *remoteAudioTracks;

/**
 *  @brief The collection of Remote Video Tracks.
 */
@property (nonatomic, copy, readonly, nonnull) NSArray<TVIRemoteVideoTrackPublication *> *remoteVideoTracks;

/**
 *  @brief The collection of Remote Data Tracks.
 */
@property (nonatomic, copy, readonly, nonnull) NSArray<TVIRemoteDataTrackPublication *> *remoteDataTracks;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use `TwilioVideo` connectWith* methods to join a `TVIRoom` with `TVIRemoteParticipant` instances.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use TwilioVideoSDK connectWith* methods to join a TVIRoom with TVIRemoteParticipant instances.")));

@end


/**
 *  `TVIRemoteParticipantDelegate` provides callbacks when important changes to a `TVIRemoteParticipant` occur.
 */
NS_SWIFT_NAME(RemoteParticipantDelegate)
@protocol TVIRemoteParticipantDelegate <NSObject>

@optional

/**
 * @brief Delegate method called when the Participant publishes a video track.
 *
 * @param participant The remote Participant.
 * @param publication The remote video track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didPublishVideoTrack:(nonnull TVIRemoteVideoTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidPublishVideoTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant unpublishes a video track.
 *
 * @param participant The remote Participant.
 * @param publication The remote video track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didUnpublishVideoTrack:(nonnull TVIRemoteVideoTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidUnpublishVideoTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant publishes an audio track.
 *
 * @param participant The remote Participant.
 * @param publication The remote audio track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didPublishAudioTrack:(nonnull TVIRemoteAudioTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidPublishAudioTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant unpublishes an audio track.
 *
 * @param participant The remote Participant.
 * @param publication The remote audio track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didUnpublishAudioTrack:(nonnull TVIRemoteAudioTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidUnpublishAudioTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant publishes a data track.
 *
 * @param participant The remote Participant.
 * @param publication The remote data track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didPublishDataTrack:(nonnull TVIRemoteDataTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidPublishDataTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant unpublishes a data track.
 *
 * @param participant The remote Participant.
 * @param publication The remote data track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didUnpublishDataTrack:(nonnull TVIRemoteDataTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidUnpublishDataTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant enables a video track.
 *
 * @param participant The remote Participant.
 * @param publication The remote video track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didEnableVideoTrack:(nonnull TVIRemoteVideoTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidEnableVideoTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant disables a video track.
 *
 * @param participant The remote Participant.
 * @param publication The remote video track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didDisableVideoTrack:(nonnull TVIRemoteVideoTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidDisableVideoTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant enables an audio track.
 *
 * @param participant The remote Participant.
 * @param publication The remote audio track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didEnableAudioTrack:(nonnull TVIRemoteAudioTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidEnableAudioTrack(participant:publication:));

/**
 * @brief Delegate method called when the Participant disables an audio track.
 *
 * @param participant The remote Participant.
 * @param publication The remote audio track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant didDisableAudioTrack:(nonnull TVIRemoteAudioTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidDisableAudioTrack(participant:publication:));

/**
 * @brief Delegate method called when the local Participant has succesfully subscribed to the Participant's remote video track.
 *
 * @param videoTrack The remote video track.
 * @param publication The remote video track publication.
 * @param participant The remote Participant.
 */
- (void)didSubscribeToVideoTrack:(nonnull TVIRemoteVideoTrack *)videoTrack
                     publication:(nonnull TVIRemoteVideoTrackPublication *)publication
                  forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didSubscribeToVideoTrack(videoTrack:publication:participant:));

/**
 * @brief Delegate method called when the local Participant has failed to subscribe to the Participant's remote video track publication.
 *
 * @param publication The remote video track publication.
 * @param error The error which indicates why the subscription failed.
 * @param participant The remote Participant.
 */
- (void)didFailToSubscribeToVideoTrack:(nonnull TVIRemoteVideoTrackPublication *)publication
                                 error:(nonnull NSError *)error
                        forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didFailToSubscribeToVideoTrack(publication:error:participant:));

/**
 * @brief Delegate method called when the local Participant has succesfully unsubscribed from the Participant's remote video track.
 *
 * @param videoTrack The remote video track.
 * @param publication The remote video track publication.
 * @param participant The remote Participant.
 */
- (void)didUnsubscribeFromVideoTrack:(nonnull TVIRemoteVideoTrack *)videoTrack
                         publication:(nonnull TVIRemoteVideoTrackPublication *)publication
                      forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didUnsubscribeFromVideoTrack(videoTrack:publication:participant:));

/**
 * @brief Delegate method called when the local Participant has succesfully subscribed to the Participant's remote audio track.
 *
 * @param audioTrack The remote audio track.
 * @param publication The remote audio track publication.
 * @param participant The remote Participant.
 */
- (void)didSubscribeToAudioTrack:(nonnull TVIRemoteAudioTrack *)audioTrack
                     publication:(nonnull TVIRemoteAudioTrackPublication *)publication
                  forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didSubscribeToAudioTrack(audioTrack:publication:participant:));

/**
 * @brief Delegate method called when the local Participant has failed to subscribe to the Participant's remote audio track publication.
 *
 * @param publication The remote audio track publication.
 * @param error The error which indicates why the subscription failed.
 * @param participant The remote Participant.
 */
- (void)didFailToSubscribeToAudioTrack:(nonnull TVIRemoteAudioTrackPublication *)publication
                                 error:(nonnull NSError *)error
                        forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didFailToSubscribeToAudioTrack(publication:error:participant:));

/**
 * @brief Delegate method called when the local Participant has succesfully unsubscribed from the Participant's remote audio track.
 *
 * @param audioTrack The remote audio track.
 * @param publication The remote audio track publication.
 * @param participant The remote Participant.
 */
- (void)didUnsubscribeFromAudioTrack:(nonnull TVIRemoteAudioTrack *)audioTrack
                         publication:(nonnull TVIRemoteAudioTrackPublication *)publication
                      forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didUnsubscribeFromAudioTrack(audioTrack:publication:participant:));

/**
 * @brief Delegate method called when the local Participant has succesfully subscribed to the Participant's remote data track.
 *
 * @param dataTrack The remote data track.
 * @param publication The remote data track publication.
 * @param participant The remote Participant.
 */
- (void)didSubscribeToDataTrack:(nonnull TVIRemoteDataTrack *)dataTrack
                    publication:(nonnull TVIRemoteDataTrackPublication *)publication
                 forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didSubscribeToDataTrack(dataTrack:publication:participant:));

/**
 * @brief Delegate method called when the local Participant has failed to subscribe to the Participant's remote data track publication.
 *
 * @param publication The remote data track publication.
 * @param error The error which indicates why the subscription failed.
 * @param participant The remote Participant.
 */
- (void)didFailToSubscribeToDataTrack:(nonnull TVIRemoteDataTrackPublication *)publication
                                error:(nonnull NSError *)error
                       forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didFailToSubscribeToDataTrack(publication:error:participant:));

/**
 * @brief Delegate method called when the local Participant has succesfully unsubscribed from the Participant's remote data track.
 *
 * @param dataTrack The remote data track.
 * @param publication The remote data track publication.
 * @param participant The remote Participant.
 */
- (void)didUnsubscribeFromDataTrack:(nonnull TVIRemoteDataTrack *)dataTrack
                        publication:(nonnull TVIRemoteDataTrackPublication *)publication
                     forParticipant:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(didUnsubscribeFromDataTrack(dataTrack:publication:participant:));

/**
 * @brief Delegate method called when the Remote Participant's `networkQualityLevel` has changed.
 *
 * @param participant The remote participant.
 * @param networkQualityLevel The new Network Quality Level.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant networkQualityLevelDidChange:(TVINetworkQualityLevel)networkQualityLevel
NS_SWIFT_NAME(remoteParticipantNetworkQualityLevelDidChange(participant:networkQualityLevel:));

/**
 * @brief Delegate method called when a subscribed `TVIRemoteVideoTrack` is switched off based on the
 * bandwidth allocation algorithm. Video will not be received for the `TVIRemoteVideoTrack` until it is switched
 * back on.
 *
 * @param participant The `TVIRemoteParticipant` connected to the `TVIRoom`.
 * @param track The subscribed `TVIRemoteVideoTrack`.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant
    switchedOffVideoTrack:(nonnull TVIRemoteVideoTrack *)track
NS_SWIFT_NAME(remoteParticipantSwitchedOffVideoTrack(participant:track:));

/**
 * @brief Emitted when a subscribed `TVIRemoteVideoTrack` that was switched off is now switched back on based
 * on the bandwidth allocation algorithm. Video will be received for the `TVIRemoteVideoTrack` until it is
 * switched off.
 *
 * @param participant The `TVIRemoteParticipant` connected to the `TVIRoom`.
 * @param track The remote video track.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant
     switchedOnVideoTrack:(nonnull TVIRemoteVideoTrack *)track
NS_SWIFT_NAME(remoteParticipantSwitchedOnVideoTrack(participant:track:));

/**
 * @brief Emitted when the `TVIRemoteParticipant` changes the published priority of one of their `TVIRemoteAudioTrack`s.
 *
 * @param participant The remote participant.
 * @param priority The publish priority.
 * @param publication The remote audio track publication
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant
 didChangePublishPriority:(nonnull TVITrackPriority)priority
            forAudioTrack:(nonnull TVIRemoteAudioTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidChangeAudioTrackPublishPriority(participant:priority:publication:));

/**
 * @brief Emitted when the `TVIRemoteParticipant` changes the published priority of one of their `TVIRemoteVideoTrack`s.
 *
 * @param participant The remote participant.
 * @param priority The publish priority.
 * @param publication The remote video track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant
 didChangePublishPriority:(nonnull TVITrackPriority)priority
            forVideoTrack:(nonnull TVIRemoteVideoTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidChangeVideoTrackPublishPriority(participant:priority:publication:));

/**
 * @brief Emitted when the `TVIRemoteParticipant` changes the published priority of one of their `TVIRemoteDataTrack`s.
 *
 * @param participant The remote participant.
 * @param priority The publish priority
 * @param publication The remote data track publication.
 */
- (void)remoteParticipant:(nonnull TVIRemoteParticipant *)participant
 didChangePublishPriority:(nonnull TVITrackPriority)priority
             forDataTrack:(nonnull TVIRemoteDataTrackPublication *)publication
NS_SWIFT_NAME(remoteParticipantDidChangeDataTrackPublishPriority(participant:priority:publication:));

@end
