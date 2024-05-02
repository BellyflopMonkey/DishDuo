using DishDuo.ContextDBConfig;
using DishDuo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//JB
namespace DishDuo.Controllers
{
    //JB This is the Recipe Controller
    public class RecipeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DishDuoDBContext context;

        public RecipeController(UserManager<ApplicationUser> userManager, DishDuoDBContext dBContext)
        {
            _userManager = userManager;
            context = dBContext;
        }

        //JB This action returns the Index view
        public IActionResult Index()
        {
            return View();
        }
        //JB This action is a POST method that takes a list of recipes and returns a partial view
        [HttpPost]
        public IActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
        {
            return PartialView("_RecipeCard", recipes);
        }
        //Search method
        public IActionResult Search([FromQuery] string recipe)
        {
            ViewBag.Recipe = recipe;
            return View(); //Returns view with the provided recipe
        }
        //Order query method
        public IActionResult Order([FromQuery] string id) 
        {
            ViewBag.Id = id;
            return View(); //Returns order screen of the provided id
        }
        //Show order task
        [HttpPost]
        public async Task<IActionResult> ShowOrder(OrderRecipeDetails orderRecipeDetails) 
        {

            var user = await _userManager.GetUserAsync(HttpContext.User); //Sets user to the HTTPContext user
            ViewBag.UserId = user?.Id;
            return PartialView("_ShowOrder",orderRecipeDetails); //Returns partial view of the order using the provided details
        }
        //Order method
        [HttpPost]
        [Authorize]
        
        public IActionResult Order([FromForm]Order order)
        {
            if(ModelState.IsValid) 
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index", "Recipe"); //Returns recipe index if modelstate is valid
            }
            return RedirectToAction("Order", "Recipe", new {id=order.Id}); //Returns recipe order with a new order id
        }
    }
}
