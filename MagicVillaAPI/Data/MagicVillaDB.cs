using MagicVillaAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Data
{
    public class MagicVillaDB : IdentityDbContext<ApplicationUser>
    {
        public MagicVillaDB(DbContextOptions<MagicVillaDB> options):base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    id = 1,
                    name = "Royal Villa",
                    details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                    Occupancy = 4,
                    rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    createDate = DateTime.Now
                },
              new Villa
              {
                  id = 2,
                  name = "Premium Pool Villa",
                  details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                  Occupancy = 4,
                  rate = 300,
                  Sqft = 550,
                  Amenity = "",
                    createDate = DateTime.Now

              },
              new Villa
              {
                  id = 3,
                  name = "Luxury Pool Villa",
                  details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                  Occupancy = 4,
                  rate = 400,
                  Sqft = 750,
                  Amenity = "",
                  createDate = DateTime.Now

              },
              new Villa
              {
                  id = 4,
                  name = "Diamond Villa",
                  details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                  Occupancy = 4,
                  rate = 550,
                  Sqft = 900,
                  Amenity = "",
                  createDate = DateTime.Now
              },
              new Villa
              {
                  id = 5,
                  name = "Diamond Pool Villa",
                  details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                  Occupancy = 4,
                  rate = 600,
                  Sqft = 1100,
                  Amenity = "",
                  createDate = DateTime.Now
              });
        }
    }
}
