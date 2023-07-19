//
//  TwilioVideo.h
//  TwilioVideo
//
//  Copyright © 2016-2017 Twilio, Inc. All rights reserved.
//

#import <UIKit/UIKit.h>

#import "TVIAppScreenSource.h"
#import "TVIAppScreenSourceOptions.h"
#import "TVIAudioCodec.h"
#import "TVIAudioDevice.h"
#import "TVIAudioFormat.h"
#import "TVIAudioOptions.h"
#import "TVIAudioSink.h"
#import "TVIAudioTrack.h"
#import "TVIAudioTrackPublication.h"
#import "TVIBandwidthProfileOptions.h"
#import "TVIBaseTrackStats.h"
#import "TVICameraPreviewView.h"
#import "TVICameraSourceOrientationTracker.h"
#import "TVICameraSource.h"
#import "TVICameraSourceOptions.h"
#import "TVIConnectOptions.h"
#import "TVIDataTrack.h"
#import "TVIDataTrackOptions.h"
#import "TVIDataTrackPublication.h"
#import "TVIDefaultAudioDevice.h"
#import "TVIEncodingParameters.h"
#import "TVIError.h"
#import "TVIG722Codec.h"
#import "TVIH264Codec.h"
#import "TVIIceCandidatePairStats.h"
#import "TVIIceCandidateStats.h"
#import "TVIIceOptions.h"
#import "TVIIsacCodec.h"
#import "TVILocalAudioTrack.h"
#import "TVILocalAudioTrackPublication.h"
#import "TVILocalAudioTrackStats.h"
#import "TVILocalDataTrack.h"
#import "TVILocalDataTrackPublication.h"
#import "TVILocalNetworkPrivacyPolicy.h"
#import "TVILocalParticipant.h"
#import "TVILocalTrackPublicationOptions.h"
#import "TVILocalTrackStats.h"
#import "TVILocalVideoTrack.h"
#import "TVILocalVideoTrackPublication.h"
#import "TVILocalVideoTrackStats.h"
#import "TVINetworkQualityConfiguration.h"
#import "TVIOpusCodec.h"
#import "TVIParticipant.h"
#import "TVIPcmaCodec.h"
#import "TVIPcmuCodec.h"
#import "TVIRemoteAudioTrack.h"
#import "TVIRemoteAudioTrackPublication.h"
#import "TVIRemoteAudioTrackStats.h"
#import "TVIRemoteDataTrack.h"
#import "TVIRemoteDataTrackPublication.h"
#import "TVIRemoteParticipant.h"
#import "TVIRemoteTrackStats.h"
#import "TVIRemoteVideoTrack.h"
#import "TVIRemoteVideoTrackPublication.h"
#import "TVIRemoteVideoTrackStats.h"
#import "TVIRoom.h"
#import "TVISampleBufferVideoView.h"
#import "TVIScreenContent.h"
#import "TVIStatsReport.h"
#import "TVITrack.h"
#import "TVITrackPriority.h"
#import "TVITrackPublication.h"
#import "TVIVideoBandwidthProfileOptions.h"
#import "TVIVideoCodec.h"
#import "TVIVideoContentPreferences.h"
#import "TVIVideoDimensions.h"
#import "TVIVideoEncodingMode.h"
#import "TVIVideoFormat.h"
#import "TVIVideoFrame.h"
#import "TVIVideoRenderer.h"
#import "TVIVideoSource.h"
#import "TVIVideoTrack.h"
#import "TVIVideoTrackPublication.h"
#import "TVIVideoView.h"
#import "TVIVp8Codec.h"
#import "TVIVp9Codec.h"

/**
 *  Different logging levels.
 */
