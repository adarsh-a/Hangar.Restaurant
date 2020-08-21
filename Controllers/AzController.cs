using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class AzController : Controller
    {
        // GET: Az
        public async Task<ActionResult> Index()
        {
            var azureClient = new HttpClient();
            var result = await azureClient.GetAsync(ConfigurationManager.AppSettings["AzureFunctionURL"]);
            var content = await result.Content.ReadAsStringAsync();

            ViewBag.cont = content;

            return View();
        }
    }
}