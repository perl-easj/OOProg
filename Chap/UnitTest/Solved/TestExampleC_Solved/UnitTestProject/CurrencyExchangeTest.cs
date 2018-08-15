using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExampleC;
// ReSharper disable UnusedVariable

namespace UnitTestProject
{
    [TestClass]
    public class CurrencyExchangeTest
    {
        private ICurrencyExchange _currencyExchange;

        public CurrencyExchangeTest()
        {
            _currencyExchange = null;
        }

        private void Arrange()
        {
            _currencyExchange = new CurrencyExchange(new CurrencyCheck());
        }

        private void ArrangeWithStandardEntries()
        {
            Arrange();
            _currencyExchange.SetExchangeRate("USDDKK", 6.50);
            _currencyExchange.SetExchangeRate("EURDKK", 7.50);
            _currencyExchange.SetExchangeRate("USDGBP", 0.80);
        }


        [TestMethod]
        public void TestSetExchangeRate_InsertSingleLegal_OK()
        {
            // Arrange
            Arrange();

            // Act (& implicit Assert)
            _currencyExchange.SetExchangeRate("USDDKK", 6.50);
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertSingleIllegal_TooShort_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate("USDDK", 6.50); });
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertSingleIllegal_TooLong_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate("USDKroner", 6.50); });
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertSingleIllegal_SameCurrency_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate("USDUSD", 6.50); });
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertSingleIllegal_Empty_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate("      ", 6.50); });
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertSingleIllegal_Null_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate(null, 6.50); });
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertSingleIllegal_NegativeExchangeRate_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate(null, -6.50); });
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertSingleIllegal_ZeroExchangeRate_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate(null, 0.0); });
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertMultipleLegal_OK()
        {
            // Arrange
            ArrangeWithStandardEntries();
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertMultipleWithIllegal_Exception()
        {
            // Arrange
            Arrange();

            // Act & Assert
            _currencyExchange.SetExchangeRate("USDDKK", 6.50);
            Assert.ThrowsException<ArgumentException>(() => { _currencyExchange.SetExchangeRate("EUDDK", 7.50); });
            _currencyExchange.SetExchangeRate("USDGBP", 0.80);
        }

        [TestMethod]
        public void TestSetExchangeRate_InsertAndUpdateSingleLegal_OK()
        {
            // Arrange
            Arrange();

            // Act (& implicit Assert)
            _currencyExchange.SetExchangeRate("USDDKK", 6.50);
            _currencyExchange.SetExchangeRate("USDDKK", 6.80);
        }

        [TestMethod]
        public void TestDoExchange_Existing_OK()
        {
            // Arrange
            ArrangeWithStandardEntries();
            double expectedResult = 1300.0;

            // Act
            double actualResult = _currencyExchange.DoExchange("USDDKK", 200.0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void TestDoExchange_ExistingWithUpdate_OK()
        {
            // Arrange
            ArrangeWithStandardEntries();
            _currencyExchange.SetExchangeRate("USDDKK", 6.80);
            double expectedResult = 1360.0;

            // Act
            double actualResult = _currencyExchange.DoExchange("USDDKK", 200.0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void TestDoExchange_NonExisting_Exception()
        {
            // Arrange
            ArrangeWithStandardEntries();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { double actualResult = _currencyExchange.DoExchange("USDNOR", 200.0); });
        }

        [TestMethod]
        public void TestDoExchange_Illegal_Exception()
        {
            // Arrange
            ArrangeWithStandardEntries();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { double actualResult = _currencyExchange.DoExchange("USDNK", 200.0); });
        }

        [TestMethod]
        public void TestDoExchange_Illegal_NegativeAmount_Exception()
        {
            // Arrange
            ArrangeWithStandardEntries();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { double actualResult = _currencyExchange.DoExchange("USDDKK", -200); });
        }

        [TestMethod]
        public void TestDoExchange_Illegal_ZeroAmount_Exception()
        {
            // Arrange
            ArrangeWithStandardEntries();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { double actualResult = _currencyExchange.DoExchange("USDDKK", 0); });
        }
    }
}
