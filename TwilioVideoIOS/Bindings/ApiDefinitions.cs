using System;
using AVFoundation;
using AudioToolbox;
using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using TwilioVideo;
using UIKit;

namespace Twilio
{
	// @interface TVIAppScreenSourceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIAppScreenSourceOptionsBuilder
	{
		// @property (nonatomic) TVIScreenContent screenContent;
		[Export ("screenContent", ArgumentSemantic.Assign)]
		TVIScreenContent ScreenContent { get; set; }
	}

	// typedef void (^TVIAppScreenSourceOptionsBuilderBlock)(TVIAppScreenSourceOptionsBuilder * _Nonnull);
	delegate void TVIAppScreenSourceOptionsBuilderBlock (TVIAppScreenSourceOptionsBuilder arg0);

	// @interface TVIAppScreenSourceOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIAppScreenSourceOptions
	{
		// @property (readonly, nonatomic) TVIScreenContent screenContent;
		[Export ("screenContent")]
		TVIScreenContent ScreenContent { get; }

		// +(instancetype _Nonnull)options;
		[Static]
		[Export ("options")]
		TVIAppScreenSourceOptions Options ();

		// +(instancetype _Nonnull)optionsWithBlock:(TVIAppScreenSourceOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIAppScreenSourceOptions OptionsWithBlock (TVIAppScreenSourceOptionsBuilderBlock block);
	}

