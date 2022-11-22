using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

            if (Session["id"] != null)
            {
                decimal userId = (decimal)Session["id"];
                ViewBag.arriendos = new Arriendo().ArriendosPorUser(userId);
                //ViewBag.arriendos = new Arriendo().ReadAll();
                return View();
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Session.RemoveAll();
                return RedirectToAction("Departamentos");
            }     
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


        public ActionResult ConfirmReserva(int id)
        {
            Reserva reserva = new Reserva();
            reserva.Arriendo = new Arriendo().Find(id);
            reserva.ArriendoId = reserva.Arriendo.Id;
            reserva.NomPersona = reserva.Arriendo.Cliente.Nombre + reserva.Arriendo.Cliente.Paterno + reserva.Arriendo.Cliente.Materno;
            reserva.Valor = 2* reserva.Arriendo.Total / 10;
            reserva.Fech = DateTime.Today;
            return View(reserva);
        }

        [HttpPost]
        public ActionResult ConfirmReserva(Reserva reserva)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(reserva);
                }

                reserva.Save();
                TempData["SuccessMessage"] = "Pago Realizado Correctamente";
                return RedirectToAction("Reserva");
            }
            catch
            {
                return View(reserva);
            }

        }

    }
}