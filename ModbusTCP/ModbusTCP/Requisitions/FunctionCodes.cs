using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Runtime;

namespace ModbusTCP
{
    static class FunctionCodes
    {
        private static byte HighByte(int value)
        {
            return (byte)((value >> 8) & 0xFF);
        }
        private static byte LowByte(int value)
        {
            return (byte)(value & 0xFF);
        }
        static public Tuple<byte[], int> ReadCoilStatus(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x01;
            int numberBytesToRead = (quantityRegister / 8);
            int sizeBufferExpected = 8;

            byte[] buffer = {HighByte(addressSlave), functionCode, LowByte(firstRegister), HighByte(firstRegister),
            LowByte(quantityRegister),HighByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);
        }
        static public Tuple<byte[], int> ReadInputStatus(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x02;
            int numberBytesToRead = (quantityRegister / 8);
            int sizeBufferExpected = 8;

            byte[] buffer = {HighByte(addressSlave), functionCode, LowByte(firstRegister), HighByte(firstRegister),
            LowByte(quantityRegister),HighByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);
        }
        static public Tuple<byte[], int> ReadHoldingRegisters(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x03;
            quantityRegister = 16;
            int numberBytesToRead = quantityRegister / 8;
            int sizeBufferExpected = 8;
            //ainda não ta lendo o ID e os registradores
            byte[] buffer = {LowByte(addressSlave), functionCode, HighByte(firstRegister), LowByte(firstRegister),
            HighByte(quantityRegister),LowByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);
        }
        static public Tuple<byte[], int> ReadInputRegisters(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x04;
            int numberBytesToRead = (quantityRegister / 8);
            int sizeBufferExpected = 8;

            byte[] buffer = {HighByte(addressSlave), functionCode, LowByte(firstRegister), HighByte(firstRegister),
            LowByte(quantityRegister),HighByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);

        }
        static public Tuple<byte[], int> ForceSingleCoil(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x05;
            int numberBytesToRead = (quantityRegister / 8);
            int sizeBufferExpected = 8;

            byte[] buffer = {HighByte(addressSlave), functionCode, LowByte(firstRegister), HighByte(firstRegister),
            LowByte(quantityRegister),HighByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);
        }
        static public Tuple<byte[], int> PresetSingleRegister(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x06;
            int numberBytesToRead = (quantityRegister / 8);
            int sizeBufferExpected = 8;

            byte[] buffer = {HighByte(addressSlave), functionCode, LowByte(firstRegister), HighByte(firstRegister),
            LowByte(quantityRegister),HighByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);
        }
        static public Tuple<byte[], int> ForceMultipleCoils(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x0F;
            int numberBytesToRead = (quantityRegister / 8);
            int sizeBufferExpected = 8;

            byte[] buffer = {HighByte(addressSlave), functionCode, LowByte(firstRegister), HighByte(firstRegister),
            LowByte(quantityRegister),HighByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);
        }
        static public Tuple<byte[], int> PresetMultipleRegisters(int addressSlave, int firstRegister, int quantityRegister)
        {
            byte functionCode = 0x10;
            int numberBytesToRead = (quantityRegister / 8);
            int sizeBufferExpected = 8 * 2;

            byte[] buffer = {HighByte(addressSlave), functionCode, LowByte(firstRegister), HighByte(firstRegister),
            LowByte(quantityRegister),HighByte(quantityRegister)};
            byte[] response = buffer.ToList().Concat(CheckSum.Calculate(buffer).ToList()).ToArray();

            return new Tuple<byte[], int>(response, sizeBufferExpected);
        }
    }
}