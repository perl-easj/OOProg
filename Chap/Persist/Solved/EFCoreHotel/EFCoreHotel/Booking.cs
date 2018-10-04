using System;
using System.Collections.Generic;

namespace EFCoreHotel
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int HotelNo { get; set; }
        public int GuestNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RoomNo { get; set; }

        public Guest GuestNoNavigation { get; set; }
        public Room Room { get; set; }
    }
}
