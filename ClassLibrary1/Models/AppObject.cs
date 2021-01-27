using Domain.Common;

namespace Domain.Models
{
    public abstract class AppObject : AuditableEntity
    {
        public long Id { get; private set; }
#nullable enable
        public string? Title { get; set; }
#nullable disable
    }
}
