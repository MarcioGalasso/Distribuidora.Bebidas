
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Repository.Postgresql.Configuration
{
    public class ResaleConfiguration : IEntityTypeConfiguration<Resale>
    {
        public void Configure(EntityTypeBuilder<Resale> builder)
        {
            builder.ToTable("resales");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(r => r.Cnpj)
                .HasColumnName("cnpj")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.RazaoSocial)
                .HasColumnName("razao_social")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(r => r.Name)
                .HasColumnName("name")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasMany(r => r.Contact)
                   .WithOne()
                   .HasForeignKey(c => c.ResaleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Address)
                   .WithOne()
                   .HasForeignKey(a => a.ResaleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
