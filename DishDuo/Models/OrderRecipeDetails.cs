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
        public List<Ingredient> Ingredients { get; set; } //Ingredients list
        public OrderRecipeDetails() 
        {
            Ingredients = new List<Ingredient>(); //Initializes the Ingredients list
        }

    }
    public class Ingredient
    {
        public string? Description { get; set; } //Ingredient desc
        public string? Quantity { get; set; } //Ingredient qty
        public string? unit { get; set; } //Ingredient unit of measure (e.g., cup, tbsp, tsps, etc.)
    }
}
