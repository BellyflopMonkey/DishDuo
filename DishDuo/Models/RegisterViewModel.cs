using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DishDuo.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; } //Registering user name
        
        [Required, EmailAddress]
        public string Email { get; set; } //Registering user email
        [Required, PasswordPropertyText]
        public string Password { get; set; } //Registering user password

    }
}
