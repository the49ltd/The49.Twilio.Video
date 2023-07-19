//
//  TVIScreenContent.h
//  TwilioVideo
//
//  Copyright © 2020 Twilio, Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

/**
 *  `TVIScreenContent` specifies how `TVIAppScreenSource` should optimize the video format.
 */
typedef NS_ENUM(NSUInteger, TVIScreenContent) {
    /**
     *  Optimize video format for image sharpness and quality.
     */
    TVIScreenContentDefault = 0,
    /**
     *  Optimize video format for fluid motion.
     */
    TVIScreenContentVideo
}
NS_SWIFT_NAME(ScreenContent);
