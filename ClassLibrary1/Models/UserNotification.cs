using Domain.Common;
using Domain.Interfaces;

namespace Domain.Models
{
    public class UserNotification :  IAggregateRoot
    {
        public long Id { get; set; }
        public string Notification { get; set; }
    }

}