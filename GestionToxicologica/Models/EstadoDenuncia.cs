using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionToxicologica.Models
{
    public class EstadoDenuncia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Id: ")]
        public int Id_Estado { get; set; }
        [Display(Name = "Nombre Estado: ")]
        public string Nombre_Estado { get; set; }
    }
}