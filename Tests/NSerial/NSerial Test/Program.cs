using System;
using System.Timers;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace NSerial_Test
{
    internal class Program
    {
        const byte MIN_MSG_SIZE = 5;
        const byte SOH = 0x01;
        const byte ASCII_RETURN = 13;
        const byte ASCII_NEWLINE = 10;
        const byte STREAM_METADATA_START_OFFSET = 4;
        const byte STREAM_METADATA_SIZE = 6;
        const byte STREAM_MINUMUM_DATA_FULL_LENGTH = STREAM_METADATA_SIZE + 1;

        static bool saftiness = false;
        static SerialPort port = new SerialPort();

        static void write()
        {
            saftiness = false;
        redo:
            Console.WriteLine();
            Console.Write("Address: ");

            ushort address;
            if (!ushort.TryParse(Console.ReadLine(), out address))
            {
                Console.WriteLine("Enter a valid number");
                goto redo;
            }

            byte[] addresBytes = BitConverter.GetBytes(address);

            Console.Write("Data: ");
            string dataInput = Console.ReadLine();

            byte[] inputBytes = Encoding.UTF8.GetBytes(dataInput);
            byte[] buffer = new byte[inputBytes.Length + STREAM_METADATA_SIZE];

            buffer[0] = SOH;
            buffer[1] = ((byte)inputBytes.Length);
            buffer[2] = addresBytes[0];
            buffer[3] = addresBytes[1];

            for (int i = 0; i < inputBytes.Length; i++)
            {
                buffer[i + STREAM_METADATA_START_OFFSET] = inputBytes[i];
            }

            buffer[buffer.Length - 2] = ASCII_RETURN;
            buffer[buffer.Length - 1] = ASCII_NEWLINE;
            Console.Write("Wrote: ");
            for (int i = 0; i < buffer.Length; i++)
            {
                Console.Write($" [{i}]: {buffer[i]}");
            }
            Console.WriteLine('\n');
            port.DataReceived -= onDataRecieve;
            port.Write(buffer, 0, buffer.Length);
            saftiness = true;
            port.DataReceived += onDataRecieve;
        }

        static void rawWrite()
        {
        redo:
            Console.Write($"{port.PortName} > ");
            string input = Console.ReadLine();
            if (input == null || input == string.Empty) goto redo;

            byte[] bytes = Encoding.ASCII.GetBytes(input);
            port.Write(bytes, 0, bytes.Length);
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

                if (size >= MIN_MSG_SIZE)
                    break;

                output += $"0x{inChar.ToString("X2")}, ";
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
            Console.Write("Enter Port Name: ");
            port.PortName = $"{Console.ReadLine()}";
            Console.Write("Enter Baudrate: ");
            port.BaudRate = int.Parse(Console.ReadLine());
            //port.DataReceived += onDataRecieve;
            port.Open();
            Thread.Sleep(1);
            port.DiscardInBuffer();
            write();
            while (true);
        }

        static void onDataRecieve(object sender, SerialDataReceivedEventArgs args)
        {
            SerialPort sp = (SerialPort)sender;
            string timeStamp = $"{DateTime.Now.Minute.ToString().PadLeft(0, '0')}:{DateTime.Now.Second.ToString().PadLeft(0, '0')}:{DateTime.Now.Millisecond.ToString().PadLeft(2, '0')}";
            byte[] bytes = new byte[sp.BytesToRead];
            sp.Read(bytes, 0, bytes.Length);
            sp.DiscardInBuffer();
            if (saftiness) write();
        }
    }
}
