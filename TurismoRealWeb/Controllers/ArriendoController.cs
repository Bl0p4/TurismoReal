using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    public class ArriendoController : Controller
    {
        // GET: Arriendo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Arriendo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Arriendo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arriendo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //TempData["SuccessMessage"] ;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Arriendo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Arriendo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                //TempData["SuccessMessage"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Arriendo/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Arriendo().Find(id) == null)
            {
                TempData["SuccessMessage"] = "No existe el departamento";
                return RedirectToAction("Index");
            }


            if (new Arriendo().Delete(id))
            {
                TempData["SuccessMessage"] = "Eliminado Correctamente";
                return RedirectToAction("Index");
            }


            TempData["SuccessMessage"] = "No se ha podido eliminar";
            return RedirectToAction("Index");            
        }

        // POST: Arriendo/Delete/5
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
//TempData["SuccessMessage"]