using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.Models
{
    public class ProductosCarro


    #region Propiedades
    {
        

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int PrecioTotal { get; set; }

        public static implicit operator ProductosCarro(List<ProductosCarro> v)
        {
            throw new NotImplementedException();
        }
    }
}   
#endregion




