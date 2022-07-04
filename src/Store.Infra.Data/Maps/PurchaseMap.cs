using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Maps
{
    internal class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchases");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();
            builder.HasOne(h => h.User)
                .WithMany(w => w.Purchases);
            builder.HasOne(h => h.Product)
                .WithMany(w => w.Purchases);
        }
    }
}
