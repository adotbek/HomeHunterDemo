using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HomeConfiguration : IEntityTypeConfiguration<Home>
{
    public void Configure(EntityTypeBuilder<Home> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.OwnerNumber).IsRequired().HasMaxLength(20);
        builder.Property(h => h.Bio).HasMaxLength(1000);
        builder.Property(h => h.Type).IsRequired().HasMaxLength(50);
        builder.Property(h => h.Status).IsRequired().HasMaxLength(50);

        builder.Property(h => h.Price)
        .HasPrecision(18, 2);

        builder.HasOne(h => h.Category)
               .WithMany(c => c.Homes);
        builder.Property(h => h.IsAvailable)
                     .HasDefaultValue(false);

        builder.HasMany(h => h.Images)
        .WithOne(i => i.Home)
        .HasForeignKey(i => i.HomeId)
        .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne<Location>()
        //    .WithMany(h=>h.Homes)
        //    ;
    }
}
