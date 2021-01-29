using Domain.Common;
using Domain.Interfaces;

namespace Domain.Models
{
    public abstract class AppObject : AuditableEntity, IAppObject
    {
        public long Id { get; private set; }
#nullable enable
        public string? Title { get; set; }
#nullable disable
    }
}
