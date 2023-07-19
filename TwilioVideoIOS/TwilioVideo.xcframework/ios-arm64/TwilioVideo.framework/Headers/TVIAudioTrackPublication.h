//
//  TVIAudioTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVITrackPublication.h"

@class TVIAudioTrack;

/**
 * `TVIAudioTrackPublication` contains the mapping between an audio track and its server generated `sid`.
 */
NS_SWIFT_NAME(AudioTrackPublication)
@interface TVIAudioTrackPublication : TVITrackPublication

/**
 *  @brief The audio track associated with the audio track publication.
 */
@property (nonatomic, strong, readonly, nullable) TVIAudioTrack *audioTrack;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Published tracks cannot be created explicitly
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIAudioTrackPublication cannot be created explicitly.")));

@end
