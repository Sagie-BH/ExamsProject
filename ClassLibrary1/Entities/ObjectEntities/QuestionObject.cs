using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class QuestionObject : DomainObject, IAggregateRoot
    {
        public string QuestionText { get; set; }
        public Subject QuestionSubject { get; set; }
        public QuestionType QuestionType { get; set; }

#nullable enable
        public ICollection<AnswerOption>? AnswerOptions { get; set; }
        public bool? QuestionCompleted { get; set; }
        public TimeSpan? QuestionTimeLimit { get; set; }
        public double? SuccessRate { get; set; }
#nullable disable
    }
}
