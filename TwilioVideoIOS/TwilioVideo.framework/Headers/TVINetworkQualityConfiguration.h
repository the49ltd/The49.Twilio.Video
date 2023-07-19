//
//  TVINetworkQualityConfiguration.h
//  TwilioVideo
//
//  Copyright © 2020 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
*  @brief The verbosity level of Network Quality information for a Participant.
*/
typedef NS_ENUM(NSUInteger, TVINetworkQualityVerbosity) {
    /**
     * Nothing is reported for the Participant. This is not a valid option for the LocalParticipant.
     */
    TVINetworkQualityVerbosityNone = 0,
    /** Reports only the NetworkQualityLevel for the Participant.
     */
    TVINetworkQualityVerbosityMinimal
}
NS_SWIFT_NAME(NetworkQualityVerbosity);

/**
 * @brief `TVINetworkQualityConfiguration` allows you to specify verbosity levels of Network Quality information returned
 * by the Network Quality API.
 */
NS_SWIFT_NAME(NetworkQualityConfiguration)
@interface TVINetworkQualityConfiguration : NSObject

/**
 * @brief The `TVINetworkQualityVerbosity` for the Local Participant.
 */
@property(nonatomic, readonly, assign) TVINetworkQualityVerbosity local;

/**
 * @brief The `TVINetworkQualityVerbosity` for the Remote Participants.
 */
@property(nonatomic, readonly, assign) TVINetworkQualityVerbosity remote;

/**
 * @brief Initializes a `TVINetworkQualityConfiguration` object with the default values, `TVINetworkQualityVerbosityMinimal`
 * for the Local Participant and `TVINetworkQualityVerbosityNone` for the Remote Participants.
 */
- (nonnull instancetype)init;

/**
 * @brief Initalizes a `TVINetworkQualityConfiguration` object with the provided `TVINetworkQualityVerbosity` levels.
 *
 * @param local The `TVINetworkQualityVerbosity` for the Local Participant. `TVINetworkQualityVerbosityNone` is invalid
 * for the Local Participant and will throw an NSInvalidArgumentException.
 * @param remote The `TVINetworkQualityVerbosity` for the Remote Participants.
 */
- (nullable instancetype)initWithLocalVerbosity:(TVINetworkQualityVerbosity)local remoteVerbosity:(TVINetworkQualityVerbosity)remote NS_DESIGNATED_INITIALIZER;

@end
