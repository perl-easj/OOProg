using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExampleA;
// ReSharper disable ExpressionIsAlwaysNull

namespace UnitTestProject
{
    [TestClass]
    public class ListMethodsUnitTest
    {
        private ListMethods testSubject;

        public ListMethodsUnitTest()
        {
            testSubject = new ListMethods();
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListIsNull_Exception()
        {
            // Arrange
            List<int> numbers = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { testSubject.SumOfSquaresOfPositives(numbers); });
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListIsEmpty_Exception()
        {
            // Arrange
            List<int> numbers = new List<int>();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { testSubject.SumOfSquaresOfPositives(numbers); });
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListOneNegative_0()
        {
            // Arrange
            List<int> numbers = new List<int> {-1};
            int expectedResult = 0;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListOneZero_0()
        {
            // Arrange
            List<int> numbers = new List<int> { 0 };
            int expectedResult = 0;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListOnePositiveA_1_1()
        {
            // Arrange
            List<int> numbers = new List<int> { 1 };
            int expectedResult = 1;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListOnePositiveB_4_16()
        {
            // Arrange
            List<int> numbers = new List<int> { 4 };
            int expectedResult = 16;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListMultipleNegative_0()
        {
            // Arrange
            List<int> numbers = new List<int> { -1, -4, -2, -907 };
            int expectedResult = 0;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListMultipleZero_0()
        {
            // Arrange
            List<int> numbers = new List<int> { 0, 0, 0, 0 };
            int expectedResult = 0;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListMultiplePositive_225()
        {
            // Arrange
            List<int> numbers = new List<int> { 4, 1, 12, 8 };
            int expectedResult = 225;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSumOfSquaresOfPositives_ListMultipleMix_455()
        {
            // Arrange
            List<int> numbers = new List<int> { -4, 3, 9, -8, 13, 14, -21 };
            int expectedResult = 455;

            // Act
            int actualResult = testSubject.SumOfSquaresOfPositives(numbers);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
