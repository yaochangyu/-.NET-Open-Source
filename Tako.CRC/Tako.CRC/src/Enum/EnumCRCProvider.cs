﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.CRC
{
    public enum EnumCRCProvider
    {
        CRC16,
        CRC16CCITT_0x0000,
        CRC16CCITT_0xFFFF,
        CRC16CCITT_0x1D0F,
        CRC16Kermit,
        CRC16Modbus,
        CRC32,
        CRC8,
        CRC8CCITT,
        CRC8DALLASMAXIM,
        CRC8SAEJ1850,
        CRC8WCDMA
    }
}