	// @interface TVIVideoFormat : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIVideoFormat
	{
		// @property (assign, nonatomic) CMVideoDimensions dimensions;
		[Export ("dimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions Dimensions { get; set; }

		// @property (assign, nonatomic) NSUInteger frameRate;
		[Export ("frameRate")]
		nuint FrameRate { get; set; }

		// @property (assign, nonatomic) TVIPixelFormat pixelFormat;
		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		TVIPixelFormat PixelFormat { get; set; }
	}

	// @interface TVIVideoFrame : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoFrame
	{
		// -(instancetype _Nullable)initWithTimestamp:(CMTime)timestamp buffer:(CVImageBufferRef _Nonnull)imageBuffer orientation:(TVIVideoOrientation)orientation __attribute__((objc_designated_initializer));
		[Export ("initWithTimestamp:buffer:orientation:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CMTime timestamp, CVImageBuffer imageBuffer, TVIVideoOrientation orientation);

		// -(instancetype _Nullable)initWithTimeInterval:(CFTimeInterval)timeInterval buffer:(CVImageBufferRef _Nonnull)imageBuffer orientation:(TVIVideoOrientation)orientation;
		[Export ("initWithTimeInterval:buffer:orientation:")]
		NativeHandle Constructor (double timeInterval, CVImageBuffer imageBuffer, TVIVideoOrientation orientation);

		// @property (readonly, assign, nonatomic) CMTime timestamp;
		[Export ("timestamp", ArgumentSemantic.Assign)]
		CMTime Timestamp { get; }

		// @property (readonly, assign, nonatomic) size_t width;
		[Export ("width")]
		nuint Width { get; }

		// @property (readonly, assign, nonatomic) size_t height;
		[Export ("height")]
		nuint Height { get; }

		// @property (readonly, assign, nonatomic) CVImageBufferRef _Nonnull imageBuffer;
		[Export ("imageBuffer", ArgumentSemantic.Assign)]
		CVImageBuffer ImageBuffer { get; }

		// @property (readonly, assign, nonatomic) TVIVideoOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		TVIVideoOrientation Orientation { get; }
	}

	// @protocol TVIVideoSink <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface TVIVideoSink
	{
		// @required @property (readonly, copy, nonatomic) TVIVideoFormat * _Nullable sourceRequirements;
		[Abstract]
		[NullAllowed, Export ("sourceRequirements", ArgumentSemantic.Copy)]
		TVIVideoFormat SourceRequirements { get; }

		// @required -(void)onVideoFrame:(TVIVideoFrame * _Nonnull)frame;
		[Abstract]
		[Export ("onVideoFrame:")]
		void OnVideoFrame (TVIVideoFrame frame);

		// @required -(void)onVideoFormatRequest:(TVIVideoFormat * _Nullable)format;
		[Abstract]
		[Export ("onVideoFormatRequest:")]
		void OnVideoFormatRequest ([NullAllowed] TVIVideoFormat format);
	}

	// @protocol TVIVideoSource <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface TVIVideoSource
	{
		// @required @property (nonatomic, weak) id<TVIVideoSink> _Nullable sink;
		[Abstract]
		[NullAllowed, Export ("sink", ArgumentSemantic.Weak)]
		TVIVideoSink Sink { get; set; }

		// @required @property (readonly, getter = isScreencast, assign, nonatomic) BOOL screencast;
		[Abstract]
		[Export ("screencast")]
		bool Screencast { [Bind ("isScreencast")] get; }

		// @required -(void)requestOutputFormat:(TVIVideoFormat * _Nonnull)outputFormat;
		[Abstract]
		[Export ("requestOutputFormat:")]
		void RequestOutputFormat (TVIVideoFormat outputFormat);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NS_SWIFT_NAME(AppScreenSource.ErrorDomain) NSErrorDomain kTVIAppScreenSourceErrorDomain __attribute__((swift_name("AppScreenSource.ErrorDomain")));
		[Field ("kTVIAppScreenSourceErrorDomain", "__Internal")]
		NSString kTVIAppScreenSourceErrorDomain { get; }
	}

	// typedef void (^TVIAppScreenSourceStartedBlock)(NSError * _Nullable);
	delegate void TVIAppScreenSourceStartedBlock ([NullAllowed] NSError arg0);

	// typedef void (^TVIAppScreenSourceStoppedBlock)(NSError * _Nullable);
	delegate void TVIAppScreenSourceStoppedBlock ([NullAllowed] NSError arg0);

	// @interface TVIAppScreenSource : NSObject <TVIVideoSource>
	[BaseType (typeof(NSObject))]
	interface TVIAppScreenSource : ITVIVideoSource
	{
		// -(instancetype _Nullable)initWithDelegate:(id<TVIAppScreenSourceDelegate> _Nullable)delegate;
		[Export ("initWithDelegate:")]
		NativeHandle Constructor ([NullAllowed] TVIAppScreenSourceDelegate @delegate);

		// -(instancetype _Nullable)initWithOptions:(TVIAppScreenSourceOptions * _Nonnull)options delegate:(id<TVIAppScreenSourceDelegate> _Nullable)delegate;
		[Export ("initWithOptions:delegate:")]
		NativeHandle Constructor (TVIAppScreenSourceOptions options, [NullAllowed] TVIAppScreenSourceDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIAppScreenSourceDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVIAppScreenSourceDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) BOOL isAvailable;
		[Export ("isAvailable")]
		bool IsAvailable { get; }

		// @property (readonly, nonatomic) BOOL isCapturing;
		[Export ("isCapturing")]
		bool IsCapturing { get; }

		// -(void)startCapture;
		[Export ("startCapture")]
		void StartCapture ();

		// -(void)startCaptureWithCompletion:(TVIAppScreenSourceStartedBlock _Nullable)completion;
		[Export ("startCaptureWithCompletion:")]
		void StartCaptureWithCompletion ([NullAllowed] TVIAppScreenSourceStartedBlock completion);

		// -(void)stopCapture;
		[Export ("stopCapture")]
		void StopCapture ();

		// -(void)stopCaptureWithCompletion:(TVIAppScreenSourceStoppedBlock _Nullable)completion;
		[Export ("stopCaptureWithCompletion:")]
		void StopCaptureWithCompletion ([NullAllowed] TVIAppScreenSourceStoppedBlock completion);
	}

	// @protocol TVIAppScreenSourceDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVIAppScreenSourceDelegate
	{
		// @optional -(void)appScreenSourceDidBecomeAvailable:(TVIAppScreenSource * _Nonnull)source;
		[Export ("appScreenSourceDidBecomeAvailable:")]
		void AppScreenSourceDidBecomeAvailable (TVIAppScreenSource source);

		// @optional -(void)appScreenSourceDidBecomeUnavailable:(TVIAppScreenSource * _Nonnull)source;
		[Export ("appScreenSourceDidBecomeUnavailable:")]
		void AppScreenSourceDidBecomeUnavailable (TVIAppScreenSource source);

		// @optional -(void)appScreenSource:(TVIAppScreenSource * _Nonnull)source didReceiveCaptureError:(NSError * _Nonnull)error __attribute__((swift_name("appScreenSourceDidReceiveCaptureError(source:error:)")));
		[Export ("appScreenSource:didReceiveCaptureError:")]
		void AppScreenSource (TVIAppScreenSource source, NSError error);

		// @optional -(void)appScreenSource:(TVIAppScreenSource * _Nonnull)source didStopCapturingWithError:(NSError * _Nullable)error __attribute__((swift_name("appScreenSourceDidStopCapture(source:error:)")));
		[Export ("appScreenSource:didStopCapturingWithError:")]
		void AppScreenSource (TVIAppScreenSource source, [NullAllowed] NSError error);
	}

	// @interface TVIAudioCodec : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIAudioCodec
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const uint32_t TVIAudioSampleRate8000 __attribute__((swift_name("AudioFormat.SampleRate8000")));
		[Field ("TVIAudioSampleRate8000", "__Internal")]
		uint TVIAudioSampleRate8000 { get; }

		// extern const uint32_t TVIAudioSampleRate16000 __attribute__((swift_name("AudioFormat.SampleRate16000")));
		[Field ("TVIAudioSampleRate16000", "__Internal")]
		uint TVIAudioSampleRate16000 { get; }

		// extern const uint32_t TVIAudioSampleRate24000 __attribute__((swift_name("AudioFormat.SampleRate24000")));
		[Field ("TVIAudioSampleRate24000", "__Internal")]
		uint TVIAudioSampleRate24000 { get; }

		// extern const uint32_t TVIAudioSampleRate32000 __attribute__((swift_name("AudioFormat.SampleRate32000")));
		[Field ("TVIAudioSampleRate32000", "__Internal")]
		uint TVIAudioSampleRate32000 { get; }

		// extern const uint32_t TVIAudioSampleRate44100 __attribute__((swift_name("AudioFormat.SampleRate44100")));
		[Field ("TVIAudioSampleRate44100", "__Internal")]
		uint TVIAudioSampleRate44100 { get; }

		// extern const uint32_t TVIAudioSampleRate48000 __attribute__((swift_name("AudioFormat.SampleRate48000")));
		[Field ("TVIAudioSampleRate48000", "__Internal")]
		uint TVIAudioSampleRate48000 { get; }

		// extern const size_t TVIAudioChannelsMono __attribute__((swift_name("AudioFormat.ChannelsMono")));
		[Field ("TVIAudioChannelsMono", "__Internal")]
		nuint TVIAudioChannelsMono { get; }

		// extern const size_t TVIAudioChannelsStereo __attribute__((swift_name("AudioFormat.ChannelsStereo")));
		[Field ("TVIAudioChannelsStereo", "__Internal")]
		nuint TVIAudioChannelsStereo { get; }
	}

	// @interface TVIAudioFormat : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIAudioFormat
	{
		// @property (readonly, assign, nonatomic) size_t numberOfChannels;
		[Export ("numberOfChannels")]
		nuint NumberOfChannels { get; }

		// @property (readonly, assign, nonatomic) uint32_t sampleRate;
		[Export ("sampleRate")]
		uint SampleRate { get; }

		// @property (readonly, assign, nonatomic) size_t framesPerBuffer;
		[Export ("framesPerBuffer")]
		nuint FramesPerBuffer { get; }

		// -(instancetype _Nullable)initWithChannels:(size_t)channels sampleRate:(uint32_t)sampleRate framesPerBuffer:(size_t)framesPerBuffer;
		[Export ("initWithChannels:sampleRate:framesPerBuffer:")]
		NativeHandle Constructor (nuint channels, uint sampleRate, nuint framesPerBuffer);

		// -(size_t)bufferSize;
		[Export ("bufferSize")]
		[Verify (MethodToProperty)]
		nuint BufferSize { get; }

		// -(AudioStreamBasicDescription)streamDescription;
		[Export ("streamDescription")]
		[Verify (MethodToProperty)]
		AudioStreamBasicDescription StreamDescription { get; }
	}

	// typedef void (^TVIAudioDeviceWorkerBlock)();
	delegate void TVIAudioDeviceWorkerBlock ();

	// @protocol TVIAudioDeviceRenderer <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface TVIAudioDeviceRenderer
	{
		// @required -(TVIAudioFormat * _Nullable)renderFormat;
		[Abstract]
		[NullAllowed, Export ("renderFormat")]
		[Verify (MethodToProperty)]
		TVIAudioFormat RenderFormat { get; }

		// @required -(BOOL)initializeRenderer;
		[Abstract]
		[Export ("initializeRenderer")]
		[Verify (MethodToProperty)]
		bool InitializeRenderer { get; }

		// @required -(BOOL)startRendering:(TVIAudioDeviceContext _Nonnull)context __attribute__((swift_name("startRendering(context:)")));
		[Abstract]
		[Export ("startRendering:")]
		unsafe bool StartRendering (void* context);

		// @required -(BOOL)stopRendering;
		[Abstract]
		[Export ("stopRendering")]
		[Verify (MethodToProperty)]
		bool StopRendering { get; }
	}

	// @protocol TVIAudioDeviceCapturer <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface TVIAudioDeviceCapturer
	{
		// @required -(TVIAudioFormat * _Nullable)captureFormat;
		[Abstract]
		[NullAllowed, Export ("captureFormat")]
		[Verify (MethodToProperty)]
		TVIAudioFormat CaptureFormat { get; }

		// @required -(BOOL)initializeCapturer;
		[Abstract]
		[Export ("initializeCapturer")]
		[Verify (MethodToProperty)]
		bool InitializeCapturer { get; }

		// @required -(BOOL)startCapturing:(TVIAudioDeviceContext _Nonnull)context __attribute__((swift_name("startCapturing(context:)")));
		[Abstract]
		[Export ("startCapturing:")]
		unsafe bool StartCapturing (void* context);

		// @required -(BOOL)stopCapturing;
		[Abstract]
		[Export ("stopCapturing")]
		[Verify (MethodToProperty)]
		bool StopCapturing { get; }
	}

	// @protocol TVIAudioDevice <TVIAudioDeviceRenderer, TVIAudioDeviceCapturer>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	interface TVIAudioDevice : ITVIAudioDeviceRenderer, ITVIAudioDeviceCapturer
	{
	}

	// @interface TVIAudioOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIAudioOptionsBuilder
	{
		// @property (assign, nonatomic) BOOL audioJitterBufferFastAccelerate;
		[Export ("audioJitterBufferFastAccelerate")]
		bool AudioJitterBufferFastAccelerate { get; set; }

		// @property (assign, nonatomic) int audioJitterBufferMaxPackets;
		[Export ("audioJitterBufferMaxPackets")]
		int AudioJitterBufferMaxPackets { get; set; }

		// @property (getter = isSoftwareAecEnabled, assign, nonatomic) BOOL softwareAecEnabled;
		[Export ("softwareAecEnabled")]
		bool SoftwareAecEnabled { [Bind ("isSoftwareAecEnabled")] get; set; }

		// @property (assign, nonatomic) BOOL highpassFilter;
		[Export ("highpassFilter")]
		bool HighpassFilter { get; set; }
	}

	// typedef void (^TVIAudioOptionsBuilderBlock)(TVIAudioOptionsBuilder * _Nonnull);
	delegate void TVIAudioOptionsBuilderBlock (TVIAudioOptionsBuilder arg0);

	// @interface TVIAudioOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIAudioOptions
	{
		// @property (readonly, assign, nonatomic) int audioJitterBufferMaxPackets;
		[Export ("audioJitterBufferMaxPackets")]
		int AudioJitterBufferMaxPackets { get; }

		// @property (readonly, assign, nonatomic) BOOL audioJitterBufferFastAccelerate;
		[Export ("audioJitterBufferFastAccelerate")]
		bool AudioJitterBufferFastAccelerate { get; }

		// @property (readonly, getter = isSoftwareAecEnabled, assign, nonatomic) BOOL softwareAecEnabled;
		[Export ("softwareAecEnabled")]
		bool SoftwareAecEnabled { [Bind ("isSoftwareAecEnabled")] get; }

		// @property (readonly, assign, nonatomic) BOOL highpassFilter;
		[Export ("highpassFilter")]
		bool HighpassFilter { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		TVIAudioOptions Options ();

		// +(instancetype _Null_unspecified)optionsWithBlock:(TVIAudioOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIAudioOptions OptionsWithBlock (TVIAudioOptionsBuilderBlock block);
	}

	// @protocol TVIAudioSink <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface TVIAudioSink
	{
		// @required -(void)renderSample:(CMSampleBufferRef)audioSample;
		[Abstract]
		[Export ("renderSample:")]
		void RenderSample (CMSampleBuffer audioSample);
	}

	// @interface TVITrack : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVITrack
	{
		// @property (readonly, getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, assign, nonatomic) TVITrackState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVITrackState State { get; }
	}

	// @interface TVIAudioTrack : TVITrack
	[BaseType (typeof(TVITrack))]
	[DisableDefaultCtor]
	interface TVIAudioTrack
	{
		// @property (readonly, nonatomic, strong) NSArray<id<TVIAudioSink>> * _Nonnull sinks;
		[Export ("sinks", ArgumentSemantic.Strong)]
		TVIAudioSink[] Sinks { get; }

		// -(void)addSink:(id<TVIAudioSink> _Nonnull)sink;
		[Export ("addSink:")]
		void AddSink (TVIAudioSink sink);

		// -(void)removeSink:(id<TVIAudioSink> _Nonnull)sink;
		[Export ("removeSink:")]
		void RemoveSink (TVIAudioSink sink);
	}

	// @interface TVITrackPublication : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVITrackPublication
	{
		// @property (readonly, nonatomic, strong) TVITrack * _Nullable track;
		[NullAllowed, Export ("track", ArgumentSemantic.Strong)]
		TVITrack Track { get; }

		// @property (readonly, getter = isTrackEnabled, assign, nonatomic) BOOL trackEnabled;
		[Export ("trackEnabled")]
		bool TrackEnabled { [Bind ("isTrackEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackName;
		[Export ("trackName")]
		string TrackName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackSid;
		[Export ("trackSid")]
		string TrackSid { get; }
	}

	// @interface TVIAudioTrackPublication : TVITrackPublication
	[BaseType (typeof(TVITrackPublication))]
	[DisableDefaultCtor]
	interface TVIAudioTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVIAudioTrack * _Nullable audioTrack;
		[NullAllowed, Export ("audioTrack", ArgumentSemantic.Strong)]
		TVIAudioTrack AudioTrack { get; }
	}

	// @interface TVIBandwidthProfileOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIBandwidthProfileOptions
	{
		// @property (readonly, nonatomic, strong) TVIVideoBandwidthProfileOptions * _Nonnull video;
		[Export ("video", ArgumentSemantic.Strong)]
		TVIVideoBandwidthProfileOptions Video { get; }

		// -(instancetype _Nonnull)initWithVideoOptions:(TVIVideoBandwidthProfileOptions * _Nonnull)video;
		[Export ("initWithVideoOptions:")]
		NativeHandle Constructor (TVIVideoBandwidthProfileOptions video);
	}

	// @interface TVIBaseTrackStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIBaseTrackStats
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackSid;
		[Export ("trackSid")]
		string TrackSid { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsLost;
		[Export ("packetsLost")]
		nuint PacketsLost { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull codec;
		[Export ("codec")]
		string Codec { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull ssrc;
		[Export ("ssrc")]
		string Ssrc { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }
	}

	// @interface TVICameraPreviewView : UIView
	[BaseType (typeof(UIView))]
	interface TVICameraPreviewView
	{
		// @property (readonly, assign, nonatomic) UIInterfaceOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		UIInterfaceOrientation Orientation { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoDimensions;
		[Export ("videoDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions VideoDimensions { get; }
	}

	// @protocol TVICameraSourceOrientationDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVICameraSourceOrientationDelegate
	{
		// @required -(void)trackerOrientationDidChange:(AVCaptureVideoOrientation)orientation __attribute__((swift_name("trackerOrientationDidChange(_:)")));
		[Abstract]
		[Export ("trackerOrientationDidChange:")]
		void TrackerOrientationDidChange (AVCaptureVideoOrientation orientation);
	}

	// @protocol TVICameraSourceOrientationTracker <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface TVICameraSourceOrientationTracker
	{
		[Wrap ("WeakDelegate"), Abstract]
		[NullAllowed]
		TVICameraSourceOrientationDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<TVICameraSourceOrientationDelegate> _Nullable delegate;
		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required @property (readonly, assign, nonatomic) AVCaptureVideoOrientation orientation;
		[Abstract]
		[Export ("orientation", ArgumentSemantic.Assign)]
		AVCaptureVideoOrientation Orientation { get; }
	}

	// @interface TVIUserInterfaceTracker : NSObject <TVICameraSourceOrientationTracker>
	[BaseType (typeof(NSObject))]
	interface TVIUserInterfaceTracker : ITVICameraSourceOrientationTracker
	{
		// @property (readonly, assign, nonatomic) AVCaptureVideoOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		AVCaptureVideoOrientation Orientation { get; }

		// @property (readonly, nonatomic, weak) API_AVAILABLE(ios(13.0)) UIWindowScene * scene __attribute__((availability(ios, introduced=13.0)));
		[iOS (13, 0)]
		[Export ("scene", ArgumentSemantic.Weak)]
		UIWindowScene Scene { get; }

		// +(instancetype _Nonnull)tracker;
		[Static]
		[Export ("tracker")]
		TVIUserInterfaceTracker Tracker ();

		// +(instancetype _Nonnull)trackerWithScene:(UIWindowScene * _Nonnull)scene __attribute__((availability(ios, introduced=13.0)));
		[iOS (13,0)]
		[Static]
		[Export ("trackerWithScene:")]
		TVIUserInterfaceTracker TrackerWithScene (UIWindowScene scene);

		// +(void)sceneInterfaceOrientationDidChange:(UIWindowScene * _Nonnull)scene __attribute__((availability(ios, introduced=13.0)));
		[iOS (13,0)]
		[Static]
		[Export ("sceneInterfaceOrientationDidChange:")]
		void SceneInterfaceOrientationDidChange (UIWindowScene scene);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NS_SWIFT_NAME(CameraSource.ErrorDomain) NSString *const kTVICameraSourceErrorDomain __attribute__((swift_name("CameraSource.ErrorDomain")));
		[Field ("kTVICameraSourceErrorDomain", "__Internal")]
		NSString kTVICameraSourceErrorDomain { get; }
	}

	// typedef void (^TVICameraSourceStartedBlock)(AVCaptureDevice * _Nonnull, TVIVideoFormat * _Nonnull, NSError * _Nullable);
	delegate void TVICameraSourceStartedBlock (AVCaptureDevice arg0, TVIVideoFormat arg1, [NullAllowed] NSError arg2);

	// typedef void (^TVICameraSourceStoppedBlock)(NSError * _Nullable);
	delegate void TVICameraSourceStoppedBlock ([NullAllowed] NSError arg0);

	// @interface TVICameraSource : NSObject <TVIVideoSource>
	[BaseType (typeof(NSObject))]
	interface TVICameraSource : ITVIVideoSource
	{
		// -(instancetype _Nullable)initWithDelegate:(id<TVICameraSourceDelegate> _Nullable)delegate;
		[Export ("initWithDelegate:")]
		NativeHandle Constructor ([NullAllowed] TVICameraSourceDelegate @delegate);

		// -(instancetype _Nullable)initWithOptions:(TVICameraSourceOptions * _Nonnull)options delegate:(id<TVICameraSourceDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:delegate:")]
		[DesignatedInitializer]
		NativeHandle Constructor (TVICameraSourceOptions options, [NullAllowed] TVICameraSourceDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVICameraSourceDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVICameraSourceDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) AVCaptureDevice * _Nullable device;
		[NullAllowed, Export ("device", ArgumentSemantic.Strong)]
		AVCaptureDevice Device { get; }

		// @property (readonly, nonatomic, strong) TVICameraPreviewView * _Nullable previewView;
		[NullAllowed, Export ("previewView", ArgumentSemantic.Strong)]
		TVICameraPreviewView PreviewView { get; }

		// -(void)startCaptureWithDevice:(AVCaptureDevice * _Nonnull)device __attribute__((swift_name("startCapture(device:)")));
		[Export ("startCaptureWithDevice:")]
		void StartCaptureWithDevice (AVCaptureDevice device);

		// -(void)startCaptureWithDevice:(AVCaptureDevice * _Nonnull)device completion:(TVICameraSourceStartedBlock _Nullable)completion __attribute__((swift_name("startCapture(device:completion:)")));
		[Export ("startCaptureWithDevice:completion:")]
		void StartCaptureWithDevice (AVCaptureDevice device, [NullAllowed] TVICameraSourceStartedBlock completion);

		// -(void)startCaptureWithDevice:(AVCaptureDevice * _Nonnull)device format:(TVIVideoFormat * _Nonnull)format completion:(TVICameraSourceStartedBlock _Nullable)completion __attribute__((swift_name("startCapture(device:format:completion:)")));
		[Export ("startCaptureWithDevice:format:completion:")]
		void StartCaptureWithDevice (AVCaptureDevice device, TVIVideoFormat format, [NullAllowed] TVICameraSourceStartedBlock completion);

		// -(void)stopCapture;
		[Export ("stopCapture")]
		void StopCapture ();

		// -(void)stopCaptureWithCompletion:(TVICameraSourceStoppedBlock _Nullable)completion __attribute__((swift_name("stopCapture(completion:)")));
		[Export ("stopCaptureWithCompletion:")]
		void StopCaptureWithCompletion ([NullAllowed] TVICameraSourceStoppedBlock completion);

		// -(void)selectCaptureDevice:(AVCaptureDevice * _Nonnull)device __attribute__((swift_name("selectCaptureDevice(_:)")));
		[Export ("selectCaptureDevice:")]
		void SelectCaptureDevice (AVCaptureDevice device);

		// -(void)selectCaptureDevice:(AVCaptureDevice * _Nonnull)device completion:(TVICameraSourceStartedBlock _Nullable)completion __attribute__((swift_name("selectCaptureDevice(_:completion:)")));
		[Export ("selectCaptureDevice:completion:")]
		void SelectCaptureDevice (AVCaptureDevice device, [NullAllowed] TVICameraSourceStartedBlock completion);

		// -(void)selectCaptureDevice:(AVCaptureDevice * _Nonnull)device format:(TVIVideoFormat * _Nonnull)format completion:(TVICameraSourceStartedBlock _Nullable)completion __attribute__((swift_name("selectCaptureDevice(_:format:completion:)")));
		[Export ("selectCaptureDevice:format:completion:")]
		void SelectCaptureDevice (AVCaptureDevice device, TVIVideoFormat format, [NullAllowed] TVICameraSourceStartedBlock completion);

		// +(AVCaptureDevice * _Nullable)captureDeviceForPosition:(AVCaptureDevicePosition)position __attribute__((swift_name("captureDevice(position:)")));
		[Static]
		[Export ("captureDeviceForPosition:")]
		[return: NullAllowed]
		AVCaptureDevice CaptureDeviceForPosition (AVCaptureDevicePosition position);

		// +(AVCaptureDevice * _Nullable)captureDeviceForPosition:(AVCaptureDevicePosition)position type:(AVCaptureDeviceType _Nonnull)deviceType __attribute__((swift_name("captureDevice(position:deviceType:)")));
		[Static]
		[Export ("captureDeviceForPosition:type:")]
		[return: NullAllowed]
		AVCaptureDevice CaptureDeviceForPosition (AVCaptureDevicePosition position, string deviceType);

		// +(NSOrderedSet<TVIVideoFormat *> * _Nonnull)supportedFormatsForDevice:(AVCaptureDevice * _Nonnull)captureDevice __attribute__((swift_name("supportedFormats(captureDevice:)")));
		[Static]
		[Export ("supportedFormatsForDevice:")]
		NSOrderedSet<TVIVideoFormat> SupportedFormatsForDevice (AVCaptureDevice captureDevice);
	}

	// @interface AVCaptureDeviceControl (TVICameraSource)
	[Category]
	[BaseType (typeof(TVICameraSource))]
	interface TVICameraSource_AVCaptureDeviceControl
	{
		// @property (assign, nonatomic) float torchLevel;
		[Export ("torchLevel")]
		float TorchLevel { get; set; }

		// @property (assign, nonatomic) AVCaptureTorchMode torchMode;
		[Export ("torchMode", ArgumentSemantic.Assign)]
		AVCaptureTorchMode TorchMode { get; set; }

		// @property (assign, nonatomic) CGFloat zoomFactor;
		[Export ("zoomFactor")]
		nfloat ZoomFactor { get; set; }
	}

	// @protocol TVICameraSourceDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVICameraSourceDelegate
	{
		// @optional -(void)cameraSourceInterruptionEnded:(TVICameraSource * _Nonnull)source __attribute__((swift_name("cameraSourceInterruptionEnded(source:)")));
		[Export ("cameraSourceInterruptionEnded:")]
		void CameraSourceInterruptionEnded (TVICameraSource source);

		// @optional -(void)cameraSourceWasInterrupted:(TVICameraSource * _Nonnull)source reason:(AVCaptureSessionInterruptionReason)reason __attribute__((swift_name("cameraSourceWasInterrupted(source:reason:)")));
		[Export ("cameraSourceWasInterrupted:reason:")]
		void CameraSourceWasInterrupted (TVICameraSource source, AVCaptureSessionInterruptionReason reason);

		// @optional -(void)cameraSource:(TVICameraSource * _Nonnull)source didFailWithError:(NSError * _Nonnull)error __attribute__((swift_name("cameraSourceDidFail(source:error:)")));
		[Export ("cameraSource:didFailWithError:")]
		void CameraSource (TVICameraSource source, NSError error);

		// @optional -(void)cameraSource:(TVICameraSource * _Nonnull)source isReportingSystemPressure:(AVCaptureSystemPressureLevel _Nonnull)level __attribute__((swift_name("cameraSourceIsReportingSystemPressure(source:level:)")));
		[Export ("cameraSource:isReportingSystemPressure:")]
		void CameraSource (TVICameraSource source, string level);
	}

	// @interface TVICameraSourceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVICameraSourceOptionsBuilder
	{
		// @property (assign, nonatomic) BOOL enableCameraMultitasking __attribute__((availability(ios, introduced=16.0)));
		[iOS (16, 0)]
		[Export ("enableCameraMultitasking")]
		bool EnableCameraMultitasking { get; set; }

		// @property (nonatomic, strong) id<TVICameraSourceOrientationTracker> _Nonnull orientationTracker;
		[Export ("orientationTracker", ArgumentSemantic.Strong)]
		TVICameraSourceOrientationTracker OrientationTracker { get; set; }

		// @property (assign, nonatomic) BOOL enablePreview;
		[Export ("enablePreview")]
		bool EnablePreview { get; set; }

		// @property (assign, nonatomic) TVICameraSourceOptionsRotationTags rotationTags;
		[Export ("rotationTags", ArgumentSemantic.Assign)]
		TVICameraSourceOptionsRotationTags RotationTags { get; set; }

		// @property (assign, nonatomic) CGFloat zoomFactor;
		[Export ("zoomFactor")]
		nfloat ZoomFactor { get; set; }
	}

	// typedef void (^TVICameraSourceOptionsBuilderBlock)(TVICameraSourceOptionsBuilder * _Nonnull);
	delegate void TVICameraSourceOptionsBuilderBlock (TVICameraSourceOptionsBuilder arg0);

	// @interface TVICameraSourceOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVICameraSourceOptions
	{
		// @property (readonly, nonatomic, strong) id<TVICameraSourceOrientationTracker> _Nonnull orientationTracker;
		[Export ("orientationTracker", ArgumentSemantic.Strong)]
		TVICameraSourceOrientationTracker OrientationTracker { get; }

		// @property (readonly, assign, nonatomic) BOOL enablePreview;
		[Export ("enablePreview")]
		bool EnablePreview { get; }

		// @property (readonly, assign, nonatomic) TVICameraSourceOptionsRotationTags rotationTags;
		[Export ("rotationTags", ArgumentSemantic.Assign)]
		TVICameraSourceOptionsRotationTags RotationTags { get; }

		// @property (readonly, assign, nonatomic) CGFloat zoomFactor;
		[Export ("zoomFactor")]
		nfloat ZoomFactor { get; }

		// @property (assign, nonatomic) BOOL enableCameraMultitasking __attribute__((availability(ios, introduced=16.0)));
		[iOS (16, 0)]
		[Export ("enableCameraMultitasking")]
		bool EnableCameraMultitasking { get; set; }

		// +(instancetype _Nonnull)optionsWithBlock:(TVICameraSourceOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVICameraSourceOptions OptionsWithBlock (TVICameraSourceOptionsBuilderBlock block);
	}

	// @interface TVIVideoCodec : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoCodec
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern TVIVideoEncodingMode  _Nonnull const TVIVideoEncodingModeAuto __attribute__((availability(ios, introduced=11.0)));
		[iOS (11, 0)]
		[Field ("TVIVideoEncodingModeAuto", "__Internal")]
		NSString TVIVideoEncodingModeAuto { get; }
	}

	// @interface TVIConnectOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIConnectOptionsBuilder
	{
		// @property (copy, nonatomic) NSArray<TVILocalAudioTrack *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Copy)]
		TVILocalAudioTrack[] AudioTracks { get; set; }

		// @property (getter = isAutomaticSubscriptionEnabled, assign, nonatomic) BOOL automaticSubscriptionEnabled;
		[Export ("automaticSubscriptionEnabled")]
		bool AutomaticSubscriptionEnabled { [Bind ("isAutomaticSubscriptionEnabled")] get; set; }

		// @property (copy, nonatomic) NSArray<TVILocalDataTrack *> * _Nonnull dataTracks;
		[Export ("dataTracks", ArgumentSemantic.Copy)]
		TVILocalDataTrack[] DataTracks { get; set; }

		// @property (nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; set; }

		// @property (getter = isDominantSpeakerEnabled, assign, nonatomic) BOOL dominantSpeakerEnabled;
		[Export ("dominantSpeakerEnabled")]
		bool DominantSpeakerEnabled { [Bind ("isDominantSpeakerEnabled")] get; set; }

		// @property (nonatomic, strong) TVIEncodingParameters * _Nullable encodingParameters;
		[NullAllowed, Export ("encodingParameters", ArgumentSemantic.Strong)]
		TVIEncodingParameters EncodingParameters { get; set; }

		// @property (nonatomic, strong) TVIIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		TVIIceOptions IceOptions { get; set; }

		// @property (getter = areInsightsEnabled, assign, nonatomic) BOOL insightsEnabled;
		[Export ("insightsEnabled")]
		bool InsightsEnabled { [Bind ("areInsightsEnabled")] get; set; }

		// @property (assign, nonatomic) TVILocalNetworkPrivacyPolicy networkPrivacyPolicy;
		[Export ("networkPrivacyPolicy", ArgumentSemantic.Assign)]
		TVILocalNetworkPrivacyPolicy NetworkPrivacyPolicy { get; set; }

		// @property (getter = isNetworkQualityEnabled, assign, nonatomic) BOOL networkQualityEnabled;
		[Export ("networkQualityEnabled")]
		bool NetworkQualityEnabled { [Bind ("isNetworkQualityEnabled")] get; set; }

		// @property (nonatomic, strong) TVINetworkQualityConfiguration * _Nullable networkQualityConfiguration;
		[NullAllowed, Export ("networkQualityConfiguration", ArgumentSemantic.Strong)]
		TVINetworkQualityConfiguration NetworkQualityConfiguration { get; set; }

		// @property (copy, nonatomic) NSArray<TVIAudioCodec *> * _Nonnull preferredAudioCodecs;
		[Export ("preferredAudioCodecs", ArgumentSemantic.Copy)]
		TVIAudioCodec[] PreferredAudioCodecs { get; set; }

		// @property (copy, nonatomic) NSArray<TVIVideoCodec *> * _Nonnull preferredVideoCodecs;
		[Export ("preferredVideoCodecs", ArgumentSemantic.Copy)]
		TVIVideoCodec[] PreferredVideoCodecs { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull region;
		[Export ("region")]
		string Region { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable roomName;
		[NullAllowed, Export ("roomName")]
		string RoomName { get; set; }

		// @property (copy, nonatomic) TVIVideoEncodingMode _Nullable videoEncodingMode;
		[NullAllowed, Export ("videoEncodingMode")]
		string VideoEncodingMode { get; set; }

		// @property (copy, nonatomic) NSArray<TVILocalVideoTrack *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Copy)]
		TVILocalVideoTrack[] VideoTracks { get; set; }

		// @property (nonatomic, strong) TVIBandwidthProfileOptions * _Nullable bandwidthProfileOptions;
		[NullAllowed, Export ("bandwidthProfileOptions", ArgumentSemantic.Strong)]
		TVIBandwidthProfileOptions BandwidthProfileOptions { get; set; }
	}

	// @interface CallKit (TVIConnectOptionsBuilder)
	[Category]
	[BaseType (typeof(TVIConnectOptionsBuilder))]
	interface TVIConnectOptionsBuilder_CallKit
	{
		// @property (nonatomic, strong) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; set; }
	}

	// typedef void (^TVIConnectOptionsBuilderBlock)(TVIConnectOptionsBuilder * _Nonnull);
	delegate void TVIConnectOptionsBuilderBlock (TVIConnectOptionsBuilder arg0);

	// @interface TVIConnectOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIConnectOptions
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalAudioTrack *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Copy)]
		TVILocalAudioTrack[] AudioTracks { get; }

		// @property (readonly, getter = isAutomaticSubscriptionEnabled, assign, nonatomic) BOOL automaticSubscriptionEnabled;
		[Export ("automaticSubscriptionEnabled")]
		bool AutomaticSubscriptionEnabled { [Bind ("isAutomaticSubscriptionEnabled")] get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalDataTrack *> * _Nonnull dataTracks;
		[Export ("dataTracks", ArgumentSemantic.Copy)]
		TVILocalDataTrack[] DataTracks { get; }

		// @property (readonly, nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; }

		// @property (readonly, getter = isDominantSpeakerEnabled, assign, nonatomic) BOOL dominantSpeakerEnabled;
		[Export ("dominantSpeakerEnabled")]
		bool DominantSpeakerEnabled { [Bind ("isDominantSpeakerEnabled")] get; }

		// @property (readonly, nonatomic, strong) TVIEncodingParameters * _Nullable encodingParameters;
		[NullAllowed, Export ("encodingParameters", ArgumentSemantic.Strong)]
		TVIEncodingParameters EncodingParameters { get; }

		// @property (readonly, nonatomic, strong) TVIIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		TVIIceOptions IceOptions { get; }

		// @property (readonly, getter = areInsightsEnabled, assign, nonatomic) BOOL insightsEnabled;
		[Export ("insightsEnabled")]
		bool InsightsEnabled { [Bind ("areInsightsEnabled")] get; }

		// @property (readonly, getter = isNetworkQualityEnabled, assign, nonatomic) BOOL networkQualityEnabled;
		[Export ("networkQualityEnabled")]
		bool NetworkQualityEnabled { [Bind ("isNetworkQualityEnabled")] get; }

		// @property (readonly, assign, nonatomic) TVILocalNetworkPrivacyPolicy networkPrivacyPolicy;
		[Export ("networkPrivacyPolicy", ArgumentSemantic.Assign)]
		TVILocalNetworkPrivacyPolicy NetworkPrivacyPolicy { get; }

		// @property (readonly, nonatomic, strong) TVINetworkQualityConfiguration * _Nullable networkQualityConfiguration;
		[NullAllowed, Export ("networkQualityConfiguration", ArgumentSemantic.Strong)]
		TVINetworkQualityConfiguration NetworkQualityConfiguration { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIAudioCodec *> * _Nonnull preferredAudioCodecs;
		[Export ("preferredAudioCodecs", ArgumentSemantic.Copy)]
		TVIAudioCodec[] PreferredAudioCodecs { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIVideoCodec *> * _Nonnull preferredVideoCodecs;
		[Export ("preferredVideoCodecs", ArgumentSemantic.Copy)]
		TVIVideoCodec[] PreferredVideoCodecs { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull region;
		[Export ("region")]
		string Region { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable roomName;
		[NullAllowed, Export ("roomName")]
		string RoomName { get; }

		// @property (readonly, copy, nonatomic) TVIVideoEncodingMode _Nullable videoEncodingMode;
		[NullAllowed, Export ("videoEncodingMode")]
		string VideoEncodingMode { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalVideoTrack *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Copy)]
		TVILocalVideoTrack[] VideoTracks { get; }

		// @property (readonly, nonatomic, strong) TVIBandwidthProfileOptions * _Nullable bandwidthProfileOptions;
		[NullAllowed, Export ("bandwidthProfileOptions", ArgumentSemantic.Strong)]
		TVIBandwidthProfileOptions BandwidthProfileOptions { get; }

		// +(instancetype _Nonnull)optionsWithToken:(NSString * _Nonnull)token;
		[Static]
		[Export ("optionsWithToken:")]
		TVIConnectOptions OptionsWithToken (string token);

		// +(instancetype _Nonnull)optionsWithToken:(NSString * _Nonnull)token block:(TVIConnectOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithToken:block:")]
		TVIConnectOptions OptionsWithToken (string token, TVIConnectOptionsBuilderBlock block);
	}

	// @interface CallKit (TVIConnectOptions)
	[Category]
	[BaseType (typeof(TVIConnectOptions))]
	interface TVIConnectOptions_CallKit
	{
		// @property (readonly, nonatomic, strong) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; }
	}

	// @interface TVIDataTrack : TVITrack
	[BaseType (typeof(TVITrack))]
	[DisableDefaultCtor]
	interface TVIDataTrack
	{
		// @property (readonly, getter = isReliable, assign, nonatomic) BOOL reliable;
		[Export ("reliable")]
		bool Reliable { [Bind ("isReliable")] get; }

		// @property (readonly, getter = isOrdered, assign, nonatomic) BOOL ordered;
		[Export ("ordered")]
		bool Ordered { [Bind ("isOrdered")] get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxPacketLifeTime;
		[Export ("maxPacketLifeTime")]
		nuint MaxPacketLifeTime { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxRetransmits;
		[Export ("maxRetransmits")]
		nuint MaxRetransmits { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const int kTVIDataTrackOptionsDefaultMaxPacketLifeTime __attribute__((swift_name("DataTrackOptions.DefaultMaxPacketLifeTime")));
		[Field ("kTVIDataTrackOptionsDefaultMaxPacketLifeTime", "__Internal")]
		int kTVIDataTrackOptionsDefaultMaxPacketLifeTime { get; }

		// extern const int kTVIDataTrackOptionsDefaultMaxRetransmits __attribute__((swift_name("DataTrackOptions.DefaultMaxRetransmits")));
		[Field ("kTVIDataTrackOptionsDefaultMaxRetransmits", "__Internal")]
		int kTVIDataTrackOptionsDefaultMaxRetransmits { get; }
	}

	// @interface TVIDataTrackOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIDataTrackOptionsBuilder
	{
		// @property (getter = isOrdered, assign, nonatomic) BOOL ordered;
		[Export ("ordered")]
		bool Ordered { [Bind ("isOrdered")] get; set; }

		// @property (assign, nonatomic) int maxPacketLifeTime;
		[Export ("maxPacketLifeTime")]
		int MaxPacketLifeTime { get; set; }

		// @property (assign, nonatomic) int maxRetransmits;
		[Export ("maxRetransmits")]
		int MaxRetransmits { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }
	}

	// typedef void (^TVIDataTrackOptionsBuilderBlock)(TVIDataTrackOptionsBuilder * _Nonnull);
	delegate void TVIDataTrackOptionsBuilderBlock (TVIDataTrackOptionsBuilder arg0);

	// @interface TVIDataTrackOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIDataTrackOptions
	{
		// @property (readonly, getter = isOrdered, assign, nonatomic) BOOL ordered;
		[Export ("ordered")]
		bool Ordered { [Bind ("isOrdered")] get; }

		// @property (readonly, assign, nonatomic) int maxPacketLifeTime;
		[Export ("maxPacketLifeTime")]
		int MaxPacketLifeTime { get; }

		// @property (readonly, assign, nonatomic) int maxRetransmits;
		[Export ("maxRetransmits")]
		int MaxRetransmits { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		TVIDataTrackOptions Options ();

		// +(instancetype _Null_unspecified)optionsWithBlock:(TVIDataTrackOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIDataTrackOptions OptionsWithBlock (TVIDataTrackOptionsBuilderBlock block);
	}

	// @interface TVIDataTrackPublication : TVITrackPublication
	[BaseType (typeof(TVITrackPublication))]
	[DisableDefaultCtor]
	interface TVIDataTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVIDataTrack * _Nullable dataTrack;
		[NullAllowed, Export ("dataTrack", ArgumentSemantic.Strong)]
		TVIDataTrack DataTrack { get; }
	}

	// typedef void (^TVIAVAudioSessionConfigurationBlock)();
	delegate void TVIAVAudioSessionConfigurationBlock ();

	// @interface TVIDefaultAudioDevice : NSObject <TVIAudioDevice>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIDefaultAudioDevice : ITVIAudioDevice
	{
		// @property (copy, nonatomic) TVIAVAudioSessionConfigurationBlock _Nonnull block;
		[Export ("block", ArgumentSemantic.Copy)]
		TVIAVAudioSessionConfigurationBlock Block { get; set; }

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// +(instancetype _Nonnull)audioDevice;
		[Static]
		[Export ("audioDevice")]
		TVIDefaultAudioDevice AudioDevice ();

		// +(instancetype _Nonnull)audioDeviceWithBlock:(TVIAVAudioSessionConfigurationBlock _Nonnull)block;
		[Static]
		[Export ("audioDeviceWithBlock:")]
		TVIDefaultAudioDevice AudioDeviceWithBlock (TVIAVAudioSessionConfigurationBlock block);
	}

	// @interface TVIEncodingParameters : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIEncodingParameters
	{
		// -(instancetype _Nonnull)initWithAudioBitrate:(NSUInteger)maxAudioBitrate videoBitrate:(NSUInteger)maxVideoBitrate;
		[Export ("initWithAudioBitrate:videoBitrate:")]
		NativeHandle Constructor (nuint maxAudioBitrate, nuint maxVideoBitrate);

		// @property (readonly, assign, nonatomic) NSUInteger maxAudioBitrate;
		[Export ("maxAudioBitrate")]
		nuint MaxAudioBitrate { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxVideoBitrate;
		[Export ("maxVideoBitrate")]
		nuint MaxVideoBitrate { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NS_SWIFT_NAME(TwilioVideoSDK.ErrorDomain) NSErrorDomain kTVIErrorDomain __attribute__((swift_name("TwilioVideoSDK.ErrorDomain")));
		[Field ("kTVIErrorDomain", "__Internal")]
		NSString kTVIErrorDomain { get; }
	}

	// @interface TVIG722Codec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIG722Codec
	{
	}

	// @interface TVIH264Codec : TVIVideoCodec
	[BaseType (typeof(TVIVideoCodec))]
	interface TVIH264Codec
	{
	}

	// @interface TVIIceCandidatePairStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceCandidatePairStats
	{
		// @property (readonly, getter = isActiveCandidatePair, assign, nonatomic) BOOL activeCandidatePair;
		[Export ("activeCandidatePair")]
		bool ActiveCandidatePair { [Bind ("isActiveCandidatePair")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable relayProtocol;
		[NullAllowed, Export ("relayProtocol")]
		string RelayProtocol { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transportId;
		[NullAllowed, Export ("transportId")]
		string TransportId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localCandidateId;
		[NullAllowed, Export ("localCandidateId")]
		string LocalCandidateId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localCandidateIp;
		[NullAllowed, Export ("localCandidateIp")]
		string LocalCandidateIp { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable remoteCandidateId;
		[NullAllowed, Export ("remoteCandidateId")]
		string RemoteCandidateId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable remoteCandidateIp;
		[NullAllowed, Export ("remoteCandidateIp")]
		string RemoteCandidateIp { get; }

		// @property (readonly, assign, nonatomic) TVIIceCandidatePairState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVIIceCandidatePairState State { get; }

		// @property (readonly, assign, nonatomic) uint64_t priority;
		[Export ("priority")]
		ulong Priority { get; }

		// @property (readonly, getter = isNominated, assign, nonatomic) BOOL nominated;
		[Export ("nominated")]
		bool Nominated { [Bind ("isNominated")] get; }

		// @property (readonly, getter = isWritable, assign, nonatomic) BOOL writable;
		[Export ("writable")]
		bool Writable { [Bind ("isWritable")] get; }

		// @property (readonly, getter = isReadable, assign, nonatomic) BOOL readable;
		[Export ("readable")]
		bool Readable { [Bind ("isReadable")] get; }

		// @property (readonly, assign, nonatomic) uint64_t bytesSent;
		[Export ("bytesSent")]
		ulong BytesSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t bytesReceived;
		[Export ("bytesReceived")]
		ulong BytesReceived { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval totalRoundTripTime;
		[Export ("totalRoundTripTime")]
		double TotalRoundTripTime { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval currentRoundTripTime;
		[Export ("currentRoundTripTime")]
		double CurrentRoundTripTime { get; }

		// @property (readonly, assign, nonatomic) double availableOutgoingBitrate;
		[Export ("availableOutgoingBitrate")]
		double AvailableOutgoingBitrate { get; }

		// @property (readonly, assign, nonatomic) double availableIncomingBitrate;
		[Export ("availableIncomingBitrate")]
		double AvailableIncomingBitrate { get; }

		// @property (readonly, assign, nonatomic) uint64_t requestsReceived;
		[Export ("requestsReceived")]
		ulong RequestsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t requestsSent;
		[Export ("requestsSent")]
		ulong RequestsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t responsesReceived;
		[Export ("responsesReceived")]
		ulong ResponsesReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t responsesSent;
		[Export ("responsesSent")]
		ulong ResponsesSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t retransmissionsReceived;
		[Export ("retransmissionsReceived")]
		ulong RetransmissionsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t retransmissionsSent;
		[Export ("retransmissionsSent")]
		ulong RetransmissionsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentRequestsReceived;
		[Export ("consentRequestsReceived")]
		ulong ConsentRequestsReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentRequestsSent;
		[Export ("consentRequestsSent")]
		ulong ConsentRequestsSent { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentResponsesReceived;
		[Export ("consentResponsesReceived")]
		ulong ConsentResponsesReceived { get; }

		// @property (readonly, assign, nonatomic) uint64_t consentResponsesSent;
		[Export ("consentResponsesSent")]
		ulong ConsentResponsesSent { get; }
	}

	// @interface TVIIceCandidateStats : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceCandidateStats
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable candidateType;
		[NullAllowed, Export ("candidateType")]
		string CandidateType { get; }

		// @property (readonly, getter = isDeleted, assign, nonatomic) BOOL deleted;
		[Export ("deleted")]
		bool Deleted { [Bind ("isDeleted")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable ip;
		[NullAllowed, Export ("ip")]
		string Ip { get; }

		// @property (readonly, getter = isRemote, assign, nonatomic) BOOL remote;
		[Export ("remote")]
		bool Remote { [Bind ("isRemote")] get; }

		// @property (readonly, assign, nonatomic) long port;
		[Export ("port")]
		nint Port { get; }

		// @property (readonly, assign, nonatomic) long priority;
		[Export ("priority")]
		nint Priority { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable protocol;
		[NullAllowed, Export ("protocol")]
		string Protocol { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable url;
		[NullAllowed, Export ("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable transportId;
		[NullAllowed, Export ("transportId")]
		string TransportId { get; }
	}

	// @interface TVIIceServer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceServer
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull urlString;
		[Export ("urlString")]
		string UrlString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export ("password")]
		string Password { get; }

		// -(instancetype _Null_unspecified)initWithURLString:(NSString * _Nonnull)serverURLString;
		[Export ("initWithURLString:")]
		NativeHandle Constructor (string serverURLString);

		// -(instancetype _Null_unspecified)initWithURLString:(NSString * _Nonnull)serverURLString username:(NSString * _Nullable)username password:(NSString * _Nullable)password;
		[Export ("initWithURLString:username:password:")]
		NativeHandle Constructor (string serverURLString, [NullAllowed] string username, [NullAllowed] string password);
	}

	// @interface TVIIceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIIceOptionsBuilder
	{
		// @property (nonatomic, strong) NSArray<TVIIceServer *> * _Nullable servers;
		[NullAllowed, Export ("servers", ArgumentSemantic.Strong)]
		TVIIceServer[] Servers { get; set; }

		// @property (assign, nonatomic) TVIIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		TVIIceTransportPolicy TransportPolicy { get; set; }
	}

	// typedef void (^TVIIceOptionsBuilderBlock)(TVIIceOptionsBuilder * _Nonnull);
	delegate void TVIIceOptionsBuilderBlock (TVIIceOptionsBuilder arg0);

	// @interface TVIIceOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIIceOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<TVIIceServer *> * _Nonnull servers;
		[Export ("servers", ArgumentSemantic.Copy)]
		TVIIceServer[] Servers { get; }

		// @property (readonly, assign, nonatomic) TVIIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		TVIIceTransportPolicy TransportPolicy { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		TVIIceOptions Options ();

		// +(instancetype _Nonnull)optionsWithBlock:(TVIIceOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIIceOptions OptionsWithBlock (TVIIceOptionsBuilderBlock block);
	}

	// @interface TVIIsacCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIIsacCodec
	{
		// @property (readonly, nonatomic) TVIIsacCodecSampleRate sampleRate;
		[Export ("sampleRate")]
		TVIIsacCodecSampleRate SampleRate { get; }
	}

	// @interface TVILocalAudioTrack : TVIAudioTrack
	[BaseType (typeof(TVIAudioTrack))]
	[DisableDefaultCtor]
	interface TVILocalAudioTrack
	{
		// @property (readonly, nonatomic, strong) TVIAudioOptions * _Nullable options;
		[NullAllowed, Export ("options", ArgumentSemantic.Strong)]
		TVIAudioOptions Options { get; }

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// +(instancetype _Nullable)track;
		[Static]
		[Export ("track")]
		[return: NullAllowed]
		TVILocalAudioTrack Track ();

		// +(instancetype _Nullable)trackWithOptions:(TVIAudioOptions * _Nullable)options enabled:(BOOL)enabled name:(NSString * _Nullable)name;
		[Static]
		[Export ("trackWithOptions:enabled:name:")]
		[return: NullAllowed]
		TVILocalAudioTrack TrackWithOptions ([NullAllowed] TVIAudioOptions options, bool enabled, [NullAllowed] string name);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern TVITrackPriority  _Nonnull const TVITrackPriorityLow;
		[Field ("TVITrackPriorityLow", "__Internal")]
		NSString TVITrackPriorityLow { get; }

		// extern TVITrackPriority  _Nonnull const TVITrackPriorityStandard;
		[Field ("TVITrackPriorityStandard", "__Internal")]
		NSString TVITrackPriorityStandard { get; }

		// extern TVITrackPriority  _Nonnull const TVITrackPriorityHigh;
		[Field ("TVITrackPriorityHigh", "__Internal")]
		NSString TVITrackPriorityHigh { get; }
	}

	// @interface TVILocalAudioTrackPublication : TVIAudioTrackPublication
	[BaseType (typeof(TVIAudioTrackPublication))]
	[DisableDefaultCtor]
	interface TVILocalAudioTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVILocalAudioTrack * _Nullable localTrack;
		[NullAllowed, Export ("localTrack", ArgumentSemantic.Strong)]
		TVILocalAudioTrack LocalTrack { get; }

		// @property (copy, nonatomic) TVITrackPriority _Nonnull priority;
		[Export ("priority")]
		string Priority { get; set; }
	}

	// @interface TVILocalTrackStats : TVIBaseTrackStats
	[BaseType (typeof(TVIBaseTrackStats))]
	[DisableDefaultCtor]
	interface TVILocalTrackStats
	{
		// @property (readonly, assign, nonatomic) int64_t bytesSent;
		[Export ("bytesSent")]
		long BytesSent { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsSent;
		[Export ("packetsSent")]
		nuint PacketsSent { get; }

		// @property (readonly, assign, nonatomic) int64_t roundTripTime;
		[Export ("roundTripTime")]
		long RoundTripTime { get; }
	}

	// @interface TVILocalAudioTrackStats : TVILocalTrackStats
	[BaseType (typeof(TVILocalTrackStats))]
	[DisableDefaultCtor]
	interface TVILocalAudioTrackStats
	{
		// @property (readonly, assign, nonatomic) NSUInteger audioLevel;
		[Export ("audioLevel")]
		nuint AudioLevel { get; }

		// @property (readonly, assign, nonatomic) NSUInteger jitter;
		[Export ("jitter")]
		nuint Jitter { get; }
	}

	// @interface TVILocalDataTrack : TVIDataTrack
	[BaseType (typeof(TVIDataTrack))]
	[DisableDefaultCtor]
	interface TVILocalDataTrack
	{
		// -(void)sendString:(NSString * _Nonnull)message;
		[Export ("sendString:")]
		void SendString (string message);

		// -(void)sendData:(NSData * _Nonnull)message;
		[Export ("sendData:")]
		void SendData (NSData message);

		// +(instancetype _Nullable)track;
		[Static]
		[Export ("track")]
		[return: NullAllowed]
		TVILocalDataTrack Track ();

		// +(instancetype _Nullable)trackWithOptions:(TVIDataTrackOptions * _Nullable)options;
		[Static]
		[Export ("trackWithOptions:")]
		[return: NullAllowed]
		TVILocalDataTrack TrackWithOptions ([NullAllowed] TVIDataTrackOptions options);
	}

	// @interface TVILocalDataTrackPublication : TVIDataTrackPublication
	[BaseType (typeof(TVIDataTrackPublication))]
	[DisableDefaultCtor]
	interface TVILocalDataTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVILocalDataTrack * _Nullable localTrack;
		[NullAllowed, Export ("localTrack", ArgumentSemantic.Strong)]
		TVILocalDataTrack LocalTrack { get; }

		// @property (copy, nonatomic) TVITrackPriority _Nonnull priority;
		[Export ("priority")]
		string Priority { get; set; }
	}

	// @interface TVIParticipant : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIParticipant
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identity;
		[Export ("identity")]
		string Identity { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sid;
		[NullAllowed, Export ("sid")]
		string Sid { get; }

		// @property (readonly, assign, nonatomic) TVIParticipantState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVIParticipantState State { get; }

		// @property (readonly, assign, nonatomic) TVINetworkQualityLevel networkQualityLevel;
		[Export ("networkQualityLevel", ArgumentSemantic.Assign)]
		TVINetworkQualityLevel NetworkQualityLevel { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIAudioTrackPublication *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Copy)]
		TVIAudioTrackPublication[] AudioTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIVideoTrackPublication *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Copy)]
		TVIVideoTrackPublication[] VideoTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIDataTrackPublication *> * _Nonnull dataTracks;
		[Export ("dataTracks", ArgumentSemantic.Copy)]
		TVIDataTrackPublication[] DataTracks { get; }

		// -(TVITrackPublication * _Nullable)getTrack:(NSString * _Nonnull)sid;
		[Export ("getTrack:")]
		[return: NullAllowed]
		TVITrackPublication GetTrack (string sid);

		// -(TVIAudioTrackPublication * _Nullable)getAudioTrack:(NSString * _Nonnull)sid;
		[Export ("getAudioTrack:")]
		[return: NullAllowed]
		TVIAudioTrackPublication GetAudioTrack (string sid);

		// -(TVIVideoTrackPublication * _Nullable)getVideoTrack:(NSString * _Nonnull)sid;
		[Export ("getVideoTrack:")]
		[return: NullAllowed]
		TVIVideoTrackPublication GetVideoTrack (string sid);

		// -(TVIDataTrackPublication * _Nullable)getDataTrack:(NSString * _Nonnull)sid;
		[Export ("getDataTrack:")]
		[return: NullAllowed]
		TVIDataTrackPublication GetDataTrack (string sid);
	}

	// @interface TVILocalParticipant : TVIParticipant
	[BaseType (typeof(TVIParticipant))]
	[DisableDefaultCtor]
	interface TVILocalParticipant
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVILocalParticipantDelegate Delegate { get; set; }

		// @property (atomic, weak) id<TVILocalParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalAudioTrackPublication *> * _Nonnull localAudioTracks;
		[Export ("localAudioTracks", ArgumentSemantic.Copy)]
		TVILocalAudioTrackPublication[] LocalAudioTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalDataTrackPublication *> * _Nonnull localDataTracks;
		[Export ("localDataTracks", ArgumentSemantic.Copy)]
		TVILocalDataTrackPublication[] LocalDataTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVILocalVideoTrackPublication *> * _Nonnull localVideoTracks;
		[Export ("localVideoTracks", ArgumentSemantic.Copy)]
		TVILocalVideoTrackPublication[] LocalVideoTracks { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull signalingRegion;
		[Export ("signalingRegion")]
		string SignalingRegion { get; }

		// -(BOOL)publishAudioTrack:(TVILocalAudioTrack * _Nonnull)track;
		[Export ("publishAudioTrack:")]
		bool PublishAudioTrack (TVILocalAudioTrack track);

		// -(BOOL)publishAudioTrack:(TVILocalAudioTrack * _Nonnull)track publicationOptions:(TVILocalTrackPublicationOptions * _Nonnull)options;
		[Export ("publishAudioTrack:publicationOptions:")]
		bool PublishAudioTrack (TVILocalAudioTrack track, TVILocalTrackPublicationOptions options);

		// -(BOOL)publishDataTrack:(TVILocalDataTrack * _Nonnull)track;
		[Export ("publishDataTrack:")]
		bool PublishDataTrack (TVILocalDataTrack track);

		// -(BOOL)publishDataTrack:(TVILocalDataTrack * _Nonnull)track publicationOptions:(TVILocalTrackPublicationOptions * _Nonnull)options;
		[Export ("publishDataTrack:publicationOptions:")]
		bool PublishDataTrack (TVILocalDataTrack track, TVILocalTrackPublicationOptions options);

		// -(BOOL)publishVideoTrack:(TVILocalVideoTrack * _Nonnull)track;
		[Export ("publishVideoTrack:")]
		bool PublishVideoTrack (TVILocalVideoTrack track);

		// -(BOOL)publishVideoTrack:(TVILocalVideoTrack * _Nonnull)track publicationOptions:(TVILocalTrackPublicationOptions * _Nonnull)options;
		[Export ("publishVideoTrack:publicationOptions:")]
		bool PublishVideoTrack (TVILocalVideoTrack track, TVILocalTrackPublicationOptions options);

		// -(BOOL)unpublishAudioTrack:(TVILocalAudioTrack * _Nonnull)track;
		[Export ("unpublishAudioTrack:")]
		bool UnpublishAudioTrack (TVILocalAudioTrack track);

		// -(BOOL)unpublishDataTrack:(TVILocalDataTrack * _Nonnull)track;
		[Export ("unpublishDataTrack:")]
		bool UnpublishDataTrack (TVILocalDataTrack track);

		// -(BOOL)unpublishVideoTrack:(TVILocalVideoTrack * _Nonnull)track;
		[Export ("unpublishVideoTrack:")]
		bool UnpublishVideoTrack (TVILocalVideoTrack track);

		// -(void)setEncodingParameters:(TVIEncodingParameters * _Nullable)encodingParameters;
		[Export ("setEncodingParameters:")]
		void SetEncodingParameters ([NullAllowed] TVIEncodingParameters encodingParameters);
	}

	// @protocol TVILocalParticipantDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVILocalParticipantDelegate
	{
		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant didPublishAudioTrack:(TVILocalAudioTrackPublication * _Nonnull)audioTrackPublication __attribute__((swift_name("localParticipantDidPublishAudioTrack(participant:audioTrackPublication:)")));
		[Export ("localParticipant:didPublishAudioTrack:")]
		void DidPublishAudioTrack (TVILocalParticipant participant, TVILocalAudioTrackPublication audioTrackPublication);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant didFailToPublishAudioTrack:(TVILocalAudioTrack * _Nonnull)audioTrack withError:(NSError * _Nonnull)error __attribute__((swift_name("localParticipantDidFailToPublishAudioTrack(participant:audioTrack:error:)")));
		[Export ("localParticipant:didFailToPublishAudioTrack:withError:")]
		void DidFailToPublishAudioTrack (TVILocalParticipant participant, TVILocalAudioTrack audioTrack, NSError error);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant didPublishDataTrack:(TVILocalDataTrackPublication * _Nonnull)dataTrackPublication __attribute__((swift_name("localParticipantDidPublishDataTrack(participant:dataTrackPublication:)")));
		[Export ("localParticipant:didPublishDataTrack:")]
		void DidPublishDataTrack (TVILocalParticipant participant, TVILocalDataTrackPublication dataTrackPublication);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant didFailToPublishDataTrack:(TVILocalDataTrack * _Nonnull)dataTrack withError:(NSError * _Nonnull)error __attribute__((swift_name("localParticipantDidFailToPublishDataTrack(participant:dataTrack:error:)")));
		[Export ("localParticipant:didFailToPublishDataTrack:withError:")]
		void DidFailToPublishDataTrack (TVILocalParticipant participant, TVILocalDataTrack dataTrack, NSError error);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant didPublishVideoTrack:(TVILocalVideoTrackPublication * _Nonnull)videoTrackPublication __attribute__((swift_name("localParticipantDidPublishVideoTrack(participant:videoTrackPublication:)")));
		[Export ("localParticipant:didPublishVideoTrack:")]
		void DidPublishVideoTrack (TVILocalParticipant participant, TVILocalVideoTrackPublication videoTrackPublication);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant didFailToPublishVideoTrack:(TVILocalVideoTrack * _Nonnull)videoTrack withError:(NSError * _Nonnull)error __attribute__((swift_name("localParticipantDidFailToPublishVideoTrack(participant:videoTrack:error:)")));
		[Export ("localParticipant:didFailToPublishVideoTrack:withError:")]
		void DidFailToPublishVideoTrack (TVILocalParticipant participant, TVILocalVideoTrack videoTrack, NSError error);

		// @optional -(void)localParticipant:(TVILocalParticipant * _Nonnull)participant networkQualityLevelDidChange:(TVINetworkQualityLevel)networkQualityLevel __attribute__((swift_name("localParticipantNetworkQualityLevelDidChange(participant:networkQualityLevel:)")));
		[Export ("localParticipant:networkQualityLevelDidChange:")]
		void NetworkQualityLevelDidChange (TVILocalParticipant participant, TVINetworkQualityLevel networkQualityLevel);
	}

	// @interface TVILocalTrackPublicationOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVILocalTrackPublicationOptions
	{
		// @property (readonly, copy, nonatomic) TVITrackPriority _Nonnull priority;
		[Export ("priority")]
		string Priority { get; }

		// +(instancetype _Nonnull)optionsWithPriority:(TVITrackPriority _Nonnull)priority;
		[Static]
		[Export ("optionsWithPriority:")]
		TVILocalTrackPublicationOptions OptionsWithPriority (string priority);
	}

	// @interface TVIVideoTrack : TVITrack
	[BaseType (typeof(TVITrack))]
	[DisableDefaultCtor]
	interface TVIVideoTrack
	{
		// @property (readonly, nonatomic, strong) NSArray<id<TVIVideoRenderer>> * _Nonnull renderers;
		[Export ("renderers", ArgumentSemantic.Strong)]
		TVIVideoRenderer[] Renderers { get; }

		// -(void)addRenderer:(id<TVIVideoRenderer> _Nonnull)renderer;
		[Export ("addRenderer:")]
		void AddRenderer (TVIVideoRenderer renderer);

		// -(void)removeRenderer:(id<TVIVideoRenderer> _Nonnull)renderer;
		[Export ("removeRenderer:")]
		void RemoveRenderer (TVIVideoRenderer renderer);
	}

	// @interface TVILocalVideoTrack : TVIVideoTrack
	[BaseType (typeof(TVIVideoTrack))]
	[DisableDefaultCtor]
	interface TVILocalVideoTrack
	{
		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// @property (readonly, nonatomic, strong) id<TVIVideoSource> _Nullable source;
		[NullAllowed, Export ("source", ArgumentSemantic.Strong)]
		TVIVideoSource Source { get; }

		// +(instancetype _Nullable)trackWithSource:(id<TVIVideoSource> _Nonnull)source;
		[Static]
		[Export ("trackWithSource:")]
		[return: NullAllowed]
		TVILocalVideoTrack TrackWithSource (TVIVideoSource source);

		// +(instancetype _Nullable)trackWithSource:(id<TVIVideoSource> _Nonnull)source enabled:(BOOL)enabled name:(NSString * _Nullable)name;
		[Static]
		[Export ("trackWithSource:enabled:name:")]
		[return: NullAllowed]
		TVILocalVideoTrack TrackWithSource (TVIVideoSource source, bool enabled, [NullAllowed] string name);
	}

	// @interface TVIVideoTrackPublication : TVITrackPublication
	[BaseType (typeof(TVITrackPublication))]
	[DisableDefaultCtor]
	interface TVIVideoTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVIVideoTrack * _Nullable videoTrack;
		[NullAllowed, Export ("videoTrack", ArgumentSemantic.Strong)]
		TVIVideoTrack VideoTrack { get; }
	}

	// @interface TVILocalVideoTrackPublication : TVIVideoTrackPublication
	[BaseType (typeof(TVIVideoTrackPublication))]
	[DisableDefaultCtor]
	interface TVILocalVideoTrackPublication
	{
		// @property (readonly, nonatomic, strong) TVILocalVideoTrack * _Nullable localTrack;
		[NullAllowed, Export ("localTrack", ArgumentSemantic.Strong)]
		TVILocalVideoTrack LocalTrack { get; }

		// @property (copy, nonatomic) TVITrackPriority _Nonnull priority;
		[Export ("priority")]
		string Priority { get; set; }
	}

	// @interface TVILocalVideoTrackStats : TVILocalTrackStats
	[BaseType (typeof(TVILocalTrackStats))]
	[DisableDefaultCtor]
	interface TVILocalVideoTrackStats
	{
		// @property (readonly, assign, nonatomic) CMVideoDimensions captureDimensions;
		[Export ("captureDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions CaptureDimensions { get; }

		// @property (readonly, assign, nonatomic) NSUInteger captureFrameRate;
		[Export ("captureFrameRate")]
		nuint CaptureFrameRate { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions dimensions;
		[Export ("dimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions Dimensions { get; }

		// @property (readonly, assign, nonatomic) NSUInteger frameRate;
		[Export ("frameRate")]
		nuint FrameRate { get; }

		// @property (readonly, assign, nonatomic) uint32_t framesEncoded;
		[Export ("framesEncoded")]
		uint FramesEncoded { get; }
	}

	// @interface TVINetworkQualityConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	interface TVINetworkQualityConfiguration
	{
		// @property (readonly, assign, nonatomic) TVINetworkQualityVerbosity local;
		[Export ("local", ArgumentSemantic.Assign)]
		TVINetworkQualityVerbosity Local { get; }

		// @property (readonly, assign, nonatomic) TVINetworkQualityVerbosity remote;
		[Export ("remote", ArgumentSemantic.Assign)]
		TVINetworkQualityVerbosity Remote { get; }

		// -(instancetype _Nullable)initWithLocalVerbosity:(TVINetworkQualityVerbosity)local remoteVerbosity:(TVINetworkQualityVerbosity)remote __attribute__((objc_designated_initializer));
		[Export ("initWithLocalVerbosity:remoteVerbosity:")]
		[DesignatedInitializer]
		NativeHandle Constructor (TVINetworkQualityVerbosity local, TVINetworkQualityVerbosity remote);
	}

	// @interface TVIOpusCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIOpusCodec
	{
		// @property (readonly, getter = isDtxEnabled, nonatomic) BOOL dtxEnabled;
		[Export ("dtxEnabled")]
		bool DtxEnabled { [Bind ("isDtxEnabled")] get; }

		// -(instancetype _Null_unspecified)initWithDtxEnabled:(BOOL)dtxEnabled;
		[Export ("initWithDtxEnabled:")]
		NativeHandle Constructor (bool dtxEnabled);
	}

	// @interface TVIPcmaCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIPcmaCodec
	{
	}

	// @interface TVIPcmuCodec : TVIAudioCodec
	[BaseType (typeof(TVIAudioCodec))]
	interface TVIPcmuCodec
	{
	}

	// @interface TVIRemoteAudioTrack : TVIAudioTrack
	[BaseType (typeof(TVIAudioTrack))]
	[DisableDefaultCtor]
	interface TVIRemoteAudioTrack
	{
		// @property (getter = isPlaybackEnabled, assign, nonatomic) BOOL playbackEnabled;
		[Export ("playbackEnabled")]
		bool PlaybackEnabled { [Bind ("isPlaybackEnabled")] get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }
	}

	// @interface TVIRemoteAudioTrackPublication : TVIAudioTrackPublication
	[BaseType (typeof(TVIAudioTrackPublication))]
	[DisableDefaultCtor]
	interface TVIRemoteAudioTrackPublication
	{
		// @property (readonly, getter = isTrackSubscribed, assign, nonatomic) BOOL trackSubscribed;
		[Export ("trackSubscribed")]
		bool TrackSubscribed { [Bind ("isTrackSubscribed")] get; }

		// @property (readonly, nonatomic, strong) TVIRemoteAudioTrack * _Nullable remoteTrack;
		[NullAllowed, Export ("remoteTrack", ArgumentSemantic.Strong)]
		TVIRemoteAudioTrack RemoteTrack { get; }

		// @property (readonly, copy, nonatomic) TVITrackPriority _Nonnull publishPriority;
		[Export ("publishPriority")]
		string PublishPriority { get; }
	}

	// @interface TVIRemoteTrackStats : TVIBaseTrackStats
	[BaseType (typeof(TVIBaseTrackStats))]
	[DisableDefaultCtor]
	interface TVIRemoteTrackStats
	{
		// @property (readonly, assign, nonatomic) int64_t bytesReceived;
		[Export ("bytesReceived")]
		long BytesReceived { get; }

		// @property (readonly, assign, nonatomic) NSUInteger packetsReceived;
		[Export ("packetsReceived")]
		nuint PacketsReceived { get; }
	}

	// @interface TVIRemoteAudioTrackStats : TVIRemoteTrackStats
	[BaseType (typeof(TVIRemoteTrackStats))]
	[DisableDefaultCtor]
	interface TVIRemoteAudioTrackStats
	{
		// @property (readonly, assign, nonatomic) NSUInteger audioLevel;
		[Export ("audioLevel")]
		nuint AudioLevel { get; }

		// @property (readonly, assign, nonatomic) NSUInteger jitter;
		[Export ("jitter")]
		nuint Jitter { get; }
	}

	// @interface TVIRemoteDataTrack : TVIDataTrack
	[BaseType (typeof(TVIDataTrack))]
	[DisableDefaultCtor]
	interface TVIRemoteDataTrack
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIRemoteDataTrackDelegate Delegate { get; set; }

		// @property (atomic, weak) id<TVIRemoteDataTrackDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }
	}

	// @protocol TVIRemoteDataTrackDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVIRemoteDataTrackDelegate
	{
		// @optional -(void)remoteDataTrack:(TVIRemoteDataTrack * _Nonnull)remoteDataTrack didReceiveString:(NSString * _Nonnull)message __attribute__((swift_name("remoteDataTrackDidReceiveString(remoteDataTrack:message:)")));
		[Export ("remoteDataTrack:didReceiveString:")]
		void DidReceiveString (TVIRemoteDataTrack remoteDataTrack, string message);

		// @optional -(void)remoteDataTrack:(TVIRemoteDataTrack * _Nonnull)remoteDataTrack didReceiveData:(NSData * _Nonnull)message __attribute__((swift_name("remoteDataTrackDidReceiveData(remoteDataTrack:message:)")));
		[Export ("remoteDataTrack:didReceiveData:")]
		void DidReceiveData (TVIRemoteDataTrack remoteDataTrack, NSData message);
	}

	// @interface TVIRemoteDataTrackPublication : TVIDataTrackPublication
	[BaseType (typeof(TVIDataTrackPublication))]
	[DisableDefaultCtor]
	interface TVIRemoteDataTrackPublication
	{
		// @property (readonly, getter = isTrackSubscribed, assign, nonatomic) BOOL trackSubscribed;
		[Export ("trackSubscribed")]
		bool TrackSubscribed { [Bind ("isTrackSubscribed")] get; }

		// @property (readonly, nonatomic, strong) TVIRemoteDataTrack * _Nullable remoteTrack;
		[NullAllowed, Export ("remoteTrack", ArgumentSemantic.Strong)]
		TVIRemoteDataTrack RemoteTrack { get; }

		// @property (readonly, copy, nonatomic) TVITrackPriority _Nonnull publishPriority;
		[Export ("publishPriority")]
		string PublishPriority { get; }
	}

	// @interface TVIRemoteParticipant : TVIParticipant
	[BaseType (typeof(TVIParticipant))]
	[DisableDefaultCtor]
	interface TVIRemoteParticipant
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIRemoteParticipantDelegate Delegate { get; set; }

		// @property (atomic, weak) id<TVIRemoteParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteAudioTrackPublication *> * _Nonnull remoteAudioTracks;
		[Export ("remoteAudioTracks", ArgumentSemantic.Copy)]
		TVIRemoteAudioTrackPublication[] RemoteAudioTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteVideoTrackPublication *> * _Nonnull remoteVideoTracks;
		[Export ("remoteVideoTracks", ArgumentSemantic.Copy)]
		TVIRemoteVideoTrackPublication[] RemoteVideoTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteDataTrackPublication *> * _Nonnull remoteDataTracks;
		[Export ("remoteDataTracks", ArgumentSemantic.Copy)]
		TVIRemoteDataTrackPublication[] RemoteDataTracks { get; }
	}

	// @protocol TVIRemoteParticipantDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVIRemoteParticipantDelegate
	{
		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didPublishVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidPublishVideoTrack(participant:publication:)")));
		[Export ("remoteParticipant:didPublishVideoTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didUnpublishVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidUnpublishVideoTrack(participant:publication:)")));
		[Export ("remoteParticipant:didUnpublishVideoTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didPublishAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidPublishAudioTrack(participant:publication:)")));
		[Export ("remoteParticipant:didPublishAudioTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didUnpublishAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidUnpublishAudioTrack(participant:publication:)")));
		[Export ("remoteParticipant:didUnpublishAudioTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didPublishDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidPublishDataTrack(participant:publication:)")));
		[Export ("remoteParticipant:didPublishDataTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didUnpublishDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidUnpublishDataTrack(participant:publication:)")));
		[Export ("remoteParticipant:didUnpublishDataTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteDataTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didEnableVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidEnableVideoTrack(participant:publication:)")));
		[Export ("remoteParticipant:didEnableVideoTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didDisableVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidDisableVideoTrack(participant:publication:)")));
		[Export ("remoteParticipant:didDisableVideoTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didEnableAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidEnableAudioTrack(participant:publication:)")));
		[Export ("remoteParticipant:didEnableAudioTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didDisableAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidDisableAudioTrack(participant:publication:)")));
		[Export ("remoteParticipant:didDisableAudioTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)didSubscribeToVideoTrack:(TVIRemoteVideoTrack * _Nonnull)videoTrack publication:(TVIRemoteVideoTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didSubscribeToVideoTrack(videoTrack:publication:participant:)")));
		[Export ("didSubscribeToVideoTrack:publication:forParticipant:")]
		void DidSubscribeToVideoTrack (TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)didFailToSubscribeToVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didFailToSubscribeToVideoTrack(publication:error:participant:)")));
		[Export ("didFailToSubscribeToVideoTrack:error:forParticipant:")]
		void DidFailToSubscribeToVideoTrack (TVIRemoteVideoTrackPublication publication, NSError error, TVIRemoteParticipant participant);

		// @optional -(void)didUnsubscribeFromVideoTrack:(TVIRemoteVideoTrack * _Nonnull)videoTrack publication:(TVIRemoteVideoTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didUnsubscribeFromVideoTrack(videoTrack:publication:participant:)")));
		[Export ("didUnsubscribeFromVideoTrack:publication:forParticipant:")]
		void DidUnsubscribeFromVideoTrack (TVIRemoteVideoTrack videoTrack, TVIRemoteVideoTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)didSubscribeToAudioTrack:(TVIRemoteAudioTrack * _Nonnull)audioTrack publication:(TVIRemoteAudioTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didSubscribeToAudioTrack(audioTrack:publication:participant:)")));
		[Export ("didSubscribeToAudioTrack:publication:forParticipant:")]
		void DidSubscribeToAudioTrack (TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)didFailToSubscribeToAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didFailToSubscribeToAudioTrack(publication:error:participant:)")));
		[Export ("didFailToSubscribeToAudioTrack:error:forParticipant:")]
		void DidFailToSubscribeToAudioTrack (TVIRemoteAudioTrackPublication publication, NSError error, TVIRemoteParticipant participant);

		// @optional -(void)didUnsubscribeFromAudioTrack:(TVIRemoteAudioTrack * _Nonnull)audioTrack publication:(TVIRemoteAudioTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didUnsubscribeFromAudioTrack(audioTrack:publication:participant:)")));
		[Export ("didUnsubscribeFromAudioTrack:publication:forParticipant:")]
		void DidUnsubscribeFromAudioTrack (TVIRemoteAudioTrack audioTrack, TVIRemoteAudioTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)didSubscribeToDataTrack:(TVIRemoteDataTrack * _Nonnull)dataTrack publication:(TVIRemoteDataTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didSubscribeToDataTrack(dataTrack:publication:participant:)")));
		[Export ("didSubscribeToDataTrack:publication:forParticipant:")]
		void DidSubscribeToDataTrack (TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)didFailToSubscribeToDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication error:(NSError * _Nonnull)error forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didFailToSubscribeToDataTrack(publication:error:participant:)")));
		[Export ("didFailToSubscribeToDataTrack:error:forParticipant:")]
		void DidFailToSubscribeToDataTrack (TVIRemoteDataTrackPublication publication, NSError error, TVIRemoteParticipant participant);

		// @optional -(void)didUnsubscribeFromDataTrack:(TVIRemoteDataTrack * _Nonnull)dataTrack publication:(TVIRemoteDataTrackPublication * _Nonnull)publication forParticipant:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("didUnsubscribeFromDataTrack(dataTrack:publication:participant:)")));
		[Export ("didUnsubscribeFromDataTrack:publication:forParticipant:")]
		void DidUnsubscribeFromDataTrack (TVIRemoteDataTrack dataTrack, TVIRemoteDataTrackPublication publication, TVIRemoteParticipant participant);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant networkQualityLevelDidChange:(TVINetworkQualityLevel)networkQualityLevel __attribute__((swift_name("remoteParticipantNetworkQualityLevelDidChange(participant:networkQualityLevel:)")));
		[Export ("remoteParticipant:networkQualityLevelDidChange:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVINetworkQualityLevel networkQualityLevel);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant switchedOffVideoTrack:(TVIRemoteVideoTrack * _Nonnull)track __attribute__((swift_name("remoteParticipantSwitchedOffVideoTrack(participant:track:)")));
		[Export ("remoteParticipant:switchedOffVideoTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteVideoTrack track);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant switchedOnVideoTrack:(TVIRemoteVideoTrack * _Nonnull)track __attribute__((swift_name("remoteParticipantSwitchedOnVideoTrack(participant:track:)")));
		[Export ("remoteParticipant:switchedOnVideoTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, TVIRemoteVideoTrack track);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didChangePublishPriority:(TVITrackPriority _Nonnull)priority forAudioTrack:(TVIRemoteAudioTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidChangeAudioTrackPublishPriority(participant:priority:publication:)")));
		[Export ("remoteParticipant:didChangePublishPriority:forAudioTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, string priority, TVIRemoteAudioTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didChangePublishPriority:(TVITrackPriority _Nonnull)priority forVideoTrack:(TVIRemoteVideoTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidChangeVideoTrackPublishPriority(participant:priority:publication:)")));
		[Export ("remoteParticipant:didChangePublishPriority:forVideoTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, string priority, TVIRemoteVideoTrackPublication publication);

		// @optional -(void)remoteParticipant:(TVIRemoteParticipant * _Nonnull)participant didChangePublishPriority:(TVITrackPriority _Nonnull)priority forDataTrack:(TVIRemoteDataTrackPublication * _Nonnull)publication __attribute__((swift_name("remoteParticipantDidChangeDataTrackPublishPriority(participant:priority:publication:)")));
		[Export ("remoteParticipant:didChangePublishPriority:forDataTrack:")]
		void RemoteParticipant (TVIRemoteParticipant participant, string priority, TVIRemoteDataTrackPublication publication);
	}

	// @interface TVIRemoteVideoTrack : TVIVideoTrack
	[BaseType (typeof(TVIVideoTrack))]
	[DisableDefaultCtor]
	interface TVIRemoteVideoTrack
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }

		// @property (readonly, getter = isSwitchedOff, assign, nonatomic) BOOL switchedOff;
		[Export ("switchedOff")]
		bool SwitchedOff { [Bind ("isSwitchedOff")] get; }

		// @property (copy, nonatomic) TVITrackPriority _Nullable priority;
		[NullAllowed, Export ("priority")]
		string Priority { get; set; }

		// -(void)switchOff;
		[Export ("switchOff")]
		void SwitchOff ();

		// -(void)switchOn;
		[Export ("switchOn")]
		void SwitchOn ();

		// -(void)setContentPreferences:(TVIVideoContentPreferences * _Nonnull)contentPreferences;
		[Export ("setContentPreferences:")]
		void SetContentPreferences (TVIVideoContentPreferences contentPreferences);
	}

	// @interface TVIRemoteVideoTrackPublication : TVIVideoTrackPublication
	[BaseType (typeof(TVIVideoTrackPublication))]
	[DisableDefaultCtor]
	interface TVIRemoteVideoTrackPublication
	{
		// @property (readonly, getter = isTrackSubscribed, assign, nonatomic) BOOL trackSubscribed;
		[Export ("trackSubscribed")]
		bool TrackSubscribed { [Bind ("isTrackSubscribed")] get; }

		// @property (readonly, nonatomic, strong) TVIRemoteVideoTrack * _Nullable remoteTrack;
		[NullAllowed, Export ("remoteTrack", ArgumentSemantic.Strong)]
		TVIRemoteVideoTrack RemoteTrack { get; }

		// @property (readonly, copy, nonatomic) TVITrackPriority _Nonnull publishPriority;
		[Export ("publishPriority")]
		string PublishPriority { get; }
	}

	// @interface TVIRemoteVideoTrackStats : TVIRemoteTrackStats
	[BaseType (typeof(TVIRemoteTrackStats))]
	[DisableDefaultCtor]
	interface TVIRemoteVideoTrackStats
	{
		// @property (readonly, assign, nonatomic) CMVideoDimensions dimensions;
		[Export ("dimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions Dimensions { get; }

		// @property (readonly, assign, nonatomic) NSUInteger frameRate;
		[Export ("frameRate")]
		nuint FrameRate { get; }
	}

	// typedef void (^TVIRoomGetStatsBlock)(NSArray<TVIStatsReport *> * _Nonnull);
	delegate void TVIRoomGetStatsBlock (TVIStatsReport[] arg0);

	// @interface TVIRoom : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIRoom
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIRoomDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVIRoomDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TVIRemoteParticipant * _Nullable dominantSpeaker;
		[NullAllowed, Export ("dominantSpeaker", ArgumentSemantic.Strong)]
		TVIRemoteParticipant DominantSpeaker { get; }

		// @property (readonly, nonatomic, strong) TVILocalParticipant * _Nullable localParticipant;
		[NullAllowed, Export ("localParticipant", ArgumentSemantic.Strong)]
		TVILocalParticipant LocalParticipant { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable mediaRegion;
		[NullAllowed, Export ("mediaRegion")]
		string MediaRegion { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIRemoteParticipant *> * _Nonnull remoteParticipants;
		[Export ("remoteParticipants", ArgumentSemantic.Copy)]
		TVIRemoteParticipant[] RemoteParticipants { get; }

		// @property (readonly, getter = isRecording, assign, nonatomic) BOOL recording;
		[Export ("recording")]
		bool Recording { [Bind ("isRecording")] get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }

		// @property (readonly, assign, nonatomic) TVIRoomState state;
		[Export ("state", ArgumentSemantic.Assign)]
		TVIRoomState State { get; }

		// -(TVIRemoteParticipant * _Nullable)getRemoteParticipantWithSid:(NSString * _Nonnull)sid __attribute__((swift_name("getRemoteParticipant(sid:)")));
		[Export ("getRemoteParticipantWithSid:")]
		[return: NullAllowed]
		TVIRemoteParticipant GetRemoteParticipantWithSid (string sid);

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)getStatsWithBlock:(TVIRoomGetStatsBlock _Nonnull)block __attribute__((swift_name("getStats(_:)")));
		[Export ("getStatsWithBlock:")]
		void GetStatsWithBlock (TVIRoomGetStatsBlock block);
	}

	// @interface CallKit (TVIRoom)
	[Category]
	[BaseType (typeof(TVIRoom))]
	interface TVIRoom_CallKit
	{
		// @property (readonly, nonatomic) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid")]
		NSUuid Uuid { get; }
	}

	// @protocol TVIRoomDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVIRoomDelegate
	{
		// @optional -(void)didConnectToRoom:(TVIRoom * _Nonnull)room __attribute__((swift_name("roomDidConnect(room:)")));
		[Export ("didConnectToRoom:")]
		void DidConnectToRoom (TVIRoom room);

		// @optional -(void)room:(TVIRoom * _Nonnull)room didFailToConnectWithError:(NSError * _Nonnull)error __attribute__((swift_name("roomDidFailToConnect(room:error:)")));
		[Export ("room:didFailToConnectWithError:")]
		void Room (TVIRoom room, NSError error);

		// @optional -(void)room:(TVIRoom * _Nonnull)room didDisconnectWithError:(NSError * _Nullable)error __attribute__((swift_name("roomDidDisconnect(room:error:)")));
		[Export ("room:didDisconnectWithError:")]
		void Room (TVIRoom room, [NullAllowed] NSError error);

		// @optional -(void)room:(TVIRoom * _Nonnull)room isReconnectingWithError:(NSError * _Nonnull)error __attribute__((swift_name("roomIsReconnecting(room:error:)")));
		[Export ("room:isReconnectingWithError:")]
		void Room (TVIRoom room, NSError error);

		// @optional -(void)didReconnectToRoom:(TVIRoom * _Nonnull)room __attribute__((swift_name("roomDidReconnect(room:)")));
		[Export ("didReconnectToRoom:")]
		void DidReconnectToRoom (TVIRoom room);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantDidConnect:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("participantDidConnect(room:participant:)")));
		[Export ("room:participantDidConnect:")]
		void Room (TVIRoom room, TVIRemoteParticipant participant);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantDidDisconnect:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("participantDidDisconnect(room:participant:)")));
		[Export ("room:participantDidDisconnect:")]
		void Room (TVIRoom room, TVIRemoteParticipant participant);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantIsReconnecting:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("participantIsReconnecting(room:participant:)")));
		[Export ("room:participantIsReconnecting:")]
		void Room (TVIRoom room, TVIRemoteParticipant participant);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantDidReconnect:(TVIRemoteParticipant * _Nonnull)participant __attribute__((swift_name("participantDidReconnect(room:participant:)")));
		[Export ("room:participantDidReconnect:")]
		void Room (TVIRoom room, TVIRemoteParticipant participant);

		// @optional -(void)roomDidStartRecording:(TVIRoom * _Nonnull)room __attribute__((swift_name("roomDidStartRecording(room:)")));
		[Export ("roomDidStartRecording:")]
		void RoomDidStartRecording (TVIRoom room);

		// @optional -(void)roomDidStopRecording:(TVIRoom * _Nonnull)room __attribute__((swift_name("roomDidStopRecording(room:)")));
		[Export ("roomDidStopRecording:")]
		void RoomDidStopRecording (TVIRoom room);

		// @optional -(void)room:(TVIRoom * _Nonnull)room dominantSpeakerDidChange:(TVIRemoteParticipant * _Nullable)participant __attribute__((swift_name("dominantSpeakerDidChange(room:participant:)")));
		[Export ("room:dominantSpeakerDidChange:")]
		void Room (TVIRoom room, [NullAllowed] TVIRemoteParticipant participant);
	}

	// @protocol TVIVideoRenderer <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface TVIVideoRenderer
	{
		// @required -(void)renderFrame:(TVIVideoFrame * _Nonnull)frame;
		[Abstract]
		[Export ("renderFrame:")]
		void RenderFrame (TVIVideoFrame frame);

		// @required -(void)updateVideoSize:(CMVideoDimensions)videoSize orientation:(TVIVideoOrientation)orientation;
		[Abstract]
		[Export ("updateVideoSize:orientation:")]
		void UpdateVideoSize (CMVideoDimensions videoSize, TVIVideoOrientation orientation);

		// @optional -(void)invalidateRenderer;
		[Export ("invalidateRenderer")]
		void InvalidateRenderer ();
	}

	// @protocol TVISampleBufferVideoViewDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVISampleBufferVideoViewDelegate
	{
		// @optional -(void)videoViewDidReceiveData:(TVISampleBufferVideoView * _Nonnull)view __attribute__((swift_name("videoViewDidReceiveData(view:)")));
		[Export ("videoViewDidReceiveData:")]
		void VideoViewDidReceiveData (TVISampleBufferVideoView view);

		// @optional -(void)videoView:(TVISampleBufferVideoView * _Nonnull)view videoDimensionsDidChange:(CMVideoDimensions)dimensions __attribute__((swift_name("videoViewDimensionsDidChange(view:dimensions:)")));
		[Export ("videoView:videoDimensionsDidChange:")]
		void VideoView (TVISampleBufferVideoView view, CMVideoDimensions dimensions);
	}

	// @interface TVISampleBufferVideoView : UIView <TVIVideoRenderer>
	[BaseType (typeof(UIView))]
	interface TVISampleBufferVideoView : ITVIVideoRenderer
	{
		// -(instancetype _Null_unspecified)initWithFrame:(CGRect)frame delegate:(id<TVISampleBufferVideoViewDelegate> _Nullable)delegate;
		[Export ("initWithFrame:delegate:")]
		NativeHandle Constructor (CGRect frame, [NullAllowed] TVISampleBufferVideoViewDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVISampleBufferVideoViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVISampleBufferVideoViewDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoDimensions;
		[Export ("videoDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions VideoDimensions { get; }

		// @property (readonly, assign, nonatomic) BOOL hasVideoData;
		[Export ("hasVideoData")]
		bool HasVideoData { get; }

		// @property (getter = shouldMirror, assign, nonatomic) BOOL mirror;
		[Export ("mirror")]
		bool Mirror { [Bind ("shouldMirror")] get; set; }
	}

	// @interface TVIStatsReport : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIStatsReport
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull peerConnectionId;
		[Export ("peerConnectionId")]
		string PeerConnectionId { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVILocalAudioTrackStats *> * _Nonnull localAudioTrackStats;
		[Export ("localAudioTrackStats", ArgumentSemantic.Strong)]
		TVILocalAudioTrackStats[] LocalAudioTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVILocalVideoTrackStats *> * _Nonnull localVideoTrackStats;
		[Export ("localVideoTrackStats", ArgumentSemantic.Strong)]
		TVILocalVideoTrackStats[] LocalVideoTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIRemoteAudioTrackStats *> * _Nonnull remoteAudioTrackStats;
		[Export ("remoteAudioTrackStats", ArgumentSemantic.Strong)]
		TVIRemoteAudioTrackStats[] RemoteAudioTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIRemoteVideoTrackStats *> * _Nonnull remoteVideoTrackStats;
		[Export ("remoteVideoTrackStats", ArgumentSemantic.Strong)]
		TVIRemoteVideoTrackStats[] RemoteVideoTrackStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIIceCandidateStats *> * _Nonnull iceCandidateStats;
		[Export ("iceCandidateStats", ArgumentSemantic.Strong)]
		TVIIceCandidateStats[] IceCandidateStats { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVIIceCandidatePairStats *> * _Nonnull iceCandidatePairStats;
		[Export ("iceCandidatePairStats", ArgumentSemantic.Strong)]
		TVIIceCandidatePairStats[] IceCandidatePairStats { get; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern TVIBandwidthProfileMode  _Nonnull const TVIBandwidthProfileModeCollaboration;
		[Field ("TVIBandwidthProfileModeCollaboration", "__Internal")]
		NSString TVIBandwidthProfileModeCollaboration { get; }

		// extern TVIBandwidthProfileMode  _Nonnull const TVIBandwidthProfileModeGrid;
		[Field ("TVIBandwidthProfileModeGrid", "__Internal")]
		NSString TVIBandwidthProfileModeGrid { get; }

		// extern TVIBandwidthProfileMode  _Nonnull const TVIBandwidthProfileModePresentation;
		[Field ("TVIBandwidthProfileModePresentation", "__Internal")]
		NSString TVIBandwidthProfileModePresentation { get; }

		// extern TVITrackSwitchOffMode  _Nonnull const TVITrackSwitchOffModeDisabled;
		[Field ("TVITrackSwitchOffModeDisabled", "__Internal")]
		NSString TVITrackSwitchOffModeDisabled { get; }

		// extern TVITrackSwitchOffMode  _Nonnull const TVITrackSwitchOffModePredicted;
		[Field ("TVITrackSwitchOffModePredicted", "__Internal")]
		NSString TVITrackSwitchOffModePredicted { get; }

		// extern TVITrackSwitchOffMode  _Nonnull const TVITrackSwitchOffModeDetected;
		[Field ("TVITrackSwitchOffModeDetected", "__Internal")]
		NSString TVITrackSwitchOffModeDetected { get; }

		// extern TVIClientTrackSwitchOffControl  _Nonnull const TVIClientTrackSwitchOffControlAuto;
		[Field ("TVIClientTrackSwitchOffControlAuto", "__Internal")]
		NSString TVIClientTrackSwitchOffControlAuto { get; }

		// extern TVIClientTrackSwitchOffControl  _Nonnull const TVIClientTrackSwitchOffControlManual;
		[Field ("TVIClientTrackSwitchOffControlManual", "__Internal")]
		NSString TVIClientTrackSwitchOffControlManual { get; }

		// extern TVIVideoContentPreferencesMode  _Nonnull const TVIVideoContentPreferencesModeAuto;
		[Field ("TVIVideoContentPreferencesModeAuto", "__Internal")]
		NSString TVIVideoContentPreferencesModeAuto { get; }

		// extern TVIVideoContentPreferencesMode  _Nonnull const TVIVideoContentPreferencesModeManual;
		[Field ("TVIVideoContentPreferencesModeManual", "__Internal")]
		NSString TVIVideoContentPreferencesModeManual { get; }
	}

	// @interface TVIVideoRenderDimensions : NSObject
	[BaseType (typeof(NSObject))]
	interface TVIVideoRenderDimensions
	{
		// @property (nonatomic, strong) TVIVideoDimensions * _Nullable low;
		[NullAllowed, Export ("low", ArgumentSemantic.Strong)]
		TVIVideoDimensions Low { get; set; }

		// @property (nonatomic, strong) TVIVideoDimensions * _Nullable standard;
		[NullAllowed, Export ("standard", ArgumentSemantic.Strong)]
		TVIVideoDimensions Standard { get; set; }

		// @property (nonatomic, strong) TVIVideoDimensions * _Nullable high;
		[NullAllowed, Export ("high", ArgumentSemantic.Strong)]
		TVIVideoDimensions High { get; set; }
	}

	// @interface TVIVideoBandwidthProfileOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoBandwidthProfileOptionsBuilder
	{
		// @property (copy, nonatomic) TVIClientTrackSwitchOffControl _Nullable clientTrackSwitchOffControl;
		[NullAllowed, Export ("clientTrackSwitchOffControl")]
		string ClientTrackSwitchOffControl { get; set; }

		// @property (copy, nonatomic) TVIVideoContentPreferencesMode _Nullable contentPreferencesMode;
		[NullAllowed, Export ("contentPreferencesMode")]
		string ContentPreferencesMode { get; set; }

		// @property (copy, nonatomic) TVITrackPriority _Nullable dominantSpeakerPriority;
		[NullAllowed, Export ("dominantSpeakerPriority")]
		string DominantSpeakerPriority { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable maxSubscriptionBitrate;
		[NullAllowed, Export ("maxSubscriptionBitrate", ArgumentSemantic.Strong)]
		NSNumber MaxSubscriptionBitrate { get; set; }

		// @property (nonatomic, strong) NSNumber * _Nullable maxTracks __attribute__((deprecated("Use the `clientTrackSwitchOffControl` property instead of `maxTracks`.")));
		[NullAllowed, Export ("maxTracks", ArgumentSemantic.Strong)]
		NSNumber MaxTracks { get; set; }

		// @property (copy, nonatomic) TVIBandwidthProfileMode _Nullable mode;
		[NullAllowed, Export ("mode")]
		string Mode { get; set; }

		// @property (nonatomic, strong) TVIVideoRenderDimensions * _Nullable renderDimensions __attribute__((deprecated("Use the `contentPreferencesMode` property instead of `renderDimensions`.")));
		[NullAllowed, Export ("renderDimensions", ArgumentSemantic.Strong)]
		TVIVideoRenderDimensions RenderDimensions { get; set; }

		// @property (copy, nonatomic) TVITrackSwitchOffMode _Nullable trackSwitchOffMode;
		[NullAllowed, Export ("trackSwitchOffMode")]
		string TrackSwitchOffMode { get; set; }
	}

	// typedef void (^TVIVideoBandwidthProfileOptionsBuilderBlock)(TVIVideoBandwidthProfileOptionsBuilder * _Nonnull);
	delegate void TVIVideoBandwidthProfileOptionsBuilderBlock (TVIVideoBandwidthProfileOptionsBuilder arg0);

	// @interface TVIVideoBandwidthProfileOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoBandwidthProfileOptions
	{
		// @property (readonly, copy, nonatomic) TVIClientTrackSwitchOffControl _Nonnull clientTrackSwitchOffControl;
		[Export ("clientTrackSwitchOffControl")]
		string ClientTrackSwitchOffControl { get; }

		// @property (readonly, copy, nonatomic) TVIVideoContentPreferencesMode _Nonnull contentPreferencesMode;
		[Export ("contentPreferencesMode")]
		string ContentPreferencesMode { get; }

		// @property (readonly, copy, nonatomic) TVITrackPriority _Nullable dominantSpeakerPriority;
		[NullAllowed, Export ("dominantSpeakerPriority")]
		string DominantSpeakerPriority { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable maxSubscriptionBitrate;
		[NullAllowed, Export ("maxSubscriptionBitrate", ArgumentSemantic.Strong)]
		NSNumber MaxSubscriptionBitrate { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable maxTracks __attribute__((deprecated("Use the `clientTrackSwitchOffControl` property instead of `maxTracks`.")));
		[NullAllowed, Export ("maxTracks", ArgumentSemantic.Strong)]
		NSNumber MaxTracks { get; }

		// @property (readonly, copy, nonatomic) TVIBandwidthProfileMode _Nullable mode;
		[NullAllowed, Export ("mode")]
		string Mode { get; }

		// @property (readonly, nonatomic, strong) TVIVideoRenderDimensions * _Nullable renderDimensions __attribute__((deprecated("Use the `contentPreferencesMode` property instead of `renderDimensions`.")));
		[NullAllowed, Export ("renderDimensions", ArgumentSemantic.Strong)]
		TVIVideoRenderDimensions RenderDimensions { get; }

		// @property (readonly, copy, nonatomic) TVITrackSwitchOffMode _Nullable trackSwitchOffMode;
		[NullAllowed, Export ("trackSwitchOffMode")]
		string TrackSwitchOffMode { get; }

		// +(instancetype _Nonnull)optionsWithBlock:(TVIVideoBandwidthProfileOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		TVIVideoBandwidthProfileOptions OptionsWithBlock (TVIVideoBandwidthProfileOptionsBuilderBlock block);
	}

	// @interface TVIVideoContentPreferencesBuilder : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoContentPreferencesBuilder
	{
		// @property (nonatomic, strong) TVIVideoDimensions * _Nullable renderDimensions;
		[NullAllowed, Export ("renderDimensions", ArgumentSemantic.Strong)]
		TVIVideoDimensions RenderDimensions { get; set; }
	}

	// typedef void (^TVIVideoContentPreferencesBuilderBlock)(TVIVideoContentPreferencesBuilder * _Nonnull);
	delegate void TVIVideoContentPreferencesBuilderBlock (TVIVideoContentPreferencesBuilder arg0);

	// @interface TVIVideoContentPreferences : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoContentPreferences
	{
		// @property (readonly, nonatomic, strong) TVIVideoDimensions * _Nullable renderDimensions;
		[NullAllowed, Export ("renderDimensions", ArgumentSemantic.Strong)]
		TVIVideoDimensions RenderDimensions { get; }

		// +(instancetype _Null_unspecified)preferencesWithBlock:(TVIVideoContentPreferencesBuilderBlock _Nonnull)block;
		[Static]
		[Export ("preferencesWithBlock:")]
		TVIVideoContentPreferences PreferencesWithBlock (TVIVideoContentPreferencesBuilderBlock block);
	}

	// @interface TVIVideoDimensions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVIVideoDimensions
	{
		// @property (assign, nonatomic) NSUInteger width;
		[Export ("width")]
		nuint Width { get; set; }

		// @property (assign, nonatomic) NSUInteger height;
		[Export ("height")]
		nuint Height { get; set; }

		// +(instancetype _Nonnull)dimensionsWithWidth:(NSUInteger)width height:(NSUInteger)height;
		[Static]
		[Export ("dimensionsWithWidth:height:")]
		TVIVideoDimensions DimensionsWithWidth (nuint width, nuint height);
	}

	// @protocol TVIVideoViewDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface TVIVideoViewDelegate
	{
		// @optional -(void)videoViewDidReceiveData:(TVIVideoView * _Nonnull)view __attribute__((swift_name("videoViewDidReceiveData(view:)")));
		[Export ("videoViewDidReceiveData:")]
		void VideoViewDidReceiveData (TVIVideoView view);

		// @optional -(void)videoView:(TVIVideoView * _Nonnull)view videoDimensionsDidChange:(CMVideoDimensions)dimensions __attribute__((swift_name("videoViewDimensionsDidChange(view:dimensions:)")));
		[Export ("videoView:videoDimensionsDidChange:")]
		void VideoView (TVIVideoView view, CMVideoDimensions dimensions);

		// @optional -(void)videoView:(TVIVideoView * _Nonnull)view videoOrientationDidChange:(TVIVideoOrientation)orientation __attribute__((swift_name("videoViewOrientationDidChange(view:dimensions:)")));
		[Export ("videoView:videoOrientationDidChange:")]
		void VideoView (TVIVideoView view, TVIVideoOrientation orientation);
	}

	// @interface TVIVideoView : UIView <TVIVideoRenderer>
	[BaseType (typeof(UIView))]
	interface TVIVideoView : ITVIVideoRenderer
	{
		// -(instancetype _Null_unspecified)initWithFrame:(CGRect)frame delegate:(id<TVIVideoViewDelegate> _Nullable)delegate;
		[Export ("initWithFrame:delegate:")]
		NativeHandle Constructor (CGRect frame, [NullAllowed] TVIVideoViewDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		TVIVideoViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVIVideoViewDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL viewShouldRotateContent;
		[Export ("viewShouldRotateContent")]
		bool ViewShouldRotateContent { get; set; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoDimensions;
		[Export ("videoDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions VideoDimensions { get; }

		// @property (readonly, assign, nonatomic) TVIVideoOrientation videoOrientation;
		[Export ("videoOrientation", ArgumentSemantic.Assign)]
		TVIVideoOrientation VideoOrientation { get; }

		// @property (readonly, assign, atomic) BOOL hasVideoData;
		[Export ("hasVideoData")]
		bool HasVideoData { get; }

		// @property (getter = shouldMirror, assign, nonatomic) BOOL mirror;
		[Export ("mirror")]
		bool Mirror { [Bind ("shouldMirror")] get; set; }
	}

	// @interface TVIVp8Codec : TVIVideoCodec
	[BaseType (typeof(TVIVideoCodec))]
	interface TVIVp8Codec
	{
		// @property (readonly, getter = isSimulcast, nonatomic) BOOL simulcast;
		[Export ("simulcast")]
		bool Simulcast { [Bind ("isSimulcast")] get; }

		// -(instancetype _Nonnull)initWithSimulcast:(BOOL)simulcast;
		[Export ("initWithSimulcast:")]
		NativeHandle Constructor (bool simulcast);
	}

	// @interface TVIVp9Codec : TVIVideoCodec
	[BaseType (typeof(TVIVideoCodec))]
	interface TVIVp9Codec
	{
	}

	// @interface TwilioVideoSDK : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface TwilioVideoSDK
	{
		// @property (nonatomic, strong, class) id<TVIAudioDevice> _Nonnull audioDevice;
		[Static]
		[Export ("audioDevice", ArgumentSemantic.Strong)]
		TVIAudioDevice AudioDevice { get; set; }

		// +(TVIRoom * _Nonnull)connectWithOptions:(TVIConnectOptions * _Nonnull)options delegate:(id<TVIRoomDelegate> _Nullable)delegate __attribute__((swift_name("connect(options:delegate:)")));
		[Static]
		[Export ("connectWithOptions:delegate:")]
		TVIRoom ConnectWithOptions (TVIConnectOptions options, [NullAllowed] TVIRoomDelegate @delegate);

		// +(NSString * _Nonnull)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		[Verify (MethodToProperty)]
		string SdkVersion { get; }

		// +(TVILogLevel)logLevel;
		// +(void)setLogLevel:(TVILogLevel)logLevel;
		[Static]
		[Export ("logLevel")]
		[Verify (MethodToProperty)]
		TVILogLevel LogLevel { get; set; }

		// +(TVILogLevel)logLevelForModule:(TVILogModule)module;
		[Static]
		[Export ("logLevelForModule:")]
		TVILogLevel LogLevelForModule (TVILogModule module);

		// +(void)setLogLevel:(TVILogLevel)logLevel module:(TVILogModule)module;
		[Static]
		[Export ("setLogLevel:module:")]
		void SetLogLevel (TVILogLevel logLevel, TVILogModule module);
	}
}
