using System;
using System.Collections.Generic;

namespace EFCoreHotel
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RoomNo { get; set; }
        public int HotelNo { get; set; }
        public string Types { get; set; }
        public double? Price { get; set; }

        public Hotel HotelNoNavigation { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
