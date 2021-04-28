using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrestationService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
         public ActionResult Bricolage()
        {
            return View();
        }
        public ActionResult Informatique()
        {
            return View();
        }
        public ActionResult Jardinage()
        {
            return View();
        }
        public ActionResult Mecanique()
        {
            return View();
        }
        public ActionResult Medecine()
        {
            return View();
        }
        public ActionResult Menage()
        {
            return View();
        }
        public ActionResult Menuiserie()
        {
            return View();
        }
        public ActionResult Voyage()
        {
            return View();
        }
        public ActionResult Evenementiel()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}