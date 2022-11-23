using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurismoRealWeb.Controllers
{
    public class ServicioContratadoController : Controller
    {
        // GET: ServicioContratado
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServicioContratado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicioContratado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioContratado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicioContratado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicioContratado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicioContratado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicioContratado/Delete/5
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
