using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;
using CoreVideo;
using TVIAudioDeviceContext = Foundation.NSObject;

namespace Twilio
{
	[Native]
	public enum TVIScreenContent : ulong
	{
		Default = 0,
		Video
	}

	public enum TVIPixelFormat : uint
	{
		TVIPixelFormat32ARGB = CVPixelFormatType.CV32ARGB,
		TVIPixelFormat32BGRA = CVPixelFormatType.CV32BGRA,
		YUV420BiPlanarVideoRange = CVPixelFormatType.CV420YpCbCr8BiPlanarVideoRange,
		YUV420BiPlanarFullRange = CVPixelFormatType.CV420YpCbCr8BiPlanarFullRange,
		YUV420PlanarVideoRange = CVPixelFormatType.CV420YpCbCr8Planar,
		YUV420PlanarFullRange = CVPixelFormatType.CV420YpCbCr8PlanarFullRange
	}

	[Native]
	public enum TVIVideoOrientation : ulong
	{
		Up = 0,
		Left,
		Down,
		Right
	}

	[Native]
	public enum TVIAppScreenSourceError : long
	{
		Capturing,
		Stopped
	}

	[Native]
	public enum TVITrackState : ulong
	{
		Ended = 0,
		Live
	}

	[Native]
	public enum TVICameraSourceError : ulong
	{
		None = 0,
		AlreadyRunning,
		CameraPermissionDenied
	}

	[Native]
	public enum TVICameraSourceOptionsRotationTags : ulong
	{
		Keep = 0,
		Remove
	}

	[Native]
	public enum TVILocalNetworkPrivacyPolicy : ulong
	{
		AllowAll = 0,
		BlockLocal = 1
	}

	[Native]
	public enum TVIError : long
	{
		Unknown = 0,
		AccessTokenInvalidError = 20101,
		AccessTokenHeaderInvalidError = 20102,
		AccessTokenIssuerInvalidError = 20103,
		AccessTokenExpiredError = 20104,
		AccessTokenNotYetValidError = 20105,
		AccessTokenGrantsInvalidError = 20106,
		AccessTokenSignatureInvalidError = 20107,
		SignalingConnectionError = 53000,
		SignalingConnectionDisconnectedError = 53001,
		SignalingConnectionTimeoutError = 53002,
		SignalingIncomingMessageInvalidError = 53003,
		SignalingOutgoingMessageInvalidError = 53004,
		SignalingDnsResolutionError = 53005,
		SignalingServerBusyError = 53006,
		RoomNameInvalidError = 53100,
		RoomNameTooLongError = 53101,
		RoomNameCharsInvalidError = 53102,
		RoomCreateFailedError = 53103,
		RoomConnectFailedError = 53104,
		RoomMaxParticipantsExceededError = 53105,
		RoomNotFoundError = 53106,
		RoomMaxParticipantsOutOfRangeError = 53107,
		RoomTypeInvalidError = 53108,
		RoomTimeoutOutOfRangeError = 53109,
		RoomStatusCallbackMethodInvalidError = 53110,
		RoomStatusCallbackInvalidError = 53111,
		RoomStatusInvalidError = 53112,
		RoomRoomExistsError = 53113,
		RoomInvalidParametersError = 53114,
		RoomMediaRegionInvalidError = 53115,
		RoomMediaRegionUnavailableError = 53116,
		RoomSubscriptionOperationNotSupportedError = 53117,
		RoomRoomCompletedError = 53118,
		RoomAccountLimitExceededError = 53119,
		RoomInvalidRecordingRuleError = 53120,
		RoomRecordingOperationNotSupportedError = 53122,
		RoomAudioOnlyFlagNotSupportedError = 53124,
		RoomTrackKindNotSupportedError = 53125,
		ParticipantIdentityInvalidError = 53200,
		ParticipantIdentityTooLongError = 53201,
		ParticipantIdentityCharsInvalidError = 53202,
		ParticipantMaxTracksExceededError = 53203,
		ParticipantNotFoundError = 53204,
		ParticipantDuplicateIdentityError = 53205,
		ParticipantAccountLimitExceededError = 53206,
		ParticipantMaxPublishedTracksOutOfRangeError = 53207,
		ParticipantInvalidSubscribeRuleError = 53215,
		ParticipantSessionLengthExceededError = 53216,
		TrackInvalidError = 53300,
		TrackNameInvalidError = 53301,
		TrackNameTooLongError = 53302,
		TrackNameCharsInvalidError = 53303,
		TrackNameIsDuplicatedError = 53304,
		TrackServerTrackCapacityReachedError = 53305,
		TrackDataTrackMessageTooLargeError = 53306,
		TrackDataTrackSendBufferFullError = 53307,
		MediaClientLocalDescFailedError = 53400,
		MediaServerLocalDescFailedError = 53401,
		MediaClientRemoteDescFailedError = 53402,
		MediaServerRemoteDescFailedError = 53403,
		MediaNoSupportedCodecError = 53404,
		MediaConnectionError = 53405,
		MediaDataTrackFailedError = 53406,
		MediaDtlsTransportFailedError = 53407,
		MediaIceRestartNotAllowedError = 53408,
		ConfigurationAcquireFailedError = 53500,
		ConfigurationAcquireTurnFailedError = 53501
	}

	[Native]
	public enum TVIIceCandidatePairState : ulong
	{
		Succeeded,
		Frozen,
		Waiting,
		InProgress,
		Failed,
		Cancelled,
		Unknown
	}

	[Native]
	public enum TVIIceTransportPolicy : ulong
	{
		All = 0,
		Relay = 1
	}

	public enum TVIIsacCodecSampleRate : ushort
	{
		Wideband = 16000,
		SuperWideband = 32000
	}

	[Native]
	public enum TVINetworkQualityLevel : long
	{
		Unknown = -1,
		Zero = 0,
		One,
		Two,
		Three,
		Four,
		Five
	}

	[Native]
	public enum TVIParticipantState : ulong
	{
		Connected = 0,
		Reconnecting,
		Disconnected
	}

	[Native]
	public enum TVINetworkQualityVerbosity : ulong
	{
		None = 0,
		Minimal
	}

	[Native]
	public enum TVIRoomState : ulong
	{
		Connecting = 0,
		Connected,
		Disconnected,
		Reconnecting
	}

	[Native]
	public enum TVILogLevel : ulong
	{
		Off = 0,
		Fatal,
		Error,
		Warning,
		Info,
		Debug,
		Trace,
		All
	}

	[Native]
	public enum TVILogModule : ulong
	{
		Core = 0,
		Platform,
		Signaling,
		WebRTC
	}
}
