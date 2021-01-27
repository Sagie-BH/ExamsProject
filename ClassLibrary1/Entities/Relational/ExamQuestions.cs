using Domain.Entities.ObjectEntities;
using Domain.Interfaces;

namespace Domain.Entities.Relational
{
    public class ExamQuestions : IAggregateRoot
    {
        public long ExamId { get; set; }
        public AppExam Exam { get; set; }
        public long QuestionId { get; set; }
        public QuestionObject Question { get; set; }
    }
}
