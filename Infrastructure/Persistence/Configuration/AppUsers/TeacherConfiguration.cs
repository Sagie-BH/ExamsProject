using Domain.Entities.UserEntities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configuration.AppUsers
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.Property(t => t.DateStarted).IsRequired();

            builder.Property(t => t.FirstName).HasMaxLength(20).IsRequired();

            builder.Property(t => t.LastName).HasMaxLength(40).IsRequired();

            builder.Property(t => t.Gender)
                   .HasConversion(gender => gender.ToString(),
                        v => (Gender)Enum.Parse(typeof(Gender), v))
                   .IsRequired();  

            //builder.HasOne(t => t.PersonalClass)
            //        .WithOne(cr => cr.ClassTeacher)
            //        .HasForeignKey<ClassRoom>(cr => cr.ClassTeacherId);

        }
    }
}
