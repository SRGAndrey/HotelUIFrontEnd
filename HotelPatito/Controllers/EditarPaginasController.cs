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
    public class EditarPaginasController : Controller
    {
        private string Base_URL = "http://localhost:58406/";
        public async Task<ActionResult> Index()
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Hotel/obtenerHotel?id=" + nombreHotel);
            var hotel = JsonConvert.DeserializeObject<HotelConImagenes>(respuesta);

            if (hotel == null)
            {
                String mensaje = "Error";
                return View(mensaje);
            }
            else
            {
                return View(hotel);
            }
        }

        public async Task<ActionResult> About()
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Hotel/obtenerHotel?id=" + nombreHotel);
            var hotel = JsonConvert.DeserializeObject<HotelConImagenes>(respuesta);

            if (hotel == null)
            {
                String mensaje = "Error al buscar el hotel";
                return View(mensaje);
            }
            else
            {
                return View(hotel);
            }
        }//about
        public async Task<ActionResult> Facilidades()
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Facilidad/ObtenerFacilidades");
            var facilidad = JsonConvert.DeserializeObject<FacilidadesConImagenes>(respuesta);
            return View(facilidad);


        }

        public async Task<ActionResult> EditarSobreNosotros(string descripcion)
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //var respuesta = await cliente.GetStringAsync("Hotel/obtenerHotel?id=" + nombreHotel);
            var respuesta = await cliente.GetStringAsync("Hotel/ActualizarSN?nombre=" + nombreHotel + "&descripcion=" + descripcion);
            
            Session["actualizado"] = "Descripción actualizada";
            return RedirectToAction("About", "Home");
                
        }//editar sobre nosotros

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Facilidad(string id, string descripcion, string nombre)
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Facilidad/actualizarFacilidad?id=" + id + "&descripcion=" + descripcion + "&nombre=" + nombre);

            return RedirectToAction("Facilidades", "EditarPaginas");
        }
        public async Task<ActionResult> EditarFacilidad(string id)
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Facilidad/obtenerTipoFacilidad?id=" + id);
            var hotel = JsonConvert.DeserializeObject<Facilidad>(respuesta);

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
        public async Task<ActionResult> ComoLlegar()
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Hotel/obtenerHotel?id=" + nombreHotel);
            var hotel = JsonConvert.DeserializeObject<HotelConImagenes>(respuesta);

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
        public async Task<ActionResult> Tarifas()
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Hotel/obtenerHabitacion");
            var hotel = JsonConvert.DeserializeObject<TipoHabitacionConImagenes>(respuesta);

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
    }
}