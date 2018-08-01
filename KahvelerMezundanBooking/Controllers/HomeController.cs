using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KahvelerMezundanBooking.Models;
using KahvelerMezundanBooking.Data;
using KahvelerMezundanBooking.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace KahvelerMezundanBooking.Controllers
{


    public class HomeController : Controller
    {

        private ApplicationDbContext _context;
        int count = 1;
        bool flag = true;

        private UserManager<ApplicationUser> _usermanager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {

            _context = context;
            _usermanager=usermanager;



        }
        public IActionResult Index()
        {
            var getMezunList = _context.MezunDetails.ToList();

            return View(getMezunList);
        }
        [HttpGet]
        public IActionResult BookNow(int Id)
        {
            BookNowViewModel vm = new BookNowViewModel();
            var item = _context.MezunDetails.Where(a => a.id == Id).FirstOrDefault();
            vm.Mezun_Name = item.Mezun_Name;
            vm.Mezun_Date = item.DateAndTime;
            vm.MezunId = Id;


            return View(vm);
        }
        [HttpPost]

        public IActionResult BookNow(BookNowViewModel vm)
        {
            List<BookingTable> booking = new List<BookingTable>();
            List<Cart> carts = new List<Cart>();
            string seatno = vm.SeatNo.ToString();
            int MezunId = vm.MezunId;


            string[] seatnoArray = seatno.Split(',');
            count = seatnoArray.Length;
            if (checkseat(seatno, MezunId) == false)
            {
                foreach (var item in seatnoArray)
                {
                    carts.Add(new Cart { MezunId = vm.MezunId, UserId = _usermanager.GetUserId(HttpContext.User), date = vm.Mezun_Date, seatno = item });
                }
                foreach (var item in carts)
                {
                    _context.Cart.Add(item);
                    _context.SaveChanges();
                }

                TempData["Success"] = "Rezerve Edildi, Sepetinizi Kontrol Ediniz!";
            }
            else
            {
                TempData["seatnomsg"] = "Lütfen Koltuk Numaranızı Değiştiriniz!";
            }
            return RedirectToAction("BookNow");
        }

        private bool checkseat(string seatno, int mezunId)
        {
            //throw new NotImplementedException();
            string seats = seatno;
            string[] seatreserve = seats.Split(',');
            var seatnolist = _context.BookingTable.Where(a => a.MezunDetailsId == mezunId).ToList();
            foreach (var item in seatnolist)
            {
                string alreadybook = item.seatno;
                foreach (var item1 in seatreserve)
                {
                    if (item1 == alreadybook)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag == false)
                return true;
            else
                return false;
        }
            



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
