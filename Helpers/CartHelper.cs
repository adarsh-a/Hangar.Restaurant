using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Helpers
{
    public static class CartHelper
    {


        public static int CalculateTotal(int menuId, int quantity)
        {

            var menuList = GetStaticMenu();
            var total = 0;
            var meal = menuList.FirstOrDefault(i => i.Id == menuId);
            if (meal != null)
            {

                total = meal.MealPrice * quantity;



            }
            return total;


        }


        public static List<Menu> GetMenuFromDb()
        {
            RestaurantDbContext db = new RestaurantDbContext();
            var menuEntities = from m in db.Menu orderby m.Id select m;

            var menuList = new List<Menu>();

            if (menuEntities != null && menuEntities.Any())
            {
                foreach (var currentMenu in menuEntities)
                {


                    var menu = new Menu();
                    menu.Id = currentMenu.Id;
                    menu.MealName = currentMenu.MealName;
                    menu.MealPrice = currentMenu.MealPrice;
                    menuList.Add(menu);
                }

            }

            return menuList;

        }

        public static List<Menu> GetStaticMenu()
        {

            var menulist = new List<Menu>();
            menulist.Add(new Menu
            {

               MealName= "Chicken Pad Thai",
               Id=1,
               MealPrice=325

            });
            menulist.Add(new Menu
            {

                MealName = "Chicken Salad",
                Id = 2,
                MealPrice = 325

            });
            menulist.Add(new Menu
            {

                MealName = "Green Thai Curry",
                Id = 3,
                MealPrice = 325

            });
            menulist.Add(new Menu
            {

                MealName = "Chicken noodles",
                Id = 4,
                MealPrice = 325

            });



            return menulist;




        }

    }
}