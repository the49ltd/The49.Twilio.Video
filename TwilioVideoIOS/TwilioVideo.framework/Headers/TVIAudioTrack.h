//
//  TVIAudioTrack.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

#import "TVITrack.h"

@protocol TVIAudioSink;

/**
 *  `TVIAudioTrack` represents a local or remote audio track.
 */
NS_SWIFT_NAME(AudioTrack)
@interface TVIAudioTrack : TVITrack
/**
 *  @brief An array of sinks that are currently attached to the `TVIAudioTrack`.
 *
 *  @note Use the 'addSink:' and 'removeSink:' methods to manipulate this collection.
 */
@property (nonatomic, strong, readonly, nonnull) NSArray<id<TVIAudioSink>> *sinks;

/**
 *  @brief Adds a sink to the Track.
 *
 *  @discussion Sinks consume raw audio samples for further processing or storage.
 *
 *  @param sink An object or Swift struct that implements the `TVIAudioSink` protocol.
 */
- (void)addSink:(nonnull id<TVIAudioSink>)sink;

/**
 *  @brief Removes a sink from the Track.
 *
 *  @param sink An object or Swift struct that implements the `TVIAudioSink` protocol.
 */
- (void)removeSink:(nonnull id<TVIAudioSink>)sink;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Tracks cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Tracks cannot be created explicitly.")));

@end
