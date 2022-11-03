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

        public ActionResult Reserva(int id)
        {            
            EnviarCiudades();
            return View();
        }

        [HttpPost]
        public ActionResult Reserva(Departamento departamento, Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarCiudades();
                    return View(departamento);
                }
                // TODO: Add update logic here
                departamento.Update();
                TempData["SuccessMessage"] = departamento.Nombre + "  Reservado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(departamento);
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