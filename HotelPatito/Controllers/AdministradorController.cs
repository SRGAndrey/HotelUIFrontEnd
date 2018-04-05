using HotelPatito.Models.Tipadas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelPatito.Controllers
{
    public class AdministradorController : Controller
    {

        private string Base_URL = "http://localhost:58406/api/";
        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        public async Task<ActionResult> Create(String usuario, String contra)
        {
            //            Administrador admin = new Administrador();
            //            admin.contrasenna_Administrador = contra;
            //            admin.id_Administrador = 0;
            //            admin.usuario_Administrador = usuario;

            //            try
            //            {
            //                HttpClient client = new HttpClient();
            //                client.BaseAddress = new Uri(Base_URL);
            //                client.DefaultRequestHeaders.Accept.Clear();
            //                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //                String jsonAtribute = JsonConvert.SerializeObject(admin);
            //                var buffer = Encoding.UTF8.GetBytes(jsonAtribute);
            //                var byteContent = new ByteArrayContent(buffer);

            //;                HttpResponseMessage response = await client.PostAsync("Administrador/insertarAdministrador", byteContent);
            //                //return response.IsSuccessStatusCode;

            //                if (response.IsSuccessStatusCode) {
            //                    return RedirectToAction("Index"); // hay que enviar alguna variable para mostrar un mensaje de que se guard'o correctamente
            //                                                      // esa variable en la vista se va encontrar en @model y se recorrería con RAZOR
            //                                                      // ver este video https://www.youtube.com/watch?v=Z08vmuSh03g a partir del min 10:40
            //                }
            //                else
            //                {
            //                    String mensaje = "Respuesta de api sin exito";
            //                    return View(mensaje);
            //                }

            //            }
            //            catch
            //            {
            //                return View();
            //            }
            return View();
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrador/Edit/5
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

        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrador/Delete/5
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
