using CarBookingData.Configurations.Entities;
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
    public class CarBookingDbContext : IdentityDbContext<ApiUser>
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
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MakeConfiguration()); // this is for the data seeding to the make table, it is optional
            builder.ApplyConfiguration(new CarModelConfiguration()); // this is for the data seeding to the CarModel table, it is optional

            builder.ApplyConfiguration(new RoleConfiguration()); // this is for the data seeding to the Role table to create the user roles

            /*builder.Entity<Make>().HasData( // this code moved to MakeConfiguration class under Configurations / Entities folder. This is working code
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
                );*/

            /*builder.Entity<CarModel>().HasData( // this code moved to CarModelConfiguration class under Configurations / Entities folder. This is working code
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
                );*/
        }
    }
}
