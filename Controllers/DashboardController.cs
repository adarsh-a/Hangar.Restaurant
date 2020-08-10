using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
       
        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterVM form)
        {
            // requires the dbContext not dbset
            RestaurantDbContext restoContext = new RestaurantDbContext();

            var userStore = new UserStore<IdentityUser>(restoContext);
            var manager = new UserManager<IdentityUser>(userStore);

            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = new AdminUserEntity()
            {
                UserName = form.Email,
                Email = form.Email,
                PasswordHash = form.Password.GetHashCode().ToString()
            };
            IdentityResult result = manager.Create(user);

            if (result.Succeeded)
            {
                ViewBag.StatusMessage = string.Format("User {0} was created successfully!", user.UserName);
            }
            else
            {
                ViewBag.StatusMessage = result.Errors.FirstOrDefault();
            }

            return View();
        }
    }
}