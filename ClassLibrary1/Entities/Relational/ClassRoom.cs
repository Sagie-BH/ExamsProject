using Domain.Entities.UserEntities;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Entities.Relational
{
    public class ClassRoom : AppObject, IAggregateRoot
    {
        public string ClassTeacherId { get; set; }
        public Teacher ClassTeacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
