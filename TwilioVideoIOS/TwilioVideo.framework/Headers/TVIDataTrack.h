//
//  TVIDataTrack.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

#import "TVITrack.h"

/**
 *  `TVIDataTrack` represents a local or remote data track.
 */
NS_SWIFT_NAME(DataTrack)
@interface TVIDataTrack : TVITrack

/**
 * @brief Returns `YES` if the data track guarantees reliable transmission of messages.
 */
@property (nonatomic, assign, readonly, getter=isReliable) BOOL reliable;

/**
 * @brief Returns `YES` if data track guarantees in-order delivery of messages.
 */
@property (nonatomic, assign, readonly, getter=isOrdered) BOOL ordered;

/**
 * @brief Returns the maximum period of time in milliseconds in which retransmissions will be sent.
 */
@property (nonatomic, assign, readonly) NSUInteger maxPacketLifeTime;

/**
 * @brief Returns the maximum number of times to transmit a message before giving up.
 */
@property (nonatomic, assign, readonly) NSUInteger maxRetransmits;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Tracks cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Tracks cannot be created explicitly.")));

@end
