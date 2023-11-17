using Microsoft.AspNetCore.Mvc;
using VideoSharingSite.DbModels;
using VideoSharingSite.Models;
using VideoSharingSite.Mapper;

namespace VideoSharingSite.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
            
        }


        public async Task<IActionResult> CreateUserAsync(UserViewModel userModel)
        {
            if(userModel == null)
            {
                throw new ArgumentNullException(nameof(userModel));
            }

            var entity = userModel.ToEntity<User>();

            return null;

        }
    }
}