typedef NS_ENUM(NSUInteger, TVILogLevel) {
    /**
     *  Turn off logging.
     */
    TVILogLevelOff = 0,
    /**
     *  Log very severe error events that will presumably lead the application to abort.
     */
    TVILogLevelFatal,
    /**
     *  Log error events that might still allow the application to continue running.
     */
    TVILogLevelError,
    /**
     *  Log warning events that may indicate potentially harmful situations.
     */
    TVILogLevelWarning,
    /**
     *  Log the progress of the application at coarse-grained level.
     */
    TVILogLevelInfo,
    /**
     *  Log fine-grained informational events that are most useful to debug an application.
     */
    TVILogLevelDebug,
    /**
     *  Log finer-grained informational events than the debug.
     */
    TVILogLevelTrace,
    /**
     *  Turn on all logging.
     */
    TVILogLevelAll
}
NS_SWIFT_NAME(TwilioVideoSDK.LogLevel);

/**
 *  Different logging modules.
 */
typedef NS_ENUM(NSUInteger, TVILogModule) {
    /**
     *  Video Core SDK.
     */
    TVILogModuleCore = 0,
    /**
     *  Video iOS SDK.
     */
    TVILogModulePlatform,
    /**
     *  Signaling Module.
     */
    TVILogModuleSignaling,
    /**
     *  Webrtc Module.
     */
    TVILogModuleWebRTC
}
NS_SWIFT_NAME(TwilioVideoSDK.LogModule);

/**
 *  `TwilioVideoSDK` is the root class of the Twilio Video SDK. You can connect to a Room using class methods on this class.
 */
@interface TwilioVideoSDK : NSObject

/**
 *  @brief The `TVIAudioDevice` used to record and playback audio in a Room.
 *
 *  @discussion If you wish to provide your own `TVIAudioDevice` then you must set it before performing any other
 *  actions with the SDK (like creating Tracks or connecting to Rooms). It is also possible to change the device when
 *  you are no longer connected to any Rooms and have destroyed all other SDK objects (Tracks, Participants, and Rooms).
 *
 *  @see [TVIAudioDevice](TVIAudioDevice.h)
 */
@property (class, nonatomic, strong, nonnull) id<TVIAudioDevice> audioDevice;

/**
 *  @brief Developers shouldn't initialize this class directly.
 *
 *  @discussion Use `TwilioVideo` class factory methods to create a `TVIRoom`.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("Use TwilioVideoSDK class factory methods to create a TVIRoom.")));

/**
 *  @brief Connect to a Room with options and a delegate.
 *
 *  @param options  The connect options.
 *  @param delegate A delegate conforming to `TVIRoomDelegate` for handling Room related events.
 *
 *  @return An instance of `TVIRoom`.
 */
+ (nonnull TVIRoom *)connectWithOptions:(nonnull TVIConnectOptions *)options
                               delegate:(nullable id<TVIRoomDelegate>)delegate
NS_SWIFT_NAME(connect(options:delegate:));

/**
 *  @brief Returns the SDK version.
 *
 *  @return Video sdk version of type string.
 */
+ (nonnull NSString *)sdkVersion;

/**
 *  @brief Retrieve the log level for the Twilio Video SDK. The default log level is `TVILogLevelError`.
 *
 *  @return The current log level.
 */
+ (TVILogLevel)logLevel;

/**
 *  @brief Set the log level for the Twilio Video SDK.
 *
 *  @param logLevel The `TVILogLevel` in use by the system.
 */
+ (void)setLogLevel:(TVILogLevel)logLevel;

/**
 *  @brief Retrieve the log level for a specific module in the Twilio Video SDK.
 * 
 *  @param module The `TVILogModule` for which the log level needs to be set.
 *
 *  @return The current log level for the specified module.
 */
+ (TVILogLevel)logLevelForModule:(TVILogModule)module;

/**
 *  @brief Set the log level for a specific module in the Twilio Video SDK.
 *
 *  @param logLevel The `TVILogLevel` to be used by the module.
 *  @param module   The `TVILogModule` for which the log level needs to be set.
 */
+ (void)setLogLevel:(TVILogLevel)logLevel module:(TVILogModule)module;

@end
