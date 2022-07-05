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
                .HasColumnName("id")
                .UseIdentityColumn();
            builder.HasOne(h => h.User)
                .WithMany(w => w.Purchases);
            builder.HasOne(h => h.Product)
                .WithMany(w => w.Purchases);
        }
    }
}
