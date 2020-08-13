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
        public ActionResult Edit()
        {
            string userId =  User.Identity.GetUserId();

            AdminUserEntity entity = userContext.Find(userId);
            EditVM user = new EditVM()
            {
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
            };


            return View(user);
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Edit(EditVM editForm)
        {
            if (!ModelState.IsValid)
            {
                return View(editForm);
            }
            string hashPass = editForm.Password.GetHashCode().ToString();

            AdminUserEntity entity = userContext.Find(User.Identity.GetUserId());

            entity.PasswordHash = hashPass;
            entity.PhoneNumber = editForm.PhoneNumber;

            userContext.Update(entity);
            userContext.Commit();

            return RedirectToAction("Index", "Home");
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

            var userStore = new UserStore<AdminUserEntity>(restoContext);
            var manager = new UserManager<AdminUserEntity>(userStore);

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

                return RedirectToAction("Index", "Home");
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

            var userStore = new UserStore<AdminUserEntity>(restoContext);
            var userManager = new UserManager<AdminUserEntity>(userStore);


            string passHash = form.Password.GetHashCode().ToString();

            var user = userContext.Collection().Where(m => m.UserName == form.Email && m.PasswordHash == passHash).FirstOrDefault();

            if(user != null)
            {
                //sign in the user
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                return RedirectToAction("Edit");
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