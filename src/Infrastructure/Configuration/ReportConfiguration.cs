using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Description)
               .IsRequired()
               .HasMaxLength(1000);

        builder.HasOne(r => r.Reporter)
               .WithMany()
               .HasForeignKey(r => r.ReporterId)
               .OnDelete(DeleteBehavior.Restrict);

     
        builder.HasOne(r => r.ReportedHome)
               .WithMany()
               .HasForeignKey(r => r.ReportedHomeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
