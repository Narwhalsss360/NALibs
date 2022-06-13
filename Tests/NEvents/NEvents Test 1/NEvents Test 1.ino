#include <NEvents.h>
#include <NTimer.h>
#include "Pin.h"

#define NONE
#define LAMBDA(capture, args, defenition) [capture](args) defenition
#define SIMPLE_LAMBDA(defenition) []() defenition
#define EVENT_LAMBDA(defenition) [](EventArgs* args) defenition
#define DEBOUNCE 25

uint32_t last;
Pin button = Pin(2, INPUT_PULLUP);
uint32_t pressCount = ZERO;

EVENT_FUNCTION(fallingEvent, args)
{
	Serial.println("Falling time: " + String(runtime));
}

EVENT_FUNCTION(risingEvent, args)
{
	Serial.println("Rising time: " + String(runtime));
}

void setup()
{
	Serial.begin(1000000);
	button.falling += fallingEvent;
	button.rising += risingEvent;
	button.change += EVENT_LAMBDA({ Serial.println("Change time: " + String(runtime)); });
}

void loop()
{
	if (interval(last, DEBOUNCE))
		button.update();
}