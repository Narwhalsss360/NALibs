#include <NDefs.h>
#include <NColor.h>
#include <NFuncs.h>
#include <NPush.h>
#include <NRotary.h>
#include <NTimer.h>
#include <NWire.h>


#pragma region NColor
constexpr byte LED_RED_PIN = 7;
constexpr byte LED_GREEN_PIN = 8;
constexpr byte LED_BLUE_PIN = 9;
RGBA rgba(BYTE_MAX, BYTE_MAX, BYTE_MAX, BYTE_MAX);
RGB rgb(BYTE_MAX, BYTE_MAX, BYTE_MAX);
HSV hsv(360, 100, 100);
Color color;
RGBLed rgbLed(LED_RED_PIN, LED_GREEN_PIN, LED_BLUE_PIN);
#pragma endregion

void setup()
{

}

void loop() 
{
  
}