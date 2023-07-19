//
//  TVIRoom.h
//  TwilioVideo
//
//  Copyright © 2016-2021 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

@class TVILocalParticipant;
@class TVIRemoteParticipant;
@class TVIStatsReport;

@protocol TVIRoomDelegate;

/**
 *  TVIRoomState represents the current state of a TVIRoom.
 *
 *  @discussion All TVIRoom instances start in `TVIRoomStateConnecting`, before transitioning to `TVIRoomStateConnected` or
 *  `TVIRoomStateDisconnected`.
 */
typedef NS_ENUM(NSUInteger, TVIRoomState) {
    /**
     *  The `TVIRoom` is attempting a connection based upon the TVIConnectOptions provided.
     */
    TVIRoomStateConnecting = 0,
    /**
     *  The `TVIRoom` is connected, and ready to interact with other Participants.
     */
    TVIRoomStateConnected,
    /**
     *  The `TVIRoom` has been disconnected, and interaction with other Participants is no longer possible.
     */
    TVIRoomStateDisconnected,
    /**
     *  The `TVIRoom` is attempting to reconnect following a network disruption.
     */
    TVIRoomStateReconnecting,
}
NS_SWIFT_NAME(Room.State);

/**
 *  `TVIRoomGetStatsBlock` is invoked asynchronously when the results of the `TVIRoom getStatsWithBlock:` method are available.
 *
 *  @param statsReports A collection of `TVIStatsReport` objects
 */
typedef void (^TVIRoomGetStatsBlock)(NSArray<TVIStatsReport *> * _Nonnull statsReports)
NS_SWIFT_NAME(Room.GetStatsBlock);

/**
 *  `TVIRoom` represents a media session with zero or more Remote Participants. Media shared by any one Participant is
 *  distributed equally to all other Participants.
 */
NS_SWIFT_NAME(Room)
@interface TVIRoom : NSObject

/**
 *  @brief The `TVIRoomDelegate`. Set this property to be notified about Room events such as connection status, and 
 *  Remote Participants joining and leaving.
 *
 *  @discussion It is recommended that this property is only accessed on the `delegateQueue` specified in the `TVIConnectOptions`
 *  when connecting to the room. If no explicit `delegateQueue` was provided, the main dispatch queue should be used.
 */
@property (nonatomic, weak, nullable) id<TVIRoomDelegate> delegate;

/**
 *  @brief The dominant speaker in the Room.
 *
 *  @discussion Indicates the dominant speaker in the Room, if any; in some Rooms (Peer-to-Peer), this cannot be
 *  computed, and so is always `nil`. This is part of the Dominant Speaker API and must be enabled by enabling
 *  the `dominantSpeakerEnabled` option in `TVIConnectOptions`.
 */
@property (nonatomic, strong, readonly, nullable) TVIRemoteParticipant *dominantSpeaker;

/**
 *  @brief A representation of your local Client in the Room.
 *
 *  @discussion `TVILocalParticipant` is available once the delegate method `didConnectToRoom` is called.
 *  If you have not yet connected to the Room, or your attempt fails then this property will return `nil`.
 */
@property (nonatomic, strong, readonly, nullable) TVILocalParticipant *localParticipant;

/**
 *  @brief The region where media is being processed.
 *
 *  @discussion This property is set in a Group Room by the time the Room reaches
 *  \ref TVIRoomStateConnected. The property is not set for Peer-to-Peer Rooms, because they do not
 *  use a central media server for routing and/or recording.
 */
@property (nonatomic, copy, readonly, nullable) NSString *mediaRegion;

/**
 *  @brief The name of the Room.
 * 
 *  @discussion `name` will return the `sid` if the Room was created without a name.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *name;

/**
 *  @brief A collection of connected Remote Participants to `TVIRoom`.
 */
@property (nonatomic, copy, readonly, nonnull) NSArray<TVIRemoteParticipant *> *remoteParticipants;

