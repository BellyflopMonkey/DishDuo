//JB
namespace DishDuo.Models
{
    //JB this is the recipe model class
    public class Recipe
    {
        //JB recipe ID
        public string? Id { get; set; }
        //JB URL of the recipe image
        public string? Image_url { get; set; }
        //JB publisher of the recipe
        public string? Publisher { get; set; }
        //JB Title of the recipe
        public string? Title { get; set; }
    }
}
