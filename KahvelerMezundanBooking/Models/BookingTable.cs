using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KahvelerMezundanBooking.Models
{
    public class BookingTable
    {
        public int Id { get; set; }
        public string seatno { get; set; }
        public string UserId { get; set; }
        public DateTime Datetopresent { get; set; }
        public int MezunDetailsId { get; set; }
        [ForeignKey("MezunDetailsId")]
        public virtual MezunDetails mezundetails { get; set; }


    }
}
