using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class DashboardController : Controller
    {
        private IRepositoryBase<AdminUserEntity> userContext;

        public DashboardController(IRepositoryBase<AdminUserEntity> userCon)
        {
            userContext = userCon;
        }

        [Authorize]
        public ActionResult Index()
        {
            ViewBag.UserMessage = "Hello " + User.Identity.Name;

            return View();
        }

        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
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
                //sign in the user
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                RedirectToAction("Index");
            }
            else
            {
                ViewBag.StatusMessage = "Account already registered";
            }

            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            RestaurantDbContext restoContext = new RestaurantDbContext();

            var userStore = new UserStore<IdentityUser>(restoContext);
            var userManager = new UserManager<IdentityUser>(userStore);
            //var user = userManager.Find(form.Email, form.Password);

            AdminUser temp = new AdminUser()
            {
                UserName = form.Email,
                PasswordHash = form.Password.GetHashCode().ToString()
            };

            var us = userContext.Collection().Where(u => u.UserName == temp.Email).FirstOrDefault();

            if(us != null)
            {
                //sign in the user
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(us, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.StatusMessage = "Invalid email or password";
            }
            return View(form);
        }

        [Authorize]
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");

        }
    }
}