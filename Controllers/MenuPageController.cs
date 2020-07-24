using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            MenuSection section = new MenuSection();
            MenuType types = new MenuType();

            MenuSectionEntity menuData = sectionContext.Collection().FirstOrDefault();

            List<MenuEntity> menus = menuContext.Collection().Include(ent => ent.Type).OrderBy(o => o.ID).Take(9).ToList();
            List<MenuTypeEntity> menuTypes = typesContext.Collection().ToList();


            List<MenuList> menuListModel = new List<MenuList>();
            List<MenuType> menutypeModel = new List<MenuType>();

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

        
    }
}