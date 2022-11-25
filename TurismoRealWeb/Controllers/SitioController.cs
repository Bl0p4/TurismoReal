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
            reserva.NomPersona = reserva.Arriendo.Cliente.Nombre +" "+reserva.Arriendo.Cliente.Paterno +" "+ reserva.Arriendo.Cliente.Materno;
            reserva.Valor = 2* reserva.Arriendo.Total / 10;
            reserva.Fech = DateTime.Today;
            reserva.Fech.ToShortDateString();
            reserva.Acomp = 0;
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

        public ActionResult Delete(int id)
        {
            if (new Reserva().Find(id) == null)
            {
                TempData["SuccessMessage"] = "Reserva no existe";
                return RedirectToAction("Reserva");
            }


            if (new Reserva().Cancelar(id))
            {
                TempData["SuccessMessage"] = "Reserva Cancelada Correctamente";
                return RedirectToAction("Reserva");
            }


            TempData["SuccessMessage"] = "No se ha podido cancelar";
            return RedirectToAction("Reserva");
        }

        [Authorize]
        public ActionResult Servicios(int id)
        {
            Servicio_Contratado servs = new Servicio_Contratado();
            servs.Arriendo = new Arriendo().Find(id);
            servs.ArriendoId = servs.Arriendo.Id;
            ViewBag.Servicios = new Servicio().ReadAll();

            return View(servs);
        }

        [HttpPost]
        public ActionResult Servicios(Servicio_Contratado servicio_Contratado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Servicios = new Servicio().ReadAll();
                    return View(servicio_Contratado);
                }
                Servicio servicio = new Servicio().Find(servicio_Contratado.ServicioId);
                servicio_Contratado.Costo = servicio.Costo;
                servicio_Contratado.Realizado = "N";
                servicio_Contratado.PostChk = "N";

                servicio_Contratado.Save();
                TempData["SuccessMessage"] = "Servicios Contratados Satisfactoriamente";
                return RedirectToAction("Reserva");
            }
            catch 
            {
                return View(servicio_Contratado);
            }      
        }

        public ActionResult CancelarReserva(int id)
        {
            if (new Reserva().Find(id) == null)
            {
                TempData["SuccessMessage"] = "Reserva no existe";
                return RedirectToAction("Reserva");
            }


            if (new Reserva().Cancelar(id))
            {
                TempData["SuccessMessage"] = "Reserva Cancelada Correctamente";
                return RedirectToAction("Reserva");
            }


            TempData["SuccessMessage"] = "No se ha podido cancelar la Reserva";
            return RedirectToAction("Reserva");
        }



    }
}