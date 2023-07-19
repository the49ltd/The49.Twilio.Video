//
//  TVIAudioOptions.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 *  `TVIAudioOptionsBuilder` constructs `TVIAudioOptions`.
 */
NS_SWIFT_NAME(AudioOptionsBuilder)
@interface TVIAudioOptionsBuilder : NSObject

/**
 *  @brief Audio receiver jitter buffer (NetEq) fast accelerate mode. Defaults to `NO`.
 */
@property (nonatomic, assign) BOOL audioJitterBufferFastAccelerate;

/**
 *  @brief Audio receiver jitter buffer (NetEq) max capacity in number of packets. Defaults to `50`.
 */
@property (nonatomic, assign) int audioJitterBufferMaxPackets;

/**
 *  @brief Enable software Acoustic Echo Cancellation (AEC). Defaults to `NO`.
 *
 *  @discussion TVIDefaultAudioDevice uses Apple's built-in hardware echo cancellation. If you are having issues with
 *  echo cancellation and `TVIDefaultAudioDevice`, or you've written your own `TVIAudioDevice` without echo cancellation
 *  you may wish to enable software echo cancellation instead. This API is currently experimental, and we may extend the
 *  `TVIAudioDecice`'s APIs to work with this property.
 */
@property (nonatomic, assign, getter=isSoftwareAecEnabled) BOOL softwareAecEnabled;

/**
 *  @brief Audio processing to remove background noise of lower frequencies. Defaults to `YES`.
 */
@property (nonatomic, assign) BOOL highpassFilter;

/**
 *  @brief You should not initialize `TVIAudioOptionsBuilder` directly, use a TVIAudioOptionsBuilderBlock instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use a TVIAudioOptionsBuilderBlock instead.")));

@end

/**
 *  `TVIAudioOptionsBuilderBlock` allows you to construct `TVIAudioOptions` using the builder pattern.
 *
 *  @param builder The builder.
 */
typedef void (^TVIAudioOptionsBuilderBlock)(TVIAudioOptionsBuilder * _Nonnull builder)
NS_SWIFT_NAME(AudioOptionsBuilder.Block);

/**
 *  `TVIAudioOptions` specifies options for `TVILocalAudioTrack`.
 */
NS_SWIFT_NAME(AudioOptions)
@interface TVIAudioOptions : NSObject

/**
 *  @brief Audio receiver jitter buffer (NetEq) max capacity in number of packets. Defaults to `50`.
 */
@property (nonatomic, assign, readonly) int audioJitterBufferMaxPackets;

/**
 *  @brief Audio receiver jitter buffer (NetEq) fast accelerate mode. Defaults to `NO`.
 */
@property (nonatomic, assign, readonly) BOOL audioJitterBufferFastAccelerate;

/**
 *  @brief Enable software Acoustic Echo Cancellation (AEC). Defaults to `NO`.
 *
 *  @discussion TVIDefaultAudioDevice uses Apple's built-in hardware echo cancellation. If you are having issues with
 *  echo cancellation and `TVIDefaultAudioDevice`, or you've written your own `TVIAudioDevice` without echo cancellation
 *  you may wish to enable software echo cancellation instead. This API is currently experimental, and we may extend the
 *  `TVIAudioDecice`'s APIs to work with this property.
 */
@property (nonatomic, assign, readonly, getter=isSoftwareAecEnabled) BOOL softwareAecEnabled;

/**
 *  @brief Audio processing to remove background noise of lower frequencies. Defaults to `YES`.
 */
@property (nonatomic, assign, readonly) BOOL highpassFilter;

/**
 *  @brief Creates default options.
 *
 *  @return An instance of `TVIAudioOptions`.
 */
+ (null_unspecified instancetype)options;

/**
 *  @brief Constructs `TVIAudioOptions` using the builder pattern.
 *
 *  @param block You can pass audio options to the builder using this block. The builder will construct a
 *  `TVIAudioOptions` object using the options provided.
 *
 *  @return An instance of `TVIAudioOptions`.
 */
+ (null_unspecified instancetype)optionsWithBlock:(nonnull TVIAudioOptionsBuilderBlock)block;

@end
