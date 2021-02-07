using Domain.Entities.Relational;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class Subject : DomainObject, IAggregateRoot
    {
        public string Description { get; set; }
#nullable enable
        public ICollection<ClassRoom>? ClassRooms { get; set; }
#nullable disable
    }
}