using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;
namespace GamingStore.Models
{
    public class CuentasdeUsuario
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Debe ingresar un Password.")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Required (ErrorMessage = "Debe ingresar un Nombre")]
        public string Usuario { get; set; }

        [Required (ErrorMessage = "Debe ingresar un Email")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Favor Ingresar E-Mail Valido")]
        public string Email { get; set; }

        public string Direccion { get; set; }
        [Required (ErrorMessage = "Se requiere ingresar la ciudad")]
        public string Ciudad { get; set; }
        [Required (ErrorMessage = "Favor indique un teléfono")]
        public string Telefono { get; set; }

    }
}