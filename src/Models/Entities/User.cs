using Microsoft.AspNetCore.Identity;

namespace Models.Entities
{
    public class User : IdentityUser
    {
        public string PasswordSalt { get; set; }
    }
}