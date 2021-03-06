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
    
    public partial class Productos
    {
        private Productos prod;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.Imagenes = new HashSet<Imagenes>();
            this.ProductosVentaDT = new HashSet<ProductosVentaDT>();
        }

        public Productos(Productos prod)
        {
            this.prod = prod;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Url { get; set; }
        public Nullable<int> id_categorias { get; set; }
        public Nullable<int> Stock { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagenes> Imagenes { get; set; }
        public virtual VentasDT VentasDT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductosVentaDT> ProductosVentaDT { get; set; }
    }
}
