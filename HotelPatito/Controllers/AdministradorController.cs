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
        public ActionResult Home()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", "Administrador", new { login = true });
            }
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrador/Create
        public ActionResult Create(bool login)
        {
            if (login)
            {
                return View();
            }
            ViewBag.ErrorMessage = "Usuario o contraseña incorrecta!!!" + "\n" + "Intentalo de nuevo";
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

                switch (administrador.rol_Administrador)
                {
                    case 1:
                        Session["Rol"] = "super";
                        break;
                    case 2:
                        Session["Rol"] = "administrador";
                        break;
                    case 3:
                        Session["Rol"] = "basico";
                        break;
                }

                
                return RedirectToAction("Home", "Administrador");
            }

            return RedirectToAction("Create", "Administrador", new { login = false });
        }
        public ActionResult BuscarHabitacion()
        {

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

        public ActionResult Logout()
        {
            //Session.Abandon();
            Session.Remove("UserName");
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            var abc = Session["UserName"];
            return RedirectToAction("Create", "Administrador", new { login = true });
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
