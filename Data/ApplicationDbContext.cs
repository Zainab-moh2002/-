using GraduationProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Location> Locations { get; set; }
       // public DbSet<HomePageViewModel> HomePages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<QRCodeModel> Models { get; set; }
        public DbSet<ChildData> Childs { get; set; }

    }
}
