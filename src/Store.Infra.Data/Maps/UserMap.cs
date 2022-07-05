using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("userstore");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId)
                .HasColumnName("userid")
                .UseIdentityColumn();
            builder.Property(p => p.Name)
                .HasColumnName("name");
            builder.Property(p => p.LastName)
                .HasColumnName("lastname");
            builder.Property(p => p.Email)
                .HasColumnName("email");
            builder.HasMany(x => x.Purchases)
                .WithOne(w => w.User)
                .HasForeignKey(c => c.UserId);
        }
    }   
}
