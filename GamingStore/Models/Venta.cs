//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamingStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public int Cliente { get; set; }
        public Nullable<int> DetalleVenta { get; set; }
        public string CiudadEnvio { get; set; }
        public string DireccionEnvio { get; set; }
        public Nullable<int> EstadoPedido { get; set; }
    
        public virtual Cliente Cliente1 { get; set; }
        public virtual EstadoPedido EstadoPedido1 { get; set; }
        public virtual VentasDT VentasDT { get; set; }
    }
}
