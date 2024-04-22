using System.ComponentModel.DataAnnotations;

namespace DishDuo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? RecipeId { get; set; }
        [Required]
        public string? RecipeName { get; set; }
        [Required]
        public string? UserId { get; set; }       
    }
}
