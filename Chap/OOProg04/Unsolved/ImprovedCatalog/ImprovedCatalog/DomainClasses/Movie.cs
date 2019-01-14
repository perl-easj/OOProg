namespace ImprovedCatalog.DomainClasses
{
    /// <summary>
    /// Simple domain class. The property ISMN (International Standard Movie Number)
    /// is defined as being a key for a Movie object.
    /// </summary>
    public class Movie
    {
        #region Properties
        public int ISMN { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string StudioName { get; set; }
        #endregion

        #region Constructor
        public Movie(int ismn, string title, int year, string studioName)
        {
            ISMN = ismn;
            Title = title;
            Year = year;
            StudioName = studioName;
        } 
        #endregion

        public override string ToString()
        {
            return $"{Title} ({Year}), by {StudioName}";
        }
    }
}