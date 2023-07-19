//
//  TVIVideoEncodingMode.h
//  TwilioVideo
//
//  Copyright © 2021 Twilio, Inc. All rights reserved.
//

/**
 *  VideoEncodingMode describes how publishers manage video codecs and video encodings.
 */
API_AVAILABLE(ios(11.0))
typedef NSString * TVIVideoEncodingMode NS_STRING_ENUM
NS_SWIFT_NAME(VideoEncodingMode);

/**
 * Twilio's SDKs and Servers select video codecs and manage video encodings automatically.
 *
 * - The publisher prefers scalable video codecs in Group Rooms, and disables scalability features that are not needed in
 * Peer-to-Peer and Go Rooms.
 *
 * - In Group Rooms, the publisher reduces resource usage by only sending the encodings
 * that are needed by subscribers or by the media server (when recording is enabled).
 *
 * - If there are no subscribers, and recording is disabled then all track encodings are suspended.
 */
API_AVAILABLE(ios(11.0))
FOUNDATION_EXPORT _Nonnull TVIVideoEncodingMode const TVIVideoEncodingModeAuto;
