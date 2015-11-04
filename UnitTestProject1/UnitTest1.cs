using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataBank;
using System.IO;

/*
    _  _     _  _  _  _  _
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _| 

 * */

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestString1()
        {
            ParseString parser = new ParseString();
            int accountNumer = parser.getAccountNumberFromString("111111111");
            Assert.AreEqual(111111111,accountNumer);
        }
        [TestMethod]
        public void TestString2()
        {
            ParseString parser = new ParseString();
            int accountNumer = parser.getAccountNumberFromString("123456789");
            Assert.AreEqual(123456789, accountNumer);
        }

        [TestMethod]
        public void TestDigit012()
        {
            string fileName = @"C:\Users\Olivier\Documents\Visual Studio 2013\Projects\ConsoleApplication1\TestFile0-1-2.txt";
            ParseString parser = new ParseString();
            string accountString = parser.getAccountNumberFromFile(fileName);
            Assert.AreEqual("020100100", accountString);
             
        }
        [TestMethod]
        public void TestDigit9()
        {
            string fileName = @"C:\Users\Olivier\Documents\Visual Studio 2013\Projects\ConsoleApplication1\TestFile9.txt";
            ParseString parser = new ParseString();
            string accountString = parser.getAccountNumberFromFile(fileName);
            Assert.AreEqual("999999999", accountString);

        }
        [TestMethod]
        public void TestDigit1to9()
        {
            string fileName = @"C:\Users\Olivier\Documents\Visual Studio 2013\Projects\ConsoleApplication1\TestFile1to9.txt";
            ParseString parser = new ParseString();
            string accountString = parser.getAccountNumberFromFile(fileName);
            Assert.AreEqual("123456789", accountString);

        }
        [TestMethod]
        public void TestCheckSumDigitOKWithZero()
        {
            CheckSum checker = new CheckSum();
            Assert.AreEqual(0, checker.computeCheckSum("000000000"));
        }

        [TestMethod]
        public void TestCheckSumDigitOKWithoutZero()
        {
            CheckSum checker = new CheckSum();
            Assert.AreEqual(0, checker.computeCheckSum("345882865"));
        }
        
        [TestMethod]
        public void TestCheckSumDigitKO1()
        {
            CheckSum checker = new CheckSum();
            Assert.AreNotEqual(0, checker.computeCheckSum("345882867"));
        }
    }
}

