namespace EFCoreHotel
{
    public partial class Hotel
    {
        public override string ToString()
        {
            return $"Hotel: {Name} ({Address}) has {Rooms?.Count} rooms";
        }
    }
}