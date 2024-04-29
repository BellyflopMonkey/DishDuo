using System.ComponentModel.DataAnnotations;

namespace DishDuo.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } //Order ID
        [Required]
        public string? RecipeId { get; set; } //Ordered item ID
        [Required]
        public string? RecipeName { get; set; } //Ordered item name
        [Required]
        public string? UserId { get; set; } //Order User ID  
    }
}
