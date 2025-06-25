
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Repository.Postgresql.Configuration
{
    public class ItemsConfiguration : IEntityTypeConfiguration<Items>
    {
        public void Configure(EntityTypeBuilder<Items> builder)
        {
            builder.ToTable("items");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(i => i.Description)
                .HasColumnName("description")
                .HasMaxLength(200);

            builder.Property(i => i.Amount)
                .HasColumnName("amount")
                .IsRequired();

            builder.Property(i => i.SKU)
                .HasColumnName("sku")
                .HasMaxLength(100);

            builder.Property(i => i.IdOrder)
                .HasColumnName("id_order")
                .IsRequired();

            builder.HasOne<Order>()
                   .WithMany(o => o.Items)
                   .HasForeignKey(i => i.IdOrder)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
