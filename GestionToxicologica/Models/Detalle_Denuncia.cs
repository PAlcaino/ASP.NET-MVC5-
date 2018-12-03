using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionToxicologica.Models
{
    public class Detalle_Denuncia
    {
        public int Correlativo_Interno { get; set; }
        public int Id_Denuncia { get; set; }
        public int Correo_Profesional { get; set; }
        public int Id_Tipo_Profesional { get; set; }
        public DateTime Fecha_Transaccion { get; set; }
        public string Observacion_Profesional { get; set; }
    }
}