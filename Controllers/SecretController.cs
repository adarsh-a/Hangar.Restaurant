using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class SecretController : Controller
    {
        // GET: Secret
        [Authorize(Roles ="admin")]
        public ContentResult Secret()
        {
            return Content("Secret informations here");
        }

        public ContentResult PublicInfo()
        {
            return Content("Public informations here");
        }
    }
}