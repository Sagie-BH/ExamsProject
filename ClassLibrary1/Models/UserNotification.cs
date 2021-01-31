using Domain.Common;
using Domain.Interfaces;

namespace Domain.Models
{
    public class UserNotification : AuditableEntity, IAggregateRoot
    {
        // ?? App Object ??

        public long Id { get; set; }
        public string Notification { get; set; }
    }

}