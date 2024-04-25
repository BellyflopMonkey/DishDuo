using Microsoft.AspNetCore.Mvc;
using DishDuo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace DishDuo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login() //Login actionresult method
        {
            return View(); //Returns the "Login" view
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string? returnUrl) //Login task method
        {
            if (ModelState.IsValid) //Checks if the ModelState is valid
            {
                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false); //Variable for sign-in using _signinmanager
                if (result.Succeeded) //Checks if result variable was successful
                {
                    if(!string.IsNullOrEmpty(returnUrl)) //Checks if the return url has a value
                        return LocalRedirect(returnUrl); //Redirects to the return url if it has a value
                    return RedirectToAction("Index", "Home"); //Redirects to the homepage if it has no value
                }

                ModelState.AddModelError("", "Invalid login Attempt"); //Displays if the result variable fails
            }
            return View(login); //Redirects to login screen
        }

        public async Task<IActionResult> Logout() //Logout task method
        {
            await _signInManager.SignOutAsync(); //Log out await using _signinmanager
            return RedirectToAction("Index", "Home"); //Redirects to homepage
        }


        public IActionResult Register() //Register result method
        {
            return View(); //Returns register view
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register) //Register task method
        {
            if (ModelState.IsValid) //Checks if the modelstate is valid
            {
                var user = new ApplicationUser() //user variable from ApplicationUser class
                {
                    Name = register.Name, //Name is set to inputted name
                    Email = register.Email, //Email is set to inputted email
                    UserName = register.Email //UserName is set to inputted email
                };
                var result = await _userManager.CreateAsync(user, register.Password); //Result variable for creating a user
                if (result.Succeeded) //Checks id the result variable succeeded
                {
                    await _signInManager.PasswordSignInAsync(user, register.Password, false, false); //Sign in await
                    return RedirectToAction("Login", "Account"); //Redirects to login screen
                }
                else //Occurs if the id result fails
                {
                    foreach (var err in result.Errors) //loops for each error in the result variable
                    {
                        ModelState.AddModelError("", err.Description); //Displays an error message for each error
                    }
                }
            }
            return View(register); //Returns the register view
        }
    }
}
