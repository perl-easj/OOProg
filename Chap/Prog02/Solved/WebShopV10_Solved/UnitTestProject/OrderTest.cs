using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebShopV10;

namespace UnitTestProject
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestCalculateTotalOrderPrice_Example1()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 12.0, 20.0, 75.0, 44.0, 15.0, 49.0 };
            Order theOrder = new Order(itemPriceList);
            double expectedResult = 282.15;

            // Act
            double result = theOrder.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCalculateTotalOrderPrice_Example2()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 80.0, 115.0, 220.0 };
            Order theOrder = new Order(itemPriceList);
            double expectedResult = 484.70;

            // Act
            double result = theOrder.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCalculateTotalOrderPrice_Example3()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 80.0, 115.0, 220.0, 12.0, 20.0, 75.0, 44.0, 15.0, 49.0 };
            Order theOrder = new Order(itemPriceList);
            double expectedResult = 754.77;

            // Act
            double result = theOrder.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCompareOrderVsOrderV2_Example1()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 12.0, 20.0, 75.0, 44.0, 15.0, 49.0 };
            Order theOrder = new Order(itemPriceList);
            OrderV2 theOrderV2 = new OrderV2(itemPriceList);
            double expectedResult = theOrder.TotalOrderPrice;

            // Act
            double result = theOrderV2.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCompareOrderVsOrderV2_Example2()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 80.0, 115.0, 220.0 };
            Order theOrder = new Order(itemPriceList);
            OrderV2 theOrderV2 = new OrderV2(itemPriceList);
            double expectedResult = theOrder.TotalOrderPrice;

            // Act
            double result = theOrderV2.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCompareOrderVsOrderV2_Example3()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 80.0, 115.0, 220.0, 12.0, 20.0, 75.0, 44.0, 15.0, 49.0 };
            Order theOrder = new Order(itemPriceList);
            OrderV2 theOrderV2 = new OrderV2(itemPriceList);
            double expectedResult = theOrder.TotalOrderPrice;

            // Act
            double result = theOrderV2.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCompareOrderVsOrderV3_Example1()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 12.0, 20.0, 75.0, 44.0, 15.0, 49.0 };
            Order theOrder = new Order(itemPriceList);
            OrderV3 theOrderV3 = new OrderV3(itemPriceList);
            double expectedResult = theOrder.TotalOrderPrice;

            // Act
            double result = theOrderV3.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCompareOrderVsOrderV3_Example2()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 80.0, 115.0, 220.0 };
            Order theOrder = new Order(itemPriceList);
            OrderV3 theOrderV3 = new OrderV3(itemPriceList);
            double expectedResult = theOrder.TotalOrderPrice;

            // Act
            double result = theOrderV3.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }

        [TestMethod]
        public void TestCompareOrderVsOrderV3_Example3()
        {
            // Arrange
            List<double> itemPriceList = new List<double> { 80.0, 115.0, 220.0, 12.0, 20.0, 75.0, 44.0, 15.0, 49.0 };
            Order theOrder = new Order(itemPriceList);
            OrderV3 theOrderV3 = new OrderV3(itemPriceList);
            double expectedResult = theOrder.TotalOrderPrice;

            // Act
            double result = theOrderV3.TotalOrderPrice;

            // Assert
            Assert.AreEqual(expectedResult, result, 0.01);
        }
    }
}
