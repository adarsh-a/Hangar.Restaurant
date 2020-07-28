using System.Web;
using System.Web.Optimization;

namespace Hangar.Restaurant
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {  
           
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Content/js/baguetteBox.min.js",                      
                      "~/Content/js/contact-form-script.js",                     
                      "~/Content/js/form-validator.min.js",
                       "~/Content/js/images-loded.min.js",
                       "~/Content/js/isotope.min.js",                      
                       "~/Content/js/jquery.mapify.js",
                       "~/Content/js/jquery.superslides.min.js",
                       "~/Content/js/legacy.js",
                      "~/Content/js/picker.date.js",
                       "~/Content/js/picker.js",
                      "~/Content/js/picker.time.js",
                      "~/Content/js/custom.js",
                       "~/Content/js/jquery-3.2.1.min.js",
                      "~/Content/js/popper.min.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/loadMore.js"
                     ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/animate.css",
                      "~/Content/css/baguetteBox.min.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/classic.css",
                      "~/Content/css/classic.date.css",
                      "~/Content/css/classic.time.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/style.css"
                      ));
        }
    }
}
