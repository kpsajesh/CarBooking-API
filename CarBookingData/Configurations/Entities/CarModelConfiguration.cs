using CarBookingData.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.Configurations.Entities
{
    internal class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CarModel> builder)
        {
            builder.HasData( 
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
