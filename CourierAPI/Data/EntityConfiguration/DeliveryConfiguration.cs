using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourierAPI.Data.EntityConfiguration
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Status)
                .IsRequired();

            builder.Property(d => d.Name)
                .IsRequired();

            builder.Property(d => d.PickedUpTime)
                .IsRequired();

            builder.Property(d => d.FinishedDeliveryTime)
                .IsRequired();

            builder.HasOne(d => d.Client)
                .WithMany()
                .HasForeignKey(d => d.ClientId)
                .IsRequired();

            builder.HasOne(d => d.StartLocation)
                .WithMany()
                .HasForeignKey(d => d.StartLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.EndLocation)
                .WithMany()
                .HasForeignKey(d => d.EndLocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
