namespace LibraryV10
{
    /// <summary>
    /// This class represent a book, with ISBN, title, author
    /// and the number of pages in the book
    /// </summary>
    public class Book
    {
        #region Instance fields
        private string _isbn;
        private string _title;
        private string _author;
        private int _noOfPages;
        #endregion

        #region Constructor
        public Book(string isbn, string title, string author, int noOfPages)
        {
            _isbn = isbn;
            _title = title;
            _author = author;
            _noOfPages = noOfPages;
        }
        #endregion

        #region Properties
        public string ISBN
        {
            get { return _isbn; }
        }

        public string Title
        {
            get { return _title; }
        }

        public string Author
        {
            get { return _author; }
        }

        public int NoOfPages
        {
            get { return _noOfPages; }
        }
        #endregion
    }
}