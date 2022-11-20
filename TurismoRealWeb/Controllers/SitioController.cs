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
            ViewBag.departamentos = new Departamento().ReadAll();

            EnviarCiudades();
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

        [Authorize]
        public ActionResult Reserva()
        {
            decimal userId = (decimal)Session["id"];
            ViewBag.arriendos = new Arriendo().ArriendosPorUser(userId);
            //ViewBag.arriendos = new Arriendo().ReadAll();
            return View();
        }

        [HttpPost]
        public ActionResult Reserva(Arriendo arriendo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarCiudades();
                    return View(arriendo);
                }
                // TODO: Add update logic here
                arriendo.Update();
                TempData["SuccessMessage"] = arriendo.Nombre + "  Reservado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(arriendo);
            }
        }


        public ActionResult DescDpto(int id)
        {
            Departamento dpto = new Departamento().Find(id);
            EnviarCiudades();
            return View(dpto);
        }

    }
}