using LibraryV11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class BookCatalogTest
    {
        private BookCatalog _catalog;

        public void TestSetup()
        {
            Book b1 = new Book("AD1337", "C# for All", "John Potter", 352);
            Book b2 = new Book("XS3220", "Gardening", "Alex Sohn", 220);
            Book b3 = new Book("DD0095", "Cars in the USA", "Susan Dreyer", 528);
            Book b4 = new Book("PT1295", "The World Narrators", "Dan Mygind", 256);

            _catalog = new BookCatalog();
            _catalog.AddBook(b1);
            _catalog.AddBook(b2);
            _catalog.AddBook(b3);
            _catalog.AddBook(b4);
        }

        [TestMethod]
        public void TestAddBook()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _catalog.Count;
            _catalog.AddBook(new Book("KS2007", "Dogs and Cats", "Jim Scott", 217));
            int afterCount = _catalog.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod]
        public void TestLookupBook_ExistingBook()
        {
            // Arrange
            TestSetup();

            // Act
            Book result = _catalog.LookupBook("AD1337");

            // Assert
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(result.ISBN, "AD1337");
        }

        [TestMethod]
        public void TestLookupBook_NonExistingBook_Case1()
        {
            // Arrange
            TestSetup();

            // Act
            Book result = _catalog.LookupBook("AD1338");

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestLookupBook_NonExistingBook_Case2()
        {
            // Arrange
            TestSetup();

            // Act
            Book result = _catalog.LookupBook("...");

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestLookupBook_NonExistingBook_Case3()
        {
            // Arrange
            TestSetup();

            // Act
            Book result = _catalog.LookupBook("ad1337");

            // Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestDeleteBook_ExistingBook()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _catalog.Count;
            _catalog.DeleteBook("XS3220");
            int afterCount = _catalog.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount - 1, afterCount);
        }

        [TestMethod]
        public void TestDeleteBook_NonExistingBook()
        {
            // Arrange
            TestSetup();

            // Act
            int beforeCount = _catalog.Count;
            _catalog.DeleteBook("SX2320");
            int afterCount = _catalog.Count;

            // Assert
            Assert.AreEqual(4, beforeCount);
            Assert.AreEqual(beforeCount, afterCount);
        }
    }
}
