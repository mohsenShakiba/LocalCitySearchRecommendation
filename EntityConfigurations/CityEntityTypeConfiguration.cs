using LCSR.Domain.Aggregates.Cities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCSR.Infrastructure.EntityConfigurations
{
    public class CityEntityTypeConfiguration: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("cities");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired();

            builder.HasMany(e => e.Histories).WithOne().HasPrincipalKey(e => e.Id).HasForeignKey(e => e.SourceCityId);
        }
    }
}