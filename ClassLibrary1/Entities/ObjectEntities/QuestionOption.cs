using Domain.Enums;
using Domain.Models;

namespace Domain.Entities.ObjectEntities
{
    public class QuestionOption : DomainObject
    {
        public bool IsRightAnswer { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
