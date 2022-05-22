#include <NColor.h>
#include <NFuncs.h>
#include <NPush.h>
#include <NRotary.h>
#include <NTimer.h>
#include <NWire.h>
#include <NSerialCom.h>

#define BUTTON_PIN 3
#define BUTTON_DEBOUNCE 30
#define LED_PIN LED_BUILTIN
#define LED_INTERVAL 500

void ledToggleEvent(ElapsedEvent);
bool ledState = false;
Event ledEvent(0, PERIODIC, LED_INTERVAL, ledToggleEvent);

Push button(BUTTON_PIN, INPUT_PULLUP, BUTTON_DEBOUNCE);

void ledToggleEvent(ElapsedEvent e)
{
	ledState = !ledState;
	digitalWrite(LED_PIN, ledState);
}

void onButtonPress()
{
	Serial.println("Button pressed.");
	if (NTimer.getEventSettings(0)->enable)
		NTimer.stop(0);
	else
		NTimer.startCall(0);
}

void onButtonRelease(unsigned int holdTime)
{
	Serial.println("Button released, held for: " + String(holdTime) + ".");
}

void setup()
{
	Serial.begin(SERIALCOM_BAUD);
	button.onPress = onButtonPress;
	button.onRelease = onButtonRelease;
}

void loop()
{
	NTimer.update();
	button.update();
}