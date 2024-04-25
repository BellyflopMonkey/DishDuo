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

        public CartController(IData data, DishDuoDBContext context) //CartController constructor
        {
            this.data = data; //Sets data to IData varaible
            this.context = context; //Sets context to DishDuoDBContext variable
        }

        public async Task<IActionResult> Index() //Index task method
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            var cartsList = context.Carts.Where(c => c.UserId == user.Id).ToList(); //Cartslist variable is set to carts context as a list
            return View(cartsList); //Returns cart view with the cartsList variable
        }

        [HttpPost]
        public async Task<IActionResult> SaveCart(Cart cart) //SaveCart task method
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            cart.UserId = user?.Id; //UserId in cart is set to the userId

            if (ModelState.IsValid) //Checks if the modelstate is valid
            {
                context.Carts.Add(cart); //adds the cart to the cart context
                context.SaveChanges(); //Saves changes to context
                return Ok(cart); //returns cart
            }

            return BadRequest(); //returns BadRequest
        }
        [HttpGet]
        public async Task<IActionResult> GetAddedCarts() //GetAddedCarts method
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            var carts = context.Carts.Where(c => c.UserId == user.Id).Select(c => c.RecipeId).ToList(); //Carts variable is set to carts context as a list
            return Ok(carts);
        }
        [HttpPost]
        public IActionResult RemoveCartFromList(string Id) //RemoveCartFromList action result method
        {
            if (!string.IsNullOrEmpty(Id)) //Runs if the Id string is not null/empty
            {
                var cart = context.Carts.Where(c => c.RecipeId == Id).FirstOrDefault(); //Sets cart variable to carts context using current Id
                if (cart != null) //Runs if the cart is not null
                {
                    context.Carts.Remove(cart); //Removes current cart item
                    context.SaveChanges(); //Saves context changes
                    return Ok();
                }
            }
            return BadRequest(); //Returns BadRequest
        }

        [HttpGet]
        public async Task<IActionResult> GetCartList() //GetCartList task method
        {
            var user = await data.GetUser(HttpContext.User); //user Variable is set to HTTPContext user
            var cartList = context.Carts.Where(c => c.UserId == user.Id).Take(3).ToList(); //CartsList variable is set to carts context as a list
            return PartialView("_CartList", cartList); //Returns a partialview of the cartlist
        }
    }
}
