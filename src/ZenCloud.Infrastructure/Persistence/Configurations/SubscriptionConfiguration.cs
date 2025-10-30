using ZenCloud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ZenCloud.Infrastructure.Persistence.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscriptions");
        builder.HasKey(us => us.SubscriptionId);

        builder.Property(us => us.IsActive)
            .HasDefaultValue(true);

        builder.Property(us => us.MercadoPagoSubscriptionId)
            .HasMaxLength(200);

        builder.Property(us => us.PaymentStatus)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(us => us.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(us => us.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(us => us.User)
            .WithMany(u => u.Subscriptions)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(us => us.Plan)
            .WithMany(p => p.Subscriptions)
            .HasForeignKey(us => us.PlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}