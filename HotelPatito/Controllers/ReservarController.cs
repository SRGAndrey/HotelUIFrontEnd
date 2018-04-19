using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelPatito.Controllers
{
    public class ReservarController : Controller
    {
        // GET: Reservar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sin_Resultado()
        {
            return View();
        }
    }
}