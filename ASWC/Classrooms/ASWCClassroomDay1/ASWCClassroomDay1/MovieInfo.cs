namespace ASWCClassroomDay1
{
    public class MovieInfo
    {
        public string Title { get; set; }
        public int YearSince1900 { get; set; }
        public double TimeHours { get; set; }

        public MovieInfo(string title, int yearSince1900, double timeHours)
        {
            Title = title;
            YearSince1900 = yearSince1900;
            TimeHours = timeHours;
        }
    }

}