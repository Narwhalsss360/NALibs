#include <NPush.h>
#include <NTimer.h>
#include <LiteTimer.h>

Push button(3, INPUT_PULLUP, 30);

NTimer timer = NTimer();

#define LED_TOGGLE_ID 0
#define LED_TOGGLE_INTERVAL 0
#define LED_PIN LED_BUILTIN

#define LED1_TOGGLE_ID 1
#define LED1_TOGGLE_INTERVAL 250
#define LED1_PIN 7

NEW_ELAPSEDEVENT(ledToggle);
NTimerEvent ledEvent(LED_TOGGLE_ID, LED_TOGGLE_INTERVAL, ledToggle);

NEW_ELAPSEDEVENT(led1Toggle);
NTimerEvent led1Event(LED1_TOGGLE_ID, LED1_TOGGLE_INTERVAL, led1Toggle);

ELAPSEDEVENT_FUNCTION(ledToggle, args)
{
	digitalWrite(LED_PIN, HIGH);
	timer.delay(500, LED_TOGGLE_ID, NPush_h_loop);
	digitalWrite(LED_PIN, LOW);
	timer.delay(500, LED_TOGGLE_ID, NPush_h_loop);
}

ELAPSEDEVENT_FUNCTION(led1Toggle, args)
{
	digitalWrite(LED1_PIN, !digitalRead(LED1_PIN));
}

ONPUSH_ESR(onPush, data,
{
	Serial.println("Button pushed.");
});

#define FUNC a

void a()
{

}

void setup()
{
	Serial.begin(1000000);
	pinMode(LED_PIN, OUTPUT);
	pinMode(LED1_PIN, OUTPUT);
	button.onPush += onPush;
	timer += ledEvent;
	timer += led1Event;
	timer.start();
	FUNC();
}

void loop()
{
}