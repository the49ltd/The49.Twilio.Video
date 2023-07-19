//
//  TVIIceCandidateStats.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 *  Specifies the type of the Ice candidate pair state.
 */
typedef NS_ENUM(NSUInteger, TVIIceCandidatePairState) {
    /**
     *  Ice candidate pair state Succeeded
     */
    TVIIceCandidatePairStateSucceeded,
    /**
     *  Ice candidate pair state Frozen
     */
    TVIIceCandidatePairStateFrozen,
    /**
     *  Ice candidate pair state Waiting
     */
    TVIIceCandidatePairStateWaiting,
    /**
     *  Ice candidate pair state in progress
     */
    TVIIceCandidatePairStateInProgress,
    /**
     *  Ice candidate pair state state Failed
     */
    TVIIceCandidatePairStateFailed,
    /**
     *  Ice candidate pair state state Cancelled
     */
    TVIIceCandidatePairStateCancelled,
    /**
     *  Unknown Ice candidate pair state
     */
    TVIIceCandidatePairStateUnknown
}
NS_SWIFT_NAME(IceCandidatePairStats.State);


/**
 * `TVIIceCandidatePairStats` reflects the properties of a Ice candidate pair
 */
NS_SWIFT_NAME(IceCandidatePairStats)
@interface TVIIceCandidatePairStats : NSObject

/**
 * @brief A boolean to indicate if the candidate pair is active.
 */
@property (nonatomic, assign, readonly, getter=isActiveCandidatePair) BOOL activeCandidatePair;

/**
 * @brief The relay protocol.
 */
@property (nonatomic, copy, readonly, nullable) NSString *relayProtocol;

/**
 * @brief The unique identifier used for TVIIceCandidateStats associated with this candidate.
 */
@property (nonatomic, copy, readonly, nullable) NSString *transportId;

/**
 * @brief The unique identifier that is associated to the object that was inspected to produce the Ice candidate attributes for the local candidate associated with this candidate pair.
 */
@property (nonatomic, copy, readonly, nullable) NSString *localCandidateId;

/**
 * @brief The IP address of the local candidate associated with this candidate pair.
 */
@property (nonatomic, copy, readonly, nullable) NSString *localCandidateIp;

/**
 * @brief The unique identifier that is associated to the object that was inspected to produce the Ice candidate attributes for the remote candidate associated with this candidate pair.
 */
@property (nonatomic, copy, readonly, nullable) NSString *remoteCandidateId;

/**
 * @brief The IP address of the remote candidate associated with this candidate pair.
 */
@property (nonatomic, copy, readonly, nullable) NSString *remoteCandidateIp;

/**
 * @brief Represents the state of the checklist for the local and remote candidates in a pair.
 */
@property (nonatomic, assign, readonly) TVIIceCandidatePairState state;

/**
 * @brief The priority of the candidate. Priority is calculated as defined in [RFC5245] section 15.1.
 */
@property (nonatomic, assign, readonly) uint64_t priority;

/**
 * @brief This booean is related to updating the nominated flag described in Section 7.1.3.2.4 of [ RFC5245].
 */
@property (nonatomic, assign, readonly, getter = isNominated) BOOL nominated;

/**
 * @brief Has gotten ACK to an ICE request.
 */
@property (nonatomic, assign, readonly, getter = isWritable) BOOL writable;

/**
 * @brief Has gotten a valid incoming ICE request.
 */
@property (nonatomic, assign, readonly, getter = isReadable) BOOL readable;

/**
 * @brief Represents the total number of payload bytes sent on this candidate pair, i.e., not including headers or padding.
 */
@property (nonatomic, assign, readonly) uint64_t bytesSent;

/**
 * @brief Represents the total number of payload bytes received on this candidate pair, i.e., not including headers or padding.
 */
@property (nonatomic, assign, readonly) uint64_t bytesReceived;

/**
 * @brief Total round trip time.
 *
 * @discussion Represents the sum of all round trip time measurements in seconds since the beginning of the session, based on both STUN connectivity check [ STUN-PATH-CHAR] responses (responsesReceived) and consent [ RFC7675] responses (consentResponsesReceived). The average round trip time can be computed from totalRoundTripTime by dividing it by (responsesReceived + consentResponsesReceived).
 */
@property (nonatomic, assign, readonly) CFTimeInterval totalRoundTripTime;

/**
 * @brief Current round trip time.
 *
 * @discussion Represents the latest round trip time measured in seconds, computed from both STUN connectivity checks [STUN-PATH-CHAR] and consent responses [RFC7675].
 */
@property (nonatomic, assign, readonly) CFTimeInterval currentRoundTripTime;

/**
 * @brief Available outgoing bitrate
 *
 * @discussion It is calculated by the underlying congestion control by combining the available bitrate for all the outgoing RTP streams using this candidate pair. The bitrate measurement does not count the size of the IP or other transport layers like TCP or UDP. It is similar to the TIAS defined in [RFC3890], i.e., it is measured in bits per second and the bitrate is calculated over a 1 second window.
 */
@property (nonatomic, assign, readonly) double availableOutgoingBitrate;

/**
 * @brief Available incoming bitrate
 *
 * @discussion It is calculated by the underlying congestion control by combining the available bitrate for all the incoming RTP streams using this candidate pair. The bitrate measurement does not count the size of the IP or other transport layers like TCP or UDP. It is similar to the TIAS defined in [RFC3890], i.e., it is measured in bits per second and the bitrate is calculated over a 1 second window.
 */
@property (nonatomic, assign, readonly) double availableIncomingBitrate;

/**
 * @brief Represents the total number of connectivity check requests received (including retransmissions).
 */
@property (nonatomic, assign, readonly) uint64_t requestsReceived;

/**
 * @brief Represents the total number of connectivity check requests sent (not including retransmissions).
 */
@property (nonatomic, assign, readonly) uint64_t requestsSent;

/**
 * @brief Represents the total number of connectivity check responses received.
 */
@property (nonatomic, assign, readonly) uint64_t responsesReceived;

/**
 * @brief Represents the total number of connectivity check responses sent.
 */
@property (nonatomic, assign, readonly) uint64_t responsesSent;

/**
 * @brief Represents the total number of connectivity check retransmissions received.
 */
@property (nonatomic, assign, readonly) uint64_t retransmissionsReceived;

/**
 * @brief Represents the total number of connectivity check retransmissions sent.
 */
@property (nonatomic, assign, readonly) uint64_t retransmissionsSent;

/**
 * @brief Represents the total number of consent requests received.
 */
@property (nonatomic, assign, readonly) uint64_t consentRequestsReceived;

/**
 * @brief Represents the total number of consent requests sent.
 */
@property (nonatomic, assign, readonly) uint64_t consentRequestsSent;

/**
 * @brief Represents the total number of consent responses received.
 */
@property (nonatomic, assign, readonly) uint64_t consentResponsesReceived;

/**
 * @brief Represents the total number of consent responses sent.
 */
@property (nonatomic, assign, readonly) uint64_t consentResponsesSent;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Ice candidate pair stats cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIIceCandidatePairStats cannot be created explicitly.")));

@end
