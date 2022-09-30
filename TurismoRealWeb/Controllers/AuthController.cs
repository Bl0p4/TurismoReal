using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;
using System.Web.Security;

namespace TurismoRealWeb.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Usuario usuario, string ReturnUrl)
        {
            if (IsValid(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.Username, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            TempData["mensaje"] = "Usuario o Contraseña Incorrectos";
            return View(usuario);
        }

        private bool IsValid(Usuario usuario)
        {
            return usuario.Autenticar();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
