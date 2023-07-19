//
//  TVIRemoteVideoTrack.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIVideoTrack.h"
#import "TVITrackPriority.h"

@class TVIVideoContentPreferences;

/**
 * `TVIRemoteVideoTrack` represents a remote video track.
 */
NS_SWIFT_NAME(RemoteVideoTrack)
@interface TVIRemoteVideoTrack : TVIVideoTrack

/**
 *  @brief The sid of the remote video track.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *sid;

/**
 *  @brief Get whether the track is switched off.
 */
@property (nonatomic, assign, readonly, getter=isSwitchedOff) BOOL switchedOff;

/**
 *  @brief A `nullable` property set by the publisher for the corresponding `TVIRemoteVideoTrack`.
 *
 *  @discussion The default subscriber priority is `nil`, which indicates that the subscriber has not set a
 *  priority for this `TVIRemoteVideoTrack`. If the `TVIRemoteVideoTrack` has been unsubscribed from then
 *  this will return the last set priority. Setting this property to `nil` clears the subscribers `TVITrackPriority` for
 *  this `TVIRemoteVideoTrack`.
 */
@property (nonatomic, copy, nullable) TVITrackPriority priority;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Tracks cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Tracks cannot be created explicitly.")));

/**
 * @brief Request to switch off a `RemoteVideoTrack`, if it is currently switched on.
 *
 * @discussion This method must be called only if the `clientTrackSwitchOffControl` is set to manual in video bandwidth profile options.
 */
- (void)switchOff;

/**
 * @brief Request to switch on a `RemoteVideoTrack`, if it was switched off using `RemoteVideoTrack.switchOff()`.
 *
 * @discussion This method must be called only if the `clientTrackSwitchOffControl` is set to manual in video bandwidth profile options.
 * Tracks may still remain switched off when available bandwidth is limited.
 */
- (void)switchOn;

/**
 * @brief Sets the `TVIVideoContentPreferences` for the `RemoteVideoTrack`.
 *
 * @param contentPreferences The `TVIVideoContentPreferences` for this `RemoteVideoTrack`.
 *
 * @discussion This method must be called only if the `contentPreferencesMode` is set to manual in video bandwidth profile options.
 */
- (void)setContentPreferences:(nonnull TVIVideoContentPreferences *)contentPreferences;

@end
