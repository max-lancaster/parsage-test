using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using parsage_test.Domain.Entities;

namespace parsage_test.Infrastructure.Persistence.Configurations;

public class ManufacturerConfiguration: IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.Property(m => m.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}