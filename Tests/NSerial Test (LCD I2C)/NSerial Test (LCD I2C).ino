#include <NSerialCom.h>
#include <LiquidCrystal_I2C.h>

#define LCD_ADDR 0x27
#define LCD_COLS 20
#define LCD_ROWS 4

#define UINT32_ADDR 0x01
#define STRING_ADDR 0x02

LiquidCrystal_I2C display(LCD_ADDR, LCD_COLS, LCD_ROWS);

uint32_t receivedNumber = 0;
String receivedString = "";

void onReceive(NSD data, const char* raw)
{
	display.setCursor(0, 0);
	display.print("A: ");
	display.print(data.address);

	if (data.address == UINT32_ADDR)
	{
		data.get(receivedNumber);
		display.print(receivedNumber);
	}
	else
	{
		data.get(receivedString);
		data.get(receivedString);
	}
}

void setup()
{
	Serial.begin(SERIALCOM_BAUD);
	NSerial.onReceive = onReceive;
	
	display.init();
	display.setBacklight(255);
	display.setCursor(0, 0);
	display.print("Set up");
}

void loop()
{

}