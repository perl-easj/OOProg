namespace EFCoreMovie
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int RunningTimeMins { get; set; }
        public int StudioId { get; set; }
    }
}
