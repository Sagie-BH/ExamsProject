using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configuration.AppObjects
{
    public class ExamTextConfiguration : IEntityTypeConfiguration<ExamText>
    {
        public void Configure(EntityTypeBuilder<ExamText> builder)
        {
            builder.Property(ex => ex.Alignment)
                    .HasConversion(al => al.ToString(),
                    a => (Alignment)Enum.Parse(typeof(Alignment), a));
        }
    }

}
