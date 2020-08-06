using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class BannerController : Controller
    {
        private IRepositoryBase<BannerEntity> context;

        public BannerController(IRepositoryBase<BannerEntity> bannerCon)
        {
            context = bannerCon;
        }

        // GET: Banner
        public PartialViewResult BannerSection()
        {

            List<BannerEntity> bannerList = context.Collection().ToList();
            List<Banner> bannerModel = new List<Banner>();

            foreach(var item in bannerList)
            {
                bannerModel.Add(new Banner()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Link = item.Link,
                    Image = item.Image,
                    ButtonName = item.ButtonName
                });
            }

            return PartialView(bannerModel);
        }

        public PartialViewResult GeneralBanner()
        {
            //get parent controller name to display on banner
            ViewBag.controller = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            return PartialView();
        }
    }
}