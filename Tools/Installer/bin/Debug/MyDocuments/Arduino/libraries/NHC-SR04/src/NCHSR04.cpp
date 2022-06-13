#include "NHCSR04.h"

SR04::SR04(byte _triggerPin, byte _echoPin, uint16_t maxCentimeters = DEFAULT_MAX)
    :triggerPin(_triggerPin), echoPin(_echoPin), maxTime((maxCentimeters * SENSOR_CM) + MICROS_OFFSET)
{
    pinMode(triggerPin, OUTPUT);
    pinMode(echoPin, INPUT);
}

uint16_t SR04::ping()
{
    digitalWrite(triggerPin, HIGH);
    delayMicroseconds(SENSOR_TRIGGER_TIME);
    digitalWrite(triggerPin, LOW);
    time = pulseIn(echoPin, HIGH, maxTime);
    return time;
}

double SR04::millimeters(bool doPing = true)
{
    if (doPing)
        ping();
    if (time == 0)
        return (maxTime - MICROS_OFFSET) / SENSOR_MM;
    return time / SENSOR_MM;
}

double SR04::centimeters(bool doPing = true)
{
    return millimeters(doPing) * MM_CM;
}

double SR04::inches(bool doPing = true)
{
    return millimeters(doPing) * MM_IN;
}