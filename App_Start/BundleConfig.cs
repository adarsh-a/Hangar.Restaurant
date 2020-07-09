using System.Web;
using System.Web.Optimization;

namespace Hangar.Restaurant
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {  
            bundles.Add(new ScriptBundle("~/bundles/script").Include(   
                      "~/Content/js/Scripts/custom.js",                      
                       "~/Content/js/Scripts/jquery-3.2.1.min.js",                       
                      "~/Content/js/Scripts/popper.min.js",
                      "~/Content/js/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                      "~/Content/js/Scripts/baguetteBox.min.js",                      
                      "~/Content/js/Scripts/contact-form-script.js",                     
                      "~/Content/js/Scripts/form-validator.min.js",
                       "~/Content/js/Scripts/images-loded.min.js",
                       "~/Content/js/Scripts/isotope.min.js",                      
                       "~/Content/js/Scripts/jquery.mapify.js",
                       "~/Content/js/Scripts/jquery.superslides.min.js",
                       "~/Content/js/Scripts/legacy.js",
                      "~/Content/js/Scripts/picker.date.js",
                       "~/Content/js/Scripts/picker.js",
                      "~/Content/js/Scripts/picker.time.js"
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
