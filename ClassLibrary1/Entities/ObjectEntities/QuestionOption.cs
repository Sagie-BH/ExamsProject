using Domain.Enums;
using Domain.Models;

namespace Domain.Entities.ObjectEntities
{
    public class AnswerOption : DomainObject
    {
        public bool IsRightAnswer { get; set; }
        public string AnswerText { get; set; }
    }
}
