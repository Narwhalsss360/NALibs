#define MANUAL_BUTTON_UPDATE
#include <NPush.h>

#define WHILE_TRUE_TEST
#define ONPRESS_METHOD_TEST
#define ONRELEASE_METHOD_TEST
#define ONPRESS_CALLBACK_TEST
#define ONRELEASE_CALLBACK_TEST

#define BAUDRATE 1000000
#define BUTTON_PIN 3
#define BUTTON_DEBOUNCE 30

Push button(BUTTON_PIN, INPUT_PULLUP, BUTTON_DEBOUNCE);

#ifdef ONPRESS_CALLBACK_TEST
void onPress()
{
	Serial.println("Button pressed, onPress() callback");
}
#endif

#ifdef ONRELEASE_CALLBACK_TEST
void onRelease(unsigned int holdTime)
{
	Serial.println("Button released, held for: " + String(holdTime) + ". onRelease() callback");
}
#endif

void setup()
{
	Serial.begin(BAUDRATE);
#ifdef ONPRESS_CALLBACK_TEST
	button.onPress = onPress;
#endif
#ifdef ONPRESS_CALLBACK_TEST
	button.onRelease = onRelease;
#endif
}

void loop()
{
#ifdef MANUAL_BUTTON_UPDATE
	button.update();
#endif

#ifdef ONPRESS_METHOD_TEST
	if (button.pressed())
	{
		Serial.println("Button pressed.");
	}
#endif

#ifdef WHILE_TRUE_TEST
	while (button.current())
	{
		uint16_t holdTime = button.getPushedHoldTime(); 
		Serial.println("Button has been held for: " + String(holdTime));
	}
#endif

#ifdef ONRELEASE_METHOD_TEST
	if (button.released())
	{
		uint16_t holdTime = button.getReleasedHoldTime(); 
		Serial.println("Button released, held for: " + String(holdTime));
	}
#endif
}