namespace DishDuo.Models
{
    public class OrderRecipeDetails
    {
        //JB recipe ID
        public string? Id { get; set; }
        //JB URL of the recipe image
        public string? Image_url { get; set; }
        //JB publisher of the recipe
        public string? Publisher { get; set; }
        //JB Title of the recipe
        public string? Title { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public OrderRecipeDetails() 
        {
            Ingredients = new List<Ingredient>();
        }

    }
    public class Ingredient
    {
        public string? Description { get; set; }
        public string? Quantity { get; set; }
        public string? unit { get; set; }
    }
}
