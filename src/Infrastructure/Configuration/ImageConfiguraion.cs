using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.ImageUrl)
               .IsRequired();

        builder.HasOne(i => i.Home)
               .WithMany(h => h.Images) 
               .HasForeignKey(i => i.HomeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
