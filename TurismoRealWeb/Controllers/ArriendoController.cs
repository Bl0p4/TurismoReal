using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;
using System.Web.Security;


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
            Arriendo arriendo = new Arriendo();
            arriendo.ClienteId = 1;
            arriendo.FecReserva = DateTime.Today;
            arriendo.ValReserva = 15000;
            arriendo.ResPago = "0";
            arriendo.CheckIn = "0";
            arriendo.Checkout = "0";

            EnviarDptos();
            return View();
        }       

        private void EnviarCiudades()
        {
            ViewBag.ciudades = new Ciudad().ReadAll();
        }

        private void EnviarDptos()
        {
            ViewBag.departamentos = new Departamento().ReadAll();            
        }
        // POST: Arriendo/Create
        [HttpPost]
        public ActionResult Create(Arriendo arriendo)
        {            
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    EnviarDptos();
                    return View(arriendo);
                }                
                arriendo.Save();
                return RedirectToAction("Reserva","Sitio");
            }
            catch
            {
                return View(arriendo);
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