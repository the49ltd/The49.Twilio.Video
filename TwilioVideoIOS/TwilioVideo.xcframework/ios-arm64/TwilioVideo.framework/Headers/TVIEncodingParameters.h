//
//  TVIEncodingParameters.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 * `TVIEncodingParameters` defines audio and video encoding parameters.
 *
 * Maximum bitrate is specified as Transport Independent Application Specific
 * Maximum (TIAS) bitrate [RFC3890](https://tools.ietf.org/html/rfc3890) in Kilobits per second (Kbps) excluding
 * IP/UDP/TCP headers. These encoding parameters are applied for each PeerConnection. For peer-to-peer
 * Rooms, there is a separate PeerConnection for each participant, i.e., if you set the maximum video bitrate to 1,000 Kbps
 * and you have two `TVIRemoteParticipant`s in the Room, the SDK sends up to 2,000 Kbps. For group Rooms, there is a single
 * PeerConnection to Twilio's Media Server.
 *
 * If you are publishing multiple video tracks (e.g., video and screen
 * share), each track receives up to the maximum bitrate specified, i.e., if you set the maximum video bitrate to 1,000 Kbps and you
 * publish both video and screen Tracks, the SDK sends at most 2,000 Kbps. You may update encoding parameters any time using
 * `[TVILocalParticipant setEncodingParameters:]`.
 */
NS_SWIFT_NAME(EncodingParameters)
@interface TVIEncodingParameters : NSObject

/**
 *  @brief Initializes a `TVIEncodingParameters` object.
 *
 *  @param maxAudioBitrate The maximum audio send bitrate in Kilobits per second (Kbps).
 *  @param maxVideoBitrate The maximum video send bitrate in Kilobits per second (Kbps).
 *
 *  @return A `TVIEncodingParameters` instance.
 *
 *  @discussion Audio and video encoding parameters. Maximum bitrate is specified as Transport Independent Application Specific
 *  Maximum (TIAS) bitrate <a href="https://tools.ietf.org/html/rfc3890">RFC3890</a> in kilobits per second (kbps) excluding
 *  IP/UDP/TCP headers. Maximum bitrate applies to variable bitrate codecs and is limited to 100 Mbps.
 *
 *  **Note:** These encoding parameters are applied for each peer connection, each track and each simulcast layer.
 *
 *  For group Rooms, there is a single peer connection to Twilio Media Server, but for peer-to-peer Rooms, there is
 *  a separate peer connection for each participant. I.e., if you set maximum video bitrate to 1 Mbps and you have two
 *  `TVIRemoteParticipant` in the Room, the effective video send bitrate may be up to 2 Mbps.
 *
 *  If you are publishing multiple video tracks (e.g. camera and screen share), each track
 *  receives the maximum bitrate specified. I.e. if you set maximum video bitrate to 1 Mbps and you publish both
 *  a camera and a screen share track, the effective video send bitrate may be up to 2 Mbps.
 *
 *  If simulcast is used for video tracks, each simulcast layer receives the maximum bitrate specified.
 *  i.e. if your set the maximum bitrate to 1 Mbps and you publish a simulcast video track, the effective
 *  video send bitrate may be up to 3 Mbps if there are three simulcast layers.
 *
 *  The codec used also affects the bitrate. Each codec type has a minimum and maximum bitrate, and the
 *  bitrate used for a track will always be between those values, even if a higher or lower bitrate is specified here.
 *
 *  Encoding parameters can be updated any time, using `TVILocalParticipant::setEncodingParameters`
 *
 *  Please note that values reported by statistics API will be higher due to packetization overhead etc.
 */
- (_Nonnull instancetype)initWithAudioBitrate:(NSUInteger)maxAudioBitrate
                                 videoBitrate:(NSUInteger)maxVideoBitrate;

/** 
 *  @brief Maximum audio send bitrate in Kilobits per second.
 *
 *  @discussion Zero indicates the WebRTC default value, which is codec dependent.
 *  The maximum bitrate for [Opus](http://opus-codec.org/) is 510 Kbps.
 */
@property (nonatomic, assign, readonly) NSUInteger maxAudioBitrate;

/** 
 *  @brief Maximum video send bitrate in Kilobits per second.
 *
 *  @discussion Zero indicates the WebRTC default value, which is 2000 Kbps.
 *  The bitrate limit is applied individually to each video track and, if simulcast is used, to each simulcast layer.
 */
@property (nonatomic, assign, readonly) NSUInteger maxVideoBitrate;

@end
