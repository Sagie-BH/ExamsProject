using Domain.Common;
using Domain.Interfaces;
using System;

namespace Domain.Models
{
    public abstract class DomainObject : AuditableEntity
    {
        public long Id { get; private set; }
#nullable enable
        public string? Title { get; set; }
#nullable disable
    }
}
