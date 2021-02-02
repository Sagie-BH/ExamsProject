using Domain.Entities.Relational;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class QuestionObject : DomainObject, IAggregateRoot
    {
        public string Question { get; set; }
        public Subject Subject { get; set; }
        public ICollection<ExamQuestions> Exams { get; set; }
#nullable enable
        public ICollection<QuestionOption>? Options { get; set; }
        public bool? QuestionCompleted { get; set; }
        public string? Tips { get; set; }
        public string? Comments { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? QuestionTimeLimit { get; set; }
        public double? SuccessRate { get; set; }
#nullable disable
    }
}
