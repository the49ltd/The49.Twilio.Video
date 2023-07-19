//
//  TVILocalAudioTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIAudioTrackPublication.h"
#import "TVITrackPriority.h"

@class TVILocalAudioTrack;

/**
 * `TVILocalAudioTrackPublication` contains the mapping between a published `TVILocalAudioTrack` and its server generated `sid`.
 */
NS_SWIFT_NAME(LocalAudioTrackPublication)
@interface TVILocalAudioTrackPublication : TVIAudioTrackPublication

/**
 *  @brief The local audio track associated with track publication.
 */
@property (nonatomic, strong, readonly, nullable) TVILocalAudioTrack *localTrack;

/**
 *  @brief The track priority of the `TVILocalAudioTrackPublication`
 *
 *  @discussion The publisher's `TVITrackPriority` for the corresponding `TVILocalAudioTrack` can be updated after
 *  it has been published.
 */
@property (nonatomic, copy, nonnull) TVITrackPriority priority;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Track publications cannot be created explicitly
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Track publications cannot be created explicitly.")));

@end
