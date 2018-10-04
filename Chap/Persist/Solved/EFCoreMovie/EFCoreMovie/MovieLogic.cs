namespace EFCoreMovie
{
    public partial class Movie
    {
        public override string ToString()
        {
            return $"{Title.TrimEnd(' ')}, from {Year}  ({RunningTimeMins} mins.)";
        }
    }
}