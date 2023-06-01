using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using parsage_test.Domain.Entities;

namespace parsage_test.Infrastructure.Persistence.Configurations;

public class BikeConfiguration: IEntityTypeConfiguration<Bike>
{
    public void Configure(EntityTypeBuilder<Bike> builder)
    {
        builder.Property(b => b.Model)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(b => b.Price).IsRequired();
        builder.Property(b => b.ManufacturerId).IsRequired();
        builder.Property(b => b.FrameSize).IsRequired();
        builder.HasOne<Manufacturer>(b => b.Manufacturer);
    }
}