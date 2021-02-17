using Domain.Entities.Relational;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.Relational
{
    //public class ExamQuestionsConfiguration : IEntityTypeConfiguration<ExamQuestions>
    //{
    //    public void Configure(EntityTypeBuilder<ExamQuestions> builder)
    //    {
    //        builder.HasKey(eq => new { eq.ExamId, eq.QuestionId });

    //        builder.HasOne(eq => eq.Exam)
    //                .WithMany(e => e.Questions)
    //                .HasForeignKey(eq => eq.ExamId)
    //                .OnDelete(DeleteBehavior.ClientSetNull);

    //        //builder.HasOne(eq => eq.Question)
    //        //        .WithMany(q => q.Exams)
    //        //        .HasForeignKey(eq => eq.QuestionId)
    //        //        .OnDelete(DeleteBehavior.ClientSetNull);
    //    }
    //}
}
