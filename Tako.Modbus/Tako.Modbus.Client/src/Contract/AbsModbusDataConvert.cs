using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    internal abstract class AbsModbusDataConvert
    {
        private ModbusUtility _modbusUtility = new ModbusUtility();

        protected ModbusUtility ModbusUtility
        {
            get { return _modbusUtility; }
            set { _modbusUtility = value; }
        }

        public abstract byte[] ResultArray { get; internal set; }

        public abstract IEnumerable<long> ToDecimal(byte[] ResultArray, EnumModbusIntegralUnit Unit);

        public abstract IEnumerable<long> ToOctal(byte[] ResultArray, EnumModbusIntegralUnit Unit);

        public abstract IEnumerable<string> ToHexadecimal(byte[] ResultArray, EnumModbusIntegralUnit Unit);

        public abstract IEnumerable<string> ToBinary(byte[] ResultArray, EnumModbusIntegralUnit Unit);

        public abstract IEnumerable<float> ToFloat(byte[] ResultArray);

        public abstract IEnumerable<double> ToDouble(byte[] ResultArray);
    }
}