using Domain.Entities.Relational;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class AppExam : DomainObject, IAggregateRoot
    {
        public Subject ExamSubject { get; set; }
#nullable enable
        public double? SuccessRate { get; set; }
        public string? Description { get; set; }
        public DateTime? TestTimeLimit { get; set; }
        public ICollection<ExamQuestions>? Questions { get; set; }
#nullable disable
    }
}