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
        [ForeignKey("Comuna")]
        [Required(ErrorMessage = "Debe seleccionar una opcion")]
        public int Id_Comuna { get; set; }
        public EstadoDenuncia Estado { get; set; }
        [ForeignKey("Estado")]
        public int Id_Estado { get; set; }
        [Display(Name ="Fecha Ingreso: ")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Ingreso { get; set; }
        [Display(Name = "Fecha Cierre: ")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Cierre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        [Display(Name ="Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name ="Correo de Usuario: ")]
        public string CorreoUsuario { get; set; }    
    }

    public class ConsultaDenunciaModel
    {

        [Display(Name = "Id:")]
        [Required(ErrorMessage = "Debe ingresar el id de su denuncia")]
        public int Id_denuncia { get; set; }
        [Required(ErrorMessage = "Debe ingresar su correo")]
        public string CorreoUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Descripcion { get; set; }
        public string NombreComuna { get; set; }
        public string Estado { get; set; }
    }

    public class CrearDenunciaViewModel
    {
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        public string Descripcion { get; set; }
        public int Id_Comuna { get; set; }
        public Comuna Comuna { get; set; }
        public List<Comuna> Comunas { get; set; }
    }

    public class EditDenunciaViewModel
    {
        [Display(Name = "Id:")]
        [Required(ErrorMessage = "Debe ingresar el id de su denuncia")]
        public int Id_denuncia { get; set; }
        [ForeignKey("Comuna")]
        [Required(ErrorMessage = "Debe seleccionar una opcion")]
        public int Id_Comuna { get; set; }

        [ForeignKey("Estado")]
        [Required(ErrorMessage = "Debe seleccionar una opcion")]
        public int Id_Estado { get; set; }

        [Display(Name = "Fecha Cierre: ")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Cierre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name ="Comunas: ")]
        public List<Comuna> Comunas { get; set; }
        [Display(Name ="Estados: ")]
        public List<EstadoDenuncia> Estados { get; set; }
    }
}