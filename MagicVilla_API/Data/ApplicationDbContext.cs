using MagicVilla_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "This is Royal Villa",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Private Villa",
                    Details = "This is Private Villa",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                    Rate = 300,
                    Sqft = 480,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Diamond Villa",
                    Details = "This is Diamond Villa",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa4.jpg",
                    Rate = 250,
                    Sqft = 410,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Diamond Pool Villa",
                    Details = "This is Diamond Pool Villa",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa5.jpg",
                    Rate = 400,
                    Sqft = 510,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                 new Villa()
                 {
                     Id = 5,
                     Name = "Luxury Pool Villa",
                     Details = "This is Luxury Pool Villa",
                     ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                     Rate = 500,
                     Sqft = 360,
                     Amenity = "",
                     CreatedDate = DateTime.Now
                 }
                );
        }
    }
}
