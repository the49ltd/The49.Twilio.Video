//
//  TVIDataTrackOptions.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 *  @brief Default value for max packet life time.
 */
FOUNDATION_EXPORT const int kTVIDataTrackOptionsDefaultMaxPacketLifeTime
NS_SWIFT_NAME(DataTrackOptions.DefaultMaxPacketLifeTime);

/**
 *  @brief Default value for max retransmits
 */
FOUNDATION_EXPORT const int kTVIDataTrackOptionsDefaultMaxRetransmits
NS_SWIFT_NAME(DataTrackOptions.DefaultMaxRetransmits);

/**
 *  `TVIDataTrackOptionsBuilder` constructs `TVIDataTrackOptionsBuilder`.
 */
NS_SWIFT_NAME(DataTrackOptionsBuilder)
@interface TVIDataTrackOptionsBuilder : NSObject

/**
 *  @brief Ordered transmission of messages. Defaults to `YES`.
 */
@property (nonatomic, assign, getter=isOrdered) BOOL ordered;

/**
 *  @brief Maximum retransmit time in milliseconds. Default value is `kTVIDataTrackOptionsDefaultMaxPacketLifeTime`.
 *
 *  @discussion `maxPacketLifeTime` and `maxRetransmits` are mutually exclusive. This means that only one of these
 *  values can be set to a non default value at a time. Valid values are `kTVIDataTrackOptionsDefaultMaxPacketLifeTime`
 *  and 0..`UINT16_MAX`.
 */
@property (nonatomic, assign) int maxPacketLifeTime;

/**
 *  @brief Maximum number of retransmitted messages. Default value is `kTVIDataTrackOptionsDefaultMaxRetransmits`.
 *
 *  @discussion `maxRetransmits` and `maxPacketLifeTime` are mutually exclusive. This means that only one of these
 *  values can be set to a non default value at a time. Valid values are `kTVIDataTrackOptionsDefaultMaxRetransmits`
 *  and 0..`UINT16_MAX`.
 */
@property (nonatomic, assign) int maxRetransmits;

/**
 *  @brief The name for the Track.
 */
@property (nonatomic, nullable, copy) NSString *name;

/**
 *  @brief You should not initialize `TVIDataTrackOptionsBuilder` directly, use a TVIDataTrackOptionsBuilderBlock instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use a TVIDataTrackOptionsBuilderBlock instead.")));

@end

/**
 *  `TVIDataTrackOptionsBuilderBlock` allows you to construct `TVIDataTrackOptions` using the builder pattern.
 *
 *  @param builder The builder.
 */
typedef void (^TVIDataTrackOptionsBuilderBlock)(TVIDataTrackOptionsBuilder * _Nonnull builder)
NS_SWIFT_NAME(DataTrackOptionsBuilder.Block);

/**
 *  `TVIDataTrackOptions` specifies options for `TVILocalDataTrack`.
 */
NS_SWIFT_NAME(DataTrackOptions)
@interface TVIDataTrackOptions : NSObject

/**
 *  @brief Ordered transmission of messages. Defaults to `YES`.
 */
@property (nonatomic, assign, readonly, getter=isOrdered) BOOL ordered;

/**
 *  @brief Maximum retransmit time in milliseconds.
 */
@property (nonatomic, assign, readonly) int maxPacketLifeTime;

/**
 *  @brief Maximum number of retransmitted messages.
 */
@property (nonatomic, assign, readonly) int maxRetransmits;

/**
 *  @brief The name for the Track.
 */
@property (nonatomic, nullable, copy, readonly) NSString *name;

/**
 *  @brief Creates default options.
 *
 *  @return An instance of `TVIDataTrackOptions`.
 */
+ (null_unspecified instancetype)options;

/**
 *  @brief Constructs `TVIDataTrackOptions` using the builder pattern.
 *
 *  @param block You can pass data track options to the builder using this block. The builder will construct a
 *  `TVIDataTrackOptions` object using the options provided.
 *
 *  @discussion If both `maxPacketLifeTime` and `maxRetransmits` are set to non default values, or if
 *  `maxPacketLifeTime` or `maxRetransmits` are set to an out of range value, an `NSInvalidArgumentException` will
 *  be thrown.
 *
 *  @return An instance of `TVIDataTrackOptions`.
 */
+ (null_unspecified instancetype)optionsWithBlock:(nonnull TVIDataTrackOptionsBuilderBlock)block;

@end
