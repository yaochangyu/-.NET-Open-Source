using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.CRC
{
    public class CRCGlobalParams
    {
        internal static string[] s_Symbol = new string[] { " ", ",", "-", "|" };

        public static byte[] HexStringToBytes(string Hex)
        {
            if (string.IsNullOrEmpty(Hex))
            {
                throw new ArgumentNullException("Hex");
            }
            string filter = s_Symbol.Aggregate(Hex, (current, symbol) => current.Replace(symbol, ""));

            return Enumerable.Range(0, filter.Length)
                              .Where(x => x % 2 == 0)
                              .Select(x => Convert.ToByte(filter.Substring(x, 2), 16))
                              .ToArray();

            //ulong number = ulong.Parse(filter, System.Globalization.NumberStyles.AllowHexSpecifier);
            //return BitConverter.GetBytes(number);
        }

        public static string BytesToHexString(byte[] HexArray)
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