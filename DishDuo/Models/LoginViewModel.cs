using System.ComponentModel.DataAnnotations;

namespace DishDuo.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string? Email { get; set; } //Login email
        [Required]
        public string? Password { get; set; } //Login password

    }
}
