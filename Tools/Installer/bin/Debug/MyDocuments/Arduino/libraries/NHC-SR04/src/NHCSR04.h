#ifndef NHCSR04
#define NHCSR04

#if defined(ARDUINO) && ARDUINO >= 100
    #include "Arduino.h"
#else
    #include "WProgram.h"
#endif

#define MM_IN 0.03937
#define MM_CM 0.1
#define MICROS_OFFSET 3198
#define SENSOR_MM 5.8
#define SENSOR_CM 58
#define SENSOR_TRIGGER_TIME 10
#define DEFAULT_MAX 100

class SR04
{
private:
    const byte triggerPin,
        echoPin;
    const uint16_t maxTime;
    uint16_t time;
public:
    SR04(byte, byte, uint16_t = DEFAULT_MAX);
    uint16_t ping();
    double millimeters(bool = true);
    double centimeters(bool = true);
    double inches(bool = true);
};

#endif