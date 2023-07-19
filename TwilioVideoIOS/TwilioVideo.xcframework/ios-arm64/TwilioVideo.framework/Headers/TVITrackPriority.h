//
//  TVITrackPriority.h
//  TwilioVideo
//
//  Copyright © 2020 Twilio, Inc. All rights reserved.
//

/**
 *  `TVITrackPriority` Defines the three possible track publication priorities for the Local publication.
 *  The default Track publication priority is `TVITrackPriorityStandard`.
 *
 *  @discussion Not all video tracks are equal. For example, in a webinar application the screen share track is
 *  more important than the webcams, while in a video collaboration service the dominant speaker has more relevance
 *  than the rest of the participants.
 *  Track priorities can be understood as the relative relevance of Tracks. This means
 *  that, from the Twilio perspective, any Track marked as high will be more important than any standard Track, which
 *  in turn will be more relevant that any low priority Track.
 *  Currently, only the Network Bandwidth Profile API consumes Track priorities to determine which Tracks are more
 *  relevant from the bandwidth allocation perspective. In the future Twilio may use Track priorities for other further purposes.
 */
typedef NSString * TVITrackPriority NS_STRING_ENUM
NS_SWIFT_NAME(Track.Priority);
/**
 *  Track priority low
 */
FOUNDATION_EXPORT _Nonnull TVITrackPriority const TVITrackPriorityLow;
/**
 *  Track priority standard
 */
FOUNDATION_EXPORT _Nonnull TVITrackPriority const TVITrackPriorityStandard;
/**
 *  Track priority high
 */
FOUNDATION_EXPORT _Nonnull TVITrackPriority const TVITrackPriorityHigh;
