using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Maps
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();
            builder.HasMany(h => h.Purchases)
                .WithOne(w => w.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
