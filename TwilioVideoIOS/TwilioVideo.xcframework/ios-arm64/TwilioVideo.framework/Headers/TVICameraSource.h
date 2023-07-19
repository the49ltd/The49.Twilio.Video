//
//  TVICameraSource.h
//  TwilioVideo
//
//  Copyright © 2018-2019 Twilio, Inc. All rights reserved.
//

#import <AVFoundation/AVFoundation.h>
#import <Foundation/Foundation.h>

#import "TVIVideoSource.h"
#import "TVIVideoFormat.h"

@class TVICameraPreviewView;
@protocol TVICameraSourceDelegate;

/**
 * The domain for errors raised by `TVICameraSource`.
 */
FOUNDATION_EXPORT NSString * _Nonnull const kTVICameraSourceErrorDomain
NS_SWIFT_NAME(CameraSource.ErrorDomain);

/**
 * Enumeration indicating the errors raised by `TVICameraSource`.
 */
typedef NS_ENUM (NSUInteger, TVICameraSourceError) {
    kTVICameraSourceErrorNone = 0,                ///< Capture session already setup.
    kTVICameraSourceErrorAlreadyRunning,          ///< The source was already started, and has not been stopped.
    kTVICameraSourceErrorCameraPermissionDenied,  ///< The user has declined camera permissions.
}
NS_SWIFT_NAME(CameraSource.Error);

/**
 *  A block called when your request to start, or reconfigure a `TVICameraSource` has completed.
 *
 *  @param device The device that you requested to start.
 *  @param format The format that you requested, or the default format selected on your behalf.
 *  @param error An error if the request to start or select could not be completed.
 */
typedef void (^TVICameraSourceStartedBlock)(AVCaptureDevice * _Nonnull device,
                                            TVIVideoFormat * _Nonnull format,
                                            NSError * _Nullable error)
NS_SWIFT_NAME(CameraSource.StartedBlock);

/**
 *  A block called when your request to stop a `TVICameraSource` has completed.
 *
 *  @param error An error if the request to stop could not be completed.
 */
typedef void (^TVICameraSourceStoppedBlock)(NSError * _Nullable error)
NS_SWIFT_NAME(CameraSource.StoppedBlock);

@class TVICameraSourceOptions;

/**
 *  `TVICameraSource` is a `TVIVideoSource` that allows you to preview and stream video from the device cameras. This
 *  class manages an `AVCaptureSession` internally.
 */
NS_SWIFT_NAME(CameraSource)
@interface TVICameraSource : NSObject <TVIVideoSource>

/**
 *  @brief Initializes a `TVICameraSource` with default options. You may set a delegate later if you wish.
 *
 *  @return A `TVICameraSource`, or nil if one could not be created.
 */
- (null_unspecified instancetype)init;

/**
 *  @brief Initializes a `TVICameraSource` with a delegate, and default options.
 *
 *  @param delegate A delegate conforming to `TVICameraSourceDelegate`, or nil.
 *
 *  @return A `TVICameraSource`, or nil if one could not be created.
 */
- (nullable instancetype)initWithDelegate:(nullable id<TVICameraSourceDelegate>)delegate;

/**
 *  @brief Initializes a `TVICameraSource` with all configuration options. This is the designated initializer.
 *
 *  @param options A `TVICameraSourceOptions` instance to configure your source.
 *  @param delegate A delegate conforming to `TVICameraSourceDelegate`, or `nil`.
 *  @return A `TVICameraSource`, or nil if one could not be created.
 */
- (nullable instancetype)initWithOptions:(nonnull TVICameraSourceOptions *)options
                                delegate:(nullable id<TVICameraSourceDelegate>)delegate NS_DESIGNATED_INITIALIZER;

/**
 *  @brief The source's delegate.
 */
@property (nonatomic, weak, nullable) id<TVICameraSourceDelegate> delegate;

/**
 *  @brief Returns the device that the source is currently capturing from. This property will be set when invoking
 *  `TVICameraSourceStartedBlock`, and reset to `nil` immediately before invoking `TVICameraSourceStoppedBlock`.
 */
@property (nonatomic, strong, readonly, nullable) AVCaptureDevice *device;

/**
 *  @brief A view which allows you to preview the camera source.
 *
 *  @discussion `previewView` will be `nil` unless the source is initialized using
 *  `[TVICameraSource initWithOptions:delegate:]`, while setting `TVICameraSourceOptions.enablePreview` to `YES`.
 */
@property (nonatomic, strong, readonly, nullable) TVICameraPreviewView *previewView;

/**
 *  @brief Starts video capture with a device. The video pipeline will start asynchronously after this method returns.
 *
 *  @param device The `AVCaptureDevice` which the source should use. Must be non-null.
 *
 *  @discussion This method will automatically choose a format that works well with your capture device.
 *
 *  @note When you are done capturing video using the `TVICameraSource` you must call either `[TVICameraSource stopCapture]`
 *  or `[TVICameraSource stopCaptureWithCompletion:]`.
 *
 *  @see stopCapture
 *  @see stopCaptureWithCompletion:
 */
