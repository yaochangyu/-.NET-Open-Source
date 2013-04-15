using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tako.CRC;

namespace Tako.CRC
{
    public abstract class AbsCRCProvider
    {
        protected abstract uint[] CRCTable { get; }

        protected abstract uint Polynomial { get; set; }

        internal virtual EnumOriginalDataFormat DataFormat { get; set; }

        public virtual CRCStatus GetCRC(string OriginalData)
        {
            if (string.IsNullOrEmpty(OriginalData))
            {
                throw new ArgumentNullException("OriginalData");
            }
            byte[] dataArray = null;

            switch (DataFormat)
            {
                case EnumOriginalDataFormat.ASCII:
                    string filter = CRCGlobalParams.s_Symbol.Aggregate(OriginalData, (current, symbol) => current.Replace(symbol, ""));
                    dataArray = Encoding.ASCII.GetBytes(filter);
                    break;

                case EnumOriginalDataFormat.HEX:
                    dataArray = CRCGlobalParams.HexStringToBytes(OriginalData);
                    break;
            }
            CRCStatus status = this.GetCRC(dataArray);
            return status;
        }

        public virtual CRCStatus GetCRC(byte[] OriginalArray)
        {
            if (OriginalArray == null || OriginalArray.Length <= 0)
            {
                throw new ArgumentNullException("OriginalArray");
            }

            return new CRCStatus();
        }

        protected void GetCRCStatus(ref CRCStatus status, uint CRC, byte[] CrcArray, byte[] OriginalArray)
        {
            //0xC57A
            //C5 is hi byte
            //7A is low byte

            status.CheckSumValue = CRC;
            var crcHex = CRC.ToString("X");

            if (crcHex.Length > 2 && crcHex.Length < 4)
            {
                status.CheckSum = crcHex.PadLeft(4, '0');
            }
            else if (crcHex.Length > 4 && crcHex.Length < 8)
            {
                status.CheckSum = crcHex.PadLeft(8, '0');
            }
            else
            {
                status.CheckSum = crcHex;
            }
            byte[] fullData = new byte[OriginalArray.Length + CrcArray.Length];
            Array.Copy(OriginalArray, fullData, OriginalArray.Length);
            var reverseCrcArray = new byte[CrcArray.Length];
            Array.Copy(CrcArray, reverseCrcArray, CrcArray.Length);

            Array.Reverse(reverseCrcArray);
            status.CheckSumArray = reverseCrcArray;

            Array.Copy(reverseCrcArray, reverseCrcArray.GetLowerBound(0), fullData, OriginalArray.GetUpperBound(0) + 1, reverseCrcArray.Length);

            status.FullDataArray = fullData;

            switch (DataFormat)
            {
                case EnumOriginalDataFormat.ASCII:
                    status.FullData = Encoding.ASCII.GetString(OriginalArray) + status.CheckSum;
                    break;

                case EnumOriginalDataFormat.HEX:
                    status.FullData = CRCGlobalParams.BytesToHexString(OriginalArray) + status.CheckSum;
                    break;
            }

            //return status;
        }
    }
}