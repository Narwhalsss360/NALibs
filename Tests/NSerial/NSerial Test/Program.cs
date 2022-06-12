﻿using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace NSerial_Test
{
    internal class Program
    {
        const byte MIN_MSG_SIZE = 5;
        const byte SOH = 0x01;
        static SerialPort port = new SerialPort();

        static void write()
        {
            Console.Write("Address: ");
            int address = int.Parse(Console.ReadLine());

            Console.Write("Data:");
            string dataInput = Console.ReadLine();
            
            int stringInt;
            if (dataInput.Substring(0, 1) == "N")
            {
                int.TryParse(dataInput.Substring(1, dataInput.Length - 1), out stringInt);
                byte[] bytes = new byte[8];
                bytes[0] = SOH;
                bytes[1] = 4;

                byte[] addressBytes = BitConverter.GetBytes(address);
                bytes[2] = addressBytes[1]; //LSB-First
                bytes[3] = addressBytes[0]; //LSB-First

                byte[] dataBytes = new byte[4];
                dataBytes = BitConverter.GetBytes(stringInt);

                bytes[4] = dataBytes[3]; //LSB-First
                bytes[5] = dataBytes[2]; //LSB-First
                bytes[6] = dataBytes[1]; //LSB-First
                bytes[7] = dataBytes[0]; //LSB-First

                port.Write(bytes, 0, bytes.Length);

                string echo = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    echo += $"0x{bytes[i].ToString("X2")}, ";
                }
                Console.Clear();
                Console.WriteLine($"Sent: {echo}\nReply:");
                Thread.Sleep(5);
                read();
            }
            else
            {
                byte[] bytes = new byte[dataInput.Length + MIN_MSG_SIZE - 1];
                bytes[0] = SOH;
                bytes[1] = (byte)dataInput.Length;

                byte[] addressBytes = BitConverter.GetBytes(address);
                bytes[2] = addressBytes[1]; //LSB-First
                bytes[3] = addressBytes[0]; //LSB-First

                byte[] dataBytes = Encoding.UTF8.GetBytes(dataInput);
                for (int i = 0; i < dataBytes.Length; i++)
                {
                    bytes[i + 4] = dataBytes[i];
                }

                port.DiscardInBuffer();
                port.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                port.DiscardOutBuffer();

                string echo = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    echo += $"0x{bytes[i].ToString("X2")}, ";
                }
                Console.Clear();
                Console.WriteLine($"Sent: {echo}\nReply:");
                Thread.Sleep(5);
                read();
            }
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

            Console.Clear();
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