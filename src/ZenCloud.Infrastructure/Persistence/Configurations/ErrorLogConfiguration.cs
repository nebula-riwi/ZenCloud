using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ErrorLog> builder)
    {
        builder.ToTable("ErrorLogs");
        builder.HasKey(el => el.ErrorId);

        builder.Property(el => el.ErrorMessage)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(el => el.StackTrace)
            .HasColumnType("text");

        builder.Property(el => el.Source)
            .HasMaxLength(200);

        builder.Property(el => el.RequestPath)
            .HasMaxLength(500);

        builder.Property(el => el.RequestMethod)
            .HasMaxLength(10);

        builder.Property(el => el.IpAddress)
            .HasMaxLength(50);

        builder.Property(el => el.Severity)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(el => el.IsNotified)
            .HasDefaultValue(false);

        builder.Property(el => el.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(el => el.User)
            .WithMany(u => u.ErrorLogs)
            .HasForeignKey(el => el.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}