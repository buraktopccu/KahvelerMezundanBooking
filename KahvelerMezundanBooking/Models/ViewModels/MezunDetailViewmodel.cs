using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KahvelerMezundanBooking.Models.ViewModels
{
    public class MezunDetailViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateofEvent { get; set; }
        public string MezunPicture { get; set; }

    }
}
