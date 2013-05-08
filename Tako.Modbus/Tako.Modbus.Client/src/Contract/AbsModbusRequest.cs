﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Globalization;
using System.IO;

namespace Tako.Modbus.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal abstract class AbsModbusRequest
    {
        private ModbusUtility _modbusUtility = new ModbusUtility();

        protected ModbusUtility ModbusUtility
        {
            get { return _modbusUtility; }
            set { _modbusUtility = value; }
        }

        public virtual ushort? TransactionID { get; set; }

        protected virtual void QuantityValidate(ushort StartAddress, ushort Quantity, ushort MinQuantity, ushort MaxQuantity)
        {
            if (Quantity < MinQuantity || Quantity > MaxQuantity)
            {
                throw ModbusException.GetModbusException(0x03);
            }
        }

        protected virtual byte GetByteCount(ushort Quantity)
        {
            byte i = (byte)(Quantity / 8);
            byte j = (byte)(Quantity - (i * 8));

            byte counter = 0;
            if (j == 0)
            {
                counter = i;
            }
            else
            {
                counter = (byte)(i + 1);
            }

            return counter;
        }

        protected virtual byte[] GetByteCount(short[] OutputValues)
        {
            byte counter = 0;
            byte[] outputArray = null;

            using (MemoryStream stream = new MemoryStream())
            {
                foreach (var output in OutputValues)
                {
                    var tempArray = BitConverter.GetBytes((short)output);
                    Array.Reverse(tempArray);
                    stream.Write(tempArray, 0, tempArray.Length);
                    counter += (byte)tempArray.Length;
                }

                outputArray = stream.ToArray();
            }
            return outputArray;
        }

        public abstract byte[] ReadCoils(byte Unit, ushort StartAddress, ushort Quantity);

        public abstract byte[] ReadDiscreteInputs(byte Unit, ushort StartAddress, ushort Quantity);

        public abstract byte[] ReadHoldingRegisters(byte Unit, ushort StartAddress, ushort Quantity);

        public abstract byte[] ReadInputRegisters(byte Unit, ushort StartAddress, ushort Quantity);

        public abstract byte[] WriteSingleCoil(byte Unit, ushort OutputAddress, bool OutputValue);

        public abstract byte[] WriteSingleRegister(byte Unit, ushort OutputAddress, short OutputValue);

        public abstract byte[] WriteMultipleCoils(byte Unit, ushort StartAddress, ushort Quantity, byte[] OutputValues);

        public abstract byte[] WriteMultipleRegisters(byte Unit, ushort StartAddress, ushort Quantity, short[] OutputValues);
    }
}