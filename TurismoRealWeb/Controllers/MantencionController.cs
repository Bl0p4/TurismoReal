﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    [Authorize]
    public class MantencionController : Controller
    {
        // GET: Mantencion
        public ActionResult Index()
        {
            ViewBag.mantencion = new Mantencion().ReadAll();
            return View();
        }

        // GET: Mantencion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mantencion/Create
        public ActionResult Create()
        {
            EnviarDptos();
            return View();
        }

        private void EnviarDptos()
        {
            ViewBag.departamentos = new Departamento().ReadAll();
        }

        // POST: Mantencion/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "DptoId, Fec_ini, Fec_term, Descripcion, Costo")] Mantencion mantencion)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    EnviarDptos();
                    return View(mantencion);
                }

                mantencion.Save();
                TempData["mensaje"] = "Guardado Correctamente";

                return RedirectToAction("Index");
            }
            catch
            {
                return View(mantencion);
            }
        }

        // GET: Mantencion/Edit/5
        public ActionResult Edit(int id)
        {
            Mantencion man = new Mantencion().Find(id);

            if (man == null)
            {
                TempData["mensaje"] = "El Objeto no existe";
                return RedirectToAction("Index");
            }

            EnviarDptos();
            return View(man);
        }

        // POST: Mantencion/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "DptoId, Fec_ini, Fec_term, Descripcion, Costo")] Mantencion mantencion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EnviarDptos();
                    return View(mantencion);

                }
                // TODO: Add update logic here
                mantencion.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(mantencion);
            }
        }

        // GET: Mantencion/Delete/5
        public ActionResult Delete(int id)
        {
            if (new Mantencion().Find(id) == null)
            {
                TempData["mensaje"] = "No existe del objeto";
                return RedirectToAction("Index");
            }

            if (new Mantencion().Delete(id))
            {
                TempData["mensaje"] = "Eliminado Correctamente";
            }

            TempData["mensaje"] = "No se ha podido Eliminar";
            return RedirectToAction("Index");
        }

        // POST: Mantencion/Delete/5
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