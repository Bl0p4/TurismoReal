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
            return View();
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create([Bind(Include = "CiudadId, Nombre, Direccion, Superficie, Precio, Condicion")] Departamento departamento)
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
                TempData["mensaje"] = "Guardado Correctamente";
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
                TempData["mensaje"] = "El Departamento no existe";
                return RedirectToAction("Index");
            }

            EnviarCiudades();
            return View(d);
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, CiudadId, Nombre, Direccion, Superficie, Precio, Disponible, Condicion")] Departamento departamento)
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
                TempData["mensaje"] = "Modificado Correctamente";
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
                TempData["mensaje"] = "No existe el departamento";
                return RedirectToAction("Index");
            }


            if(new Departamento().Delete(id))
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("Index");
            }


            TempData["mensaje"] = "No se ha podido eliminar";
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
