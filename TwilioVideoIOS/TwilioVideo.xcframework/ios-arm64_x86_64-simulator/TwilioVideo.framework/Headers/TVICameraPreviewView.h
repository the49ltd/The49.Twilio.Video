//
//  TVICameraPreviewView.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CoreMedia/CoreMedia.h>

/**
 *  `TVICameraPreviewView` previews video captured by `TVICameraCapturer`.
 *
 *  @discussion This view uses the special preview path offered by `AVCaptureVideoPreviewLayer`. It offers some benefits
 *  which are not provided by `TVIVideoView` such as frame accurate mirroring, and graceful support for UIViewContentMode.
 *  The supported content modes are: `UIViewContentModeScaleToFill`, `UIViewContentModeScaleAspectFill`, and `UIViewContentModeScaleAspectFit`.
 */
NS_SWIFT_NAME(CameraPreviewView)
@interface TVICameraPreviewView : UIView

/**
 *  @brief The orientation of the view's content. This value is updated by listening to `UIApplicationWillChangeStatusBarOrientationNotification`.
 */
@property (nonatomic, assign, readonly) UIInterfaceOrientation orientation;

/**
 *  @brief The dimensions of the preview feed, in the frame of reference specified by the `TVICameraPreviewView`'s `orientation`.
 *
 *  @discussion With default constraints the dimensions would be 640x480 in landscape, and 480x640 in portrait.
 */
@property (nonatomic, assign, readonly) CMVideoDimensions videoDimensions;

@end
