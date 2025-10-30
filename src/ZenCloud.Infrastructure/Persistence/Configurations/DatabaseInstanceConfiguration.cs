using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class DatabaseInstanceConfiguration : IEntityTypeConfiguration<DatabaseInstance>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DatabaseInstance> builder)
    {
        builder.ToTable("DatabaseInstances");
        builder.HasKey(di => di.InstanceId);

        builder.Property(di => di.DatabaseName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(di => di.DatabaseUser)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(di => di.DatabasePasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(di => di.AssignedPort)
            .IsRequired();

        builder.HasIndex(di => di.AssignedPort)
            .IsUnique();

        builder.Property(di => di.ConnectionString)
            .HasMaxLength(1000);

        builder.Property(di => di.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(di => di.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(di => di.ServerIpAddress)
            .HasMaxLength(50);

        builder.HasOne(di => di.User)
            .WithMany(u => u.DatabaseInstances)
            .HasForeignKey(di => di.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(di => di.Engine)
            .WithMany(de => de.DatabaseInstances)
            .HasForeignKey(di => di.EngineId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}