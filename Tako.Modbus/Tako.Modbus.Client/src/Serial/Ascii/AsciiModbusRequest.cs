using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal class AsciiModbusRequest : AbsModbusRequest
    {
        protected override byte[] CreateRequestMessage(byte Unit, EnumModbusFunctionCode FunctionCode, byte? MultiOutputLength, params byte[] Parameters)
        {
            ushort dataLength = 0;
            if (MultiOutputLength == null)
            {
                dataLength = 0;
            }
            else
            {
                dataLength = (ushort)(MultiOutputLength + 1);
            }
            using (MemoryStream memory = new MemoryStream())
            {
                memory.WriteByte(Unit);
                memory.WriteByte((byte)FunctionCode);
                memory.Write(Parameters, 0, Parameters.Length);

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