/**
 *  @brief Indicates if the Room is being recorded.
 */
@property (nonatomic, assign, readonly, getter=isRecording) BOOL recording;

/**
 *  @brief The sid of the Room.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *sid;

/**
 *  @brief The Room's current state. Use `TVIRoomDelegate` to know about changes in `TVIRoomState`.
 */
@property (nonatomic, assign, readonly) TVIRoomState state;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion `TVIRoom` can not be created with init
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIRoom can not be created with init")));

/**
 *  @brief Utility method which gets a Remote Participant using its sid.
 *
 *  @param sid The sid.
 *
 *  @return An instance of `TVIRemoteParticipant` if successful, or `nil` if not.
 */
- (nullable TVIRemoteParticipant *)getRemoteParticipantWithSid:(nonnull NSString *)sid
NS_SWIFT_NAME(getRemoteParticipant(sid:));

/**
 *  @brief Disconnects from the Room.
 */
- (void)disconnect;

/**
 * @brief Retrieve stats for all media tracks.
 *
 * @param block The block to be invoked when the stats are available.
 *
 * @discussion Stats are retrieved asynchronously. In the case where the room is the `TVIRoomStateDisconnected` state,
 *             reports won't be delivered.
 */
- (void)getStatsWithBlock:(nonnull TVIRoomGetStatsBlock)block
NS_SWIFT_NAME(getStats(_:));

@end

/**
 *  CallKit specific additions.
 */
@interface TVIRoom (CallKit)

/**
 *  @brief The CallKit identifier for the Room.
 *
 *  @discussion Use this UUID as an argument to CallKit methods.
 */
@property (nonatomic, readonly, nullable) NSUUID *uuid;

@end

/**
 *  `TVIRoomDelegate` provides callbacks when important changes to a `TVIRoom` occur.
 */
NS_SWIFT_NAME(RoomDelegate)
@protocol TVIRoomDelegate <NSObject>

@optional
/**
 *  @brief This method is invoked when connecting to the Room succeeds.
 *
 *  @param room The Room for which connection succeeded.
 */
- (void)didConnectToRoom:(nonnull TVIRoom *)room
NS_SWIFT_NAME(roomDidConnect(room:));

/**
 *  @brief This method is invoked when connecting to the Room fails.
 *
 *  @param room The Room for which connection failed.
 *  @param error The error encountered during the connection attempt.
 */
- (void)room:(nonnull TVIRoom *)room didFailToConnectWithError:(nonnull NSError *)error
NS_SWIFT_NAME(roomDidFailToConnect(room:error:));

/**
 *  @brief This method is invoked when the Client disconnects from a Room.
 *
 *  @param room The Room from which the Client disconnected.
 *  @param error An NSError describing why disconnect occurred, or nil if the disconnect was initiated locally.
 */
- (void)room:(nonnull TVIRoom *)room didDisconnectWithError:(nullable NSError *)error
NS_SWIFT_NAME(roomDidDisconnect(room:error:));

/**
 *  @brief This method is invoked when the Client is attempting to reconnect to a Room due to a network disruption.
 *
 *  @param room The Room for which the Client is attempting to reconnect.
 *  @param error An NSError describing why the Client is reconnecting.
 *
 *  @discussion This method is invoked when the Client is attempting to reconnect to a Room due to a network disruption.
 *  The possible errors which could occur are `TVIErrorSignalingConnectionDisconnectedError` and
 *  `TVIErrorMediaConnectionError`. During a media reconnection signaling related methods may continue to be
 *  invoked.
 *
 *  There are certain instances when an application is put into the background that both the signaling and media
 *  connection are closed which will cause this delegate method to be invoked.
 *
 *    - When connected to a Peer-to-Peer Room with no Remote Participants.
 *    - When connected to a Peer-to-Peer Room with other Remote Participants and no shared audio tracks.
 *    - When connected to a Group Room with no shared audio tracks.
 *
 */
