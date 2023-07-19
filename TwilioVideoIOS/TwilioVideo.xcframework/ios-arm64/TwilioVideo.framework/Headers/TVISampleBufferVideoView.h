//
//  TVISampleBufferVideoView.h
//  TwilioVideo
//
//  Created by Tim Rozum on 8/18/22.
//  Copyright © 2022 Twilio, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>

#import "TVIVideoRenderer.h"

@class TVISampleBufferVideoView;
@protocol TVIVideoRenderer;

/**
 *  `TVISampleBufferVideoViewDelegate` allows you to respond to, and customize the behavior of `TVISampleBufferVideoView`.
 */
NS_SWIFT_NAME(SampleBufferVideoViewDelegate)
@protocol TVISampleBufferVideoViewDelegate <NSObject>

@optional
/**
 *  @brief This method is called once, and only once after the first frame is received.
 *  Use it to drive user interface animations.
 *  @note: Querying hasVideoData will return 'YES' within, and after this call.
 *
 *  @param view The video view which became ready.
 */
- (void)videoViewDidReceiveData:(nonnull TVISampleBufferVideoView *)view
NS_SWIFT_NAME(videoViewDidReceiveData(view:));

/**
 *  @brief This method is called every time the video track's dimensions change.
 *
 *  @param view The video view.
 *  @param dimensions The new dimensions of the video stream.
 */
- (void)videoView:(nonnull TVISampleBufferVideoView *)view videoDimensionsDidChange:(CMVideoDimensions)dimensions
NS_SWIFT_NAME(videoViewDimensionsDidChange(view:dimensions:));

@end

/**
 *  A `TVISampleBufferVideoView` draws video frames from a `TVIVideoTrack`.
 *  `TVISampleBufferVideoView` should only be used on the application's main thread. Subclassing `TVISampleBufferVideoView` is not supported.
 *  UIViewContentModeScaleToFill, UIViewContentModeScaleAspectFill and UIViewContentModeScaleAspectFit are the
 *  supported content modes.
 *
 *  When `TVISampleBufferVideoView` is contained within a `UIWindowScene` on iOS 13.0+, it registers for lifecycle notifications from the scene. When the view is used on
 *  earlier versions of iOS or added to a `UIWindow` without a `UIWindowScene`, it registers for `UIApplication` lifecycle notifications instead.
 */
NS_SWIFT_NAME(SampleBufferVideoView)
@interface TVISampleBufferVideoView : UIView <TVIVideoRenderer>

/**
 *  @brief Creates a video view with a frame and delegate.
 *
 *  @param frame The frame rectangle for the view.
 *  @param delegate An object implementing the `TVISampleBufferVideoViewDelegate` protocol (often a UIViewController).
 *
 *  @return A renderer.
 */
- (null_unspecified instancetype)initWithFrame:(CGRect)frame delegate:(nullable id<TVISampleBufferVideoViewDelegate>)delegate;

/**
 *  @brief A delegate which receives callbacks when important view rendering events occur.
 *
 *  @note The delegate is always called on the main thread in order to synchronize with UIKit.
 */
@property (nonatomic, weak, nullable) id<TVISampleBufferVideoViewDelegate> delegate;

/**
 *  @brief The dimensions of incoming video frames (without rotations applied). Use this to layout `TVISampleBufferVideoView`.
 */
@property (nonatomic, assign, readonly) CMVideoDimensions videoDimensions;

/**
 *  @brief Indicates that at least one frame of video data has been received.
 */
@property (nonatomic, assign, readonly) BOOL hasVideoData;

/**
 *  @brief Determines whether the view should be mirrored.
 *
 *  @discussion This is useful when rendering the local feed from the front camera. The default is `NO`.
 */
@property (nonatomic, assign, getter=shouldMirror) BOOL mirror;

@end
