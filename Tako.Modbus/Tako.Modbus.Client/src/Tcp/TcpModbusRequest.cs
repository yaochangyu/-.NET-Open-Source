﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Tako.Modbus.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class TcpModbusRequest : AbsModbusRequest
    {
        private ushort? _transaction;
        private readonly ushort MODBUS_PROTOCOL = 0;
        private readonly ushort MODBUS_DEFAULT_LENGTH = 6;

        private byte[] createReadMessage(byte Unit, EnumModbusFunctionCode FunctionCode, ushort StartAddress, ushort Quantity)
        {
            if (this.TransactionID != null)
            {
                this._transaction = TransactionID;
            }
            if (this._transaction == null)
            {
                this._transaction = 0;
            }

            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)(this._transaction >> 8));
                memory.WriteByte((byte)this._transaction);
                memory.WriteByte((byte)(MODBUS_PROTOCOL >> 8));
                memory.WriteByte((byte)MODBUS_PROTOCOL);
                memory.WriteByte((byte)(MODBUS_DEFAULT_LENGTH >> 8));
                memory.WriteByte((byte)MODBUS_DEFAULT_LENGTH);
                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)FunctionCode);
                memory.WriteByte((byte)(StartAddress >> 8));
                memory.WriteByte((byte)(StartAddress));
                memory.WriteByte((byte)(Quantity >> 8));
                memory.WriteByte((byte)(Quantity));
                this._transaction++;

                return memory.ToArray();
            }
        }

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
            if (this.TransactionID != null)
            {
                this._transaction = TransactionID;
            }
            if (this._transaction == null)
            {
                this._transaction = 0;
            }

            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)(this._transaction >> 8));
                memory.WriteByte((byte)this._transaction);
                memory.WriteByte((byte)(MODBUS_PROTOCOL >> 8));
                memory.WriteByte((byte)MODBUS_PROTOCOL);
                memory.WriteByte((byte)(MODBUS_DEFAULT_LENGTH >> 8));
                memory.WriteByte((byte)MODBUS_DEFAULT_LENGTH);
                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteSingleCoil);
                memory.WriteByte((byte)(OutputAddress >> 8));
                memory.WriteByte((byte)(OutputAddress));
                memory.WriteByte((byte)(outputValue >> 8));
                memory.WriteByte((byte)(outputValue));
                this._transaction++;

                return memory.ToArray();
            }
        }

        public override byte[] WriteSingleRegister(byte Unit, ushort OutputAddress, short OutputValue)
        {
            if (this.TransactionID != null)
            {
                this._transaction = TransactionID;
            }
            if (this._transaction == null)
            {
                this._transaction = 0;
            }

            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)(this._transaction >> 8));
                memory.WriteByte((byte)this._transaction);
                memory.WriteByte((byte)(MODBUS_PROTOCOL >> 8));
                memory.WriteByte((byte)MODBUS_PROTOCOL);
                memory.WriteByte((byte)(MODBUS_DEFAULT_LENGTH >> 8));
                memory.WriteByte((byte)MODBUS_DEFAULT_LENGTH);
                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteSingleRegister);
                memory.WriteByte((byte)(OutputAddress >> 8));
                memory.WriteByte((byte)(OutputAddress));
                memory.WriteByte((byte)(OutputValue >> 8));
                memory.WriteByte((byte)(OutputValue));
                this._transaction++;

                return memory.ToArray();
            }
        }

        public override byte[] WriteMultipleCoils(byte Unit, ushort StartAddress, ushort Quantity, byte[] OutputValues)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 0x07B0);

            byte counter = base.GetByteCount(Quantity);

            if (counter != OutputValues.Length)
            {
                ModbusException.GetModbusException(0x03);
            }

            if (this.TransactionID != null)
            {
                this._transaction = TransactionID;
            }
            if (this._transaction == null)
            {
                this._transaction = 0;
            }

            ushort dataLength = (ushort)(MODBUS_DEFAULT_LENGTH + OutputValues.Length + 1);
            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)(this._transaction >> 8));
                memory.WriteByte((byte)this._transaction);
                memory.WriteByte((byte)(MODBUS_PROTOCOL >> 8));
                memory.WriteByte((byte)MODBUS_PROTOCOL);

                memory.WriteByte((byte)(dataLength >> 8));
                memory.WriteByte((byte)dataLength);

                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteMultipleCoils);
                memory.WriteByte((byte)(StartAddress >> 8));
                memory.WriteByte((byte)(StartAddress));
                memory.WriteByte((byte)(Quantity >> 8));
                memory.WriteByte((byte)(Quantity));
                memory.WriteByte((byte)(counter));
                memory.Write(OutputValues, 0, OutputValues.Length);
                this._transaction++;

                return memory.ToArray();
            }
        }

        public override byte[] WriteMultipleRegisters(byte Unit, ushort StartAddress, ushort Quantity, short[] OutputValues)
        {
            this.QuantityValidate(StartAddress, Quantity, 1, 0x007B);

            byte[] outputArray = base.GetByteCount(OutputValues);
            byte counter = (byte)outputArray.Length;

            if (Quantity * 2 != outputArray.Length)
            {
                ModbusException.GetModbusException(0x02);
            }
            if (this.TransactionID != null)
            {
                this._transaction = TransactionID;
            }
            if (this._transaction == null)
            {
                this._transaction = 0;
            }
            ushort dataLength = (ushort)(MODBUS_DEFAULT_LENGTH + counter + 1);
            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte((byte)(this._transaction >> 8));
                memory.WriteByte((byte)this._transaction);
                memory.WriteByte((byte)(MODBUS_PROTOCOL >> 8));
                memory.WriteByte((byte)MODBUS_PROTOCOL);

                memory.WriteByte((byte)(dataLength >> 8));
                memory.WriteByte((byte)dataLength);

                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)EnumModbusFunctionCode.WriteMultipleRegisters);
                memory.WriteByte((byte)(StartAddress >> 8));
                memory.WriteByte((byte)(StartAddress));
                memory.WriteByte((byte)(Quantity >> 8));
                memory.WriteByte((byte)(Quantity));
                memory.WriteByte((byte)(counter));
                memory.Write(outputArray, 0, outputArray.Length);

                this._transaction++;

                return memory.ToArray();
            }
        }
    }
}