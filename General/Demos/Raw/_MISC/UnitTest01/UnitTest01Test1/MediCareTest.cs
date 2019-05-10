using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest01;

namespace UnitTest01Test1
{
    [TestClass]
    public class MediCareTest
    {
        [TestMethod]
        public void SubsidisedExpense_NegativeAmount_Exception()
        {
            // Arrange
            MediCare mCare = new MediCare(new SubsidyTable());
            double expense = -1.0;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                mCare.SubsidisedExpense(expense);
            });
        }

        [TestMethod]
        public void SubsidisedExpense_0kr_0kr()
        {
            // Arrange
            MediCare mCare = new MediCare(new SubsidyTable());
            double expense = 0.0;
            double expectedSubsidisedExpense = 0.0;

            // Act
            double actualSubsidisedExpense = mCare.SubsidisedExpense(expense);

            // Assert
            Assert.AreEqual(expectedSubsidisedExpense, actualSubsidisedExpense, 0.5, "Incorrect result for 0 kr.");
        }

        [TestMethod]
        public void SubsidisedExpense_1kr_1kr()
        {
            // Arrange
            MediCare mCare = new MediCare(new SubsidyTable());
            double expense = 1.0;
            double expectedSubsidisedExpense = 1.0;

            // Act
            double actualSubsidisedExpense = mCare.SubsidisedExpense(expense);

            // Assert
            Assert.AreEqual(expectedSubsidisedExpense, actualSubsidisedExpense, 0.5, "Incorrect result for 1 kr.");
        }

        [TestMethod]
        public void SubsidisedExpense_500kr_500kr()
        {
            // Arrange
            MediCare mCare = new MediCare(new SubsidyTable());
            double expense = 500.0;
            double expectedSubsidisedExpense = 500.0;

            // Act
            double actualSubsidisedExpense = mCare.SubsidisedExpense(expense);

            // Assert
            Assert.AreEqual(expectedSubsidisedExpense, actualSubsidisedExpense, 0.5, "Incorrect result for 500 kr.");
        }

        [TestMethod]
        public void SubsidisedExpense_950kr_950kr()
        {
            // Arrange
            MediCare mCare = new MediCare(new SubsidyTable());
            double expense = 950.0;
            double expectedSubsidisedExpense = 950.0;

            // Act
            double actualSubsidisedExpense = mCare.SubsidisedExpense(expense);

            // Assert
            Assert.AreEqual(expectedSubsidisedExpense, actualSubsidisedExpense, 0.5, "Incorrect result for 950 kr.");
        }

        [TestMethod]
        public void SubsidisedExpense_1000kr_975kr()
        {
            // Arrange
            MediCare mCare = new MediCare(new SubsidyTable());
            double expense = 1000.0;
            double expectedResult = 975.0;

            // Act
            double actualResult = mCare.SubsidisedExpense(expense);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, 0.5, "Fail for 1000 kr.");
        }

        [TestMethod]
        public void SubsidisedExpense_5000kr_1955point25kr()
        {
            // Arrange
            MediCare mCare = new MediCare(new SubsidyTable());
            double expense = 5000.0;
            double expectedResult = 1955.25;

            // Act
            double actualResult = mCare.SubsidisedExpense(expense);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, 0.01, "Fail for 5000 kr.");
        }
    }
}
