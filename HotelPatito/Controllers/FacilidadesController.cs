using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelPatito.Controllers
{
    public class FacilidadesController : Controller
    {
        private string Base_URL = "http://localhost:58406/";
        // GET: Facilidades
        public async Task<ActionResult> Index()
        {

            //HttpClient cliente = new HttpClient();
            //cliente.BaseAddress = new Uri(Base_URL);
            //cliente.DefaultRequestHeaders.Accept.Clear();
            //cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //var respuesta = await cliente.GetStringAsync("Facilidad/ObtenerFacilidades");
            //var facilidad = JsonConvert.DeserializeObject<FacilidadesConImagenes>(respuesta);
            //return View(facilidad);
            return View();
        }
        public async Task<ActionResult> PaginaUnoFacilidades()
        {
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




