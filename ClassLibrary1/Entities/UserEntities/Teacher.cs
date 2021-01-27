using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.UserEntities
{
    public class Teacher : AppUser, IAggregateRoot
    {
        public DateTime DateStarted { get; set; }
        public double MonthlySalary { get; set; }
#nullable enable
        public virtual ICollection<Subject>? Subjects { get; set; }
        public virtual ClassRoom? PersonalClass { get; set; }

#nullable disable
    }
}
