using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal class RtuModbusRequest : AbsModbusRequest
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
                memory.WriteByte((byte)Unit);
                memory.WriteByte((byte)FunctionCode);
                memory.Write(Parameters, 0, Parameters.Length);

                var crcArray = ModbusUtility.CalculateCRC(memory.ToArray());
                memory.Write(crcArray, 0, crcArray.Length);
                return memory.ToArray();
            }
        }
    }
}