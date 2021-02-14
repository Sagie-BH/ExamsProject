using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public abstract class DomainUser : IAggregateRoot
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
#nullable enable
        public ICollection<UserNotification>? Notifications { get; set; }
#nullable disable
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
