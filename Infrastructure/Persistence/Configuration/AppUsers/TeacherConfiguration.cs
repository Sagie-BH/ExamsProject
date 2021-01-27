using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //builder.HasBaseType<AppUser>();
            builder.Property(t => t.FirstName).HasMaxLength(20).IsRequired();

            builder.Property(t => t.LastName).HasMaxLength(40).IsRequired();

            builder.ToTable("Teachers");

            builder.Property(t => t.DateStarted).IsRequired();

            builder.Property(t => t.MonthlySalary)
                    .HasPrecision(3, 2)
                    .IsRequired();

            //builder.Property(t => t.Subjects).IsRequired(false);

            builder.HasOne(t => t.PersonalClass)
                    .WithOne(cr => cr.ClassTeacher)
                    .HasForeignKey<ClassRoom>(cr => cr.ClassTeacherId);

            builder.ToTable("Teachers");

            //builder.Property(a => a.Gender)
            //       .HasConversion(v => v.ToString(),
            //            v => (Gender)Enum.Parse(typeof(Gender), v))
            //       .IsRequired();

        }
    }
}
