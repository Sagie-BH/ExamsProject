using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Entities.UserEntities
{
    public class Student : AppUser, IAggregateRoot
    {
        public double AvrageGrade { get; set; }
        public Teacher PersonalTeacher { get; set; }
#nullable enable
        public virtual ICollection<StudentExams>? Exams { get; }
#nullable disable
    }
}
