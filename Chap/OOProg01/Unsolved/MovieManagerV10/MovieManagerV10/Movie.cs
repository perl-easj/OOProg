namespace MovieManagerV10
{
    public class Movie
    {
        #region Instance fields
        private string _title;
        private string _director;
        private int _runtimeInMinutes;
        private int _noOfViews;
        #endregion

        #region Constructor
        /// <summary>
        /// When creating a Movie object, you must
        /// specify a title, a director, and the
        /// running time of the movie (in minutes)
        /// </summary>
        public Movie(string title, string director, int runtime)
        {
            _title = title;
            _director = director;
            _runtimeInMinutes = runtime;
            _noOfViews = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the title of the movie
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        /// <summary>
        /// Returns the director of the movie
        /// </summary>
        public string Director
        {
            get { return _director; }
        }

        /// <summary>
        /// Returns the running of the movie (in minutes)
        /// </summary>
        public int Runtime
        {
            get { return _runtimeInMinutes; }
        }

        /// <summary>
        /// Returns the number of times the movie has been watched
        /// </summary>
        public int NoOfViews
        {
            get { return _noOfViews; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Call this method to indicate that you
        /// have watched the movie once.
        /// </summary>
        public void Watch()
        {
            _noOfViews = _noOfViews + 1;
        } 
        #endregion
    }
}