using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal class AsciiModbusDataConvert : AbsModbusDataConvert
    {
        public override byte[] ResultArray { get; internal set; }

        public override IEnumerable<long> ToDecimal(byte[] ResultArray, EnumModbusIntegralUnit Unit)
        {
            var length = ((int)Unit) * 2;
            if (ResultArray == null)
            {
                throw new ArgumentNullException("ResultArray");
            }
            if (ResultArray.Length <= 0 || ResultArray.Length < length)
            {
                throw new FormatException("ResultArray");
            }
            this.ResultArray = ResultArray;

            List<long> resultList = new List<long>();
            for (int i = 0; i < ResultArray.Length; i = i + length)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(ResultArray, i, length);
                    var tempArray = memory.ToArray();

                    var hex = Encoding.ASCII.GetString(tempArray);
                    long result = 0;
                    switch (Unit)
                    {
                        case EnumModbusIntegralUnit.Byte:
                            result = Convert.ToInt16(hex, 16);
                            break;

                        case EnumModbusIntegralUnit.Word:
                            result = Convert.ToInt16(hex, 16);
                            break;

                        case EnumModbusIntegralUnit.DWord:
                            result = Convert.ToInt32(hex, 16);
                            break;

                        case EnumModbusIntegralUnit.QWord:
                            result = Convert.ToInt64(hex, 16);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException("Unit");
                    }

                    resultList.Add(result);
                }
            }
            return resultList;
        }

        public override IEnumerable<long> ToOctal(byte[] ResultArray, EnumModbusIntegralUnit Unit)
        {
            var length = ((int)Unit) * 2;
            if (ResultArray == null)
            {
                throw new ArgumentNullException("ResultArray");
            }
            if (ResultArray.Length <= 0 || ResultArray.Length < length)
            {
                throw new FormatException("ResultArray");
            }
            this.ResultArray = ResultArray;
            List<long> resultList = new List<long>();

            for (int i = 0; i < ResultArray.Length; i = i + length)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(ResultArray, i, length);
                    var tempArray = memory.ToArray();
                    var hex = Encoding.ASCII.GetString(tempArray);

                    switch (Unit)
                    {
                        case EnumModbusIntegralUnit.Byte:
                            var decByte = Convert.ToInt16(hex, 16);
                            var octByte = Convert.ToInt16(Convert.ToString(decByte, 8));
                            resultList.Add(octByte);
                            break;

                        case EnumModbusIntegralUnit.Word:
                            var decShort = Convert.ToInt16(hex, 16);
                            var octShort = Convert.ToInt32(Convert.ToString(decShort, 8));
                            resultList.Add(octShort);
                            break;

                        case EnumModbusIntegralUnit.DWord:
                            var decInt = Convert.ToInt32(hex, 16);
                            var octInt = Convert.ToInt64(Convert.ToString(decInt, 8));
                            resultList.Add(octInt);
                            break;

                        case EnumModbusIntegralUnit.QWord:
                            var decLong = Convert.ToInt64(hex, 16);
                            var octLong = Convert.ToInt64(Convert.ToString(decLong, 8));
                            resultList.Add(octLong);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException("Unit");
                    }
                }
            }

            return resultList;
        }

        public override IEnumerable<string> ToHexadecimal(byte[] ResultArray, EnumModbusIntegralUnit Unit)
        {
            var length = ((int)Unit) * 2;
            if (ResultArray == null)
            {
                throw new ArgumentNullException("ResultArray");
            }
            if (ResultArray.Length <= 0 || ResultArray.Length < length)
            {
                throw new FormatException("ResultArray");
            }
            this.ResultArray = ResultArray;
            List<string> resultList = new List<string>();
            for (int i = 0; i < ResultArray.Length; i = i + length)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(ResultArray, i, length);
                    var tempArray = memory.ToArray();
                    var result = Encoding.ASCII.GetString(tempArray);
                    resultList.Add(result);
                }
            }
            return resultList;
        }

        public override IEnumerable<string> ToBinary(byte[] ResultArray, EnumModbusIntegralUnit Unit)
        {
            var length = ((int)Unit) * 2;
            if (ResultArray == null)
            {
                throw new ArgumentNullException("ResultArray");
            }
            if (ResultArray.Length <= 0 || ResultArray.Length < length)
            {
                throw new FormatException("ResultArray");
            }
            this.ResultArray = ResultArray;
            List<string> resultList = new List<string>();
            for (int i = 0; i < ResultArray.Length; i = i + length)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(ResultArray, i, length);
                    var tempArray = memory.ToArray();
                    var hex = Encoding.ASCII.GetString(tempArray);
                    string bin = "";
                    switch (Unit)
                    {
                        case EnumModbusIntegralUnit.Byte:
                            var decByte = Convert.ToInt16(hex, 16);
                            bin = Convert.ToString(decByte, 2).PadLeft(8, '0');
                            break;

                        case EnumModbusIntegralUnit.Word:
                            var decShort = Convert.ToInt16(hex, 16);
                            bin = Convert.ToString(decShort, 2).PadLeft(16, '0');
                            break;

                        case EnumModbusIntegralUnit.DWord:
                            var decInt = Convert.ToInt32(hex, 16);
                            bin = Convert.ToString(decInt, 2).PadLeft(32, '0');
                            break;

                        case EnumModbusIntegralUnit.QWord:
                            var decLong = Convert.ToInt64(hex, 16);
                            bin = Convert.ToString(decLong, 2).PadLeft(64, '0');
                            break;

                        default:
                            throw new ArgumentOutOfRangeException("Unit");
                    }

                    resultList.Add(bin);
                }
            }

            return resultList;
        }

        public override IEnumerable<float> ToFloat(byte[] ResultArray)
        {
            var length = 8;
            if (ResultArray == null)
            {
                throw new ArgumentNullException("ResultArray");
            }
            if (ResultArray.Length <= 0 || ResultArray.Length < length)
            {
                throw new FormatException("ResultArray");
            }

            this.ResultArray = ResultArray;
            int count = ResultArray.Length / length;

            List<float> resultList = new List<float>();
            List<string> hexList = new List<string>();

            for (int i = 0; i < count * length; i = i + length)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(ResultArray, i, length);
                    var tempArray = memory.ToArray();
                    var hex = Encoding.ASCII.GetString(tempArray);
                    hexList.Add(hex);
                }
            }

            for (int i = 0; i < hexList.Count; i++)
            {
                var hexArray = this.ModbusUtility.HexStringToBytes(hexList[i]);
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(hexArray, 1, 1);
                    memory.Write(hexArray, 0, 1);
                    memory.Write(hexArray, 3, 1);
                    memory.Write(hexArray, 2, 1);

                    float result = BitConverter.ToSingle(memory.ToArray(), 0);
                    resultList.Add(result);
                }
            }
            return resultList;
        }

        public override IEnumerable<double> ToDouble(byte[] ResultArray)
        {
            var length = 16;
            if (ResultArray == null)
            {
                throw new ArgumentNullException("ResultArray");
            }
            if (ResultArray.Length <= 0 || ResultArray.Length < length)
            {
                throw new FormatException("ResultArray");
            }

            this.ResultArray = ResultArray;
            int count = ResultArray.Length / length;

            List<double> resultList = new List<double>();
            List<string> hexList = new List<string>();

            for (int i = 0; i < count * length; i = i + length)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(ResultArray, i, length);
                    var tempArray = memory.ToArray();
                    var hex = Encoding.ASCII.GetString(tempArray);
                    hexList.Add(hex);
                }
            }

            for (int i = 0; i < hexList.Count; i++)
            {
                var hexArray = this.ModbusUtility.HexStringToBytes(hexList[i]);
                using (MemoryStream memory = new MemoryStream())
                {
                    memory.Write(hexArray, 1, 1);
                    memory.Write(hexArray, 0, 1);
                    memory.Write(hexArray, 3, 1);
                    memory.Write(hexArray, 2, 1);

                    memory.Write(hexArray, 5, 1);
                    memory.Write(hexArray, 4, 1);
                    memory.Write(hexArray, 7, 1);
                    memory.Write(hexArray, 6, 1);

                    double result = BitConverter.ToDouble(memory.ToArray(), 0);
                    resultList.Add(result);
                }
            }
            return resultList;
        }
    }
}