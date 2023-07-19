//
//  TVIAppScreenSource.h
//  TwilioVideo
//
//  Copyright © 2020 Twilio, Inc. All rights reserved.
//

#import "TVIAppScreenSourceOptions.h"
#import "TVIVideoSource.h"

@protocol TVIAppScreenSourceDelegate;

/**
 * The domain for errors raised by `TVIAppScreenSource`.
 */
FOUNDATION_EXPORT NSErrorDomain _Nonnull const kTVIAppScreenSourceErrorDomain
NS_SWIFT_NAME(AppScreenSource.ErrorDomain);

/**
 * Enumeration indicating the errors raised by `TVIAppScreenSource`.
 */
typedef NS_ERROR_ENUM (kTVIAppScreenSourceErrorDomain, TVIAppScreenSourceError) {
    kTVIAppScreenSourceErrorAlreadyCapturing,   ///< The source was already started, and has not been stopped.
    kTVIAppScreenSourceErrorAlreadyStopped,     ///< The source was already stopped.
}
NS_SWIFT_NAME(AppScreenSource.Error);

/**
 *  A block called when your request to start a `TVIAppScreenSource` has completed.
 *
 *  @param error An error if the request to start or select could not be completed.
 */
typedef void (^TVIAppScreenSourceStartedBlock)(NSError * _Nullable error)
NS_SWIFT_NAME(AppScreenSource.StartedBlock);

/**
 *  A block called when your request to stop a `TVIAppScreenSource` has completed.
 *
 *  @param error An error if the request to stop could not be completed.
 */
typedef void (^TVIAppScreenSourceStoppedBlock)(NSError * _Nullable error)
NS_SWIFT_NAME(AppScreenSource.StoppedBlock);

/**
 *  `TVIAppScreenSource` is a `TVIVideoSource` that allows you to stream video of the app screen. This
 *  class manages a `RPScreenRecorder` internally.
 */
NS_SWIFT_NAME(AppScreenSource)
@interface TVIAppScreenSource : NSObject <TVIVideoSource>

/**
 *  @brief Initializes a `TVIAppScreenSource` with default options. You may set a delegate later if you wish.
 *
 *  @return A `TVIAppScreenSource`, or nil if one could not be created.
 *
 *  @discussion When running on the simulator nil will be returned.
 */
- (null_unspecified instancetype)init;

/**
 *  @brief Initializes a `TVIAppScreenSource` with a delegate and default options.
 *
 *  @param delegate A delegate conforming to `TVIAppScreenSourceDelegate`, or nil.
 *
 *  @return A `TVIAppScreenSource`, or nil if one could not be created.
 *
 *  @discussion When running on the simulator nil will be returned. The delegate is called on the main queue.
 */
- (nullable instancetype)initWithDelegate:(nullable id<TVIAppScreenSourceDelegate>)delegate;

/**
 *  @brief Initializes a `TVIAppScreenSource` with all configuration options.
 *
 *  @param options A `TVIAppScreenSourceOptions` instance to configure your source.
 *  @param delegate A delegate conforming to `TVIAppScreenSourceDelegate`, or `nil`.
 *
 *  @return A `TVIAppScreenSource`, or nil if one could not be created.
 *
 *  @discussion When running on the simulator nil will be returned. The delegate is called on the main queue.
 */
- (nullable instancetype)initWithOptions:(nonnull TVIAppScreenSourceOptions *)options
                               delegate:(nullable id<TVIAppScreenSourceDelegate>)delegate;

/**
 *  @brief The source's delegate.
 *
 *  @discussion The delegate is called on the main queue.
 */
@property (nonatomic, weak, nullable) id<TVIAppScreenSourceDelegate> delegate;

/**
 *  @brief Indicates whether the screen is available for capture.
 *
 *  @discussion When set to `YES`, the screen is available for capture. Screen capture can be unavailable due to unsupported
 *  hardware, the user’s device displaying information over AirPlay or through a TVOut session, or another app using ReplayKit.
 */
@property (nonatomic, readonly) BOOL isAvailable;

/**
 *  @brief Indicates whether the screen is being captured.
 *
 *  @discussion When set to `YES`, the screen is being captured.
 */
@property (nonatomic, readonly) BOOL isCapturing;

/**
 *  @brief Starts capture. The video pipeline will start asynchronously after this method returns.
 *
 *  @discussion The system will lock screen orientation during screen capture. When you are done capturing video using the `TVIAppScreenSource`
 *  you must call either `[TVIAppScreenSource stopCapture]` or `[TVIAppScreenSource stopCaptureWithCompletion:]`.
 *
 *  @see stopCapture
 *  @see stopCaptureWithCompletion:
 */
- (void)startCapture;

/**
 *  @brief Starts capture with a completion handler.
 *
 *  @param completion A handler block to be called on the main queue once capture has started, or failed to start.
 *
 *  @discussion The system will lock screen orientation during screen capture. When you are done capturing video using the `TVIAppScreenSource`
 *  you must call either `[TVIAppScreenSource stopCapture]` or `[TVIAppScreenSource stopCaptureWithCompletion:]`.
 *
 *  @see stopCapture
 *  @see stopCaptureWithCompletion:
 */
- (void)startCaptureWithCompletion:(nullable TVIAppScreenSourceStartedBlock)completion;

/**
 *  @brief Stops capture asynchronously.
 *
 *  @discussion This method is equivalent to calling `[TVIAppScreenSource stopCaptureWithCompletion:]` with a nil block.
 */
- (void)stopCapture;

/**
 *  @brief Stops capture asynchronously with a completion handler.
 *
 *  @param completion A handler block to be called on the main queue once the `RPScreenRecorder` is stopped.
 *
 *  @discussion Use this method to coordinate your application logic with the stopping of the source's video pipeline.
 */
- (void)stopCaptureWithCompletion:(nullable TVIAppScreenSourceStoppedBlock)completion;

@end

/**
 *  `TVIAppScreenSourceDelegate` receives important lifecycle events related to `TVIAppScreenSource`.
 *  By implementing these methods you can handle state changes and errors that may occur.
 */
NS_SWIFT_NAME(AppScreenSourceDelegate)
@protocol TVIAppScreenSourceDelegate <NSObject>

@optional

/**
 *  @brief Screen capture has become available.
 *
 *  @discussion You may wish to enable your `TVILocalVideoTrack` if you disabled it when the the source was unavailable.
 *
 *  @param source The source that has become available.
 */
- (void)appScreenSourceDidBecomeAvailable:(nonnull TVIAppScreenSource *)source;

/**
 *  @brief Screen capture has become unavailable.
 *
 *  @discussion You may wish to disable your `TVILocalVideoTrack`, and update your UI when screen capture is unavailable.
 *
 *  @param source The source that has become unavailable.
 */
- (void)appScreenSourceDidBecomeUnavailable:(nonnull TVIAppScreenSource *)source;

/**
 *  @brief The source received an error while capturing.
 *
 *  @param source The source which received the error.
 *  @param error  The error received.
 */
- (void)appScreenSource:(nonnull TVIAppScreenSource *)source
 didReceiveCaptureError:(nonnull NSError *)error
NS_SWIFT_NAME(appScreenSourceDidReceiveCaptureError(source:error:));

/**
 *  @brief The source unexpectedly stopped capturing.
 *
 *  @param source The source which stopped.
 *  @param error  The error which caused the source to stop.
 */
- (void)appScreenSource:(nonnull TVIAppScreenSource *)source
didStopCapturingWithError:(nullable NSError *)error
NS_SWIFT_NAME(appScreenSourceDidStopCapture(source:error:));

@end
