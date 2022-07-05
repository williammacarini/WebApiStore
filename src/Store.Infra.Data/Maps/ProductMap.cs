using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Maps
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.ProductId);
            builder.Property(p => p.ProductId)
                .HasColumnName("id")
                .UseIdentityColumn();
            builder.Property(p => p.Code)
                .HasColumnName("code");
            builder.Property(p => p.Name)
                .HasColumnName("name");
            builder.Property(p => p.Price)
                .HasColumnName("price");
            builder.HasMany(h => h.Purchases)
                .WithOne(w => w.Product)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
