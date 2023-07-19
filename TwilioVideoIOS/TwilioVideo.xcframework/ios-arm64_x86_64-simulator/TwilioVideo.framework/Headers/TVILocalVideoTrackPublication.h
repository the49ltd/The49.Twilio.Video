//
//  TVILocalVideoTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVITrack.h"
#import "TVIVideoTrackPublication.h"

@class TVILocalVideoTrack;

/**
 * `TVILocalVideoTrackPublication` contains the mapping between a published `TVILocalVideoTrack` and its server generated `sid`.
 */
NS_SWIFT_NAME(LocalVideoTrackPublication)
@interface TVILocalVideoTrackPublication : TVIVideoTrackPublication

/**
 *  @brief The local video track associated with track publication.
 */
@property (nonatomic, strong, readonly, nullable) TVILocalVideoTrack *localTrack;

/**
 *  @brief The track priority of the `TVILocalVideoTrackPublication`
 *
 *  @discussion The publisher's `TVITrackPriority` for the corresponding `TVILocalVideoTrack` can be updated after
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
