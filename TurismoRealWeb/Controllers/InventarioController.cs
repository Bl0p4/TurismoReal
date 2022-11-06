using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    [Authorize]
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Index()
        {
            ViewBag.inventarios = new Inventario().ReadAll();

            EnviarDptos();
            return View();
        }

        // GET: Inventario/Details/5
        public ActionResult Details(int id)
        {
            Inventario inven = new Inventario().Find(id);
            EnviarDptos();
            return View(inven);
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {
            EnviarDptos();
            return View();
        }

        private void EnviarDptos()
        {
            ViewBag.departamentos = new Departamento().ReadAll();
        }

        // POST: Inventario/Create
        [HttpPost]
        public ActionResult Create( Inventario inventario)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    EnviarDptos();
                    return View(inventario);
                }

                inventario.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View(inventario);
            }
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit(int id)
        {
            Inventario inv = new Inventario().Find(id);

            if (inv == null)
            {
                TempData["mensaje"] = "El Objeto no existe";
                return RedirectToAction("Index");
            }

            if (inv.Disponible == "1")
            {
                inv.IsDisp = true;
            }
            else
            {
                inv.IsDisp = false;
            }

            EnviarDptos();
            return View(inv);
        }

        // POST: Inventario/Edit/5
        [HttpPost]
        public ActionResult Edit( Inventario inventario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarDptos();
                    return View(inventario);
                }
                // TODO: Add update logic here
                inventario.Update();
                TempData["mensaje"] = "Modificado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(inventario);
            }
        }

        // GET: Inventario/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Inventario().Find(id) == null)
            {
                TempData["mensaje"] = "No existe el Objeto";
                return RedirectToAction("Index");
            }


            if (new Inventario().Delete(id))
            {
                TempData["mensaje"] = "Eliminado Correctamente";
                return RedirectToAction("Index");
            }


            TempData["mensaje"] = "No se ha podido eliminar";
            return RedirectToAction("Index");
        }

        // POST: Inventario/Delete/5
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
