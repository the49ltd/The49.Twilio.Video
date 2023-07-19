//
//  TVIParticipant.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

@class TVITrackPublication;
@class TVIAudioTrackPublication;
@class TVIVideoTrackPublication;
@class TVIDataTrackPublication;

/**
 *  @brief `TVINetworkQualityLevel` represents the Network Quality Level.
 *
 *  @discussion Twilio's Video SDKs, where possible, attempt to calculate a singular Network Quality Level describing
 *  the quality of a Participant's connection to a Room. This value ranges from -1 to 5, with -1 representing that the
 *  Network Quality Level can not be determined, 0 representing a failed network connection, 1 representing a poor
 *  network connection, and 5 representing an excellent network connection. The SDK calculates this metric only when
 *  connected to Group Rooms. In case of a connection to Peer-to-Peer Room the value is expected to be -1 at all times.
 *
 *  Note that the Network Quality Level is not an absolute metric but a score relative to the demand being placed on
 *  the network. For example, the NQ score might be a 5 while on a good network and publishing only an AudioTrack.
 *  Later, if a HD VideoTrack is added, the score might come down to 2. This also means that when the network is not
 *  being used at all (i.e. the Client is neither publishing nor subscribing to any tracks) the Network Quality Level
 *  will always be 5 given that any network will be capable of complying with a zero communications demand.
 */
typedef NS_ENUM(NSInteger, TVINetworkQualityLevel) {
    /**
     *  The Network Quality Level cannot be determined or the Network Quality API has not been enabled.
     */
    TVINetworkQualityLevelUnknown = -1,
    /**
     *  The network connection has failed.
     */
    TVINetworkQualityLevelZero = 0,
    /**
     *  The Network Quality is Very Bad.
     */
    TVINetworkQualityLevelOne,
    /**
     *  The Network Quality is Bad.
     */
    TVINetworkQualityLevelTwo,
    /**
     *  The Network Quality is Good.
     */
    TVINetworkQualityLevelThree,
    /**
     *  The Network Quality is Very Good.
     */
    TVINetworkQualityLevelFour,
    /**
     *  The Network Quality is Excellent.
     */
    TVINetworkQualityLevelFive
}
NS_SWIFT_NAME(NetworkQualityLevel);

/**
 * Enumeration indicating the state of the signaling connection for a TVIParticipant.
 */
typedef NS_ENUM (NSUInteger, TVIParticipantState) {
    TVIParticipantStateConnected = 0,  ///< The Participant has connected to signaling.
    TVIParticipantStateReconnecting,   ///< The Participant is attempting to reconnect to signaling.
    TVIParticipantStateDisconnected    ///< The Participant has disconnected from signaling
}
NS_SWIFT_NAME(Participant.State);

/**
 *  `TVIParticipant` is the base class from which Local and Remote Participants are derived.
 */
NS_SWIFT_NAME(Participant)
@interface TVIParticipant : NSObject

/**
 *  @brief The Participant's identity.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *identity;

/**
 *  @brief The Participant's server identifier. This value uniquely identifies the Participant in a Room and is often 
 *  useful for debugging purposes.
 */
@property (nonatomic, copy, readonly, nullable) NSString *sid;

/**
 *  @brief The signaling connection state of the Participant.
 */
@property (nonatomic, assign, readonly) TVIParticipantState state;

/**
 *  @brief The Participant's Network Quality Level
 *
 *  @discussion This property represents the quality of a Participant's connection in a Room. This value may not
 *  be immediately available, and, in some cases, it's impossible to calculate it. In these instances,
 *  `networkQualityLevel` will return `TVINetworkQualityLevelUnknown`. Calling this API in a Peer-to-Peer Room will
 *  always return `TVINetworkQualityLevelUnknown`. This is part of the Network Quality API and must be enabled by
 *  enabling the `networkQualityEnabled` option in `TVIConnectOptions`.
 */
@property (nonatomic, assign, readonly) TVINetworkQualityLevel networkQualityLevel;

/**
 *  @brief A collection of shared audio tracks.
 */
@property (nonatomic, copy, readonly, nonnull) NSArray<TVIAudioTrackPublication *> *audioTracks;

/**
 *  @brief A collection of shared video tracks.
 */
@property (nonatomic, copy, readonly, nonnull) NSArray<TVIVideoTrackPublication *> *videoTracks;

/**
 *  @brief A collection of shared data tracks.
 */
@property (nonatomic, copy, readonly, nonnull) NSArray<TVIDataTrackPublication *> *dataTracks;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion `TVIParticipant` cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIParticipant cannot be created explicitly.")));

/**
 *  @brief A utility method which finds a `TVITrackPublication` by its `sid`.
 *
 *  @param sid The track sid.
 *
 *  @return An instance of `TVITrackPublication` if found, otherwise `nil`.
 */
- (nullable TVITrackPublication *)getTrack:(nonnull NSString *)sid;

/**
 *  @brief A utility method which finds a `TVIAudioTrackPublication` by its `sid`.
 *
 *  @param sid The track sid.
 *
 *  @return An instance of `TVIAudioTrackPublication` if found, otherwise `nil`.
 */
- (nullable TVIAudioTrackPublication *)getAudioTrack:(nonnull NSString *)sid;

/**
 *  @brief A utility method which finds a `TVIVideoTrackPublication` by its `sid`.
 *
 *  @param sid The track sid.
 *
 *  @return An instance of `TVIVideoTrackPublication` if found, otherwise `nil`.
 */
- (nullable TVIVideoTrackPublication *)getVideoTrack:(nonnull NSString *)sid;

/**
 *  @brief A utility method which finds a `TVIDataTrackPublication` by its `sid`.
 *
 *  @param sid The track sid.
 *
 *  @return An instance of `TVIDataTrackPublication` if found, otherwise `nil`.
 */
- (nullable TVIDataTrackPublication *)getDataTrack:(nonnull NSString *)sid;

@end
