//
//  TVITrackPublication.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

@class TVITrack;

/**
 * `TVITrackPublication` contains the mapping between a local track and its server generated `sid`.
 */
NS_SWIFT_NAME(TrackPublication)
@interface TVITrackPublication : NSObject

/**
*  @brief The track associated with the track publication.
*/
@property (nonatomic, strong, readonly, nullable) TVITrack *track;

/**
 *  @brief Indicates if the Track is enabled or not.
 */
@property (nonatomic, assign, readonly, getter = isTrackEnabled) BOOL trackEnabled;

/**
 *  @brief The Track name.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *trackName;

/**
 *  @brief The Local Tracks's server identifier. This value uniquely identifies the Local Track within the scope of a Room.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *trackSid;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Published tracks cannot be created explicitly
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVITrackPublication cannot be created explicitly.")));

@end
