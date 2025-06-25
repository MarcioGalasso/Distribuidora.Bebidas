
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Repository.Postgresql.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("id")
                .IsRequired();

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
             v => v.Kind == DateTimeKind.Utc
                     ? v
                     : DateTime.SpecifyKind(v, DateTimeKind.Utc),    
             v => DateTime.SpecifyKind(v, DateTimeKind.Utc)   
         );

            builder.Property(o => o.Request)
                .HasColumnName("request")
                .HasColumnType("timestamp with time zone")
                .IsRequired()
                .HasConversion(dateTimeConverter);


            builder.Property(o => o.Status)
                .HasColumnName("status")
                .HasConversion<int>()    
                .IsRequired();

            builder.Property(o => o.IdResale)
                .HasColumnName("id_resale")
                .IsRequired();

            builder.Property(o => o.IdDeliveryAddress)
                .HasColumnName("id_delivery_address")
                .IsRequired();

            
            builder.HasOne(o => o.Resale)
                   .WithMany()        
                   .HasForeignKey(o => o.IdResale)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasOne<DeliveryAddress>()
                   .WithMany()                     
                   .HasForeignKey(o => o.IdDeliveryAddress)
                   .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasMany(o => o.Items)
                   .WithOne()               
                   .HasForeignKey(i => i.IdOrder)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
