//
//  TVICameraSourceOptions.h
//  TwilioVideo
//
//  Copyright © 2018-2019 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <AVFoundation/AVFoundation.h>

#import "TVICameraSourceOrientationTracker.h"
#import "TVIVideoFrame.h"

/**
 *  `TVICameraSourceOptionsRotationTags` specifies how `TVICameraSource` should handle rotation tags.
 */
typedef NS_ENUM(NSUInteger, TVICameraSourceOptionsRotationTags) {
    /**
     *  Capture video in the natural orientation of the device and use rotation tags to describe the delivered orientation.
     *  If one or more subscribers does not support rotation tags then the tags will be physically removed using the CPU before encoding the frames.
     */
    TVICameraSourceOptionsRotationTagsKeep = 0,
    /**
     *  Capture frames in the natural orientation of the device, and use hardware acceleration to physically remove any tags. This option is uesful in some scenarios:
     *  1. To save energy in a Group Room where rotation tags are not supported.
     *  2. When recording local video with AVAssetWriter, so that recordings do not need to include transforms.
     *  3. For image processing with Computer Vision & Machine Learning algorithms.
     *  However, there are disadvantages such as:
     *  1. On older devices (< iPhone 8), the output from the camera might be interrupted momentarily after a rotation occurs.
     *  2. The dimensions of the video are not consistent before/after a rotation (since width and height become swapped).
     */
    TVICameraSourceOptionsRotationTagsRemove,
}
NS_SWIFT_NAME(CameraSourceOptions.RotationTags);

/**
 *  `TVICameraSourceOptionsBuilder` is a builder class for `TVICameraSourceOptions`.
 */
NS_SWIFT_NAME(CameraSourceOptionsBuilder)
@interface TVICameraSourceOptionsBuilder : NSObject

/**
 *  @brief Allows the developer to enable support for camera multi tasking. When this is supported by the device, setting this option to true will allow the camera to continue running when the video applicaiton is put in background, or on a splitted view.
 *
 *  @discussion Only a few apple devices supports this features. Twilio Video SDK will enable this feature by default when possible.
 *
 *  @see [Accessing the camera while multitasking on iPad](https://developer.apple.com/documentation/avkit/accessing_the_camera_while_multitasking_on_ipad)
 */
@property (nonatomic, assign) BOOL enableCameraMultitasking API_AVAILABLE(ios(16.0));;

/**
 *  @brief Allows the developer to customize how `TVICameraSource` tracks video orientation for capture and preview.
 *
 *  @discussion Defaults to `+[TVIUserInterfaceTracker tracker]` which monitors `-[UIApplication statusBarOrientation]`.
 *
 *  When a tracker is created with `+[TVIUserInterfaceTracker trackerWithScene:]`, `TVICameraSource` monitors for `UISceneWillEnterForegroundNotification`.
 *  Otherwise, the source monitors for `UIApplicationWillEnterForegroundNotification`.
 *
 *  You can also manually control how orientation is tracked. For example, you might decide to use `UIDevice` instead of `UIScene` to determine the orientation of the camera.
 *
 *  Note that the video data output connection is configured for the native orientation of the camera sensor.
 *  The connection is set to `AVCaptureVideoOrientationLandscapeLeft` for front facing devices, and
 *  `AVCaptureVideoOrientationLandscapeRight` for rear facing devices. For example, if you are holding your iOS device in
 *  `AVCaptureVideoOrientationLandscapeLeft` (`UIDeviceOrientationLandscapeRight`) with the front
 *  camera facing towards you, then no rotation is required and the correct tag would be `TVIVideoOrientationUp`.
 *
 *  @see TVICameraSourceOrientationTracker.h
 */
@property (nonatomic, strong, nonnull) id<TVICameraSourceOrientationTracker> orientationTracker;

/**
 *  Enable the use of `TVICameraPreviewView` to preview video from the camera. Defaults to `NO`.
 */
@property (nonatomic, assign) BOOL enablePreview;

/**
 *  @brief How `TVICameraSource` should handle rotation tags. Defaults to `TVICameraSourceOptionsRotationTagsKeep`.
 *
 *  @see TVICameraSourceOptionsRotationTags
 */
