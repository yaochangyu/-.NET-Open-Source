using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tako.Modbus;
using Tako.Modbus.Client;

namespace Tako.Modbus.Client.UnitTest
{
    /// <summary>
    ///This is a test class for TcpModbusTransportTest and is intended
    ///to contain all TcpModbusTransportTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TcpModbusRequestTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion Additional test attributes

        private ModbusUtility _modbusUtility = new ModbusUtility();

        /// <summary>
        ///A test for ReadCoilsRequest
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ModbusException))]
        public void ReadCoilsRequest_Exception_Test()
        {
            TcpModbusRequest target = new TcpModbusRequest();
            byte Unit = 0;
            ushort StartAddress = 0;
            ushort Quantity = 0;
            ushort Transaction = 0;
            byte[] expected = null;
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.ReadCoils(Unit, StartAddress, Quantity);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ReadCoilsTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();

            byte Unit = 1;
            ushort StartAddress = 0;
            ushort Quantity = 10;
            ushort Transaction = 0;
            byte[] expected = _modbusUtility.HexStringToBytes("00 00 00 00 00 06 01 01 00 00 00 0A");
            target.TransactionID = Transaction;
            byte[] actual;
            actual = target.ReadCoils(Unit, StartAddress, Quantity);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void ReadDiscreteInputsTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();

            byte Unit = 1;
            ushort StartAddress = 0;
            ushort Quantity = 10;
            ushort Transaction = 0;
            byte[] expected = _modbusUtility.HexStringToBytes("00 00 00 00 00 06 01 02 00 00 00 0A");
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.ReadDiscreteInputs(Unit, StartAddress, Quantity);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void ReadHoldingRegistersTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();

            byte Unit = 1;
            ushort StartAddress = 0;
            ushort Quantity = 10;
            ushort Transaction = 0;
            byte[] expected = _modbusUtility.HexStringToBytes("00 00 00 00 00 06 01 03 00 00 00 0A");
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.ReadHoldingRegisters(Unit, StartAddress, Quantity);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void ReadInputRegistersTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();

            byte Unit = 1;
            ushort StartAddress = 0;
            ushort Quantity = 100;
            ushort Transaction = 934;
            byte[] expected = _modbusUtility.HexStringToBytes("03 A6 00 00 00 06 01 04 00 00 00 64");
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.ReadInputRegisters(Unit, StartAddress, Quantity);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteSingleCoilTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();

            byte Unit = 1;
            ushort OutputAddress = 0;
            bool OutputValue = true;
            ushort Transaction = 1106;
            byte[] expected = _modbusUtility.HexStringToBytes("04 52 00 00 00 06 01 05 00 00 FF 00");
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.WriteSingleCoil(Unit, OutputAddress, OutputValue);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteSingleRegisterTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();
            byte Unit = 1;
            ushort OutputAddress = 2;
            short OutputValue = 234;
            ushort Transaction = 18;
            byte[] expected = _modbusUtility.HexStringToBytes("00 12 00 00 00 06 01 06 00 02 00 EA");
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.WriteSingleRegister(Unit, OutputAddress, OutputValue);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteMultipleCoilsTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();
            byte Unit = 1;
            ushort StartAddress = 0;
            ushort Quantity = 9;
            byte[] OutputValues = new byte[] { 0x0E, 0x00 };
            ushort Transaction = 895;
            byte[] expected = _modbusUtility.HexStringToBytes("03 7F 00 00 00 09 01 0F 00 00 00 09, 02 0E 00");
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.WriteMultipleCoils(Unit, StartAddress, Quantity, OutputValues);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteMultipleRegistersTest()
        {
            TcpModbusRequest target = new TcpModbusRequest();
            byte Unit = 1;
            ushort StartAddress = 0;
            ushort Quantity = 10;
            short[] OutputValues = new short[] { 78, 87, -78, -87, 23, 35, 123, 12, 33, 6 };
            ushort Transaction = 0x03DA;
            byte[] expected = _modbusUtility.HexStringToBytes("03 DA 00 00 00 1B 01 10 00 00 00 0A 14 00 4E 00 57 FF B2 FF A9 00 17 00 23 00 7B 00 0C 00 21 00 06");
            byte[] actual;
            target.TransactionID = Transaction;
            actual = target.WriteMultipleRegisters(Unit, StartAddress, Quantity, OutputValues);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}