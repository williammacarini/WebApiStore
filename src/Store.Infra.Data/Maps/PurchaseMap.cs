using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Maps
{
    internal class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("purchase");
            builder.HasKey(x => x.PurchaseId);
            builder.Property(p => p.PurchaseId)
                .HasColumnName("purchase_id")
                .UseIdentityColumn();
            builder.Property(p => p.UserId)
                .HasColumnName("user_id");
            builder.Property(p => p.ProductId)
                .HasColumnName("product_id");
            builder.Property(p => p.PurchaseDate)
                .HasColumnType("date")
                .HasColumnName("purchase_date");
            builder.HasOne(h => h.User)
                .WithMany(w => w.Purchases);
            builder.HasOne(h => h.Product)
                .WithMany(w => w.Purchases);
        }
    }
}
