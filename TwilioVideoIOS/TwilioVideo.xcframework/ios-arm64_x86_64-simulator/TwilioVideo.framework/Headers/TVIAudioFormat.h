//
//  TVIAudioFormat.h
//  TwilioVideo
//
//  Copyright © 2018 Twilio, Inc. All rights reserved.
//

#import <CoreAudio/CoreAudioTypes.h>

/**
 *  Audio Sample Rate 8000 Hz
 */
extern uint32_t const TVIAudioSampleRate8000
NS_SWIFT_NAME(AudioFormat.SampleRate8000);

/**
 *  Audio Sample Rate 16000 Hz
 */
extern uint32_t const TVIAudioSampleRate16000
NS_SWIFT_NAME(AudioFormat.SampleRate16000);

/**
 *  Audio Sample Rate 24000 Hz
 */
extern uint32_t const TVIAudioSampleRate24000
NS_SWIFT_NAME(AudioFormat.SampleRate24000);

/**
 *  Audio Sample Rate 32000 Hz
 */
extern uint32_t const TVIAudioSampleRate32000
NS_SWIFT_NAME(AudioFormat.SampleRate32000);

/**
 *  Audio Sample Rate 44100 Hz
 */
extern uint32_t const TVIAudioSampleRate44100
NS_SWIFT_NAME(AudioFormat.SampleRate44100);

/**
 *  Audio Sample Rate 48000 Hz
 */
extern uint32_t const TVIAudioSampleRate48000
NS_SWIFT_NAME(AudioFormat.SampleRate48000);

/**
 *  Mono audio channels
 */
extern size_t const TVIAudioChannelsMono
NS_SWIFT_NAME(AudioFormat.ChannelsMono);

/**
 *  Stereo audio channels
 */
extern size_t const TVIAudioChannelsStereo
NS_SWIFT_NAME(AudioFormat.ChannelsStereo);

/**
 *  TVIAudioFormat describes audio that is captured or rendered via a `TVIAudioDevice`. The class also offers
 *  convenience methods to help interoperate with CoreAudio and size your audio buffers appropriately.
 */
NS_SWIFT_NAME(AudioFormat)
@interface TVIAudioFormat : NSObject

/**
 *  @brief The number of channels in the audio stream.
 *
 *  @discussion Valid values for this property are either 1 or 2. Only mono and stereo LPCM audio are supported.
 */
@property (nonatomic, assign, readonly) size_t numberOfChannels;

/**
 *  @brief The sample rate of the audio stream in units of frequency (Hz), i.e. the number of audio samples per second.
 *
 *  @discussion Valid values for this property are 8000, 16000, 24000, 32000, 44100 and 48000 Hz.
 */
@property (nonatomic, assign, readonly) uint32_t sampleRate;

/**
 *  @brief The maximum number of frames contained in a single audio buffer.
 *
 *  @discussion The underlying media engine operates on 10 millisecond slices of LPCM audio. Ideally, your audio device
 *  should capture and render in exactly 10 millisecond buffers. However, in many cases this is not possible on iOS.
 *  If you're using AudioUnits to produce or consume audio you should use `AVAudioSession.preferredIOBufferDuration`
 *  to request appropriately sized buffers.
 */
@property (nonatomic, assign, readonly) size_t framesPerBuffer;

/**
 *  @brief Developers shouldn't use init to create `TVIAudioFormat`.
 *
 *  @discussion Use `initWithChannels:sampleRate:framesPerBuffer:` instead.
 */
- (null_unspecified instancetype)init __attribute__((unavailable("TVIAudioFormat can not be created with init")));

/**
 *  @brief Initializes an instance of `TVIAudioFormat`.
 *
 *  @param channels The number of channels in the audio stream.
 *  @param sampleRate The sample rate of the audio stream.
 *  @param framesPerBuffer The maximum number of frames contained in a single audio stream buffer.
 *
 *  @return An instance of `TVIAudioFormat`, which is immutable once created. Returns `nil` if one or more parameters
 *  passed to the initializer are not supported by the SDK.
 *
 *  @discussion `TVIAudioFormat` describes signed 16-bit LPCM audio. This is the working format used to interoperate
 *  between `TVIAudioDevice` and the underlying media engine. Please note that the media engine may be forced to perform
 *  a format conversion depending on the codecs used for sending and receiving audio. For example, ISAC accepts mono
 *  32 kHz audio while OPUS accepts mono or stereo at 48 kHz.
 *
 *  @see [TVIAudioCodec](TVIAudioCodec.h)
 */
- (nullable instancetype)initWithChannels:(size_t)channels
                               sampleRate:(uint32_t)sampleRate
                          framesPerBuffer:(size_t)framesPerBuffer;

/**
 *  @brief Computes the required buffer size for a given audio format.
 *
 *  @return The required buffer size, in bytes, to work with a given `TVIAudioFormat`.
 *
 *  @discussion This helper method can be used to size audio buffers appropriately.
 */
- (size_t)bufferSize;

/**
 *  @brief Generates an audio stream description which can be used with CoreAudio.
 *
 *  @return An `AudioStreamBasicDescription` which reflects the properties of the `TVIAudioFormat` being queried.
 *
 *  @discussion `AudioStreamBasicDescription` can be used to describe many different constant bitrate audio formats.
 *  Since `TVIAudioFormat` defines only signed 16-bit LPCM audio there is a well known transformation between the two.
 */
- (AudioStreamBasicDescription)streamDescription;

@end
