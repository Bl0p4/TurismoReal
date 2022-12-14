using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            ViewBag.departamentos = new Departamento().ReadAll();

            EnviarCiudades();
            return View();
        }


        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            Departamento dpto = new Departamento().Find(id);
            EnviarCiudades();
            return View(dpto);
        }

        [HttpGet]
        public JsonResult ListarDptos()
        {
            List<Departamento> oList = new List<Departamento>();

            oList = new Departamento().ReadAll();

            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            EnviarCiudades();
            return View();
        }
        
        private void EnviarCiudades()
        {
            ViewBag.ciudades = new Ciudad().ReadAll();
        }

        // POST: Departamento/Create
        [HttpPost]
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    EnviarCiudades();
                    return View(departamento);
                }

                departamento.Save();
                TempData["SuccessMessage"] = departamento.Nombre + "  Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(departamento);
            }
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int id)
        {
            Departamento d = new Departamento().Find(id);

            if(d == null)
            {
                TempData["SuccessMessage"] = "El Departamento no existe";
                return RedirectToAction("Index");
            }

            if (d.Disponible == "1")
            {                
                d.IsDisp = true;
            }
            else
            {
                d.IsDisp = false;
            }
            
            EnviarCiudades();
            return View(d);
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        public ActionResult Edit( Departamento departamento)
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
                TempData["SuccessMessage"] = departamento.Nombre + "  Modificado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(departamento);
            }
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int id)
        {
            if(new Departamento().Find(id) == null)
            {
                TempData["SuccessMessage"] = "No existe el departamento";
                return RedirectToAction("Index");
            }


            if(new Departamento().Delete(id))
            {
                TempData["SuccessMessage"] = "Eliminado Correctamente";
                return RedirectToAction("Index");
            }


            TempData["SuccessMessage"] = "No se ha podido eliminar";
            return RedirectToAction("Index");
        }

        // POST: Departamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
