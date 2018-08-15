using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExampleB;
// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable RedundantAssignment

namespace UnitTestProject
{
    [TestClass]
    public class WarriorUnitTest
    {
        [TestMethod]
        public void TestWarrior_Constructor_NameTooShort_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("A", 100); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_NameIsNull_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior(null, 100); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_NameIsEmpty_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("", 100); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_NameIsOnlySpaces_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("     ", 100); });
        }

        [TestMethod] 
        public void TestWarrior_Constructor_NameIsMinimal_NoException()
        {
            // Arrange
            Warrior unexpectedResult = null;

            // Act
            Warrior actualResult = new Warrior("Bo", 100);

            // Arrange, Act & Assert
            Assert.AreNotEqual(unexpectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_Constructor_NameIsOK_NoException()
        {
            // Arrange
            Warrior unexpectedResult = null;

            // Act
            Warrior actualResult = new Warrior("Rolf", 100);

            // Arrange, Act & Assert
            Assert.AreNotEqual(unexpectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_Constructor_HitPointsNegative_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("Rolf", -10); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_HitPointsZero_Exception()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { Warrior testSubject = new Warrior("Rolf", 0); });
        }

        [TestMethod]
        public void TestWarrior_Constructor_HitPointsMinimal_NoException()
        {
            // Arrange
            Warrior unexpectedResult = null;

            // Act
            Warrior actualResult = new Warrior("Rolf", 1);

            // Arrange, Act & Assert
            Assert.AreNotEqual(unexpectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_Constructor_HitPointsPositive_NoException()
        {
            // Arrange
            Warrior unexpectedResult = null;

            // Act
            Warrior actualResult = new Warrior("Rolf", 100);

            // Arrange, Act & Assert
            Assert.AreNotEqual(unexpectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_Name_GetOnce()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            string expectedResult = "Rolf";

            // Act
            string actualResult = testSubject.Name;

            // Arrange, Act & Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_Name_GetTwice()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            string expectedResult = "Rolf";

            // Act
            string actualResult = testSubject.Name;
            actualResult = testSubject.Name;

            // Arrange, Act & Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_HitPoints_GetOnce()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            int expectedResult = 100;

            // Act
            int actualResult = testSubject.HitPoints;

            // Arrange, Act & Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_HitPoints_GetTwice()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            int expectedResult = 100;

            // Act
            int actualResult = testSubject.HitPoints;
            actualResult = testSubject.HitPoints;

            // Arrange, Act & Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_ReceiveDamage_Negative_Exception()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);

            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => { testSubject.ReceiveDamage(-1); });
        }

        [TestMethod]
        public void TestWarrior_ReceiveDamage_Zero_NoException()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);

            // Act (& implicit assert)
            testSubject.ReceiveDamage(0);
        }

        [TestMethod]
        public void TestWarrior_ReceiveDamage_Positive_NoException()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);

            // Act (& implicit assert)
            testSubject.ReceiveDamage(50);
        }

        [TestMethod]
        public void TestWarrior_ReceiveDamageUpdatesHitPoints_OneUpdate()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(20);
            int expectedResult = 80;

            // Act
            int actualResult = testSubject.HitPoints;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_ReceiveDamageUpdatesHitPoints_TwoUpdate()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(20);
            testSubject.ReceiveDamage(35);
            int expectedResult = 45;

            // Act
            int actualResult = testSubject.HitPoints;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetInitial()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            bool expectedResult = false;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetWithPositiveHitPoints()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(80);
            bool expectedResult = false;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetWithMinimalHitPoints()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(99);
            bool expectedResult = false;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetWithZeroHitPoints()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(100);
            bool expectedResult = true;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestWarrior_IsDead_GetWithNegativeHitPoints()
        {
            // Arrange
            Warrior testSubject = new Warrior("Rolf", 100);
            testSubject.ReceiveDamage(200);
            bool expectedResult = true;

            // Act
            bool actualResult = testSubject.IsDead;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
