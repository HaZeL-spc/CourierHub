using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourierAPI.Data.EntityConfiguration;

public class InquiryConfiguration : IEntityTypeConfiguration<Inquiry>
{
    public void Configure(EntityTypeBuilder<Inquiry> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(inquiry => inquiry.StartLocation)
        .WithMany()
        .OnDelete(DeleteBehavior.NoAction); // Restrict delete behavior for StartLocation

        builder.HasOne(inquiry => inquiry.EndLocation)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction); // Or specify NoAction for EndLocation
    }
}
