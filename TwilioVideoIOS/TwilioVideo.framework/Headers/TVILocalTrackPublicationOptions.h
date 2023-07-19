//
//  TVILocalParticipantOptions.h
//  TwilioVideo
//
//  Copyright © 2020 Twilio, Inc. All rights reserved.
//

#import "TVITrackPriority.h"

/**
 * `TVILocalTrackPublicationOptions` represents options that can be specified when publishing a Local Track.
 */
NS_SWIFT_NAME(LocalTrackPublicationOptions)
@interface TVILocalTrackPublicationOptions : NSObject

/**
 *  @brief The track priority to be used when publishing a Local Track. `TVITrackPriorityStandard` is the default priority.
 */
@property (nonatomic, copy, readonly, nonnull) TVITrackPriority priority;

/**
 *  @brief Creates an instance of `TVILocalTrackPublicationOptions`.
 *
 *  @param priority The track priority to be used when publishing a Local Track.
 *
 *  @return An instance of `TVILocalTrackPublicationOptions`.
*/
+ (nonnull instancetype)optionsWithPriority:(nonnull TVITrackPriority)priority;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use the class methods `optionsWithPriority:` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use `optionsWithPriority:` instead.")));

@end
