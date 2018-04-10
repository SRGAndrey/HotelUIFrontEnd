using HotelPatito.Models.Tipadas;
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
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("http://localhost:58406/");
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Hotel/obtenerHotel?id=" + nombreHotel);
            var hotel = JsonConvert.DeserializeObject<HotelConImagenes>(respuesta);

            if (hotel == null )
            {
                String mensaje = "Error al leer informacion";
                return View(mensaje);
            }
            else
            {
                //HotelConImagenes hotelIndex = new HotelConImagenes();
                //hotelIndex.nombre_Hotel = hotel.nombre_Hotel;
                //hotelIndex.descripcion_Hotel = hotel.descripcion_Hotel;
                //hotelIndex.imagenes = imagenes;
                return View(hotel);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ComoLlegar()
        {
            ViewBag.Message = "Pagina de Como Llegar?.";

            return View();
        }
    }
}