namespace EFCoreHotel
{
    public partial class Guest
    {
        public override string ToString()
        {
            return $"Guest: {Name} ({Address})  Bookings: {Bookings?.Count}";
        }
    }
}