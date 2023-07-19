//
//  TVIAudioSink.h
//  TwilioVideo
//
//  Copyright © 2017 Twilio, Inc. All rights reserved.
//

#import <CoreMedia/CoreMedia.h>

/**
 *  TVIAudioSink consumes raw audio content from a TVIAudioTrack.
 */
NS_SWIFT_NAME(AudioSink)
@protocol TVIAudioSink <NSObject>

/**
 *  @brief Render a single audio sample.
 *
 *  @discussion Samples are delivered in a `CMSampleBuffer` which fully describes the format and timings of the audio.
 *  Please note that many audio frames are contained within a single CMSampleBuffer.
 *  Callbacks are raised at presentation time with an interval of 10 milliseconds.
 *  The `CMSampleBuffer`s are suitable to pass to Apple APIs like `AVAssetWriterInput`, or `SFSpeechAudioBufferRecognitionRequest`.
 *  However, you should ensure that you process each sample in a real-time fashion. Holding on to seconds worth of audio
 *  will result in future samples being dropped.
 *
 *  @param audioSample A CMSampleBufferRef which is being delivered to the sink. You should retain this if you need it
 *  outside of the scope of this method call.
 */
- (void)renderSample:(CMSampleBufferRef)audioSample;

@end

