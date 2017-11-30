using GamingStore.Controllers;
namespace GamingStore.Models
{
    public class ProductosVM
    {


        public ProductosVM(int id) {
            this.Id = id;
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
            this.Descripcion = Descripcion;
            this.Precio = Precio;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }

    }

}
    
