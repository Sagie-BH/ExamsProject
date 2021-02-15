using Domain.Entities.ObjectEntities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configuration.AppObjects
{
    public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            builder.Property(qo => qo.QuestionType)
                    .HasConversion(qt => qt.ToString(),
                         v => (QuestionType)Enum.Parse(typeof(QuestionType), v))
                    .IsRequired();
        }
    }

}
