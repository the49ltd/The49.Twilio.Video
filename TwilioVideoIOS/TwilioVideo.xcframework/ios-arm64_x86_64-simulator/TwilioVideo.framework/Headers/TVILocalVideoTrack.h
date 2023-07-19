//
//  TVILocalVideoTrack.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIVideoTrack.h"

@protocol TVIVideoSource;

/**
 * `TVILocalVideoTrack` represents local video produced by a `TVIVideoSource`.
 */
NS_SWIFT_NAME(LocalVideoTrack)
@interface TVILocalVideoTrack : TVIVideoTrack

/**
 *  @brief Indicates if track is enabled.
 *
 *  @discussion It is possible to enable and disable local tracks. The results of this operation are signaled to other
 *  Participants in the same Room. When a video track is disabled, black frames are sent in place of normal video.
 */
@property (nonatomic, assign, getter = isEnabled) BOOL enabled;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use `trackWithCapturer:` or `trackWithCapturer:enabled:constraints:name:` to create a `TVILocalVideoTrack`.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use `trackWithCapturer:` or `trackWithCapturer:enabled:constraints:name:` to create a `TVILocalVideoTrack`.")));

/**
 *  @brief The video source that is associated with this track when using the `TVIVideoSource` based initializers.
 */
@property (nonatomic, strong, readonly, nullable) id<TVIVideoSource> source;

/**
 *  @brief Creates a `TVILocalVideoTrack` with a `TVIVideoSource`.
 *
 *  @discussion The Track will be enabled, and use a randomly generated name.
 *  @see [TVIVideoSource](TVIVideoSource.h)
 *
 *  @param source A `TVIVideoSource` which will provide the content for this Track.
 *
 *  @return A Track which is ready to be shared with Participants in a Room, or `nil` if an error occurs.
 */
+ (nullable instancetype)trackWithSource:(nonnull id<TVIVideoSource>)source;

/**
 *  @brief Creates a `TVILocalVideoTrack` with a `TVIVideoSource`.
 *
 *  @discussion The Track will be enabled, and use a randomly generated name.
 *  @see [TVIVideoSource](TVIVideoSource.html)
 *
 *  @param source A `TVIVideoSource` which will provide the content for this Track.
 *  @param enabled Determines if the Track is enabled at creation time.
 *  @param name A name for the Track. Names are immutable and can only be provided at Track creation time.
 *
 *  @return A Track which is ready to be shared with Participants in a Room, or `nil` if an error occurs.
 */
+ (nullable instancetype)trackWithSource:(nonnull id<TVIVideoSource>)source
                                 enabled:(BOOL)enabled
                                    name:(nullable NSString *)name;

@end
