using System.ComponentModel.DataAnnotations;

namespace DishDuo.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; } //Cart ID
        [Required]
        public string? Image_url { get; set; } //Cart item image
        [Required]
        public string? Publisher { get; set; } //Cart item publisher
        [Required]
        public string? Title { get; set; } //Cart item name
        public string? UserId { get; set; } //Cart user's ID
        public string? RecipeId { get; set;} //Cart item recipe ID
    }
}
