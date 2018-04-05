using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelPatito.Controllers
{
    public class FacilidadesController : Controller
    {
        // GET: Facilidades
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PaginaUnoFacilidades()
        {
            ViewBag.Message = "Pagina uno de facilidades";

            return View();
        }
        public ActionResult PaginaDosFacilidades()
        {
            ViewBag.Message = "Pagina dos de facilidades";

            return View();
        }
        public ActionResult PaginaTresFacilidades()
        {
            ViewBag.Message = "Pagina tres de facilidades";

            return View();
        }
        public ActionResult PaginaCuatroFacilidades()
        {
            ViewBag.Message = "Pagina cuatro de facilidades";

            return View();
        }
       
    }
}




