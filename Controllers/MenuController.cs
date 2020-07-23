using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        IRepositoryBase<MenusEntity> menuContext;
        IRepositoryBase<MenuSectionEntity> sectionContext;
        IRepositoryBase<MenuTypeEntity> typeContext;
        public MenuController(IRepositoryBase<MenusEntity> menuCon, IRepositoryBase<MenuSectionEntity> sectionCon, IRepositoryBase<MenuTypeEntity> typeCon)
        {
            menuContext = menuCon;
            sectionContext = sectionCon;
            typeContext = typeCon;
        }
        public ActionResult Index()
        {

            var menuModel = new MenuSection();
            var menuData = sectionContext.Collection().FirstOrDefault();

            List<MenusEntity> menusEntities = menuContext.Collection().Include(x => x.Type).OrderBy(p=>p.Price).ToList();
            
            List<Menus> menulist = new List<Menus>();

            List<MenuTypeEntity> menuTypeEntities = typeContext.Collection().ToList();
            List<MenuType> menuTypes = new List<MenuType>();

            if (menuData != null)
            {
                menuModel.Title = menuData.Title;
                menuModel.Description = menuData.Description;

            }

            foreach (var item in menusEntities)
            {
                menulist.Add(new Menus()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price,
                    Type = new MenuType() { Name = item.Type.Name.ToLower() }

                });

            }
            foreach (var item in menuTypeEntities)
            {
                menuTypes.Add(new MenuType()
                {
                    Name = item.Name.ToLower()
                });
            }

            var model = new MenusViewModel() { menulistVM = menulist, Description = menuModel.Description, Title = menuModel.Title, menuTypesList = menuTypes };
            return PartialView("~/Views/Menu/Index.cshtml", model);
        }
    }
    
}