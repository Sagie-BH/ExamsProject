using Domain.Models;

namespace Domain.Entities.ObjectEntities
{
    public class AnswerOption : DomainObject
    {
        public bool IsRightAnswer { get; set; }
        public ExamText AnswerText { get; set; }
    }
}
