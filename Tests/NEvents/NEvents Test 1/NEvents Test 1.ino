#include <NEvents.h>
#include <NTimer.h>
#include "Pin.h"

#define DEBOUNCE 15

uint32_t last;
Pin button = Pin(2, INPUT_PULLUP);

EVENT_FUNCTION(fallingEvent, args)
{
	Serial.println("Falling time: " + String(runtime));
}

EVENT_FUNCTION(risingEvent, args)
{
	Serial.println("Rising time: " + String(runtime));
}

EVENT_FUNCTION(changeEvent, args)
{
	Serial.println("Change time: " + String(runtime));
}

void setup()
{
	Serial.begin(1000000);
	button.falling += fallingEvent;
	button.rising += risingEvent;
	button.change += changeEvent;
}

void loop()
{
	if (interval(last, DEBOUNCE))
		button.update();
}