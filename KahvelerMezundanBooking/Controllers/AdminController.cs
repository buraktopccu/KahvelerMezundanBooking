using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUploadControl;
using KahvelerMezundanBooking.Data;
using KahvelerMezundanBooking.Models;
using KahvelerMezundanBooking.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KahvelerMezundanBooking.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;
        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            _upload = upload;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<IFormFile> files, MezunDetailViewmodel vmodel, MezunDetails mezun)
        {
            string path = string.Empty;
            mezun.Mezun_Name = vmodel.Name;
            mezun.Mezun_Description = vmodel.Description;
            mezun.DateAndTime = vmodel.DateofEvent;
            foreach (var item in files)
            {
                path = Path.GetFileName(item.FileName.Trim());
                mezun.MezunPicture = "~/uploads/" + path;
            }
            _upload.uploadfilemultiple(files);
            _context.MezunDetails.Add(mezun);
            _context.SaveChanges();
            TempData["Success"] = "Mezunu Kaydet";
            return RedirectToAction("Create", "Admin");
        }
        [HttpGet]
        public IActionResult CheckBookSeat()
        {
            var GetBookingTable = _context.BookingTable.ToList().OrderByDescending(a => a.Datetopresent);
            return View(GetBookingTable);
        }
        [HttpGet]
        public IActionResult GetUserDetails()
        {
            var getUserTable = _context.Users.ToList();
            return View(getUserTable);
        }

    }
}