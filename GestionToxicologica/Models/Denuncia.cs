using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionToxicologica.Models
{
    public class Denuncia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id:")]
        public int Id_denuncia { get; set; }

        public Comuna Comuna { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una opcion")]
        public int Id_Comuna { get; set; }


        public EstadoDenuncia Estado { get; set; }

        public int Id_Estado { get; set; }

        public DateTime Fecha_Ingreso { get; set; }

        public DateTime Fecha_Cierre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        public string Descripcion { get; set; }

        public string CorreoUsuario { get; set; }
    }

    public class ConsultaDenunciaModel
    {
        [Display(Name = "Id:")]
        [Required(ErrorMessage = "Debe ingresar el id de su denuncia")]
        public int Id_denuncia { get; set; }
        public string CorreoUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

}