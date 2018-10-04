namespace EFCoreMovie
{
    public partial class Studio
    {
        public override string ToString()
        {
            return $"{Name.TrimEnd(' ')}, in {HqCity.TrimEnd(' ')}  ({NoOfEmployees} employees)";
        }
    }
}