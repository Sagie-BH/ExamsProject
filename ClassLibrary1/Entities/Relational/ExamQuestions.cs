using Domain.Entities.ObjectEntities;
using Domain.Interfaces;
using System;

namespace Domain.Entities.Relational
{
    public class ExamQuestions 
    {
        public Guid ExamId { get; set; }
        public AppExam Exam { get; set; }
        public Guid QuestionId { get; set; }
        public QuestionObject Question { get; set; }
    }
}
