using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolAdministrationV10;

namespace UnitTestProject
{
    [TestClass]
    public class StudentCatalogTest
    {
        private StudentCatalog _students;

        public void TestSetup()
        {
            _students = new StudentCatalog();

            Student anna = new Student(12, "Anna");
            Student betty = new Student(338, "Betty");
            Student carl = new Student(92, "Carl");
            Student diana = new Student(295, "Diana");

            anna.AddTestResult("English", 85);
            anna.AddTestResult("Math", 70);
            anna.AddTestResult("Biology", 90);
            anna.AddTestResult("French", 52);

            betty.AddTestResult("English", 77);
            betty.AddTestResult("Math", 82);
            betty.AddTestResult("Chemistry", 65);
            betty.AddTestResult("French", 41);

            carl.AddTestResult("English", 55);
            carl.AddTestResult("Math", 48);
            carl.AddTestResult("Biology", 70);
            carl.AddTestResult("French", 38);

            _students.AddStudent(anna);
            _students.AddStudent(betty);
            _students.AddStudent(carl);
            _students.AddStudent(diana);
        }

        [TestMethod]
        public void TestAddStudent()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _students.Count;
            _students.AddStudent(new Student(987, "Eric"));
            int afterCount = _students.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod]
        public void TestGetStudent_ExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            Student result = _students.GetStudent(338);

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(result.ID, 338);
        }

        [TestMethod]
        public void TestGetStudent_NonExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            Student result = _students.GetStudent(833);

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetAverageForStudent_ExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            int result = _students.GetAverageForStudent(12);
            int expectedResult = (85 + 70 + 90 + 52) / 4;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestGetAverageForStudent_NonExistingStudent()
        {
            // Arrange
            TestSetup();

            // Act
            int result = _students.GetAverageForStudent(21);
            int expectedResult = -1;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestGetTotalAverage()
        {
            // Arrange
            TestSetup();

            // Act
            int result = _students.GetTotalAverage();
            int expectedResult = (_students.GetAverageForStudent(12) +
                                  _students.GetAverageForStudent(338) +
                                  _students.GetAverageForStudent(92)) / 3;

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
