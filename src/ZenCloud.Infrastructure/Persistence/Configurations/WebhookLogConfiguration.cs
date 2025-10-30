using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class WebhookLogConfiguration : IEntityTypeConfiguration<WebhookLog>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WebhookLog> builder)
    {
        builder.ToTable("WebhookLogs");
        builder.HasKey(wl => wl.WebhookLogId);

        builder.Property(wl => wl.EventType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(wl => wl.PayloadJson)
            .HasColumnType("text");

        builder.Property(wl => wl.ResponseBody)
            .HasColumnType("text");

        builder.Property(wl => wl.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(wl => wl.AttemptCount)
            .HasDefaultValue(0);

        builder.Property(wl => wl.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(wl => wl.WebhookConfiguration)
            .WithMany(wc => wc.WebhookLogs)
            .HasForeignKey(wl => wl.WebhookId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}