using Domain.Entities.Relational;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.AppObjects
{
    public class ClassRoomSubjectsConfiguration : IEntityTypeConfiguration<ClassRoomSubjects>
    {
        public void Configure(EntityTypeBuilder<ClassRoomSubjects> builder)
        {
            builder.HasKey(crs => new { crs.ClassRoomId, crs.SubjectId });

        }
    }
}
