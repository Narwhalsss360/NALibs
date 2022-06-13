#include <NHCSR04.h>

int baudrate = 9600;

int triggerPin = 2;
int echoPin = 3;

SR04 sensor(triggerPin, echoPin);

double cm;
double mm;
double in;

void setup()
{
    Serial.begin(baudrate);
}

void loop()
{
    sensor.ping();
    cm = sensor.centimeters(false); //false to not send another ping. We dont need to again.
    mm = sensor.millimeters(false); //false to not send another ping.
    in = sensor.inches(false); //false to not send another ping.

    Serial.print("cm: ");
    Serial.print(cm)
    Serial.print(" mm: ");
    Serial.print(mm)
    Serial.print(" in: ");
    Serial.println(in)
}