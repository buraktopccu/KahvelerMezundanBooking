using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KahvelerMezundanBooking.Models;
using KahvelerMezundanBooking.Models.ViewModels;

namespace KahvelerMezundanBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookingTable> BookingTable { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<MezunDetails> MezunDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<KahvelerMezundanBooking.Models.ViewModels.MezunDetailViewmodel> MezunDetailViewmodel { get; set; }

        public DbSet<KahvelerMezundanBooking.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
