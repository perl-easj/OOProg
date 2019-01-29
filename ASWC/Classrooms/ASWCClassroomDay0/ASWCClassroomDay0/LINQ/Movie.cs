namespace ASWCClassroomDay0.LINQ
{
    public class Movie
    {
        public Movie(string title, int year, int durationInMins, string studioName)
        {
            Title = title;
            Year = year;
            DurationInMins = durationInMins;
            StudioName = studioName;
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int DurationInMins { get; set; }
        public string StudioName { get; set; }
    }

}