using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            ViewBag.arriendos = new Arriendo().ReadAll();
            return View("Index");
        }


        public ActionResult Index()
        {
            ViewBag.arriendos = new Arriendo().ReadAll();
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