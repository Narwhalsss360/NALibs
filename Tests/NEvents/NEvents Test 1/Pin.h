#pragma once

enum STATESBITS
{
	CURRENT,
	PREVIOUS
};

class Pin
{
public:
	Pin(uint8_t _pin, uint8_t _mode)
		: pin(_pin), mode(_mode), args(EventArgs(this))
	{

	}

	event rising;
	event falling;
	event change;

	virtual bool value()
	{
		return digitalRead(pin);
	}

	virtual void value(bool state)
	{
		if (mode == OUTPUT)
		{
			digitalWrite(pin, state);
		}
	}

	virtual void update()
	{
		if (mode != OUTPUT)
		{
			bitWrite(states, CURRENT, digitalRead(pin));

			if (bitRead(states, CURRENT) != bitRead(states, PREVIOUS))
			{
				if (bitRead(states, CURRENT))
				{
					rising.invoke(&args);
				}
				else
				{
					falling.invoke(&args);
				}

				change.invoke(&args);

				bitWrite(states, PREVIOUS, bitRead(states, CURRENT));
			}
		}
	}

	~Pin()
	{

	}
private:
	uint8_t states;
	const uint8_t pin;
	const uint8_t mode;
	EventArgs args;
};