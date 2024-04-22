using DishDuo.Models;
using System.Security.Claims;

namespace DishDuo.Repository
{
    public interface IData
    {
        Task<ApplicationUser> GetUser(ClaimsPrincipal claims);
    }
}
