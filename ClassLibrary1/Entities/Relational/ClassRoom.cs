using Domain.Entities.ObjectEntities;
using Domain.Entities.UserEntities;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Relational
{
    public class ClassRoom : DomainObject, IAggregateRoot
    {
        public Teacher ClassTeacher { get; set; }
        public ICollection<Student> Students { get; set; }
        public Subject Subject { get; set; }
    }
}
