//
//  TVILocalDataTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIDataTrackPublication.h"
#import "TVITrackPriority.h"

@class TVILocalDataTrack;

/**
 * `TVILocalDataTrackPublication` contains the mapping between a published `TVILocalDataTrack` and its server generated `sid`.
 */
NS_SWIFT_NAME(LocalDataTrackPublication)
@interface TVILocalDataTrackPublication : TVIDataTrackPublication

/**
 *  @brief The local data track associated with track publication.
 */
@property (nonatomic, strong, readonly, nullable) TVILocalDataTrack *localTrack;

/**
 *  @brief The track priority of the `TVILocalDataTrackPublication`
 *
 *  @discussion The publisher's `TVITrackPriority` for the corresponding `TVILocalDataTrack` can be updated after
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
