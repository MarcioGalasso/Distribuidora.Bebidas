
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Repository.Postgresql.Configuration
{
    public class DeliveryAddressConfiguration : IEntityTypeConfiguration<DeliveryAddress>
    {
        public void Configure(EntityTypeBuilder<DeliveryAddress> builder)
        {
            builder.ToTable("delivery_addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(a => a.Street)
                .HasColumnName("street")
                .HasMaxLength(200);

            builder.Property(a => a.City)
                .HasColumnName("city")
                .HasMaxLength(100);

            builder.Property(a => a.ZipCode)
                .HasColumnName("zip_code")
                .HasMaxLength(20);

            builder.Property(a => a.Country)
                .HasColumnName("country")
                .HasMaxLength(100);

            builder.Property(a => a.ResaleId)
                .HasColumnName("resale_id")
                .IsRequired();

            builder.HasOne<Resale>()
                   .WithMany(r => r.Address)
                   .HasForeignKey(a => a.ResaleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
