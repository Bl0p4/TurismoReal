using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;
using System.Web.Security;


namespace TurismoRealWeb.Controllers
{
    [Authorize]
    public class ArriendoController : Controller
    {
        // GET: Arriendo
        public ActionResult Index()
        {
            ViewBag.arriendos = new Arriendo().ReadAll();
            return View();
        }

        // GET: Arriendo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Buscar(string texto)
        {
            if (texto != null)
            {
                ViewBag.arriendos = new Arriendo().BuscarPorCliente(texto);
                return View();                
            }

            ViewBag.arriendos = new Arriendo().ReadAll();
            return View();
        }


        // GET: Arriendo/Create
        public ActionResult Create(int id)
        {
            if (Session["id"] != null)
            {
                Arriendo arriendo = new Arriendo();
                arriendo.Departamento = new Departamento().Find(id);
                arriendo.ClienteId = (decimal)Session["id"];
                arriendo.total_serv = 0;
                arriendo.DptoId = arriendo.Departamento.Id;
                arriendo.Total = arriendo.Departamento.Precio;
                return View(arriendo);
            }

            else
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Session.RemoveAll();
                return RedirectToAction("Departamentos");
            }

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
                    return View(arriendo);
                }                
                arriendo.Save();
                TempData["SuccessMessage"] = arriendo.Departamento.Nombre + "  Reservado Correctamente";
                return RedirectToAction("Reserva", "Sitio");
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

        public  ActionResult RecibirPago(decimal id)
        {
            Arriendo arri = new Arriendo().Find(id);
            arri.Total = 4 * arri.Total / 5;
            arri.FecIni.ToShortDateString();
            arri.FecFin.ToShortDateString();
            return View(arri);
        }

        [HttpPost]
        public ActionResult RecibirPago(Arriendo arriendo)
        {
            arriendo.Check_In();
            TempData["SuccessMessage"] = "Pago Recibido Correctamente";
            return RedirectToAction("Index");
        }
               
                

        public ActionResult CheckOut(int id)
        {
            if (new Arriendo().Find(id) == null)
            {
                TempData["SuccessMessage"] = "No existe el arriendo";
                return RedirectToAction("Index");
            }


            if (new Arriendo().Check_Out(id))
            {
                TempData["SuccessMessage"] = "Check-Out Correcto";
                return RedirectToAction("Index");
            }


            TempData["SuccessMessage"] = "No se ha podido realizar Check-Out";
            return RedirectToAction("Index");
        }
                
    }
}
//TempData["SuccessMessage"]