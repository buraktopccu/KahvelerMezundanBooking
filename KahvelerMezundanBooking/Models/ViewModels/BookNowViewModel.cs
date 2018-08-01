using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KahvelerMezundanBooking.Models.ViewModels
{
    public class BookNowViewModel
    {
        public int Id { get; set; }
        public string Mezun_Name { get; set; }
        public DateTime Mezun_Date { get; set; }
        public string SeatNo { get; set; }
        public int MezunId { get; set; }
    }
}
