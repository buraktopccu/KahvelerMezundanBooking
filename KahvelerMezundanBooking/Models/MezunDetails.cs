using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KahvelerMezundanBooking.Models
{
    public class MezunDetails
    {
        public int id { get; set; }
        public string Mezun_Name { get; set; }
        public string Mezun_Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string MezunPicture { get; set; }
        public virtual ICollection<BookingTable> booking { get; set; }
    }
}
