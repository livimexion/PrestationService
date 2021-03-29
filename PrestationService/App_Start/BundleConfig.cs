using System.Web;
using System.Web.Optimization;

namespace PrestationService
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/PagedList.css",
                      "~/Content/site.css"));

           /* bundles.Add(new StyleBundle("~/asset/tempcss").Include(
                      "~/asset/css/bootstrap.min.css",
                      "~/asset/css/font-awesome.min.csss",
                      "~/asset/css/nalika-icon.css",
                      "~/asset/css/owl.carousel.css",
                      "~/asset/css/owl.theme.css",
                      "~/asset/css/owl.transitions.css",
                      "~//asset/css/animate.css",
                      "~/asset/css/normalize.css",
                      "~/asset/css/meanmenu.min.css",
                      "~/asset/css/main.css",
                      "~/asset/css/morrisjs/morris.css",
                      "~/asset/css/scrollbar/jquery.mCustomScrollbar.min.css",
                      "~/asset/css/metisMenu/metisMenu.min.css",
                      "~/asset/css/calendar/fullcalendar.min.css",
                      "~/asset/css/calendar/fullcalendar.print.min.css",
                      "~/asset/css/responsive.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/modernizrTemp").Include(
                       "~/asset/js/vendor/modernizr-2.8.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/tempJS").Include(
                     "~/asset/js/vendor/jquery-1.12.4.min.js",
                     "~/asset/js/bootstrap.min.js",
                     "~/asset/js/wow.min.js",
                     "~/asset/js/jquery-price-slider.js",
                     "~/asset/js/jquery.meanmenu.js",
                     "~/asset/js/owl.carousel.min.js",
                     "~/asset/js/jquery.sticky.js",
                     "~/asset/js/jquery.scrollUp.min.js",
                     "~/asset/js/scrollbar/jquery.mCustomScrollbar.concat.min.js",
                     "~/asset/js/scrollbar/mCustomScrollbar-active.js",
                     "~/asset/js/metisMenu/metisMenu.min.js",
                     "~/asset/js/sparkline/jquery.sparkline.min.js",
                     "~//asset/js/sparkline/jquery.charts-sparkline.js",
                     "~/asset/js/calendar/moment.min.js",
                     "~/asset/js/calendar/fullcalendar.min.js",
                     "~/asset/js/calendar/fullcalendar-active.js",
                     "~/asset/js/flot/jquery.flot.js",
                     "~/asset/js/flot/jquery.flot.resize.js",
                     "~/asset/js/flot/jquery.flot.pie.js",
                     "~/asset/js/flot/jquery.flot.tooltip.min.js",
                     "~/asset/js/flot/jquery.flot.orderBars.js",
                     "~/asset/js/flot/curvedLines.js",
                     "~/asset/js/flot/flot-active.js",
                     "~/asset/js/plugins.js",
                     "~/asset/js/main.js"
                     ));
            */
        }
    }
}
