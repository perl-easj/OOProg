namespace ASWCClassroomDay4.ExtensionLib
{
    public static class MovieExtensions
    {
        // Why not extension properties..?
        // Maybe in C# 8...
        public static double DurationInHours(this Movie aMovie)
        {
            return aMovie.DurationInMins / 60.0;
        }
    }
}