﻿using Domain.Entities.Relational;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class AppExam : DomainObject, IAggregateRoot
    {
        public bool IsPrivate { get; set; }
        public Subject ExamSubject { get; set; }
#nullable enable
        public double? SuccessRate { get; set; }
        public string? Description { get; set; }
        public TimeSpan? TestTimeLimit { get; set; }
        public ICollection<ExamQuestions>? Questions { get; set; }
        public ICollection<ExamText>? ExamText { get; set; }
        public ICollection<ExamImage>? ExamImages { get; set; }
        public DateTime? DueTime { get; set; }
#nullable disable
    }
}