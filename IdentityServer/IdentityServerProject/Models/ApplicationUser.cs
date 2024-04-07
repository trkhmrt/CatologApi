using Microsoft.AspNetCore.Identity;

namespace IdentityServerProject.Models
{
   
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
