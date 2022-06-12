#include <LiquidCrystal_I2C.h>
#include <NSerialCom.h>

#define LCD_ADDR 0x27
#define LCD_COLS 20
#define LCD_ROWS 4

#define UINT32_ADDR 0x01
#define STRING_ADDR 0x02

#define WAIT_TIME 3

LiquidCrystal_I2C display(LCD_ADDR, LCD_COLS, LCD_ROWS);

uint32_t receivedNumber = 0;
String receivedString = "";

char stream[38] = { 0 };
uint8_t count = 0;

struct TestStruct
{
	uint8_t length;
	uint8_t* data;
	void get(uint16_t &out)
	{
		out = reinterpret_c_style(uint16_t, data);
	}
	TestStruct()
		:data(nullptr), length(NULL)
	{

	}
	TestStruct(void* pData, uint8_t len)
	{
		length = len;
		data = new uint8_t[len];
		if (data == nullptr)
		{
			len = 0;
			return;
		}
		memmove(data, pData, len);
	}
	~TestStruct()
	{
		delete[] data;
	}
};

void se()
{
	count = 0;
	while (Serial.available())
	{
		stream[count] = (char)Serial.read();
		count++;
		delayMicroseconds(WAIT_TIME);
	}

	if (stream[0] == 1)
	{
		char* sizeHex = stream + 1;
		char* addressHex = stream + 3;
		char* rawData = stream + 7;

		uint8_t size = x2i(sizeHex, 2);
		uint16_t address = x2i(addressHex, 4);
		uint32_t data = x2i(rawData, size * 2);

		Serial.print("Size: ");
		Serial.print(size);
		Serial.print(" Address: ");
		Serial.print(address);
		Serial.print(" Data: ");
		Serial.println(data);
	}

	for (size_t i = 0; i < 38; i++)
	{
		stream[i] = 0;
	}
}

void onRecv(NSD d, uint8_t* r)
{
	Serial.println("Called: ");
	uint32_t data;
	d.get(data);

	Serial.print("	Address: ");
	Serial.println(d.address);

	Serial.print("	Size: ");
	Serial.println(d.length);

	Serial.print("	Data: ");
	Serial.println(data);

	Serial.print("	Pointing to: ");
	Serial.println((size_t)d.data);
}

void setup()
{
	Serial.begin(1000000);
	display.init();
	display.setBacklight(255);
	display.setCursor(0, 0);
	display.print("Set up");
	NSerial.onReceive = onRecv;
}

void testLoop()
{
	char data[] = "FFEEFFEE";

	NSD nsd(3, &data, 8);
	String parsedData;
	nsd.get(parsedData);

	Serial.print("Pointing to: ");
	Serial.print((uint16_t)nsd.data);

	Serial.print(", Size: ");
	Serial.print(nsd.length);

	Serial.print(", Data[0]: ");
	Serial.print(nsd.data[0], HEX);

	Serial.print(", Data[1]: ");
	Serial.print(nsd.data[1], HEX);

	Serial.print(", Parsed: ");
	Serial.println(parsedData);

	delay(1000);
}

void loop()
{
}