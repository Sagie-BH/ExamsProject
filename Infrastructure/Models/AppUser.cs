using Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using System;

namespace Infrastructure.Models
{
    public class AppUser : IdentityUser
    {
        public Student Student { get; set; }
        public long? StudentId { get; set; }
        public Teacher Teacher { get; set; }
        public long? TeacherId { get; set; }
    }
}
