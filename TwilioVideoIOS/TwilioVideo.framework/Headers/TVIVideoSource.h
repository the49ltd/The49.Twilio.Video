//
//  TVIVideoSource.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

#import "TVIVideoFormat.h"
#import "TVIVideoFrame.h"

/**
 * A source delivers video to a sink. Sources and sinks each provide requirements which must be satisfied.
 */
NS_SWIFT_NAME(VideoSink)
@protocol TVIVideoSink <NSObject>

/**
 * The source's current requirements, delivered via `onVideoFormatRequest:`. A nil value indicates that the developer has
 * made no specific request to modify the format that the source is delivering.
 */
@property (nonatomic, copy, nullable, readonly) TVIVideoFormat *sourceRequirements;

/**
 * @brief Deliver a frame to the sink.
 *
 * @param frame A `TVIVideoFrame` to be delivered.
 *
 * @discussion Frames delivered to a `TVIVideoSink` will be broadcasted to attached `TVIVideoRenderer`s, as well as
 * any video encoders that might exist in the media engine. If cropping is required, either due to source requirements
 * or internal sink (encoder) requirements, then the sink will add an attachment (`kCVImageBufferCleanApertureKey`)
 * to the underlying `CVPixelBuffer`.
 */
- (void)onVideoFrame:(nonnull TVIVideoFrame *)frame;

/**
 * @brief Request that the source output in a specific format.
 *
 * @discussion Developers who are using a `TVIVideoSource` should call `[TVIVideoSource requestOutputFormat:]` instead.
 *
 * @param format A `TVIVideoFormat` object which describes the desired output format.
 */
- (void)onVideoFormatRequest:(nullable TVIVideoFormat *)format;

@end

/**
 * A source produces video content and delivers it to a single `TVIVideoSink`. The output produced by a source may be
 * modified by using a format request.
 */
NS_SWIFT_NAME(VideoSource)
@protocol TVIVideoSource <NSObject>

/**
 * @brief The sink where video frames and format requests will be delivered.
 *
 * @discussion This property is automatically set when a `TVILocalVideoTrack` is created with your source.
 * This property is unset when the `TVILocalVideoTrack` is destroyed.
 *
 * @see TVILocalVideoTrack
 */
@property (nonatomic, weak, nullable) id<TVIVideoSink> sink;

/**
 * Indicates that the content from this source is a screenshare. When a source produces screen content, encoders downstream
 * from the source optimize for detail (spatial resolution) over frame rate (temporal resolution).
 */
@property (nonatomic, assign, readonly, getter = isScreencast) BOOL screencast;

/**
 * @brief Requests that the source deliver frames in a specific format, which may have scaling and/or cropping applied.
 *
 * @param outputFormat A `TVIVideoFormat` instance which specifies the desired output size. A combination of scaling/cropping will
 * be used to achieve the output dimensions. If a frame rate is specified then the sink will drop frames to achieve it.
 *
 * @discussion Output format requests are useful when you have a source that is restricted to capturing in certain formats,
 * but you want to publish in another format. For example, capture in 640x480 from the camera, and crop to square 480x480.
 * If you are implementing your own `TVIVideoSource`, you should respond to this method by forwarding the request to your
 * sink via `[TVIVideoSink onVideoFormatRequest:]`.
 */
- (void)requestOutputFormat:(nonnull TVIVideoFormat *)outputFormat;

@end
