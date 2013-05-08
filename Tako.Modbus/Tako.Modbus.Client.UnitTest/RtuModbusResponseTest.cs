﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tako.Modbus;
using Tako.Modbus.Client;

namespace Tako.Modbus.Client.UnitTest
{
    /// <summary>
    ///This is a test class for RtuModbusResponseTest and is intended
    ///to contain all RtuModbusResponseTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RtuModbusResponseTest
    {
        private TestContext testContextInstance;

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

        [TestMethod()]
        [DeploymentItem("TestDoc\\RtuReadFunc1Test.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDoc\\RtuReadFunc1Test.csv", "RtuReadFunc1Test#csv", DataAccessMethod.Random)]
        public void ReadCoilsTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();
            byte[] RequestArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[0].ToString());
            byte[] ResponseArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[1].ToString());
            byte[] expected = _modbusUtility.HexStringToBytes(TestContext.DataRow[2].ToString());

            byte[] actual;
            actual = target.ReadCoils(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        [DeploymentItem("TestDoc\\RtuReadFunc2Test.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDoc\\RtuReadFunc2Test.csv", "RtuReadFunc2Test#csv", DataAccessMethod.Sequential)]
        public void ReadDiscreteInputsTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();

            byte[] RequestArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[0].ToString());
            byte[] ResponseArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[1].ToString());
            byte[] expected = _modbusUtility.HexStringToBytes(TestContext.DataRow[2].ToString());

            byte[] actual;
            actual = target.ReadDiscreteInputs(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        [DeploymentItem("TestDoc\\RtuReadFunc3Test.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDoc\\RtuReadFunc3Test.csv", "RtuReadFunc3Test#csv", DataAccessMethod.Sequential)]
        public void ReadHoldingRegistersTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();

            byte[] RequestArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[0].ToString());
            byte[] ResponseArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[1].ToString());
            byte[] expected = _modbusUtility.HexStringToBytes(TestContext.DataRow[2].ToString());

            byte[] actual;
            actual = target.ReadHoldingRegisters(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        [DeploymentItem("TestDoc\\RtuReadFunc4Test.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestDoc\\RtuReadFunc4Test.csv", "RtuReadFunc4Test#csv", DataAccessMethod.Sequential)]
        public void ReadInputRegistersTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();

            byte[] RequestArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[0].ToString());
            byte[] ResponseArray = _modbusUtility.HexStringToBytes(TestContext.DataRow[1].ToString());
            byte[] expected = _modbusUtility.HexStringToBytes(TestContext.DataRow[2].ToString());

            byte[] actual;
            actual = target.ReadInputRegisters(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteSingleCoilTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();
            byte[] RequestArray = _modbusUtility.HexStringToBytes("01 05 00 02 FF 00 2D FA");
            byte[] ResponseArray = _modbusUtility.HexStringToBytes("01 05 00 02 FF 00 2D FA");
            byte[] expected = ResponseArray;
            byte[] actual;
            actual = target.WriteSingleCoil(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteSingleRegisterTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();
            byte[] RequestArray = _modbusUtility.HexStringToBytes("01 06 00 03 00 DF 38 52");
            byte[] ResponseArray = _modbusUtility.HexStringToBytes("01 06 00 03 00 DF 38 52");
            byte[] expected = ResponseArray;
            byte[] actual;
            actual = target.WriteSingleRegister(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteMultipleCoilsTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();
            byte[] RequestArray = _modbusUtility.HexStringToBytes("01 0F 00 00 00 0A 02 3A 01 36 58");
            byte[] ResponseArray = _modbusUtility.HexStringToBytes("01 0F 00 00 00 0A D5 CC");
            byte[] expected = ResponseArray;
            byte[] actual;
            actual = target.WriteMultipleCoils(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void WriteMultipleRegistersTest()
        {
            RtuModbusResponse target = new RtuModbusResponse();
            byte[] RequestArray = _modbusUtility.HexStringToBytes("01 10 00 00 00 0A 14 03 15 00 00 00 0D 00 0C 00 00 FF E9 00 00 00 00 00 6D 00 00 E7 B1");
            byte[] ResponseArray = _modbusUtility.HexStringToBytes("01 10 00 00 00 0A 40 0E");
            byte[] expected = ResponseArray;
            byte[] actual;
            actual = target.WriteMultipleRegisters(RequestArray, ResponseArray);
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}