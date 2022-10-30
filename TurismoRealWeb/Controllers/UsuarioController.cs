using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.usuarios = new Usuario().ReadAll();
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            EnviarTipos();
            return View();
        }

        private void EnviarTipos()
        {
            ViewBag.tipos_user = new Tipo_usuario().ReadAll();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Nombre,Paterno,Materno,Rut,Dv,Direccion,Ciudad,Telefono,Email,Area,Username,Password,Id_tipo")] Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                usuario.Save();
                TempData["mensaje"] = "Guardado Correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
