using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionToxicologica.Models
{
    public class Comuna
    {
        [Key]
        [Display(Name = "Id: ")]
        public int Id_Comuna { get; set; }
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
    }
}