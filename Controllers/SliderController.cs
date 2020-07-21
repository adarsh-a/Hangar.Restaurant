using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.DB.Repository;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class SliderController : Controller
    {
        private IRepository<SliderEntity> sliderContext;
        public SliderController(IRepository<SliderEntity> sliderCon)
        {
            sliderContext = sliderCon;
        }
        // GET: Slider
        public PartialViewResult slideShow()
        {
            Slider slide = new Slider();
            List<SliderEntity> sliderList = sliderContext.Collection().ToList();
            List<Slider> sliders = new List<Slider>();
            foreach (var slides in sliderList)
            {
                sliders.Add(new Slider()
                {
                    Title = slides.Title,
                    Description = slides.Description,
                    Description1 = slides.Description1,
                    Image = slides.Image,
                    Links = slides.Links
                });
            }
            return PartialView(sliders);
        }
    }
}