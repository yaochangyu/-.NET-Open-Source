using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal abstract class AbsModbusResponse
    {
        private ModbusUtility _utility = new ModbusUtility();

        protected abstract byte FunctionCodePosition { get; set; }

        protected virtual ModbusUtility Utility
        {
            get { return _utility; }
            set { _utility = value; }
        }

        protected virtual void ExceptionValidate(byte[] ResponseArray)
        {
            if (ResponseArray == null | ResponseArray.Length <= FunctionCodePosition)
            {
                throw new ModbusException("No Response or Miss response data");
            }

            //exception
            var functionCode = ResponseArray[FunctionCodePosition];
            if (functionCode >= 80)
            {
                var exceptionCode = ResponseArray[FunctionCodePosition + 1];
                throw ModbusException.GetModbusException(exceptionCode);
            }
        }

        protected virtual void FunctionCodeValidate(byte[] RequestArray, byte[] ResponseArray, EnumModbusFunctionCode FunctionCodeFlag)
        {
            //function code valid
            if (RequestArray[FunctionCodePosition] != ResponseArray[FunctionCodePosition])
            {
                throw ModbusException.GetModbusException(0x01);
            }
            if ((byte)FunctionCodeFlag != RequestArray[FunctionCodePosition])
            {
                throw ModbusException.GetModbusException(0x01);
            }
            if ((byte)FunctionCodeFlag != ResponseArray[FunctionCodePosition])
            {
                throw ModbusException.GetModbusException(0x01);
            }
        }

        protected abstract void CheckDataValidate(byte[] ResponseArray);

        protected abstract byte[] GetResultArray(byte[] ResponseArray);

        public virtual byte[] ReadCoils(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.ReadCoils);
            this.CheckDataValidate(ResponseArray);
            var resultArray = GetResultArray(ResponseArray);
            return resultArray;
        }

        public virtual byte[] ReadDiscreteInputs(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.ReadDiscreteInputs);
            this.CheckDataValidate(ResponseArray);
            var resultArray = GetResultArray(ResponseArray);
            return resultArray;
        }

        public virtual byte[] ReadHoldingRegisters(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.ReadHoldingRegisters);
            this.CheckDataValidate(ResponseArray);
            var resultArray = GetResultArray(ResponseArray);
            return resultArray;
        }

        public virtual byte[] ReadInputRegisters(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.ReadInputRegisters);
            this.CheckDataValidate(ResponseArray);
            var resultArray = GetResultArray(ResponseArray);
            return resultArray;
        }

        public virtual byte[] WriteSingleCoil(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.WriteSingleCoil);
            this.CheckDataValidate(ResponseArray);
            return ResponseArray;
        }

        public virtual byte[] WriteSingleRegister(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.WriteSingleRegister);
            this.CheckDataValidate(ResponseArray);
            return ResponseArray;
        }

        public virtual byte[] WriteMultipleCoils(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.WriteMultipleCoils);
            this.CheckDataValidate(ResponseArray);
            return ResponseArray;
        }

        public virtual byte[] WriteMultipleRegisters(byte[] RequestArray, byte[] ResponseArray)
        {
            this.ExceptionValidate(ResponseArray);
            this.FunctionCodeValidate(RequestArray, ResponseArray, EnumModbusFunctionCode.WriteMultipleRegisters);
            this.CheckDataValidate(ResponseArray);
            return ResponseArray;
        }
    }
}