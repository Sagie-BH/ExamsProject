using Domain.Common;

namespace Domain.Models
{
    public class UserNotification : AuditableEntity
    {
        public long Id { get; set; }
        public string Notification { get; set; }
    }

}