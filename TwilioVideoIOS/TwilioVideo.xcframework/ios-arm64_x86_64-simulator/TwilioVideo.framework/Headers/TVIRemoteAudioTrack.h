//
//  TVIRemoteAudioTrack.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIAudioTrack.h"

/**
 * `TVIRemoteAudioTrack` represents a remote audio track.
 */
NS_SWIFT_NAME(RemoteAudioTrack)
@interface TVIRemoteAudioTrack : TVIAudioTrack

/**
 *  @brief Controls whether the contents of the AudioTrack are played locally. Defaults to 'YES'. Note that the remote 
 *  party can still enable or disable the track.
 */
@property (nonatomic, assign, getter=isPlaybackEnabled) BOOL playbackEnabled;

/**
 *  @brief The sid of the remote audio track.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *sid;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Tracks cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Tracks cannot be created explicitly.")));

@end