- (void)startCaptureWithDevice:(nonnull AVCaptureDevice *)device
NS_SWIFT_NAME(startCapture(device:));

/**
 *  @brief Starts video capture with a device and a completion handler.
 *
 *  @param device The `AVCaptureDevice` which the source should use. Must be non-null.
 *  @param completion A handler block to be called on the main thread once capture has started, or failed to start.
 *
 *  @discussion This method will automatically choose a format that works well with your capture device.
 *
 *  @note When you are done capturing video using the `TVICameraSource` you must call either `[TVICameraSource stopCapture]`
 *  or `[TVICameraSource stopCaptureWithCompletion:]`.
 *
 *  @see stopCapture
 *  @see stopCaptureWithCompletion:
 */
- (void)startCaptureWithDevice:(nonnull AVCaptureDevice *)device
                    completion:(nullable TVICameraSourceStartedBlock)completion
NS_SWIFT_NAME(startCapture(device:completion:));

/**
 *  @brief Starts video capture with a device, format and completion handler.
 *
 *  @param device The AVCaptureDevice which the source should use. Must be non-null.
 *  @param format The TVIVideoFormat which the source should use. Must be non-null.
 *  @param completion A handler block to be called on the main thread once capture has started, or failed to start.
 *
 *  @discussion Use this method if you have a specific capture device and format in mind for your use case.
 *
 *  @note When you are done capturing video using the `TVICameraSource` you must call either `[TVICameraSource stopCapture]`
 *  or `[TVICameraSource stopCaptureWithCompletion:]`.
 *
 *  @see stopCapture
 *  @see stopCaptureWithCompletion:
 */
- (void)startCaptureWithDevice:(nonnull AVCaptureDevice *)device
                        format:(nonnull TVIVideoFormat *)format
                    completion:(nullable TVICameraSourceStartedBlock)completion
NS_SWIFT_NAME(startCapture(device:format:completion:));

/**
 *  @brief Stops capture asynchronously.
 *
 *  @discussion This method is equivalent to calling `[TVICameraSource stopCaptureWithCompletion:]` with a nil block.
 */
- (void)stopCapture;

/**
 *  @brief Stops video capture asynchronously with a completion handler.
 *
 *  @param completion A handler block to be called on the main thread once the AVCaptureSession is stopped.
 *
 *  @discussion Use this method to coordinate your application logic with the stopping of the source's video pipeline.
 *  If you are managing your own `AVCaptureSession`, you should be able to use it safely after the handler is called.
 */
- (void)stopCaptureWithCompletion:(nullable TVICameraSourceStoppedBlock)completion
NS_SWIFT_NAME(stopCapture(completion:));

/**
 *  @brief Reconfigures the source to capture from a new device. The video pipeline will start asynchronously
 *  after this method returns.
 *
 *  @param device The AVCaptureDevice which the source should use. Must be non-null.
 *
 *  @discussion This method will automatically choose a format that works well with your capture device.
 */
- (void)selectCaptureDevice:(nonnull AVCaptureDevice *)device
NS_SWIFT_NAME(selectCaptureDevice(_:));

/**
 *  @brief Reconfigures the source to capture from a new device. The video pipeline will start asynchronously
 *  after this method returns.
 *
 *  @param device The AVCaptureDevice which the source should use. Must be non-null.
 *  @param completion A handler block to be called on the main thread once configuration has completed, or failed.
 *
 *  @discussion Use this method if you have a specific capture device and format in mind for your use case.
 */
- (void)selectCaptureDevice:(nonnull AVCaptureDevice *)device
                 completion:(nullable TVICameraSourceStartedBlock)completion
NS_SWIFT_NAME(selectCaptureDevice(_:completion:));

/**
 *  @brief Reconfigures the source to capture from a new device and/or format.
 *
 *  @param device The AVCaptureDevice which the source should use. Must be non-null.
 *  @param format The TVIVideoFormat which the source should use. Must be non-null.
 *  @param completion A handler block to be called on the main thread once configuration has completed, or failed.
 *
 *  @discussion Use this method if you have a specific capture device and format in mind for your use case.
 */
- (void)selectCaptureDevice:(nonnull AVCaptureDevice *)device
                     format:(nonnull TVIVideoFormat *)format
                 completion:(nullable TVICameraSourceStartedBlock)completion
NS_SWIFT_NAME(selectCaptureDevice(_:format:completion:));

/**
 *  @brief Discover an `AVCaptureDevice` by position.
 *
 *  @param position The position that you want to use, or AVCaptureDevicePositionUnspecified if you don't care.
 *
 *  @return An `AVCaptureDevice` of type `AVMediaTypeVideo`, or `nil` if one could not be found.
 *
 *  @discussion If you are on an iOS simulator then you should not expect to discover any devices.
 */
+ (nullable AVCaptureDevice *)captureDeviceForPosition:(AVCaptureDevicePosition)position
NS_SWIFT_NAME(captureDevice(position:));

