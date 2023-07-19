//
//  TVIVideoTrack.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "TVITrack.h"

@protocol TVIVideoRenderer;

/**
 *  `TVIVideoTrack` represents video, and provides an interface to render frames from the track.
 */
NS_SWIFT_NAME(VideoTrack)
@interface TVIVideoTrack : TVITrack

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Tracks cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Tracks cannot be created explicitly.")));

/**
 *  @brief An array of renderers that are currently attached to the video track.
 *
 *  @note Use the 'addRenderer:' and 'removeRenderer:' methods to manipulate this collection.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<id<TVIVideoRenderer>> *renderers;

/**
 *  @brief Adds a renderer to the video track. Renderers provide fine control over how video is displayed.
 *
 *  @discussion Calling `addRenderer` multiple times with the same renderer will result in an NSInvalidArgumentException.
 *
 *  @param renderer An object or swift struct that implements the `TVIVideoRenderer` protocol.
 */
- (void)addRenderer:(nonnull id<TVIVideoRenderer>)renderer;

/**
 *  @brief Removes a renderer from the video track.
 *
 *  @param renderer An object or swift struct that implements the `TVIVideoRenderer` protocol.
 */
- (void)removeRenderer:(nonnull id<TVIVideoRenderer>)renderer;

@end
