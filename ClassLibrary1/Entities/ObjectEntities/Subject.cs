using Domain.Entities.Relational;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Entities.ObjectEntities
{
    public class Subject : DomainObject, IAggregateRoot
    {
        public string Description { get; set; }

    }
}