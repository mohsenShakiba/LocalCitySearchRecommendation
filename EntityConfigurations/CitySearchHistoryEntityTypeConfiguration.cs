using LCSR.Domain.Aggregates.Cities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCSR.Infrastructure.EntityConfigurations
{
    public class CitySearchHistoryEntityTypeConfiguration: IEntityTypeConfiguration<CitySearchHistory>
    {
        public void Configure(EntityTypeBuilder<CitySearchHistory> builder)
        {
            builder.ToTable("history");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.DestinationCity).WithMany().HasForeignKey(e => e.DestinationCityId)
                .HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(e => e.SourceCity).WithMany().HasForeignKey(e => e.SourceCityId)
                .HasPrincipalKey(e => e.Id).OnDelete(DeleteBehavior.Restrict);
        }
    }
}