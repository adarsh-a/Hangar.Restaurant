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
    public class slideshowController : Controller
    {
        private IRepositoryBase<SlideshowEntity> slidesContext;
        public slideshowController(IRepositoryBase<SlideshowEntity> slidesCon)
        {
            slidesContext = slidesCon;
        }
        // GET: slideshow
        public PartialViewResult slideshow()
        {
            SlideshowModel slides = new SlideshowModel();
            List<SlideshowEntity> slidesList = slidesContext.Collection().ToList();
            List<SlideshowModel> slideshowsmodel = new List<SlideshowModel>();
            foreach (var banner in slidesList)
            {
                slideshowsmodel.Add(new SlideshowModel()
                {
                    title = banner.title,
                    description = banner.description,
                    image = banner.image,
                    links = banner.links
                });
            }
            return PartialView("~/Views/PartialView/bannerslides.cshtml", slideshowsmodel);
            //return PartialView("~/Views/PartialView/bannerslides.cshtml", slide);
        }
    }
}