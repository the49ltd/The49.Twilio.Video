//
//  TVIRemoteDataTrack.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import "TVIDataTrack.h"

@protocol TVIRemoteDataTrackDelegate;

/**
 * `TVIRemoteDataTrack` represents a remote data track.
 */
NS_SWIFT_NAME(RemoteDataTrack)
@interface TVIRemoteDataTrack : TVIDataTrack

/**
 *  @brief The `TVIRemoteDataTrackDelegate`. Set this property to receive messages sent on the DataTrack.
 */
@property (atomic, weak, nullable) id<TVIRemoteDataTrackDelegate> delegate;

/**
 *  @brief The sid of the remote data track.
 */
@property (nonatomic, copy, readonly, nonnull) NSString *sid;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Tracks cannot be created explicitly.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Tracks cannot be created explicitly.")));

@end

/**
 *  `TVIRemoteDataTrackDelegate` provides callbacks when data is received on a remote data track.
 */
NS_SWIFT_NAME(RemoteDataTrackDelegate)
@protocol TVIRemoteDataTrackDelegate <NSObject>

@optional

/**
 * @brief Delegate method called when data is received in string format.
 *
 * @param remoteDataTrack The remote data track.
 * @param message The message.
 */
- (void)remoteDataTrack:(nonnull TVIRemoteDataTrack *)remoteDataTrack didReceiveString:(nonnull NSString *)message
NS_SWIFT_NAME(remoteDataTrackDidReceiveString(remoteDataTrack:message:));

/**
 * @brief A delegate method which is called when opaque data is received.
 *
 * @discussion It's up to your application to define a wire format for the data which Participants send and receive.
 * For example you could use [Universal Binary JSON](https://en.wikipedia.org/wiki/UBJSON) for higher efficiency than
 * just exchanging JSON encoded strings.
 *
 * @param remoteDataTrack The remote data track.
 * @param message The message.
 */
- (void)remoteDataTrack:(nonnull TVIRemoteDataTrack *)remoteDataTrack didReceiveData:(nonnull NSData *)message
NS_SWIFT_NAME(remoteDataTrackDidReceiveData(remoteDataTrack:message:));

@end
