using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

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
            int initTake = 3;

            MenuSectionEntity menuData = sectionContext.Collection().FirstOrDefault();
            MenuSection section = new MenuSection();

            List<MenuEntity> menus = menuContext.Collection().Include(t => t.Type).OrderBy(p => p.Price).Take(initTake).ToList();
            List<Menu> menuListModel = new List<Menu>();

            List<MenuTypeEntity> menuTypes = typeContext.Collection().ToList();
            List<MenuType> menuTypeList = new List<MenuType>();

            MenuEntity menuCheck = menuContext.Collection().Include(t => t.Type).OrderBy(p => p.Price).Skip(initTake).Take(1).FirstOrDefault();
        
            bool hasNextElemnt = false;

            if( menuCheck != null)
            {
                hasNextElemnt = true;
            }

            if (menuData != null)
            {
                section.Title = menuData.Title;
                section.Description = menuData.Description;

            }

            if(menus != null)
            {
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
            }
            
            if(menuTypes != null)
            {
                foreach (var type in menuTypes)
                {
                    //menuTypeList and menuCount must have same order
                    menuTypeList.Add(new MenuType
                    {
                        name = type.name.ToLower()
                    });
                }
            }
            

            //define model to display in view
            SectionVM model = new SectionVM()
            {
                menuList = menuListModel,
                Title = section.Title,
                Description = section.Description,
                typeList = menuTypeList,
                hasNext = hasNextElemnt
            };

            return PartialView(model);
        }

        [WebMethod]
        [HttpPost]
        [AllowAnonymous]
        public JsonResult loadMenu(int skip, string type)
        {

            List<MenuEntity> menus;
            List<Menu> menuListModel = new List<Menu>();
            MenuEntity menuCheck = new MenuEntity();
            bool hasNext = false;
            int initTake = 3;

            if (type == "all")
            {
                menus = menuContext.Collection().OrderBy(p => p.Price).Skip(skip).Take(initTake).Include(ent => ent.Type).ToList();
                menuCheck = menuContext.Collection().OrderBy(p => p.Price).Skip(skip + initTake).Take(1).FirstOrDefault();
                if ( menuCheck != null)
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
                    .Take(initTake)
                    .Include(ent => ent.Type)
                    .ToList();
                menuCheck = menuContext.Collection().Where(m => m.Type.name == type).OrderBy(p => p.Price).Skip(skip + initTake).Take(1).FirstOrDefault();
                
                if (menuCheck == null)
                {
                    hasNext = true;
                }
            }
            

            if (menus != null)
            {
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
            }

            return Json(new { menuListModel, hasNext });
        }

        /*[WebMethod]
        [HttpPost]
        [AllowAnonymous]
        public JsonResult sort(string type)
        {
            int initTake = 3;
            List<MenuEntity> menuList = menuContext.Collection()
                .Include(t => t.Type)
                .OrderBy(type)
            return Json(new { });
        }*/
        
        [WebMethod]
        [HttpPost]
        [AllowAnonymous]
        public JsonResult OtherTabs(string type)
        {
            int initTake = 3;
            List<MenuEntity> menuList = menuContext.Collection()
                .Include(t => t.Type)
                .Where(t => t.Type.name == type)
                .Take(initTake)
                .ToList();
            List<Menu> menuListModel = new List<Menu>();
            MenuEntity menuCheck = menuContext.Collection()
                .Include(t => t.Type)
                .Where(t => t.Type.name == type)
                .OrderBy(p => p.Price)
                .Skip(initTake)
                .Take(1)
                .FirstOrDefault();
            bool hasNext = false;

            if (menuCheck != null)
            {
                hasNext = true;
            }

            if (menuList != null)
            {
                foreach(var menu in menuList)
                {
                    menuListModel.Add(new Menu
                    {
                        Name = menu.Name,
                        Description = menu.Description,
                        Image = menu.Image,
                        Price = menu.Price,
                        Type = new MenuType { name = menu.Type.name }
                    });
                }
            }
            return Json(new {menuListModel, hasNext});
        }
    }
}