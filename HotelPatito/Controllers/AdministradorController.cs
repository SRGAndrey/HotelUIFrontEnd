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

        private string Base_URL = "http://localhost:58406/";
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
        public async Task<ActionResult> Create(string usuario, string contra)
        {
            
                HttpClient cliente = new HttpClient();
                cliente.BaseAddress = new Uri(Base_URL);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var respuesta = await cliente.GetStringAsync("Admin/obtenerAdmin?usuario=" + usuario + "&contra=" + contra);
                var administrador = JsonConvert.DeserializeObject<Administrador>(respuesta);

                if (administrador != null)
                {
                    Session["UserName"] = administrador.usuario_Administrador;
                    Session["Contrasena"] = administrador.contrasenna_Administrador;
                    return RedirectToAction("Index","Home");
                }

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
