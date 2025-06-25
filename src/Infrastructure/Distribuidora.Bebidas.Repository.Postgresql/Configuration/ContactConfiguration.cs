
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Distribuidora.Bebidas.Domain.Entities;

namespace Distribuidora.Bebidas.Repository.Postgresql.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("contacts");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.Telephone)
                .HasColumnName("telephone")
                .HasMaxLength(20);

            builder.Property(c => c.Responsible)
                .HasColumnName("responsible")
                .HasMaxLength(100);

            builder.Property(c => c.ResaleId)
                .HasColumnName("resale_id")
                .IsRequired();

            builder.HasOne<Resale>()
                   .WithMany(r => r.Contact)
                   .HasForeignKey(c => c.ResaleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
