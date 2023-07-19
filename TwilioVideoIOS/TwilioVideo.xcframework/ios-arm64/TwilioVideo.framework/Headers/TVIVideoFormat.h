//
//  TVIVideoFormat.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <CoreVideo/CoreVideo.h>
#import <CoreMedia/CoreMedia.h>

/**
 *  The subset of Core Video pixel formats which are supported by `TVIVideoSink`.
 */
typedef NS_ENUM(OSType, TVIPixelFormat) {
    /**
     *  32-bit ARGB.
     */
    TVIPixelFormat32ARGB = kCVPixelFormatType_32ARGB,

    /**
     *  32-bit BGRA.
     */
    TVIPixelFormat32BGRA = kCVPixelFormatType_32BGRA,

    /**
     *  Bi-Planar Component Y'CbCr 8-bit 4:2:0, video-range (luma=[16,235] chroma=[16,240]). baseAddr points to a big-endian CVPlanarPixelBufferInfo_YCbCrBiPlanar struct.
     */
    TVIPixelFormatYUV420BiPlanarVideoRange = kCVPixelFormatType_420YpCbCr8BiPlanarVideoRange,

    /**
     *  Bi-Planar Component Y'CbCr 8-bit 4:2:0, full-range (luma=[0,255] chroma=[1,255]). baseAddr points to a big-endian CVPlanarPixelBufferInfo_YCbCrBiPlanar struct.
     */
    TVIPixelFormatYUV420BiPlanarFullRange = kCVPixelFormatType_420YpCbCr8BiPlanarFullRange,

    /**
     *  Planar Component Y'CbCr 8-bit 4:2:0. baseAddr points to a big-endian CVPlanarPixelBufferInfo_YCbCrPlanar struct.
     */
    TVIPixelFormatYUV420PlanarVideoRange = kCVPixelFormatType_420YpCbCr8Planar,

    /**
     *  Planar Component Y'CbCr 8-bit 4:2:0, full range. baseAddr points to a big-endian CVPlanarPixelBufferInfo_YCbCrPlanar struct. 
     */
    TVIPixelFormatYUV420PlanarFullRange = kCVPixelFormatType_420YpCbCr8PlanarFullRange
}
NS_SWIFT_NAME(PixelFormat);

/**
 *  `TVIVideoFormat` describes the properties of video content which a `TVIVideoSource` produces.
 *  A capturer can support many formats, but only one will be selected when capture is started.
 */
NS_SWIFT_NAME(VideoFormat)
@interface TVIVideoFormat : NSObject

/**
 *  @brief The size of the video content.
 *
 *  @discussion Dimensions should be in the native coordinate system of your capturer (before rotations are applied).
 */
@property (nonatomic, assign) CMVideoDimensions dimensions;

/**
 *  @brief The frame rate of the video content.
 *
 *  @discussion This value should be greater than zero.
 */
@property (nonatomic, assign) NSUInteger frameRate;

/**
 *  @brief The pixel format of the video content.
 *
 *  @discussion This should be set to one of the supported values defined in `TVIPixelFormat`.
 */
@property (nonatomic, assign) TVIPixelFormat pixelFormat;

@end
