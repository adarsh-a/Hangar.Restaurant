using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

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
            var countMenus = menuContext.Collection().ToList().Count();
            int size = 3;
            List<MenusEntity> menusEntities = menuContext.Collection().Include(x => x.Type).OrderBy(p=>p.ID).Take(size).OrderBy(p=>p.Price).ToList();

            var flagCheck = menuContext.Collection().Include(x => x.Type).OrderBy(p => p.ID).Skip(size).ToList().FirstOrDefault();
            bool flag;
            if(flagCheck == null)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
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

            var model = new MenusViewModel() { menulistVM = menulist, Description = menuModel.Description, Title = menuModel.Title, menuTypesList = menuTypes, flagElement= flag};
            return PartialView("~/Views/Menu/Index.cshtml", model);
        }
        [HttpPost]
        [WebMethod]
        [AllowAnonymous]
        public JsonResult menuDisplay(int size, string type, int sizeType)
        {
            bool flag = true;
            bool flagType = true;
            List<MenusEntity> menusEntities;
            if (type == "all allSort")
            {
                var sizeLeft = size + 3;
                menusEntities = menuContext.Collection().Include(x => x.Type).OrderBy(p => p.ID).Skip(size).Take(3).ToList();
                var flagCount = menuContext.Collection().Include(x => x.Type).OrderBy(p => p.ID).Skip(sizeLeft).Take(1).ToList().FirstOrDefault();

                if (flagCount == null)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            else
            {
                var sizeLeft = sizeType +1;
                menusEntities = menuContext.Collection().Include(x => x.Type).Where(t => t.Type.Name == type).OrderBy(p => p.ID).Skip(sizeType).Take(1).ToList();
                var flagCountType = menuContext.Collection().Include(x => x.Type).Where(t => t.Type.Name == type).OrderBy(p => p.ID).Skip(sizeLeft).Take(1).ToList().FirstOrDefault();

                if (flagCountType == null)
                {
                    flagType = false;
                }
                else
                {
                    flagType = true;
                }
            }
            

            List<Menus> menulist = new List<Menus>();

            List<MenusEntity> menusAllCount= menuContext.Collection().Include(x => x.Type).ToList();

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
            int collectionCount = menusAllCount.Count();
            int modelCount = menulist.Count();

            

            return Json(new { menulist, modelCount , collectionCount, flag, flagType});
        }
        [HttpPost]
        [WebMethod]
        [AllowAnonymous]
        public JsonResult getTypeList(string type)
        {
            List<MenusEntity> menusEntities = menuContext.Collection().Include(x => x.Type).Where(t=>t.Type.Name == type).OrderBy(p=>p.ID).Take(1).ToList();
       
            List<Menus> menulist = new List<Menus>();
            

            foreach (var item in menusEntities)
            {
                menulist.Add(new Menus()
                {
                    Name = item.Name.ToLower(),
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price,
                    Type = new MenuType() { Name = item.Type.Name.ToLower() }



                });
            }
            int modelCount = menulist.Count();
            return Json(new { menulist, modelCount});
        }
        [HttpPost]
        [WebMethod]
        [AllowAnonymous]
        public JsonResult getSort(string sortType)
        {
            List<MenusEntity> menusEntities = menuContext.Collection().Include(x => x.Type).ToList();
            List <Menus> menulist = new List<Menus>();
            if (sortType == "Name")
            {
               menusEntities = menusEntities.OrderBy(p => p.Name).Take(3).ToList();
            }

            else if(sortType == "Price")
            {
                menusEntities = menusEntities.OrderBy(p => p.Price).Take(3).ToList();
            }
            else if(sortType == "Type")
            {
                menusEntities = menusEntities.OrderBy(t => t.MenuTypeID).Take(3).ToList();
            }

            else
            {
                menusEntities = menuContext.Collection().ToList();
            }
            
            foreach (var item in menusEntities)
            {
                menulist.Add(new Menus()
                {
                    Name = item.Name.ToLower(),
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price,
                    MenuTypeID = item.MenuTypeID,
                    Type = new MenuType() { ID= item.Type.ID, Name = item.Type.Name }
                    
                }); ;
            }
            int modelCount = menulist.Count();
            return Json(new { menulist, modelCount });
        }
    }

}