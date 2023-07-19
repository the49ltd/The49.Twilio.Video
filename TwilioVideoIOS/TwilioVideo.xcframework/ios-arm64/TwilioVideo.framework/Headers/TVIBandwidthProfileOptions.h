//
//  TVIBandwidthProfileOptions.h
//  TwilioVideo
//
//  Copyright © 2020 Twilio, Inc. All rights reserved.
//

@class TVIVideoBandwidthProfileOptions;

/**
 *  BandwidthProfileOptions enables you to configure how available bandwidth is shared among the
 *  Tracks in a Group Room.
 */
NS_SWIFT_NAME(BandwidthProfileOptions)
@interface TVIBandwidthProfileOptions : NSObject

/**
 *  @brief Get video options specified in the  BandwidthProfileOptions initializer.
 */
@property (nonatomic, strong, readonly, nonnull) TVIVideoBandwidthProfileOptions *video;

/**
 *  The initializer with video options param.
 *
 *  @param video Bandwidth profile options for video.
 *
 *  @return An instance of TVIBandwidthProfileOptions.
 */
- (nonnull instancetype)initWithVideoOptions:(nonnull TVIVideoBandwidthProfileOptions *)video;

@end
