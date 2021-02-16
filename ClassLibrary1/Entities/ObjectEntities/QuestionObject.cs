using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class QuestionObject : DomainObject, IAggregateRoot
    {
        public string Question { get; set; }
#nullable enable
        public ICollection<QuestionOption>? Options { get; set; }
        public bool? QuestionCompleted { get; set; }
        public DateTime? QuestionTimeLimit { get; set; }
        public double? SuccessRate { get; set; }
#nullable disable
    }
}
