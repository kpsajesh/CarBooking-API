using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.DataModels
{
    //public class CarBookingDbContext : DbContext
    public class CarBookingDbContext : IdentityDbContext
    {
        public CarBookingDbContext(DbContextOptions<CarBookingDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<CarModel> CarModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) // This is for seeding data to the database tables
        {
            builder.Entity<Make>().HasData(
                new Make
                {
                    Id = 4,
                    Name = "Honda",
                    CreatedBy = "Sajesh",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "Sajesh",
                    UpdatedDate = DateTime.Now
                },
                new Make
                {
                    Id = 5,
                    Name = "Mercides",
                    CreatedBy = "Sajesh",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "Sajesh",
                    UpdatedDate = DateTime.Now
                }
                );

            builder.Entity<CarModel>().HasData(
                new CarModel
                {
                    Id = 6,
                    Name = "Jazz",
                    CreatedBy = "Sajesh",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "Sajesh",
                    UpdatedDate = DateTime.Now,
                    MakeId = 4
                },
                new CarModel
                {
                    Id = 7,
                    Name = "RX400",
                    CreatedBy = "Sajesh",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "Sajesh",
                    UpdatedDate = DateTime.Now,
                    MakeId = 5
                }
                );
        }
    }
}
