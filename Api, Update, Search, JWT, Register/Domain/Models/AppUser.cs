using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
