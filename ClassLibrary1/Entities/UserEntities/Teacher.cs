using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.UserEntities
{
    public class Teacher : DomainUser
    {
        public DateTime DateStarted { get; set; }
#nullable enable
        public virtual ICollection<Subject>? Subjects { get; set; }
        public virtual ICollection<ClassRoom>? MyClasses { get; set; }

#nullable disable
    }
}
