using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");
        builder.HasKey(p => p.PlanId);

        builder.Property(p => p.PlanName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.MaxDatabasesPerEngine)
            .IsRequired();

        builder.Property(p => p.PriceInCOP)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.DurationInDays)
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true);

        builder.Property(p => p.Description)
            .HasMaxLength(500);
    }
}