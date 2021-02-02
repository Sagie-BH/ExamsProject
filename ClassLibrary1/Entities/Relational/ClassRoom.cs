using Domain.Entities.UserEntities;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Relational
{
    public class ClassRoom : DomainObject, IAggregateRoot
    {
        public Guid ClassTeacherId { get; set; }
        public Teacher ClassTeacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
