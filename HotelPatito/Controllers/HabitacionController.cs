using HotelPatito.Models.Tipadas;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelPatito.Controllers
{
    public class HabitacionController : Controller
    {
        private string Base_URL = "http://localhost:58406/";


        // GET: Habitación
        public async Task<ActionResult> Index(int page=1, int pageSize= 4)
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Habitacion/obtenerHabitaciones");
            var hotel = JsonConvert.DeserializeObject<List<Habitacion>>(respuesta);

            PagedList<Habitacion> model = new PagedList<Habitacion>(hotel, page, pageSize);


            if (hotel == null)
            {
                String mensaje = "Error al buscar el hotel";
                return View(mensaje);
            }
            else
            {
                return View(model);
            }
        }
    }
}