using System;
using System.Collections.Generic;

namespace EFCoreHotel
{
    public partial class Guest
    {
        public Guest()
        {
            Bookings = new HashSet<Booking>();
        }

        public int GuestNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
