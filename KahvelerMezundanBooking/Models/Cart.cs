using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KahvelerMezundanBooking.Models
{
    public class Cart
    {
        public int id { get; set; }
        public string seatno { get; set; }
        public string UserId { get; set; }
        public DateTime date { get; set; }
        public int MezunId { get; set; }
    }
}
