using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace Hangar.Restaurant.Controllers
{
    public class MenuPageController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();
        private IRepositoryBase<MenuEntity> menuContext;
        private IRepositoryBase<MenuSectionEntity> sectionContext;
        private IRepositoryBase<MenuTypeEntity> typesContext;


        public MenuPageController(IRepositoryBase<MenuEntity> menuCon, IRepositoryBase<MenuSectionEntity> secCon, IRepositoryBase<MenuTypeEntity> typescon)
        {
            menuContext = menuCon;
            sectionContext = secCon;
            typesContext = typescon;
        }
        // GET: MenuPage
        public ActionResult Index()
        {
            int initTake = 9;

            MenuSection section = new MenuSection();
            MenuType types = new MenuType();

            MenuSectionEntity menuData = sectionContext.Collection().FirstOrDefault();

            List<MenuEntity> menus = menuContext.Collection().Include(ent => ent.Type).OrderBy(p => p.Price).Take(initTake).ToList();
            List<MenuTypeEntity> menuTypes = typesContext.Collection().ToList();

            List<MenuList> menuListModel = new List<MenuList>();
            List<MenuType> menutypeModel = new List<MenuType>();

            MenuEntity menuCheck = menuContext.Collection().Include(t => t.Type).OrderBy(p => p.Price).Skip(initTake).Take(1).FirstOrDefault();

            if (menuData != null)
            {
                section.Title = menuData.Title;
                section.Description = menuData.Description;

            }
            foreach (var item in menus)
            {
                menuListModel.Add(new MenuList()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    Type = new MenuType() { name = item.Type.name }
                });

            }
            foreach (var type in menuTypes)
            {
                menutypeModel.Add(new MenuType()
                {
                    name = type.name
                });
            }
            MultipleData model = new MultipleData()
            {
                menuList = menuListModel,
                menutype = menutypeModel,
                name = types.name,
                Title = section.Title,
                Description = section.Description
            };
            return PartialView("~/Views/PartialView/MenuPage.cshtml", model);
            //return PartialView(model);
        }
        [WebMethod]
        [HttpPost]
        [AllowAnonymous]
        public JsonResult loadMenu(int skip, string type)
        {
            List<MenuEntity> menus;
            List<MenuList> menuListModel = new List<MenuList>();
            MenuEntity menuCheck = new MenuEntity();
            bool hasNext;
            if (type == "all")
            {
                menus = menuContext.Collection().OrderBy(p => p.Price).Skip(skip).Take(3).Include(ent => ent.Type).ToList();
                menuCheck = menuContext.Collection().OrderBy(p => p.Price).Skip(skip + 1).Take(1).FirstOrDefault();
                if (menuCheck == null)
                {
                    hasNext = false;
                }
                else
                {
                    hasNext = true;
                }
            }
            else
            {
                menus = menuContext.Collection()
                    .Where(m => m.Type.name == type)
                    .OrderBy(p => p.Price)
                    .Skip(skip)
                    .Take(3)
                    .Include(ent => ent.Type)
                    .ToList();

                if (menuContext.Collection().Where(m => m.Type.name == type).OrderBy(p => p.Price).Skip(skip + 1).Take(1) == null)
                {
                    hasNext = false;
                }
                else
                {
                    hasNext = true;
                }
            }
            if (menus != null)
            {
                foreach (var item in menus)
                {
                    menuListModel.Add(new MenuList()
                    {
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        Image = item.Image,
                        Type = new MenuType() { name = item.Type.name }

                    }); ;
                }
            }
            return Json(new { menuListModel, hasNext });
        }
    }
}