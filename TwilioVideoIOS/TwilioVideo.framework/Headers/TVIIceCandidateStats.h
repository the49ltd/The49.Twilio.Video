//
//  TVIIceCandidateStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * `TVIIceCandidateStats` reflects the properties of a candidate in Section 15.1 in [RFC5245].
 */
NS_SWIFT_NAME(IceCandidateStats)
@interface TVIIceCandidateStats : NSObject

/**
 * @brief Ice candidate type.
 */
@property (nonatomic, copy, readonly, nullable) NSString *candidateType;

/**
 * @brief Determines if the ice candidate is deleted or not.
 *
 * @discussion For local candidates, `YES` indicates that the candidate has been deleted/freed as described by [RFC5245]. For host candidates, this means that any network resources (typically a socket) associated with the candidate have been released. For TURN candidates, this means the TURN allocation is no longer active.
 */
@property (nonatomic, assign, readonly, getter = isDeleted) BOOL deleted;

/**
 * @brief The IP address of the candidate, allowing for IPv4 addresses and IPv6 addresses, but fully qualified domain names (FQDNs) are not allowed. See [RFC5245] section 15.1 for details.
 */
@property (nonatomic, copy, readonly, nullable) NSString *ip;

/**
 * @brief `NO` indicates that this represents a local candidate; `YES` indicates that this represents a remote candidate.
 */
@property (nonatomic, assign, readonly, getter = isRemote) BOOL remote;

/**
 * @brief The port number of the candidate.
 */
@property (nonatomic, assign, readonly) long port;

/**
 * @brief The priority of the candidate. Priority is calculated as defined in [RFC5245] section 15.1.
 */
@property (nonatomic, assign, readonly) long priority;

/**
 * @brief The protocol used by the candidate. The valid values for transport is one of udp and tcp. Based on the "transport" defined in [RFC5245] section 15.1.
 */
@property (nonatomic, copy, readonly, nullable) NSString *protocol;


/**
 * @brief The URL of the TURN or STUN server indicated in the that translated this IP address. It is the URL address surfaced in an peer connection ice event.
 */
@property (nonatomic, copy, readonly, nullable) NSString *url;

/**
 * @brief The unique identifier used for TVIIceCandidateStats associated with this candidate.
 */
@property (nonatomic, copy, readonly, nullable) NSString *transportId;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Ice candidate stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIIceCandidateStats cannot be created explicitly.")));

@end

