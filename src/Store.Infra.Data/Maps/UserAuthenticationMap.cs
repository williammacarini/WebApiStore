﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Data.Maps
{
    internal class UserAuthenticationMap : IEntityTypeConfiguration<UserAuthentication>
    {
        public void Configure(EntityTypeBuilder<UserAuthentication> builder)
        {
            builder.ToTable("user_authentication");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
                .HasColumnName("user_id");
            builder.Property(p => p.Email)
                            .HasColumnName("email");
            builder.Property(p => p.Password)
                            .HasColumnName("password");
        }
    }
}
