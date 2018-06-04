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
        // GET: Administrador/Details/5

        public async Task<ActionResult> ActualizarHabitacion(string nombreTipoHabitacion)
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Habitacion/obtenerTipoHabitacion?tipo=" + nombreTipoHabitacion);
            var hotel = JsonConvert.DeserializeObject<Tipo_Habitacion>(respuesta);

            if (hotel == null)
            {
                String mensaje = "Error al buscar el hotel";
                return View(mensaje);
            }
            else
            {
                return View(hotel);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ActualizarHabitaciones(string tipo, string descripcion, double tarifa)
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Habitacion/actualizarTipo?tipo=" + tipo + "&descripcion=" + descripcion + "&tarifa=" + tarifa);

            return RedirectToAction("AdministrarHabitaciones", "Habitacion");

        }

        [HttpPost]
        public async Task<ActionResult> ObtenerDisponibilidad(string fechaLlegada, string fechaSalida, string tipo)
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Habitacion/ObtenerDisponibilidad?fechaLlegada=" + fechaLlegada + "&fechaSalida=" + fechaSalida + "&tipo=" + tipo);

            var habitacionesDisponibles = JsonConvert.DeserializeObject<List<HabitacionesDisponibles>>(respuesta);
            string resultado = "";
            foreach (var habitacionActual in habitacionesDisponibles)
            {
                resultado += habitacionActual.numero_Habitacion + "/" +
                            habitacionActual.tipo_Habitacion + "/" +
                            habitacionActual.costo + ";";
            }//foreach

            if (habitacionesDisponibles != null)
            {
                return Json(resultado);
            }//if
            else
            {
                return Json(null);

            }//else

        }//obtenerDisponibilidad

        public async Task<ActionResult> AdministrarHabitaciones()
        {
            String nombreHotel = "Patito";

            HttpClient cliente = new HttpClient();

            cliente.BaseAddress = new Uri(Base_URL);

            cliente.DefaultRequestHeaders.Accept.Clear();

            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            var respuesta = await cliente.GetStringAsync("Habitacion/obtenerTodas");

            var habitacion = JsonConvert.DeserializeObject<List<AdministrarHabitacion>>(respuesta);


            ViewBag.Tipo = habitacion;
            return View();
        }
    }
}