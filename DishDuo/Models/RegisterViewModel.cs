using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DishDuo.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, PasswordPropertyText]
        public string Password { get; set; }

    }
}
