using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    public class SitioController : Controller
    {
        // GET: Sitio
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Departamentos()
        {
            ViewBag.departamentos = new Departamento().ReadAll();

            EnviarCiudades();
            return View();
        }

        private void EnviarCiudades()
        {
            ViewBag.ciudades = new Ciudad().ReadAll();
        }

        public ActionResult Reserva()
        {
            return View();
        }

        public ActionResult DescDpto()
        {
            return View();
        }

    }
}