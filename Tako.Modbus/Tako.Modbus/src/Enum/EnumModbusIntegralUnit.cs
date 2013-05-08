using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.Modbus
{
    public enum EnumModbusIntegralUnit : byte
    {
        Byte = 1, Word = 2, DWord = 4, QWord = 8
    }
}