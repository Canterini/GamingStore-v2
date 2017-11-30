using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GamingStore.Models;

namespace GamingStore.Controllers
{
    public class AdminController : Controller
    {
        private GamingStoreDBEntities db = new GamingStoreDBEntities();

        // GET: Admin
        public async Task<ActionResult> Index()
        {
            var productos = db.Productos.Include(p => p.Categorias).Include(p => p.VentasDT);
            return View(await productos.ToListAsync());

        }

        // GET: Admin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.id_categorias = new SelectList(db.Categorias, "id", "Nombre");
            ViewBag.Stock = new SelectList(db.VentasDT, "Id", "Precio");
            return View();
        }

        // POST: Admin/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Descripcion,Precio,Url,id_categorias,Stock")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_categorias = new SelectList(db.Categorias, "id", "Nombre", productos.id_categorias);
            ViewBag.Stock = new SelectList(db.VentasDT, "Id", "Precio", productos.Stock);
            return View(productos);
        }

        // GET: Admin/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categorias = new SelectList(db.Categorias, "id", "Nombre", productos.id_categorias);
            ViewBag.Stock = new SelectList(db.VentasDT, "Id", "Precio", productos.Stock);
            return View(productos);
        }

        // POST: Admin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Descripcion,Precio,Url,id_categorias,Stock")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_categorias = new SelectList(db.Categorias, "id", "Nombre", productos.id_categorias);
            ViewBag.Stock = new SelectList(db.VentasDT, "Id", "Precio", productos.Stock);
            return View(productos);
        }

        // GET: Admin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Productos productos = await db.Productos.FindAsync(id);
            db.Productos.Remove(productos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
