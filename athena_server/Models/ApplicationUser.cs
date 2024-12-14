using Microsoft.AspNetCore.Identity;

namespace athena_server.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<Wiki> WikisJoined {  get; set; }
    }
}