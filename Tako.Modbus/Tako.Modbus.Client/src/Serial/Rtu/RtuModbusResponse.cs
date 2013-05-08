using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal class RtuModbusResponse : AbsModbusResponse
    {
        private byte _functionCodePosition = 1;

        protected override byte FunctionCodePosition
        {
            get { return _functionCodePosition; }
            set { _functionCodePosition = value; }
        }

        protected override void CheckDataValidate(byte[] ResponseArray)
        {
            var sourceCrcArray = new byte[2];
            Array.Copy(ResponseArray, ResponseArray.Length - 2, sourceCrcArray, 0, sourceCrcArray.Length);
            var sourceDataArray = new byte[ResponseArray.Length - 2];
            Array.Copy(ResponseArray, 0, sourceDataArray, 0, sourceDataArray.Length);
            var destinationCrcArray = Utility.CalculateCRC(sourceDataArray);
            if (!sourceCrcArray.SequenceEqual(destinationCrcArray))
            {
                throw new ModbusException("CRC Validate Fail");
            }
        }

        protected override byte[] GetResultArray(byte[] ResponseArray)
        {
            var counterPosition = this.FunctionCodePosition + 1;
            var position = ResponseArray[counterPosition];
            var resultArray = new byte[position];
            Array.Copy(ResponseArray, counterPosition + 1, resultArray, 0, resultArray.Length);
            return resultArray;
        }
    }
}