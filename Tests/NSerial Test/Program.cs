using System;
using System.IO.Ports;
namespace NSerial_Test
{
    internal class Program
    {
        const byte EOT = 0x04;
        static SerialPort port = new SerialPort();

        static void write()
        {

        }

        static void read()
        {
            string output = $"{DateTime.Now.Minute.ToString().PadLeft(2, '0')}:{DateTime.Now.Second.ToString().PadLeft(2, '0')}:{DateTime.Now.Millisecond.ToString().PadLeft(3, '0')} →";
            int size = 0;
            while (true)
            {
                if (port.BytesToRead == 0)
                {
                    if (size == 0)
                    {
                        return;
                    }
                    break;
                }

                byte inChar = (byte)port.ReadByte();
                
                if (inChar == EOT && size >= 6)
                    break;
                
                output += $"0x{ inChar.ToString("X2") }, ";
                size++;
                
                if (size > 38)
                {
                    port.DiscardInBuffer();
                    break;
                }
            }
            Console.WriteLine(output);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Port Name:");
            port.PortName = $"{ Console.ReadLine() }";
            Console.Write("Enter Baudrate:");
            port.BaudRate = int.Parse(Console.ReadLine());

            string rw;
            while (true)
            {
                Console.Write("R/W:");
                rw = Console.ReadLine().ToUpper();
                
                if (rw == "R" || rw == "W")
                    break;
                Console.WriteLine();
            }

            port.Open();
            port.DiscardInBuffer();
            if (rw == "R")
                while (true)
                    read();
            else
                while (true)
                    write();
        }
    }
}
