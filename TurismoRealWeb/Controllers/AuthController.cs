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
                usuario = usuario.Buscar(usuario.Username);
                Session["User"] = usuario;
                Session["id"] = usuario.Id;
                Session["username"] = usuario.Username;

                if (usuario.Id_tipo == 1)
                {
                    return RedirectToAction("Home", "Sitio");
                }
                return RedirectToAction("Index", "Home");
                
            }
            TempData["mensaje"] = "Usuario o Contraseña Incorrectos";
            return View(usuario);
        }



        private bool IsValid(Usuario usuario)
        {
            if (usuario.Password != null)
            {
                usuario.Password = TR_Recursos.ConvertirSha256(usuario.Password);
                return usuario.Autenticar();
            }
            else
            {
                return false;
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut2()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Sitio");
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {                    
                    return View(usuario);
                }

                usuario.Password = TR_Recursos.ConvertirSha256(usuario.Password);
                usuario.Id_tipo = 1;

                // TODO: Add insert logic here
                usuario.Reg();

                TempData["mensaje"] = "Registrado Correctamente";

                return RedirectToAction("Home", "Sitio");
            }
            catch
            {
                return View(usuario);
            }
        }


    }
}
