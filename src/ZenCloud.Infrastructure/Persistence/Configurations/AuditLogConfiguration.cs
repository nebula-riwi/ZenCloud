using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");
        builder.HasKey(al => al.AuditId);

        builder.Property(al => al.Action)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(al => al.EntityType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(al => al.OldValue)
            .HasColumnType("text");

        builder.Property(al => al.NewValue)
            .HasColumnType("text");

        builder.Property(al => al.IpAddress)
            .HasMaxLength(50);

        builder.Property(al => al.UserAgent)
            .HasMaxLength(500);

        builder.Property(al => al.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(al => al.User)
            .WithMany(u => u.AuditLogs)
            .HasForeignKey(al => al.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}