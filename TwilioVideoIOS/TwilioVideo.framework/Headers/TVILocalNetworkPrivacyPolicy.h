//
//  TVILocalNetworkPrivacyPolicy.h
//  TwilioVideo
//
//  Copyright © 2020 Twilio, Inc. All rights reserved.
//

/**
 *  `TVILocalNetworkPrivacyPolicy` restricts which communication routes can be used to send and receive media with other Participants.
 *  Local addresses that are allowed by the policy are shared with other Participants. Remote addresses that are allowed by the policy
 *  are used for connectivity checks.
 *
 *  In order to ensure that end user privacy is respected the privacy policy is always applied equally to local and remote addresses.
 *  As a result, the Participant with the most restrictive privacy policy determines which routes are allowed in a Peer-to-Peer Room.
 */
typedef NS_ENUM(NSUInteger, TVILocalNetworkPrivacyPolicy) {
    /**
     *  Allow local network addresses. Select this policy if you have consent to send and receive media using the local network.
     */
    TVILocalNetworkPrivacyPolicyAllowAll = 0,

    /**
     *  Block the gathering and use of local network addresses. Unicast and multicast DNS resolution of remote hostnames is disabled.
     *  Select this policy if you do not want to take any actions that might result in a local network permissions request.
     */
    TVILocalNetworkPrivacyPolicyBlockLocal = 1
}
NS_SWIFT_NAME(LocalNetworkPrivacyPolicy);
