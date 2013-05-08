using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tako.CRC;

namespace Tako.Modbus
{
    public class ModbusUtility
    {
        public readonly static string ASCII_START_SYMBOL = ":";
        public readonly static string ASCII_END_SYMBOL = "\r\n";

        private CRCManager m_CrcManager = new CRCManager();
        private AbsCRCProvider m_CrcProvider;
        private string[] s_Symbol = new string[] { " ", ",", "-" };

        public string BytesToBinaryString(byte[] HexArray)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var b in HexArray)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public byte[] HexStringToBytes(string Hex)
        {
            string filter = s_Symbol.Aggregate(Hex, (current, symbol) => current.Replace(symbol, ""));

            return Enumerable.Range(0, filter.Length)
                              .Where(x => x % 2 == 0)
                              .Select(x => Convert.ToByte(filter.Substring(x, 2), 16))
                              .ToArray();
        }

        public string BytesToHexString(byte[] HexArray)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var b in HexArray)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        public string CalculateLRC(byte[] DataArray)
        {
            if (DataArray == null)
                throw new ArgumentNullException("data");

            byte lrc = 0;
            foreach (byte b in DataArray)
            {
                lrc += b;
            }

            lrc = (byte)((lrc ^ 0xFF) + 1);

            var hex = lrc.ToString("X2");
            return hex;
        }

        public byte[] CalculateCRC(byte[] DataArray)
        {
            if (m_CrcProvider == null)
            {
                m_CrcProvider = m_CrcManager.CreateCRCProvider(EnumCRCProvider.CRC16Modbus);
            }
            var crcArray = m_CrcProvider.GetCRC(DataArray).CrcArray;
            Array.Reverse(crcArray);
            return crcArray;
        }
    }
}