/**
 *  @brief Discover an `AVCaptureDevice` by position and type.
 *
 *  @param position The position that you want to use, or AVCaptureDevicePositionUnspecified if you don't care.
 *  @param deviceType An `AVCaptureDeviceType` to further refine your query.
 *
 *  @return An `AVCaptureDevice` of type `AVMediaTypeVideo`, or `nil` if one could not be found.
 *
 *  @discussion If you are on an iOS simulator then you should not expect to discover any devices.
 *  This method uses `AVCaptureDeviceDiscoverySession`.
 */
+ (nullable AVCaptureDevice *)captureDeviceForPosition:(AVCaptureDevicePosition)position
                                                  type:(nonnull AVCaptureDeviceType)deviceType
NS_SWIFT_NAME(captureDevice(position:deviceType:));

/**
 *  @brief Determines the formats that are optimal for video streaming from a given `AVCaptureDevice`.
 *
 *  @param captureDevice The `AVCaptureDevice` that you want to query.
 *
 *  @return An `NSOrderedSet` containing zero or more `TVIVideoFormat` objects ordered by increasing size.
 *
 *  @discussion Use this method in conjunction with `[TVICameraSource startCaptureWithDevice:format:completion:]` for
 *  fine-grained control over video format selection.
 */
+ (nonnull NSOrderedSet<TVIVideoFormat *> *)supportedFormatsForDevice:(nonnull AVCaptureDevice *)captureDevice
NS_SWIFT_NAME(supportedFormats(captureDevice:));

@end

/**
 *  Methods to safely control some `AVCaptureDevice` features.
 */
@interface TVICameraSource (AVCaptureDeviceControl)

/**
 *  @brief The torch level to use for the capture device. Throws an `NSInvalidArgumentException` if setting the
 *  torch level is not supported by the currently selected device. Defaults to 0.
 *
 *  @discussion You should only set the torch level while using `AVCaptureTorchModeOn`.
 *
 *  @see [AVCaptureDevice](AVCaptureDevice.h)
 */
@property (nonatomic, assign) float torchLevel;

/**
 *  @brief The torch mode to use for the capture device. Throws an `NSInvalidArgumentException` if the
 *  torch mode is not supported by the currently selected device. Defaults to `AVCaptureTorchModeOff`.
 *
 *  @see [AVCaptureDevice](AVCaptureDevice.h)
 */
@property (nonatomic, assign) AVCaptureTorchMode torchMode;

/**
 *  @brief The zoom factor to use for the capture device. Throws an `NSInvalidArgumentException` if the
 *  zoom factor is not supported by the currently selected device. Defaults to `TVICameraSourceOptions.zoomFactor`.
 *
 *  @see [AVCaptureDevice](AVCaptureDevice.h)
 */
@property (nonatomic, assign) CGFloat zoomFactor;

@end

/**
 *  `TVICameraSourceDelegate` receives important lifecycle events related to `TVICameraSource`.
 *  By implementing these methods you can override default behavior, or handle errors that may occur.
 */
NS_SWIFT_NAME(CameraSourceDelegate)
@protocol TVICameraSourceDelegate <NSObject>

@optional

/**
 *  @brief The camera source interruption has now ended.
 *
 *  @discussion You might wish to enable your `TVILocalVideoTrack` if you disabled it when the interruption began.
 *
 *  @param source The source which started.
 */
- (void)cameraSourceInterruptionEnded:(nonnull TVICameraSource *)source
NS_SWIFT_NAME(cameraSourceInterruptionEnded(source:));

/**
 *  @brief The source was interrupted, and will not produce any more frames until the interruption ends.
 *
 *  @discussion You may wish to disable your `TVILocalVideoTrack`, and update your UI in response to an interruption.
 *
 *  @param source The source which was interrupted.
 *  @param reason The reason why the source was interrupted.
 */
- (void)cameraSourceWasInterrupted:(nonnull TVICameraSource *)source
                            reason:(AVCaptureSessionInterruptionReason)reason
NS_SWIFT_NAME(cameraSourceWasInterrupted(source:reason:));

/**
 *  @brief The source stopped running with a fatal error.
 *
 *  @param source The source which stopped.
 *  @param error  The error which caused the source to stop.
 */
- (void)cameraSource:(nonnull TVICameraSource *)source
    didFailWithError:(nonnull NSError *)error
NS_SWIFT_NAME(cameraSourceDidFail(source:error:));

/**
 *   @brief The system is reporting system pressure due to the camera source
 *
 *  @param source The source which is causing the pressure.
 *  @param level  The pressure [level](https://developer.apple.com/documentation/avfoundation/avcapturedevice/systempressurestate/level).
*/
- (void)cameraSource:(nonnull TVICameraSource *)source
    isReportingSystemPressure:(nonnull AVCaptureSystemPressureLevel)level
NS_SWIFT_NAME(cameraSourceIsReportingSystemPressure(source:level:));
@end
