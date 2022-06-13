#ifndef NFuncs_h
#define NFuncs_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "Arduino.h"
#else
	#include "WProgram.h"
#endif

#include <NDefs.h>

#define NFUNCS_MAJOR_VERSION 1
#define NFUNCS_MINOR_VERSION 1
#define NFUNCS_PATCH_VERSION 0

#define BCD2DEC(num) hornerScheme(num, 0x10, 10)

unsigned long x2i(char *);

unsigned long x2i(char *, uint8_t);

String toHex(unsigned long, byte);

int octalToDecimal(int);

double mapf(double, double, double, double, double);

unsigned long hornerScheme(unsigned long, unsigned long, unsigned long);

String boolToString(int);

String fromRight(String, String, byte);

#endif