- (void)room:(nonnull TVIRoom *)room isReconnectingWithError:(nonnull NSError *)error
NS_SWIFT_NAME(roomIsReconnecting(room:error:));

/**
 *  @brief This method is invoked after the Client has reconnected to a Room following a network disruption.
 *
 *  @param room The Room which the Client has been reconnected.
 */
- (void)didReconnectToRoom:(nonnull TVIRoom *)room
NS_SWIFT_NAME(roomDidReconnect(room:));

/**
 *  @brief This method is invoked when a Remote Participant connects to the Room.
 *
 *  @param room The Room to which a Remote Participant connected.
 *  @param participant The Remote Participant who connected to the Room.
 */
- (void)room:(nonnull TVIRoom *)room participantDidConnect:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(participantDidConnect(room:participant:));

/**
 *  @brief This method is invoked when a Remote Participant disconnects from the Room.
 *
 *  @param room The Room from which a Remote Participant got disconnected.
 *  @param participant The Remote Participant who disconnected from the Room.
 */
- (void)room:(nonnull TVIRoom *)room participantDidDisconnect:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(participantDidDisconnect(room:participant:));

/**
 *  @brief This method is invoked when a Remote Participant is reconnecting to the Room after a signaling connection disruption.
 *
 *  @param room The Room to which a Remote Participant is reconnecting.
 *  @param participant The Remote Participant who is reconnecting to the Room.
 *
 *  @discussion It can take up to 15 seconds for our signaling backend to detect that a RemoteParticipant's connection has been
 *  disrupted due to a network degradation or handoff.
 */
- (void)room:(nonnull TVIRoom *)room participantIsReconnecting:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(participantIsReconnecting(room:participant:));

/**
 *  @brief This method is invoked when a Remote Participant has reconnected to the Room after a signaling connection disruption.
 *
 *  @param room The Room to which a Remote Participant has reconnected.
 *  @param participant The Remote Participant who has reconnected to the Room.
 */
- (void)room:(nonnull TVIRoom *)room participantDidReconnect:(nonnull TVIRemoteParticipant *)participant
NS_SWIFT_NAME(participantDidReconnect(room:participant:));

/**
 *  @brief This method is invoked when recording of media being shared to a Room has started.
 *
 *  @param room The Room for which recording has been started.
 *
 *  @discussion This method is only called when a Room which was not previously recording starts recording. If you've
 *  joined a Room which is already recording this event will not be fired.
 */
- (void)roomDidStartRecording:(nonnull TVIRoom *)room
NS_SWIFT_NAME(roomDidStartRecording(room:));

/**
 *  @brief This method is invoked when the recording of media shared to a Room has stopped.
 *
 *  @param room The Room for which recording has been stopped.
 *
 *  @discussion This method is only called when a Room which was previously recording stops recording. If you've joined
 *  a Room which is not recording this event will not be fired.
 */
- (void)roomDidStopRecording:(nonnull TVIRoom *)room
NS_SWIFT_NAME(roomDidStopRecording(room:));

/**
 *  @brief This method is invoked when the dominant speaker in the Room changes.
 *
 *  @param room The Room in which the dominant speaker changed.
 *  @param participant The Remote Participant who is now the dominant speaker. If there is currently no dominant
 *  speaker, `nil` will be sent.
 *
 *  @discussion This method is invoked  when the dominant speaker in the Room changes. Either there is a new dominant
 *  speaker, in which case the Room's dominantSpeaker property equals the RemoteParticipant included in the event;
 *  or, there is no longer a dominant speaker, in which case the Room's dominantSpeaker property equals `nil`.
 */
- (void)room:(nonnull TVIRoom *)room dominantSpeakerDidChange:(nullable TVIRemoteParticipant *)participant
NS_SWIFT_NAME(dominantSpeakerDidChange(room:participant:));

@end
