//
//  TVIVideoFrame.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <CoreMedia/CoreMedia.h>
#import <CoreVideo/CoreVideo.h>

/**
 *  Specifies the orientation of video content.
 */
typedef NS_ENUM(NSUInteger, TVIVideoOrientation) {
    /**
     *  The video is rotated 0 degrees, oriented with its top side up.
     */
    TVIVideoOrientationUp = 0,
    /**
     *  The video is rotated 90 degrees, oriented with its top side to the left.
     */
    TVIVideoOrientationLeft,
    /**
     *  The video is rotated 180 degrees, oriented with its top side to bottom.
     */
    TVIVideoOrientationDown,
    /**
     *  The video is rotated 270 degrees, oriented with its top side to the right.
     */
    TVIVideoOrientationRight,
}
NS_SWIFT_NAME(VideoOrientation);

/**
 *  @brief A helper which constructs an affine transform for any orientation.
 *
 *  @param orientation The orientation of the video you wish to display.
 *
 *  @return A `CGAffineTransform` struct which can be applied to a renderer's view.
 */
NS_SWIFT_NAME(VideoOrientation.makeTransform(orientation:))
static inline CGAffineTransform TVIVideoOrientationMakeTransform(TVIVideoOrientation orientation) {
    return CGAffineTransformMakeRotation((CGFloat)orientation * M_PI_2);
}

/**
 *  @brief A helper which indicates if the orientation would cause the native dimensions to be flipped.
 *
 *  @param orientation The orientation to check.
 *
 *  @return `YES` if the orientation would cause the dimensions to be flipped, and `NO` otherwise.
 */
NS_SWIFT_NAME(VideoOrientation.isRotated(orientation:))
static inline BOOL TVIVideoOrientationIsRotated(TVIVideoOrientation orientation) {
    return (orientation == TVIVideoOrientationLeft ||
            orientation == TVIVideoOrientationRight);
}

/**
 *  @brief A helper which indicates if the orientation is valid.
 *
 *  @param orientation The orientation to check.
 *
 *  @return `YES` if the orientation is valid, and `NO` otherwise.
 */
NS_SWIFT_NAME(VideoOrientation.isValid(orientation:))
static inline BOOL TVIVideoOrientationIsValid(TVIVideoOrientation orientation) {
    return (orientation == TVIVideoOrientationLeft ||
            orientation == TVIVideoOrientationRight ||
            orientation == TVIVideoOrientationUp ||
            orientation == TVIVideoOrientationDown);
}

/**
 *  A video frame which has been captured or decoded.
 *
 *  @discussion `TVIVideoFrame` represents a CoreVideo buffer, along with metadata important for rendering and encoding.
 */
NS_SWIFT_NAME(VideoFrame)
@interface TVIVideoFrame : NSObject

/**
 *  @brief Developers shouldn't use this initializer.
 *
 *  @discussion Create using `initWithTimestamp:buffer:orientation:` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Create using initWithTimestamp:buffer:orientation: instead.")));

/**
 *  @brief Initialize a video frame that has been captured.
 *
 *  @param timestamp A CMTime struct which represents the time at which this frame was captured.
 *  @param imageBuffer A `CVImageBufferRef` which conforms to one of the pixel formats defined by `TVIPixelFormat`.
 *  This buffer is retained for the lifetime of `TVIVideoFrame`.
 *  @param orientation The orientation at which this frame was captured.
 *
 *  @discussion Use this initializer if you already have a CMTime representation of your capture timestamp. Please note
 *  that this timestamp may be internally translated after being delivered to the `TVIVideoSink` and before
 *  being raised to your renderer(s).
 *
 *  @see TVIVideoSource.h
 */
- (nullable instancetype)initWithTimestamp:(CMTime)timestamp
                                    buffer:(nonnull CVImageBufferRef)imageBuffer
                               orientation:(TVIVideoOrientation)orientation NS_DESIGNATED_INITIALIZER;

/**
 *  @brief Initialize a video frame that has been captured.
 *
 *  @param timeInterval A CFTimeInterval which represents the time when this frame was captured.
 *  @param imageBuffer A `CVImageBufferRef` which conforms to one of the pixel formats defined by `TVIPixelFormat`.
 *  This buffer is retained for the lifetime of `TVIVideoFrame`.
 *  @param orientation The orientation at which this frame was captured.
 *
 *  @discussion This convenience initializer will convert a CFTimeInterval into a CMTime using a timescale appropriate
 *  for the underlying media engine.
 *
 *  @see TVIVideoSource.h
 */
- (nullable instancetype)initWithTimeInterval:(CFTimeInterval)timeInterval
                                       buffer:(nonnull CVImageBufferRef)imageBuffer
                                  orientation:(TVIVideoOrientation)orientation;

/**
 *  @brief The timestamp at which this frame was captured, or should be rendered.
 *
 *  @discussion For decoded frames this is the display time measured using the system monotonic clock.
 *  For captured frames this should be the capture time measured using the timebase of the capturer.
 */
@property (nonatomic, assign, readonly) CMTime timestamp;

/**
 *  @brief A convenience getter which returns the width of `imageBuffer`.
 */
@property (nonatomic, assign, readonly) size_t width;

/**
 *  @brief A convenience getter which returns the height of `imageBuffer`.
 */
@property (nonatomic, assign, readonly) size_t height;

/**
 *  @brief A CVImageBuffer which contains the image data for the frame.
 */
@property (nonatomic, assign, readonly, nonnull) CVImageBufferRef imageBuffer;

/**
 *  @brief The orientation metadata for the frame.
 */
@property (nonatomic, assign, readonly) TVIVideoOrientation orientation;

@end
