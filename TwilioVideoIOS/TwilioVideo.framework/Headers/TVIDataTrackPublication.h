//
//  TVIDataTrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVITrackPublication.h"

@class TVIDataTrack;

/**
 * `TVIDataTrackPublication` contains the mapping between a data track and its server generated `sid`.
 */
NS_SWIFT_NAME(DataTrackPublication)
@interface TVIDataTrackPublication : TVITrackPublication

/**
 *  @brief The data track associated with the data track publication.
 */
@property (nonatomic, strong, readonly, nullable) TVIDataTrack *dataTrack;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Published tracks cannot be created explicitly
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIDataTrackPublication cannot be created explicitly.")));

@end
