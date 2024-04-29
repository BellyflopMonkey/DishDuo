using Microsoft.AspNetCore.Identity;

namespace DishDuo.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; } //Username
    }
}
