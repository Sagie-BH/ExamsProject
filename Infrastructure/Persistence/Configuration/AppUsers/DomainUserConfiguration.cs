using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.AppUsers
{
    public class DomainUserConfiguration : IEntityTypeConfiguration<DomainUser>
    {
        public void Configure(EntityTypeBuilder<DomainUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(20).IsRequired();

            builder.Property(u => u.LastName).HasMaxLength(40).IsRequired();

            builder.Property(a => a.Gender)
                   .HasConversion(v => v.ToString(),
                        v => (Gender)Enum.Parse(typeof(Gender), v))
                   .IsRequired();
            //builder.Map
        }
    }
}
