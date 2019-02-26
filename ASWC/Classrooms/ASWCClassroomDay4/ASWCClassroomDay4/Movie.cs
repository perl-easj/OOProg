namespace ASWCClassroomDay4
{
    public class Movie
    {
        public int DurationInMins { get; set; }
        public string Title { get; set; }

        public Movie(string title, int durationInMins)
        {
            Title = title;
            DurationInMins = durationInMins;
        }
    }
}