@property (nonatomic, assign) TVICameraSourceOptionsRotationTags rotationTags;

/**
 *  @brief The initial zoom factor to use for the capture device. Throws an `NSInvalidArgumentException` if the
 *  selected zoom factor is not supported by the device. Defaults to `1.0`.
 *
 *  @see [AVCaptureDevice](AVCaptureDevice.h)
 */
@property (nonatomic, assign) CGFloat zoomFactor;

/**
 *  @brief You should not initialize `TVICameraSourceOptionsBuilder` directly, use a `TVICameraSourceOptionsBuilderBlock` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use a TVICameraSourceOptionsBuilderBlock instead.")));

@end

/**
 *  `TVICameraSourceOptionsBuilderBlock` allows you to construct `TVICameraSourceOptions` using the builder pattern.
 *
 *  @param builder The builder.
 */
typedef void (^TVICameraSourceOptionsBuilderBlock)(TVICameraSourceOptionsBuilder * _Nonnull builder)
NS_SWIFT_NAME(CameraSourceOptionsBuilder.Block);

/**
 *  Represents immutable configuration options for a `TVICameraSource`.
 */
NS_SWIFT_NAME(CameraSourceOptions)
@interface TVICameraSourceOptions : NSObject

/**
 *  @brief Allows the developer to customize how `TVICameraSource` tracks video orientation for capture and preview.
 *
 *  @discussion Defaults to `+[TVIUserInterfaceTracker tracker]`.
 *
 *  You can also manually control how orientation is tracked. For example, you might decide to use `UIDevice` instead of `UIScene` to determine the orientation of video from the camera.
 *
 *  Note that the video data output connection is configured for the native orientation of the camera sensor.
 *  The connection is set to `AVCaptureVideoOrientationLandscapeLeft` for front facing devices, and
 *  `AVCaptureVideoOrientationLandscapeRight` for rear facing devices. For example, if you are holding your iOS device in
 *  `AVCaptureVideoOrientationLandscapeLeft` (`UIDeviceOrientationLandscapeRight`) with the front
 *  camera facing towards you, then no rotation is required and the correct tag would be `TVIVideoOrientationUp`.
 *
 *  @see TVICameraSourceOrientationTracker.h
 */
@property (nonatomic, strong, readonly, nonnull) id<TVICameraSourceOrientationTracker> orientationTracker;

/**
 *  Enable the use of `TVICameraPreviewView` to preview video from the camera. Defaults to `NO`.
 */
@property (nonatomic, assign, readonly) BOOL enablePreview;

/**
*  @brief How `TVICameraSource` should handle rotation tags. Defaults to `TVICameraSourceOptionsRotationTagsKeep`.
*
*  @see TVICameraSourceOptionsRotationTags
*/
@property (nonatomic, assign, readonly) TVICameraSourceOptionsRotationTags rotationTags;

/**
 *  @brief The initial zoom factor to use for the capture device. Throws an `NSInvalidArgumentException` if the
 *  selected zoom factor is not supported by the device. Defaults to `1.0`.
 *
 *  @see [AVCaptureDevice](AVCaptureDevice.h)
 */
@property (nonatomic, assign, readonly) CGFloat zoomFactor;


/**
 *  @brief Allows the developer to enable support for camera multi tasking. When this is supported by the device, setting this option to true will allow the camera to continue running when the video applicaiton is put in background
 *
 *  @discussion Only a few apple devices supports this features. Twilio Video SDK will enable this feature by default when possible.
 *
 *  @see [Accessing the camera while multitasking on iPad](https://developer.apple.com/documentation/avkit/accessing_the_camera_while_multitasking_on_ipad)
 */
@property (nonatomic, assign) BOOL enableCameraMultitasking API_AVAILABLE(ios(16.0));;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use the class method `optionsWithBlock:` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use optionsWithBlock: to create a TVICameraSourceOptions instance.")));

/**
 *  @brief Creates an instance of `TVICameraSourceOptions` using a builder block.
 *
 *  @param block The builder block which will be used to configure the `TVICameraSourceOptions` instance.
 *
 *  @return An instance of `TVICameraSourceOptions`.
 */
+ (nonnull instancetype)optionsWithBlock:(nonnull TVICameraSourceOptionsBuilderBlock)block;

@end
