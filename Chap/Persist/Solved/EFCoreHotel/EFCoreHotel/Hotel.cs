using System;
using System.Collections.Generic;

namespace EFCoreHotel
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        public int HotelNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
