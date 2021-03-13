using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class QuestionObject : DomainObject, IAggregateRoot
    {
        public int Index { get; set; }
        public ExamText QuestionText { get; set; }
#nullable enable
        public ICollection<AnswerOption>? AnswerOptions { get; set; }
#nullable disable
    }
}
