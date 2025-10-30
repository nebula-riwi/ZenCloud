using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class EmailLogConfiguration : IEntityTypeConfiguration<EmailLog>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmailLog> builder)
    {
        builder.ToTable("EmailLogs");
        builder.HasKey(el => el.EmailLogId);

        builder.Property(el => el.EmailType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(el => el.RecipientEmail)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(el => el.Subject)
            .HasMaxLength(500);

        builder.Property(el => el.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(el => el.ErrorMessage)
            .HasMaxLength(2000);

        builder.Property(el => el.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(el => el.User)
            .WithMany(u => u.EmailLogs)
            .HasForeignKey(el => el.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}