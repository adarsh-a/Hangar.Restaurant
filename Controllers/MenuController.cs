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
        private IRepositoryBase<MenuEntity> menuContext;
        private IRepositoryBase<MenuSectionEntity> sectionContext;
        private IRepositoryBase<MenuTypeEntity> typeContext;

        public MenuController(IRepositoryBase<MenuEntity> menuCon, IRepositoryBase<MenuSectionEntity> secCon,
            IRepositoryBase<MenuTypeEntity> typeCon)
        {
            menuContext = menuCon;
            sectionContext = secCon;
            typeContext = typeCon;
        }

        // GET: Menu
        public PartialViewResult Index()
        {
            MenuSectionEntity menuData = sectionContext.Collection().FirstOrDefault();
            MenuSection section = new MenuSection();

            List<MenuEntity> menus = menuContext.Collection().Include(ent => ent.Type).OrderBy(p => p.Price).ToList();
            List<Menu> menuListModel = new List<Menu>();

            List<MenuTypeEntity> menuTypes = typeContext.Collection().ToList();
            List<MenuType> menuTypeList = new List<MenuType>();


            if (menuData != null)
            {
                section.Title = menuData.Title;
                section.Description = menuData.Description;

            }

            foreach (var item in menus)
            {

                menuListModel.Add(new Menu()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    Type = new MenuType() { name = item.Type.name.ToLower() }

                }); ;
            }

            foreach (var type in menuTypes)
            {
                menuTypeList.Add(new MenuType
                {
                    name = type.name.ToLower()
                });
            }

            //define model to display in view
            SectionVM model = new SectionVM()
            {
                menuList = menuListModel,
                Title = section.Title,
                Description = section.Description,
                typeList = menuTypeList
            };

            return PartialView(model);
        }
    }
}