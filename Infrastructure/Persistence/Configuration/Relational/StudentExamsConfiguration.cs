using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.Relational
{
    class StudentExamsConfiguration : IEntityTypeConfiguration<FinishedExams>
    {
        public void Configure(EntityTypeBuilder<FinishedExams> builder)
        {
            builder.Property(se => se.IsDone).IsRequired();

            builder.Property(se => se.Grade).HasPrecision(3, 2).IsRequired();

            //builder.Property(se => se.Student).IsRequired();

            //builder.Property(se => se.Exam).IsRequired();
        }
    }
}
