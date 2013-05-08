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
    using System.Linq;
    using System.Text;

    public abstract class AbsModbusClient : IModbusTransport, IDisposable
    {
        //fields

        private int _receiveTimeout = 1000;
        private int _sendTimeout = 1000;
        private bool _isConnected = false;
        private int _retryTime = 10;
        private ushort? _transactionID;

        //virtual properties
        public virtual bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }

        public virtual int ReceiveTimeout
        {
            get { return _receiveTimeout; }
            set { _receiveTimeout = value; }
        }

        public virtual int SendTimeout
        {
            get { return _sendTimeout; }
            set { _sendTimeout = value; }
        }

        public virtual int RetryTime
        {
            get { return _retryTime; }
            set { _retryTime = value; }
        }

        public virtual ushort? TransactionID
        {
            get { return _transactionID; }
            set
            {
                _transactionID = value;
                this.ModbusRequest.TransactionID = value;
            }
        }

        protected virtual bool Disposed
        {
            get;
            set;
        }

        //abstract properties
        internal abstract AbsModbusRequest ModbusRequest { get; set; }

        internal abstract AbsModbusResponse ModbusResponse { get; set; }

        internal abstract AbsModbusDataConvert ModbusDataConvert { get; set; }

        //virtual method
        public virtual byte[] SendAndReceive(byte[] RequestArray)
        {
            if (RequestArray == null)
            {
                throw new ArgumentNullException("RequestArray");
            }
            Send(RequestArray);
            var resultArray = Receive();
            return resultArray;
        }

        //abstract method
        public abstract bool Disconnect();

        public abstract byte[] Receive();

        public abstract bool Send(byte[] RequestArray);

        public abstract bool Connect<T>(T ConnectConfig);

        public abstract void Dispose();

        public virtual byte[] ReadCoils(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var requestArray = this.ModbusRequest.ReadCoils(Unit, StartAddress, Quantity);
            var responseArray = SendAndReceive(requestArray);
            var result = this.ModbusResponse.ReadCoils(requestArray, responseArray);
            return result;
        }

        public virtual IEnumerable<long> ReadCoilsToDecimal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadCoils(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToDecimal(resultArray, EnumModbusIntegralUnit.Byte);
        }

        public virtual IEnumerable<string> ReadCoilsToBinary(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadCoils(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToBinary(resultArray, EnumModbusIntegralUnit.Byte);
        }

        public virtual IEnumerable<long> ReadCoilsToOctal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadCoils(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToOctal(resultArray, EnumModbusIntegralUnit.Byte);
        }

        public virtual byte[] ReadDiscreteInputs(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var requestArray = this.ModbusRequest.ReadDiscreteInputs(Unit, StartAddress, Quantity);
            var responseArray = SendAndReceive(requestArray);
            var result = this.ModbusResponse.ReadCoils(requestArray, responseArray);
            return result;
        }

        public virtual IEnumerable<long> ReadDiscreteInputsToDecimal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadDiscreteInputs(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToDecimal(resultArray, EnumModbusIntegralUnit.Byte);
        }

        public virtual IEnumerable<string> ReadDiscreteInputsToBinary(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadDiscreteInputs(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToBinary(resultArray, EnumModbusIntegralUnit.Byte);
        }

        public virtual IEnumerable<long> ReadDiscreteInputsToOctal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadDiscreteInputs(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToOctal(resultArray, EnumModbusIntegralUnit.Byte);
        }

        public virtual byte[] ReadHoldingRegisters(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var requestArray = this.ModbusRequest.ReadHoldingRegisters(Unit, StartAddress, Quantity);
            var responseArray = SendAndReceive(requestArray);
            var result = this.ModbusResponse.ReadHoldingRegisters(requestArray, responseArray);
            return result;
        }

        public virtual IEnumerable<long> ReadHoldingRegistersToDecimal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadHoldingRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToDecimal(resultArray, EnumModbusIntegralUnit.Word);
        }

        public virtual IEnumerable<string> ReadHoldingRegistersToBinary(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadHoldingRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToBinary(resultArray, EnumModbusIntegralUnit.Word);
        }

        public virtual IEnumerable<long> ReadHoldingRegistersToOctal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadHoldingRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToOctal(resultArray, EnumModbusIntegralUnit.Word);
        }

        public virtual IEnumerable<float> ReadHoldingRegistersToFloat(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadHoldingRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToFloat(resultArray);
        }

        public virtual IEnumerable<double> ReadHoldingRegistersToDouble(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadHoldingRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToDouble(resultArray);
        }

        public virtual byte[] ReadInputRegisters(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var requestArray = this.ModbusRequest.ReadInputRegisters(Unit, StartAddress, Quantity);
            var responseArray = SendAndReceive(requestArray);
            var result = this.ModbusResponse.ReadInputRegisters(requestArray, responseArray);
            return result;
        }

        public virtual IEnumerable<long> ReadInputRegistersToDecimal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadInputRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToDecimal(resultArray, EnumModbusIntegralUnit.Word);
        }

        public virtual IEnumerable<string> ReadInputRegistersToBinary(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadInputRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToBinary(resultArray, EnumModbusIntegralUnit.Word);
        }

        public virtual IEnumerable<long> ReadInputRegistersToOctal(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadInputRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToOctal(resultArray, EnumModbusIntegralUnit.Word);
        }

        public virtual IEnumerable<float> ReadInputRegistersToFloat(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadInputRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToFloat(resultArray);
        }

        public virtual IEnumerable<double> ReadInputRegistersTDouble(byte Unit, ushort StartAddress, ushort Quantity)
        {
            var resultArray = this.ReadInputRegisters(Unit, StartAddress, Quantity);
            return this.ModbusDataConvert.ToDouble(resultArray);
        }

        public virtual bool WriteSingleCoil(byte Unit, ushort OutputAddress, bool OutputValue)
        {
            var requestArray = this.ModbusRequest.WriteSingleCoil(Unit, OutputAddress, OutputValue);
            var responseArray = SendAndReceive(requestArray);
            var result = this.ModbusResponse.WriteSingleCoil(requestArray, responseArray);
            return result != null;
        }

        public virtual bool WriteSingleRegister(byte Unit, ushort OutputAddress, short OutputValue)
        {
            var requestArray = this.ModbusRequest.WriteSingleRegister(Unit, OutputAddress, OutputValue);
            var responseArray = SendAndReceive(requestArray);
            var result = this.ModbusResponse.WriteSingleRegister(requestArray, responseArray);
            return result != null;
        }

        public virtual bool WriteMultipleCoils(byte Unit, ushort StartAddress, ushort Quantity, byte[] OutputValues)
        {
            var requestArray = this.ModbusRequest.WriteMultipleCoils(Unit, StartAddress, Quantity, OutputValues);
            var responseArray = SendAndReceive(requestArray);
            var result = this.ModbusResponse.WriteMultipleCoils(requestArray, responseArray);
            return result != null;
        }

        public virtual bool WriteMultipleRegisters(byte Unit, ushort StartAddress, ushort Quantity, short[] OutputValues)
        {
            var requestArray = this.ModbusRequest.WriteMultipleRegisters(Unit, StartAddress, Quantity, OutputValues);
            var responseArray = SendAndReceive(requestArray);

            var result = this.ModbusResponse.WriteMultipleRegisters(requestArray, responseArray);
            return result != null;
        }
    }
}