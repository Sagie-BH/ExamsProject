using Domain.Common;
using Domain.Interfaces;
using System;

namespace Domain.Models
{
    public abstract class DomainObject
    {
        public long Id { get; set; }
#nullable enable
        public string? Title { get; set; }
#nullable disable
    }
}
