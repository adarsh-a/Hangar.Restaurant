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
    public class BannerSectionController : Controller
    {
        // GET: BannerSection
        private IRepositoryBase<BannerSectionEntity> bannerContext;

        public BannerSectionController(IRepositoryBase<BannerSectionEntity> bannerCon)
        {
            bannerContext = bannerCon;
        }
        public PartialViewResult FetchBannerSection()
        {

            var bannerSectionEntities = bannerContext.Collection().ToList(); //take info from database

            List<BannerSection> bannerList = new List<BannerSection>(); //creating list to store data

            if (bannerSectionEntities != null)
            {
                foreach (var banner in bannerSectionEntities)
                {
                    bannerList.Add(new BannerSection
                    {
                        Title = banner.Title,
                        Description = banner.Description,
                        Link = banner.Link,
                        Image = banner.Image,
                        LinkName=banner.LinkName

                    });
                }

            }
            return PartialView(bannerList);
        }

    }
}