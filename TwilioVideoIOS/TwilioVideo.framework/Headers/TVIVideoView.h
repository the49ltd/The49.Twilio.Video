//
//  TVIVideoView.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>

#import "TVIVideoRenderer.h"

@class TVIVideoView;
@protocol TVIVideoRenderer;

/**
 *  `TVIVideoViewDelegate` allows you to respond to, and customize the behavior of `TVIVideoView`.
 */
NS_SWIFT_NAME(VideoViewDelegate)
@protocol TVIVideoViewDelegate <NSObject>

@optional
/**
 *  @brief This method is called once, and only once after the first frame is received.
 *  Use it to drive user interface animations.
 *  @note: Querying hasVideoData will return 'YES' within, and after this call.
 *
 *  @param view The video view which became ready.
 */
- (void)videoViewDidReceiveData:(nonnull TVIVideoView *)view
NS_SWIFT_NAME(videoViewDidReceiveData(view:));

/**
 *  @brief This method is called every time the video track's dimensions change.
 *
 *  @param view The video view.
 *  @param dimensions The new dimensions of the video stream.
 */
- (void)videoView:(nonnull TVIVideoView *)view videoDimensionsDidChange:(CMVideoDimensions)dimensions
NS_SWIFT_NAME(videoViewDimensionsDidChange(view:dimensions:));

/**
 *  @brief This method is called when the video track's orientation changes, and your app is handling content rotation.
 *
 *  @param view The video view.
 *  @param orientation The new orientation of the video stream.
 *
 *  @discussion This method will only be called when `TVIVideoView.viewShouldRotateContent` is set to NO.
 */
- (void)videoView:(nonnull TVIVideoView *)view videoOrientationDidChange:(TVIVideoOrientation)orientation
NS_SWIFT_NAME(videoViewOrientationDidChange(view:dimensions:));

@end

/**
 *  A `TVIVideoView` draws video frames from a `TVIVideoTrack`.
 *  `TVIVideoView` should only be used on the application's main thread. Subclassing `TVIVideoView` is not supported.
 *  UIViewContentModeScaleToFill, UIViewContentModeScaleAspectFill and UIViewContentModeScaleAspectFit are the
 *  supported content modes.
 *
 *  When `TVIVideoView` is contained within a `UIWindowScene` on iOS 13.0+, it registers for lifecycle notifications from the scene. When the view is used on
 *  earlier versions of iOS or added to a `UIWindow` without a `UIWindowScene`, it registers for `UIApplication` lifecycle notifications instead.
 *
 *  Since the `TVIVideoView` uses metal, video rendering on iOS 11.x simulators is not supported.
 */
NS_SWIFT_NAME(VideoView)
@interface TVIVideoView : UIView <TVIVideoRenderer>

/**
 *  @brief Creates a video view with a frame and delegate.
 *
 *  @param frame The frame rectangle for the view.
 *  @param delegate An object implementing the `TVIVideoViewDelegate` protocol (often a UIViewController).
 *
 *  @return A renderer.
 */
- (null_unspecified instancetype)initWithFrame:(CGRect)frame delegate:(nullable id<TVIVideoViewDelegate>)delegate;

/**
 *  @brief A delegate which receives callbacks when important view rendering events occur.
 *
 *  @note The delegate is always called on the main thread in order to synchronize with UIKit.
 */
@property (nonatomic, weak, nullable) id<TVIVideoViewDelegate> delegate;

/**
 *  @brief Specify if the video view or the application will handle rotated video content.
 *
 *  @discussion Handling rotations at the application level is more complex, but allows you to smoothly animate
 *  transitions. By default, video frame rotation is performed by `TVIVideoView`. Set this property to `NO` if
 *  you want to handle rotations in your own layout using `[TVIVideoViewDelegate videoView:videoOrientationDidChange:].
 */
@property (nonatomic, assign) BOOL viewShouldRotateContent;

/**
 *  @brief The dimensions of incoming video frames (without rotations applied). Use this to layout `TVIVideoView`.
 */
@property (nonatomic, assign, readonly) CMVideoDimensions videoDimensions;

/**
 *  @brief The orientation of incoming video frames. Use this to layout `TVIVideoView`.
 */
@property (nonatomic, assign, readonly) TVIVideoOrientation videoOrientation;

/**
 *  @brief Indicates that at least one frame of video data has been received.
 */
@property (atomic, assign, readonly) BOOL hasVideoData;

/**
 *  @brief Determines whether the view should be mirrored.
 *
 *  @discussion This is useful when rendering the local feed from the front camera. The default is `NO`.
 */
@property (nonatomic, assign, getter=shouldMirror) BOOL mirror;

@end
