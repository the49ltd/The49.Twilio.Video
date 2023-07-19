//
//  TVIVideoDimensions.h
//  TwilioVideo
//
//  Copyright © 2021 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 *  TVIVideoDimensions represents dimensions for a VideoTrack.
 */
NS_SWIFT_NAME(VideoDimensions)
@interface TVIVideoDimensions : NSObject

/**
 *  @brief The video width.
 */
@property (nonatomic, assign) NSUInteger width;

/**
 *  @brief The video height.
 */
@property (nonatomic, assign) NSUInteger height;

/**
 *  @brief Creates an instance of `TVIVideoDimensions`.
 *
 *  @param width The video width.
 *  @param height The video height.
 *
 *  @return An instance of `TVIVideoDimensions`.
 */
+ (nonnull instancetype)dimensionsWithWidth:(NSUInteger)width height:(NSUInteger)height;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use the class methods `dimensionsWithWidth:height:` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use `dimensionsWithWidth:height` instead.")));

@end
