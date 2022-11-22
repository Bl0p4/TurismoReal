using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TurismoRealWeb.BLL;

namespace TurismoRealWeb.Controllers
{
    public class ImagenController : Controller
    {
        // GET: Imagen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imagen/Create
        [HttpPost]
        public ActionResult Create(Imagen img)
        {     
            return View();            
        }




    }
}
