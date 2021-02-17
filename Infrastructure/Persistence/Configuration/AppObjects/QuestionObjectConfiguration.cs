using Domain.Entities.ObjectEntities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Persistence.Configuration.AppObjects
{
    public class QuestionObjectConfiguration : IEntityTypeConfiguration<QuestionObject>
    {
        public void Configure(EntityTypeBuilder<QuestionObject> builder)
        {
            builder.Property(qo => qo.QuestionType)
                    .HasConversion(qt => qt.ToString(),
                         v => (QuestionType)Enum.Parse(typeof(QuestionType), v))
                    .IsRequired();
        }
    }

}
