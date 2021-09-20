using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volvo.Domain.Entities;

namespace Volvo.Infra.Data.EntityConfigurations
{    
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Truck");

            builder.HasKey(p => p.Id).HasName("PrimaryKey_Truck");            

            builder.Property(p => p.Model).HasMaxLength(20).IsRequired();

            builder.Property(p => p.YearManufacture).IsRequired();

            builder.Property(p => p.ModelYear).IsRequired();

            builder.HasData(
                    new Truck
                    {
                        Id = 1,
                        Model = "FH",
                        YearManufacture = 2021,
                        ModelYear = 2022
                    },
                    new Truck
                    {
                        Id = 2,
                        Model = "FM",
                        YearManufacture = 2021,
                        ModelYear = 2022
                    }
            );
        }
    }
}
