using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingStore.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GamingStore.Controllers
{
    public class UserController : Controller
    {
        GamingStoreDBEntities db_context = new GamingStoreDBEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Registrar()
        {


            return View();
        }


        //Registra un Cliente
        [HttpPost]
        public ActionResult Registrar(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                db_context.Cliente.Add(cliente);
                db_context.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.Message = "Bienvenido" + " " + cliente.Usuario;
            return View();

        }

        //Inicia sesion de un cliente
        [HttpGet]
        public ActionResult IniciarSesion()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Cliente Usr)
        {

            var Usuario = db_context.Cliente.Where(m => m.Usuario == Usr.Usuario && m.Password == Usr.Password).FirstOrDefault();
            if (Usuario != null)
            {
                Session["Usuario"] = Usr.Usuario.ToString();
                
            } else
            {
                ModelState.AddModelError("", "Nombre o Contraseña de Cliente es Incorrecta.");
                return View();
            }
           return RedirectToAction("/SesionIniciada");
        }

        public ActionResult SesionIniciada()
        {

            if (Session["Usuario"] != null)
            {
                
                return View();


            }
            else
            {
                return RedirectToAction("IniciarSesion");
            }

        }
        
    }
}


