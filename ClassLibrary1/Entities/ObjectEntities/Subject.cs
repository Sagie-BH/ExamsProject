using Domain.Interfaces;
using Domain.Models;

namespace Domain.Entities.ObjectEntities
{
    public class Subject : DomainObject, IAggregateRoot
    {
        public string Description { get; set; }
    }
}