using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamingStore.Models;

namespace GamingStore.Controllers
{
    public class ProductosController : Controller
    {
        GamingStoreDBEntities db_context = new GamingStoreDBEntities();
        // GET: Productos
        public ActionResult Index()
        {

            return View(db_context.Productos.ToList());
        }


        public ActionResult Crear()
        {

            return View();

        }


        [HttpPost]
        public ActionResult AgregarProductos(Productos producto)
        {
            
            db_context.Productos.Add(producto);
            db_context.SaveChanges();
            ViewBag.msg = "Datos guardados exitosamente";
            Response.Redirect("/Productos/Index");
            return View();

        }

        [HttpGet]
        public ActionResult VerProducto(int id)
        {
            Productos prod = db_context.Productos.Where(x => x.Id == id).FirstOrDefault();
            return View(prod);


        }



        [HttpGet]
        public ActionResult Editar(int id)
        {

            Productos prod = db_context.Productos.Where(x => x.Id == id).FirstOrDefault();
            return View(prod);


        }

        [HttpPost]
        public ActionResult EditarProducto(string nombre, string descripcion, int precio, string categorias)

        {
            Categorias ncategoria = db_context.Categorias.Where(x => x.Nombre == categorias).FirstOrDefault();
            Productos prod = db_context.Productos.Where(x => x.Nombre == nombre).FirstOrDefault();

            prod.Nombre = nombre;
            prod.Descripcion = descripcion;
            prod.Precio = precio;
            ncategoria.Nombre = categorias;
            db_context.SaveChanges();
            return RedirectToAction("Index", "Productos");

        }
        


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Productos Product = db_context.Productos.Where(x => x.Id == id).FirstOrDefault();
            return View(Product);
        }

        [HttpDelete]
        public ActionResult EliminarProducto(Productos Product)
        {
      
            db_context.Productos.Remove(Product);
            db_context.SaveChanges();
            ViewBag.Msgg = "Producto eliminado exitosamente";

            return RedirectToAction("Index", "Productos", ViewBag.msgg);



        }



    }



}