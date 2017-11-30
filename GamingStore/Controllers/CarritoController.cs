using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using GamingStore.Models;




namespace GamingStore.Controllers
{
    public class CarritoController : Controller
    {

        GamingStoreDBEntities db_context = new GamingStoreDBEntities();


        // GET: Carrito
        public int Cuentacarrito { get; set; }

        [HttpGet]
        public JsonResult ConsultaCarrito()
        {
            List<ProductosCarro> milista = (List<ProductosCarro>)Session["Carrito"];
            {   
                if (milista != null)
                {
                    Cuentacarrito = milista.Count();

                }else  {  
                    Cuentacarrito = 0;
                }
                return Json(Cuentacarrito, JsonRequestBehavior.AllowGet);

            }

        }
        


        #region Metodos de Modificación de Items 


        [HttpPost]
        public JsonResult AddProductoCarro(int id)
        {
            Productos prod = db_context.Productos.Where(x => x.Id == id).FirstOrDefault();
            Productos prodbd = new Productos(prod);
            


            if (prod != null)
            {
                

                if (Session["Carrito"] == null)
                {
                    List<ProductosCarro> Listacarrito = new List<ProductosCarro>();
                    Listacarrito.Add(new ProductosCarro { Id = prod.Id, Nombre = prod.Nombre, Descripcion = prod.Descripcion, Cantidad = 1 , Precio = prod.Precio, PrecioTotal = Convert.ToInt32(prod.Precio) });
                    Session.Add("Carrito", Listacarrito);
                    
                }
                else
                {

                    List<ProductosCarro> Listacarrito = (List<ProductosCarro>)Session["Carrito"];
                    ProductosCarro ProductoenCarro = Listacarrito.Where(x => x.Id == prod.Id).FirstOrDefault();
                    {
                        if (ProductoenCarro != null)
                        {
                            ProductoenCarro.Cantidad += 1;
                            ProductoenCarro.PrecioTotal = Convert.ToInt32(ProductoenCarro.Precio * ProductoenCarro.Cantidad);
                        }
                        else
                        {
                            Listacarrito.Add(new ProductosCarro { Id = prod.Id, Nombre = prod.Nombre, Descripcion = prod.Descripcion, Cantidad = 1, Precio = prod.Precio, PrecioTotal = Convert.ToInt32(prod.Precio) });
                            Session["Carrito"] = Listacarrito;
                        }

                        
                    }
                }
            }

            return Json((List<ProductosCarro>)Session["Carrito"]);
        }


        public JsonResult EliminardeCarrito (int id)
        {
            
            List<ProductosCarro> milista = (List<ProductosCarro>)Session["Carrito"];
            ProductosCarro productoeliminar = milista.Where(x => x.Id == id).FirstOrDefault();
            if (productoeliminar != null)
            {
                milista.Remove(productoeliminar);
                

            }else
            {
                Dictionary<string, object> error = new Dictionary<string, object>();
                error.Add("ErrorCode", -1);
                error.Add("ErrorMessage", "Debes seleccionar un producto que esté en el carro");
                return Json(error);

            }

            return Json((List<ProductosCarro>)Session["Carrito"]);
            
        }




        /*  public void ProductoenCero(int id, int Cantidad)
          {
              if (Listacarrito != null && Cantidad == 0)
              {
                  Listacarrito.RemoveAt(id);
                  return;

              }

              ProductosCarro ReduceCantidad = new ProductosCarro();

              foreach (ProductosCarro prod in Listacarrito)
              {
                  if (prod.Equals(ReduceCantidad))
                  {
                      prod.Cantidad = Cantidad;
                      return;
                  }
              }


          }

          [HttpPost]
          public void EliminardeCarrito(int id)
          {

              ProductosCarro ProductoEliminado = new ProductosCarro();
              Listacarrito.Remove(ProductoEliminado);

          }
          public int GetSubTotal()
          {
              int subtotal = 0;
              foreach (ProductosCarro prod in Listacarrito)
              subtotal += prod.PrecioTotal;
              return subtotal;
          }

      }
      */
        #endregion

        public ActionResult VerCarro()
        {


            return View();


        }


    }
}