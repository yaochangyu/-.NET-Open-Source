﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.CRC
{
    public abstract class AbsCRCProvider
    {
        internal string[] _symbol = new string[] { " ", ",", "-", "|" };

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
                    string filter = _symbol.Aggregate(OriginalData, (current, symbol) => current.Replace(symbol, ""));
                    dataArray = Encoding.ASCII.GetBytes(filter);
                    break;

                case EnumOriginalDataFormat.HEX:
                    dataArray = HexStringToBytes(OriginalData);
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

            status.CrcDecimal = CRC;
            var crcHex = CRC.ToString("X");

            if (crcHex.Length > 2 && crcHex.Length < 4)
            {
                status.CrcHexadecimal = crcHex.PadLeft(4, '0');
            }
            else if (crcHex.Length > 4 && crcHex.Length < 8)
            {
                status.CrcHexadecimal = crcHex.PadLeft(8, '0');
            }
            else
            {
                status.CrcHexadecimal = crcHex;
            }
            byte[] fullData = new byte[OriginalArray.Length + CrcArray.Length];
            Array.Copy(OriginalArray, fullData, OriginalArray.Length);
            var reverseCrcArray = new byte[CrcArray.Length];
            Array.Copy(CrcArray, reverseCrcArray, CrcArray.Length);

            Array.Reverse(reverseCrcArray);
            status.CrcArray = reverseCrcArray;

            Array.Copy(reverseCrcArray, reverseCrcArray.GetLowerBound(0), fullData, OriginalArray.GetUpperBound(0) + 1, reverseCrcArray.Length);

            status.FullDataArray = fullData;

            switch (DataFormat)
            {
                case EnumOriginalDataFormat.ASCII:
                    status.FullDataHexadecimal = Encoding.ASCII.GetString(OriginalArray) + status.CrcHexadecimal;
                    break;

                case EnumOriginalDataFormat.HEX:
                    status.FullDataHexadecimal = BytesToHexString(OriginalArray) + status.CrcHexadecimal;
                    break;
            }

            //return status;
        }

        public virtual byte[] HexStringToBytes(string Hex)
        {
            if (string.IsNullOrEmpty(Hex))
            {
                throw new ArgumentNullException("Hex");
            }
            string filter = _symbol.Aggregate(Hex, (current, symbol) => current.Replace(symbol, ""));

            return Enumerable.Range(0, filter.Length)
                              .Where(x => x % 2 == 0)
                              .Select(x => Convert.ToByte(filter.Substring(x, 2), 16))
                              .ToArray();

            //ulong number = ulong.Parse(filter, System.Globalization.NumberStyles.AllowHexSpecifier);
            //return BitConverter.GetBytes(number);
        }

        public virtual string BytesToHexString(byte[] HexArray)
        {
            if (HexArray == null || HexArray.Length <= 0)
            {
                throw new ArgumentNullException("HexArray");
            }

            var result = BitConverter.ToString(HexArray).Replace("-", "");
            return result;
        }
    }
}