using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class WebhookConfigurationConfiguration : IEntityTypeConfiguration<WebhookConfiguration>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WebhookConfiguration> builder)
    {
        builder.ToTable("WebhookConfigurations");
        builder.HasKey(wc => wc.WebhookId);

        builder.Property(wc => wc.WebhookUrl)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(wc => wc.EventType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(wc => wc.IsActive)
            .HasDefaultValue(true);

        builder.Property(wc => wc.SecretToken)
            .HasMaxLength(500);

        builder.Property(wc => wc.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(wc => wc.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(wc => wc.User)
            .WithMany(u => u.WebhookConfigurations)
            .HasForeignKey(wc => wc.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}