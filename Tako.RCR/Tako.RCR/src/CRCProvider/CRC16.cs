using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.CRC
{
    internal class CRC16 : AbsCRCProvider
    {
        //fields

        private uint _polynomial = 0xA001;
        private uint[] _crcTable = new uint[256];

        //property

        public override uint[] CRCTable
        {
            get { return _crcTable; }
        }

        public override uint Polynomial
        {
            get { return _polynomial; }
            set { _polynomial = value; }
        }

        public CRC16(uint Polynomial = 0xA001)
        {
            this.Polynomial = Polynomial;

            uint value;
            uint temp;
            for (uint i = 0; i < this.CRCTable.Length; ++i)
            {
                value = 0;
                temp = i;
                for (uint j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (value >> 1) ^ this.Polynomial;
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                this.CRCTable[i] = value;
            }
        }

        public override CRCStatus GetCRC(byte[] OriginalArray)
        {
            CRCStatus status = base.GetCRC(OriginalArray);
            ushort crc = 0;
            for (uint i = 0; i < OriginalArray.Length; ++i)
            {
                byte index = (byte)(crc ^ OriginalArray[i]);
                crc = (ushort)((crc >> 8) ^ this._crcTable[index]);
            }
            var crcArray = BitConverter.GetBytes(crc);

            base.GetCRCStatus(ref status, crc, crcArray, OriginalArray);
            return status;
        }
    }
}