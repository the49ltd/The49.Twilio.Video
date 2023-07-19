//
//  TVIVideoTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVITrackPublication.h"

@class TVIVideoTrack;

/**
 * `TVIVideoTrackPublication` contains the mapping between a video track and its server generated `sid`.
 */
NS_SWIFT_NAME(VideoTrackPublication)
@interface TVIVideoTrackPublication : TVITrackPublication

/**
 *  @brief The video track associated with the video track publication.
 */
@property (nonatomic, strong, readonly, nullable) TVIVideoTrack *videoTrack;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Published tracks cannot be created explicitly
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIVideoTrackPublication cannot be created explicitly.")));

@end
