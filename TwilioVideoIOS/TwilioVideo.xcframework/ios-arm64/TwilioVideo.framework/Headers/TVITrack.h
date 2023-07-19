//
//  TVITrack.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

/**
 *  `TVITrackState` is an enum defines the possible states of a track.
 */
typedef NS_ENUM(NSUInteger, TVITrackState) {
    /**
     *  Track ended.
     */
    TVITrackStateEnded = 0,
    /**
     *  Track live.
     */
    TVITrackStateLive,
}
NS_SWIFT_NAME(Track.State);

/**
 *  `TVITrack` is the base class from which all other Track types are derived.
 */
NS_SWIFT_NAME(Track)
@interface TVITrack : NSObject

/**
 *  @brief Indicates if the Track is enabled or not.
 */
@property (nonatomic, assign, readonly, getter=isEnabled) BOOL enabled;

/**
 *  @brief The Track name. 
 */
@property (nonatomic, copy, readonly, nonnull) NSString *name;

/**
 *  @brief The current state of the Track.
 */
@property (nonatomic, assign, readonly) TVITrackState state;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion `TVITrack` cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVITrack cannot be created explicitly.")));

@end
