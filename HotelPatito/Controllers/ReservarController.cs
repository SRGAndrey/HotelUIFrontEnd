using HotelPatito.Models.Tipadas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
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

            string fechaI = Convert.ToString(habitacionDisponible.fechaInic);
            string fechaF = Convert.ToString(habitacionDisponible.fechaFin);

            var fechainicial = fechaI.Substring(0, 10);

            var fechaFinal = fechaF.Substring(0, 10);

            string[] fechas = new string[2];

            fechas[0] = fechainicial;
            fechas[1] = fechaFinal;

            ViewBag.Message = fechas;

            return View(habitacionDisponible);
        }

        [HttpPost]
        public async Task<ActionResult> CargarDatosCliente(string cedula)
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Reservacion/CargarDatosCliente?cedula=" + cedula);

            //La variable Cliente debe estar en Tipadas
            var clienteResultante = JsonConvert.DeserializeObject<Cliente>(respuesta);

            string resultado = clienteResultante.nombre_Cliente + "/" +
                               clienteResultante.apellidos_Cliente + "/" +
                               clienteResultante.email_Cliente + "/" +
                               clienteResultante.tarjeta_Cliente;

            if (clienteResultante != null)
            {
                return Json(resultado);
            }
            else
            {
                return Json(null);

            }

            //return Json(clienteResultante);

        }//CargarDatosCliente

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

            try
            {

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sergdios09@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Reservacion en Hotel Patito";
                correo.Body = "El siguiente correo es para verificar que el cliente: "+nombre+" "+ apellidos+ 
                    " realizó una reservacion para la habitación número: "+ habitacion+" para la fecha"+fechaLlegada+
                    " hasta la fecha "+ fechaSalida +". Gracias por preferirnos ";
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string sCuentaCorreo = "hotelpatito2018@gmail.com";
                string sPasswordCorreo = "segama701";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correo);

                ViewBag.Message = "Se envio correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }


            //ACA va la cara de tipadas

            ClienteReserva clienteReserva = new ClienteReserva();
            clienteReserva.nombre_cliente = nombre;
            clienteReserva.numero_habitacion = habitacion;
            clienteReserva.mail = email;
            
            return RedirectToAction("Result",clienteReserva);
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

        // GET: Reservar/Details/5
        public ActionResult Result(ClienteReserva cliente)
        {
            return View(cliente);
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
