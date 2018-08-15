using System.Collections.Generic;

namespace LibraryV10
{
    /// <summary>
    /// This class represents a collection of Book objects,
    /// for instance the books in a library
    /// </summary>
    public class BookCatalog
    {
        #region Instance fields
        private List<Book> _books;
        #endregion

        #region Constructor
        public BookCatalog()
        {
            _books = new List<Book>();
        }
        #endregion

        #region Properties
        public int Count
        {
            get { return _books.Count; }
        } 
        #endregion

        #region Methods
        /// <summary>
        /// This method adds a single Book object 
        /// to the List of books 
        /// </summary>
        public void AddBook(Book aBook)
        {
            _books.Add(aBook);
        }

        /// <summary>
        /// This method returns a Book object (if any) from
        /// the List of books, which has a matching ISBN number.
        /// If no such object exists, the method returns null.
        /// </summary>
        public Book LookupBook(string isbn)
        {
            foreach (var book in _books)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }
            }

            return null;
        }

        /// <summary>
        /// This method deletes a Book object from the List
        /// of books, specifically the object which has a
        /// matching ISBN number. If no such object exists,
        /// no object is deleted.
        /// </summary>
        public void DeleteBook(string isbn)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].ISBN == isbn)
                {
                    _books.RemoveAt(i);
                    return;
                }
            }
        }
        #endregion
    }
}