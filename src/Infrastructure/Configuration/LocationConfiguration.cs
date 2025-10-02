using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.City)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.District)
               .HasMaxLength(100);

        builder.Property(l => l.Street)
               .HasMaxLength(150);

        builder.Property(l => l.HouseNumber)
               .HasMaxLength(20);

        builder.Property(l => l.ZipCode)
               .HasMaxLength(20);

        builder.Property(l => l.Landmark)
               .HasMaxLength(200);

        builder.HasMany(l => l.Homes)
               .WithOne(h => h.Location)
               .HasForeignKey(h => h.LocationId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
