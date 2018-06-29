using CrystalDecisions.CrystalReports.Engine;
using HotelPatito.Models.Tipadas;
using Newtonsoft.Json;
using PagedList;
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

        public ActionResult Export()
        {

            
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reporte"), "ReporteDeHabitacion.rpt"));
            rd.Refresh();
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Reporte.pdf");
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
            var hotel = JsonConvert.DeserializeObject<TipoHabitacionConImagenes>(respuesta);

            if (hotel == null)
            {
                String mensaje = "Error al buscar el hotel";
                return View(mensaje);
            }
            else
            {
                if (nombreTipoHabitacion == "Junior")
                {
                    hotel.imagenX = hotel.imagenJunior.imagen_Imagen;
                    hotel.idImagen = hotel.imagenJunior.id_Imagen;
                    hotel.descripcionImagen = hotel.imagenJunior.descripcion_Imagen;
                }
                else if (nombreTipoHabitacion == "Standard")
                {
                    hotel.imagenX = hotel.imagenStandard.imagen_Imagen;
                    hotel.idImagen = hotel.imagenStandard.id_Imagen;
                    hotel.descripcionImagen = hotel.imagenStandard.descripcion_Imagen;
                }
                else if (nombreTipoHabitacion == "Suite")
                {
                    hotel.imagenX = hotel.imagenSuite.imagen_Imagen;
                    hotel.idImagen = hotel.imagenSuite.id_Imagen;
                    hotel.descripcionImagen = hotel.imagenSuite.descripcion_Imagen;
                }
                return View(hotel);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ActualizarHabitaciones(HttpPostedFileBase file, string imagenActual, string descripcionImagenActual, string tipo, string descripcion, double tarifa)
        {
            String nombreHotel = "Patito";
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(Base_URL);
            cliente.DefaultRequestHeaders.Accept.Clear();
            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var respuesta = await cliente.GetStringAsync("Habitacion/actualizarTipo?tipo=" + tipo + "&descripcion=" + descripcion + "&tarifa=" + tarifa);

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
                //miImagen.fileID_Imagen = new Guid();
                /*Serializar Imagen */
                var imagen = JsonConvert.SerializeObject(miImagen);
                var buffer = Encoding.UTF8.GetBytes(imagen);

                var imagenContent = new ByteArrayContent(buffer);
                imagenContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");

                /* ************* */
                HttpResponseMessage respuestaImagen = new HttpResponseMessage();
                respuestaImagen = await cliente.PostAsync("Habitacion/actualizarImagenTH", imagenContent);

            }

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