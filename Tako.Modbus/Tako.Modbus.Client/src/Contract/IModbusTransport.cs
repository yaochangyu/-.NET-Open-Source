using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tako.Modbus.Client
{
    public interface IModbusTransport
    {
        byte[] ReadCoils(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadCoilsToDecimal(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<string> ReadCoilsToBinary(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadCoilsToOctal(byte Unit, ushort StartAddress, ushort Quantity);

        byte[] ReadDiscreteInputs(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadDiscreteInputsToDecimal(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<string> ReadDiscreteInputsToBinary(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadDiscreteInputsToOctal(byte Unit, ushort StartAddress, ushort Quantity);

        byte[] ReadHoldingRegisters(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadHoldingRegistersToDecimal(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<string> ReadHoldingRegistersToBinary(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadHoldingRegistersToOctal(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<float> ReadHoldingRegistersToFloat(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<double> ReadHoldingRegistersToDouble(byte Unit, ushort StartAddress, ushort Quantity);

        byte[] ReadInputRegisters(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadInputRegistersToDecimal(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<string> ReadInputRegistersToBinary(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<long> ReadInputRegistersToOctal(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<float> ReadInputRegistersToFloat(byte Unit, ushort StartAddress, ushort Quantity);

        IEnumerable<double> ReadInputRegistersTDouble(byte Unit, ushort StartAddress, ushort Quantity);

        bool WriteSingleCoil(byte Unit, ushort OutputAddress, bool OutputValue);

        bool WriteSingleRegister(byte Unit, ushort OutputAddress, short OutputValue);

        bool WriteMultipleCoils(byte Unit, ushort StartAddress, ushort Quantity, byte[] OutputValues);

        bool WriteMultipleRegisters(byte Unit, ushort StartAddress, ushort Quantity, short[] OutputValues);
    }
}