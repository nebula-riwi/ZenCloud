using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;


public class DatabaseEngineConfiguration : IEntityTypeConfiguration<DatabaseEngine>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DatabaseEngine> builder)
    {
        builder.ToTable("DatabaseEngines");
        builder.HasKey(de => de.EngineId);

        builder.Property(de => de.EngineName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(de => de.DefaultPort)
            .IsRequired();

        builder.Property(de => de.IsActive)
            .HasDefaultValue(true);

        builder.Property(de => de.IconUrl)
            .HasMaxLength(500);

        builder.Property(de => de.Description)
            .HasMaxLength(500);
    }
}