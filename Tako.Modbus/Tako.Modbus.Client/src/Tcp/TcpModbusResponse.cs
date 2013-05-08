using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal class TcpModbusResponse : AbsModbusResponse
    {
        private byte _functionCodePosition = 7;

        protected override byte FunctionCodePosition
        {
            get { return _functionCodePosition; }
            set { _functionCodePosition = value; }
        }

        protected override void CheckDataValidate(byte[] ResponseArray)
        {
        }

        protected override byte[] GetResultArray(byte[] ResponseArray)
        {
            //get result data
            var counterPosition = this.FunctionCodePosition + 1;
            var counter = ResponseArray[counterPosition];
            var resultArray = new byte[counter];
            Array.Copy(ResponseArray, counterPosition + 1, resultArray, 0, counter);
            return resultArray;
        }
    }
}