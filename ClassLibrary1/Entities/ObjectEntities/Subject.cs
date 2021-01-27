using Domain.Interfaces;
using Domain.Models;

namespace Domain.Entities.ObjectEntities
{
    public class Subject : AppObject, IAggregateRoot
    {
        public string Description { get; set; }

    }
}