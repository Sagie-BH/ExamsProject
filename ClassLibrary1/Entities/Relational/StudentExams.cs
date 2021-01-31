using Domain.Common;
using Domain.Entities.ObjectEntities;
using Domain.Entities.UserEntities;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class FinishedExams : IAggregateRoot
    {
        public long Id { get; set; }
        public bool IsDone { get; set; }
        public double Grade { get; set; }
        public Student Student { get; set; }
        public AppExam Exam { get; set; }
    }
}