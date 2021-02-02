using Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Models
{
    public class AppUser : IdentityUser
    {
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
