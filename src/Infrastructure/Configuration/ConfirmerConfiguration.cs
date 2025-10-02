using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ConfirmerConfiguration : IEntityTypeConfiguration<UserConfirm>
{
    public void Configure(EntityTypeBuilder<UserConfirm> builder)
    {
        builder.ToTable("Confirmers");

        builder.HasKey(uc => uc.ConfirmerId);

        builder.Property(uc => uc.ConfirmingCode)
            .IsRequired(false)
            .HasMaxLength(6);

        builder.HasIndex(uc => uc.Email)
            .IsUnique();

        builder.Property(uc => uc.ExpiredDate)
            .IsRequired()
            .HasDefaultValueSql("DATEADD(MINUTE, 10, GETUTCDATE())");

        builder.Property(uc => uc.IsConfirmed)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(uc => uc.User)
            .WithOne(u => u.Confirmer)
            .HasForeignKey<UserConfirm>(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
