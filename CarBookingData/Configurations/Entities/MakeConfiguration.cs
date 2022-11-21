using CarBookingData.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingData.Configurations.Entities
{
    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasData(
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
        }
    }
}
