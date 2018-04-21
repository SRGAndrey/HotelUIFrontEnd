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
    public class ReservarController : Controller
    {

        private string Base_URL = "http://localhost:58406/";
        // GET: Reservar
        public ActionResult BuscaHabitacion()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ReservarHabitacion(string fechaLlegada, string fechaSalida, string tipo)
        {
            //System.DateTime fechaInic = DateTime.Parse(fechaLlegada);
            //System.DateTime fechaFin = DateTime.Parse(fechaSalida);

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Reservacion/HabitacionDisponible?fechaLlegada=" + fechaLlegada + "&fechaSalida=" + fechaSalida + "&tipo=" + tipo);

            var habitacionDisponible = JsonConvert.DeserializeObject<HabitacionDisponible>(respuesta);

            return View(habitacionDisponible);
        }

        [HttpPost]
        public async Task<ActionResult> HacerReservacion(string fechaLlegada, string fechaSalida, int habitacion, string cedula,
            string nombre, string apellidos, int tarjeta, string email)
        {
            //System.DateTime fechaInic = DateTime.Parse(fechaLlegada);
            //System.DateTime fechaFin = DateTime.Parse(fechaSalida);

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Reservacion/HacerReservacion?fechaLlegada=" + fechaLlegada + "&fechaSalida=" 
                + fechaSalida + "&habitacion=" + habitacion + "&cedula=" + cedula + "&nombre=" + nombre + "&apellidos=" + apellidos
                + "&tarjeta=" + tarjeta + "&email=" + email);

            var Reservacion = JsonConvert.DeserializeObject<Reservacion>(respuesta);
            
            return RedirectToAction("BuscaHabitacion");
        }
        // GET: Reservar
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reservar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservar/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
