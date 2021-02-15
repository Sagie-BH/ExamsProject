using Domain.Entities.UserEntities;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.AppUsers
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.Property(s => s.FirstName).HasMaxLength(20).IsRequired();

            builder.Property(s => s.LastName).HasMaxLength(40).IsRequired();

            builder.Property(s => s.Gender)
                   .HasConversion(v => v.ToString(),
                        v => (Gender)Enum.Parse(typeof(Gender), v))
                   .IsRequired();

            builder.Property(s => s.AvrageGrade)
                .HasPrecision(3, 2);
        }
    }
}
