using DishDuo.Models;
using Microsoft.AspNetCore.Mvc;
using DishDuo.Repository;
using Microsoft.AspNetCore.Authorization;
using DishDuo.ContextDBConfig;

namespace DishDuo.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IData data;
        private readonly DishDuoDBContext context;

        public CartController(IData data, DishDuoDBContext context)
        {
            this.data = data; 
            this.context = context;
        }
        //Index display task
        public async Task<IActionResult> Index()
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            var cartsList = context.Carts.Where(c => c.UserId == user.Id).ToList(); //Cartslist variable is set to carts context as a list
            return View(cartsList); //Returns cart view with the cartsList variable
        }
        //Cart data saving task
        [HttpPost]
        public async Task<IActionResult> SaveCart(Cart cart) 
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            cart.UserId = user?.Id; //UserId in cart is set to the userId

            if (ModelState.IsValid) 
            {
                context.Carts.Add(cart); 
                context.SaveChanges();
                return Ok(cart);
            }

            return BadRequest(); //returns BadRequest
        }
        //Get data added to cart task
        [HttpGet]
        public async Task<IActionResult> GetAddedCarts()
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            var carts = context.Carts.Where(c => c.UserId == user.Id).Select(c => c.RecipeId).ToList(); //Carts variable is set to carts context as a list
            return Ok(carts);
        }
        //Remove from cart method
        [HttpPost]
        public IActionResult RemoveCartFromList(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var cart = context.Carts.Where(c => c.RecipeId == Id).FirstOrDefault(); //Sets cart variable to carts context using current Id
                if (cart != null) 
                {
                    context.Carts.Remove(cart); //Removes current cart item
                    context.SaveChanges(); //Saves context changes
                    return Ok();
                }
            }
            return BadRequest(); //Returns BadRequest
        }
        //Get cart task
        [HttpGet]
        public async Task<IActionResult> GetCartList()
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            var cartList = context.Carts.Where(c => c.UserId == user.Id).Take(3).ToList(); //CartsList variable is set to carts context as a list
            return PartialView("_CartList", cartList); //Returns a partialview of the cartlist
        }
    }
}
