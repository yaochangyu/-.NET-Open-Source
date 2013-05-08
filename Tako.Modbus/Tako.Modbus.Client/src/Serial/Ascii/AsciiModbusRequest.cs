﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal class AsciiModbusRequest : AbsModbusRequest
    {
        public override byte[] ReadCoils(byte Unit, ushort StartAddress, ushort Quantity)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 2000);
            var requestArray = this.createReadMessage(Unit, EnumModbusFunctionCode.ReadCoils, StartAddress, Quantity);
            return requestArray;
        }

        public override byte[] ReadDiscreteInputs(byte Unit, ushort StartAddress, ushort Quantity)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 2000);
            var requestArray = this.createReadMessage(Unit, EnumModbusFunctionCode.ReadDiscreteInputs, StartAddress, Quantity);
            return requestArray;
        }

        public override byte[] ReadHoldingRegisters(byte Unit, ushort StartAddress, ushort Quantity)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 175);
            var requestArray = this.createReadMessage(Unit, EnumModbusFunctionCode.ReadHoldingRegisters, StartAddress, Quantity);
            return requestArray;
        }

        public override byte[] ReadInputRegisters(byte Unit, ushort StartAddress, ushort Quantity)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 175);
            var requestArray = this.createReadMessage(Unit, EnumModbusFunctionCode.ReadInputRegisters, StartAddress, Quantity);
            return requestArray;
        }

        public override byte[] WriteSingleCoil(byte Unit, ushort OutputAddress, bool OutputValue)
        {
            ushort outputValue = 0x0000;
            if (OutputValue)
            {
                outputValue = 0xFF00;
            }
            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte(Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteSingleCoil);
                memory.WriteByte((byte)(OutputAddress >> 8));
                memory.WriteByte((byte)OutputAddress);
                memory.WriteByte((byte)(outputValue >> 8));
                memory.WriteByte((byte)(outputValue));
                var aduArray = toAsciiData(memory.ToArray());
                return aduArray;
            }
        }

        public override byte[] WriteSingleRegister(byte Unit, ushort OutputAddress, short OutputValue)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteSingleRegister);
                memory.WriteByte((byte)(OutputAddress >> 8));
                memory.WriteByte((byte)(OutputAddress));
                memory.WriteByte((byte)(OutputValue >> 8));
                memory.WriteByte((byte)(OutputValue));

                var aduArray = toAsciiData(memory.ToArray());
                return aduArray;
            }
        }

        public override byte[] WriteMultipleCoils(byte Unit, ushort StartAddress, ushort Quantity, byte[] OutputValues)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 0x07B0);

            byte counter = base.GetByteCount(Quantity);

            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteMultipleCoils);
                memory.WriteByte((byte)(StartAddress >> 8));
                memory.WriteByte((byte)(StartAddress));
                memory.WriteByte((byte)(Quantity >> 8));
                memory.WriteByte((byte)(Quantity));
                memory.WriteByte((byte)(counter));

                memory.Write(OutputValues, 0, OutputValues.Length);

                var lrc = ModbusUtility.CalculateLRC(memory.ToArray());
                var pdu = ModbusUtility.BytesToHexString(memory.ToArray());
                var adu = Encoding.ASCII.GetBytes(ModbusUtility.ASCII_START_SYMBOL + pdu + lrc + ModbusUtility.ASCII_END_SYMBOL);
                return adu;
            }
        }

        public override byte[] WriteMultipleRegisters(byte Unit, ushort StartAddress, ushort Quantity, short[] OutputValues)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 0x007B);

            var outputArray = base.GetByteCount(OutputValues);
            byte counter = (byte)outputArray.Length;
            if (Quantity * 2 != outputArray.Length)
            {
                ModbusException.GetModbusException(0x02);
            }

            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteMultipleRegisters);
                memory.WriteByte((byte)(StartAddress >> 8));
                memory.WriteByte((byte)(StartAddress));
                memory.WriteByte((byte)(Quantity >> 8));
                memory.WriteByte((byte)(Quantity));
                memory.WriteByte((byte)(counter));
                memory.Write(outputArray, 0, outputArray.Length);
                var aduArray = toAsciiData(memory.ToArray());
                return aduArray;
            }
        }

        private byte[] createReadMessage(byte Unit, EnumModbusFunctionCode FunctionCode, ushort StartAddress, ushort Quantity)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte(Unit);
                memory.WriteByte((byte)FunctionCode);
                memory.WriteByte((byte)(StartAddress >> 8));
                memory.WriteByte((byte)StartAddress);
                memory.WriteByte((byte)(Quantity >> 8));
                memory.WriteByte((byte)(Quantity));
                var aduArray = toAsciiData(memory.ToArray());
                return aduArray;
            }
        }

        private byte[] toAsciiData(byte[] OriginalArray)
        {
            var lrc = ModbusUtility.CalculateLRC(OriginalArray);
            var pdu = ModbusUtility.BytesToHexString(OriginalArray);
            var adu = Encoding.ASCII.GetBytes(ModbusUtility.ASCII_START_SYMBOL + pdu + lrc + ModbusUtility.ASCII_END_SYMBOL);
            return adu;
        }
    }
}