//
//  TVIVideoContentPreferences.h
//  TwilioVideo
//
//  Copyright © 2021 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

@class TVIVideoDimensions;

/**
 *  `TVIVideoContentPreferencesBuilder` is a builder class for `TVIVideoContentPreferences`.
 */
NS_SWIFT_NAME(VideoContentPreferencesBuilder)
@interface TVIVideoContentPreferencesBuilder : NSObject

/**
 * @brief Indicates the render dimensions for a `TVIRemoteVideoTrack` represented as `TVIVideoDimensions`.
 */
@property (nonatomic, strong, nullable) TVIVideoDimensions *renderDimensions;

/**
 *  @brief You should not initialize `TVIVideoContentPreferencesBuilder` directly, use a `TVIVideoContentPreferencesBuilderBlock` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use a TVIVideoContentPreferencesBuilderBlock instead.")));

@end

/**
 *  `TVIVideoContentPreferencesBuilderBlock` allows you to construct `TVIVideoContentPreferences` using the builder pattern.
 *
 *  @param builder The builder.
 */
typedef void (^TVIVideoContentPreferencesBuilderBlock)(TVIVideoContentPreferencesBuilder * _Nonnull builder)
NS_SWIFT_NAME(VideoContentPreferencesBuilder.Block);


/**
 *  `TVIVideoContentPreferences` represents the subscriber's preferences for a `TVIRemoveVideoTrack`.
 */
NS_SWIFT_NAME(VideoContentPreferences)
@interface TVIVideoContentPreferences : NSObject

/**
 * @brief Indicates the render dimensions for a `TVIRemoteVideoTrack` represented as `TVIVideoDimensions`.
 */
@property (nonatomic, strong, readonly, nullable) TVIVideoDimensions *renderDimensions;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use the class method `preferencesWithBlock:` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use preferencesWithBlock: to create a TVIVideoContentPreferences instance.")));


/**
 *  @brief Constructs `TVIVideoContentPreferences` using the builder pattern.
 *
 *  @param block The builder block which will be used to configure the `TVIVideoContentPreferences` instance.
 *
 *  @return An instance of `TVIVideoContentPreferences`.
 */
+ (null_unspecified instancetype)preferencesWithBlock:(nonnull TVIVideoContentPreferencesBuilderBlock)block;

@end
