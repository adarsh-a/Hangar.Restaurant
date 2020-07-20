using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class MenuSectionController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();
        private IRepositoryBase<MenuEntity> menuContext;
        private IRepositoryBase<MenuSectionEntity> sectionContext;
        private IRepositoryBase<MenuTypeEntity> typeContext;

        public  MenuSectionController(IRepositoryBase<MenuEntity> menuCon, IRepositoryBase<MenuSectionEntity> secCon,
            IRepositoryBase<MenuTypeEntity> typeCon)
        {
            menuContext = menuCon;
            sectionContext = secCon;
            typeContext = typeCon;
        }

        // GET: MenuSection
        public ActionResult FetchMenuSection()
        {
            

            MenuSectionEntity menuData = sectionContext.Collection().FirstOrDefault();
            MenuSection section = new MenuSection();

            List<MenuEntity> menus = menuContext.Collection().Include(ent => ent.Type).ToList();
            List<Menu> menuListModel = new List<Menu>();

            List<MenuTypeEntity> menuTypes = typeContext.Collection().ToList();
            List <MenuType> menuTypeList= new List<MenuType>();
   

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
                    Type = new MenuType() { name = item.Type.name.ToLower()}

                }); ;
            }

            foreach(var type in menuTypes)
            {
                menuTypeList.Add(new MenuType
                {
                    name = type.name.ToLower()
                });
            }

            //define model to display in view
            SectionVM model = new SectionVM() {
                menuList = menuListModel,
                Title = section.Title,
                Description = section.Description,
                typeList = menuTypeList
            };

            return PartialView("~/Views/PartialView/Menus.cshtml", model);
        }

        

        
    }
}