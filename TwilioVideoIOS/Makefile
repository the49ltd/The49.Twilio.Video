BINARY_NAME := TwilioVideo
XC_FRAMEWORK_PATH := TwilioVideo.xcframework
IPHONE_FRAMEWORK_PATH := $(XC_FRAMEWORK_PATH)/ios-arm64/TwilioVideo.framework
SIMULATOR_FRAMEWORK_PATH := $(XC_FRAMEWORK_PATH)/ios-arm64_x86_64-simulator/TwilioVideo.framework
BINDINGS_PATH := Bindings
IOS_SDK_VERSION := 16.4

build: clean
	cp -R "$(IPHONE_FRAMEWORK_PATH)" "./Release-fat"
	cp -R "$(SIMULATOR_FRAMEWORK_PATH)" "./Release-simulator"

	lipo -remove arm64 "./Release-simulator/$(BINARY_NAME)" -o "./Release-simulator/$(BINARY_NAME)"

	lipo -create "$(IPHONE_FRAMEWORK_PATH)/$(BINARY_NAME)" "./Release-simulator/$(BINARY_NAME)" -output "./Release-fat/$(BINARY_NAME).framework/$(BINARY_NAME)"

	cp -Rf "./Release-fat/$(BINARY_NAME).framework" "./"

	sharpie bind --sdk=iphoneos$(IOS_SDK_VERSION) --output="$(BINDINGS_PATH)" --namespace="Twilio" --scope="$(BINARY_NAME).framework/Headers" "$(BINARY_NAME).framework/Headers/TwilioVideo.h"
	
clean:
	rm -Rf $(BINDINGS_PATH)
	rm -Rf ./Release-simulator

.PHONY: clean build
