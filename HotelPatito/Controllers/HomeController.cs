using HotelPatito.Models.Tipadas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelPatito.Controllers
{
    public class HomeController : Controller
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
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
        }//Tarifas
        
        public async Task<ActionResult> AdministrarHome()
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

                //ViewBag.ErrorMessage = "Se actualizó la imagen!!";
                return View(hotel);
            }

        }

        [HttpPost]
        public async Task<ActionResult> ActualizarHome(HttpPostedFileBase file, string imagenActual, string descripcionImagenActual, string hotel, string textoDescripcion)
        {

            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage respuestaImagen = new HttpResponseMessage();
            HttpResponseMessage respuestaDatos = new HttpResponseMessage();

            /* Serializar String */
            //string descripcionYid = hotel + "," + descripcionImagenActual;
            Hotel miHotel = new Hotel();
            miHotel.nombre_Hotel = hotel;
            miHotel.descripcion_Hotel = textoDescripcion;
            var dato = JsonConvert.SerializeObject(miHotel);
            var bufferDatos = Encoding.UTF8.GetBytes(dato);
            var datosContent = new ByteArrayContent(bufferDatos);
            datosContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
            /* ************* */

            if (file != null)
            {
                var datosImagen = new MemoryStream();

                file.InputStream.CopyTo(datosImagen);

                byte[] nuevaImagen = datosImagen.ToArray();

                int imagenCambiar = Int32.Parse(imagenActual);

                Imagen miImagen = new Imagen();
                miImagen.descripcion_Imagen = descripcionImagenActual;
                miImagen.imagen_Imagen = nuevaImagen;
                miImagen.id_Imagen = imagenCambiar;
                // miImagen.fileID_Imagen = new Guid();
                /*Serializar Imagen */
                var imagen = JsonConvert.SerializeObject(miImagen);
                var buffer = Encoding.UTF8.GetBytes(imagen);

                var imagenContent = new ByteArrayContent(buffer);
                imagenContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");

                /* ************* */

                respuestaImagen = await cliente.PostAsync("Hotel/actualizarImagenHome", imagenContent);

            }

            respuestaDatos = await cliente.PostAsync("Hotel/actualizarDescripcionHome", datosContent);


            if (respuestaDatos.IsSuccessStatusCode)
            {
                //var hotel = JsonConvert.DeserializeObject<HotelConImagenes>(respuesta.Content.ReadAsStringAsync().Result);

                return RedirectToAction("AdministrarHome", "Home");
            }
            return RedirectToAction("AdministrarHome", "Home");

        }
    }
}
