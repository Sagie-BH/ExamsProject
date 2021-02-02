using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Entities.UserEntities
{
    public class Student : DomainUser
    {
        public double AvrageGrade { get; set; }
        public Teacher PersonalTeacher { get; set; }
#nullable enable
        public ICollection<FinishedExams>? Exams { get; }
#nullable disable
    }
}
