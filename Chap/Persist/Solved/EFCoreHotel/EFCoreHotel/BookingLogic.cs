namespace EFCoreHotel
{
    public partial class Booking
    {
        public override string ToString()
        {
            return $"Room {RoomNo} at {Room?.HotelNoNavigation?.Name}: Booking from {DateFrom} to {DateTo}, by {GuestNoNavigation.Name}";
        }
    }
}