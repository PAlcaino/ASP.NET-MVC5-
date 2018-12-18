using GestionToxicologica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GestionToxicologica.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Denuncia()
        {
     
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(int? id, string correoUser)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var denuncia = db.Denuncias.Find(id);
            if (correoUser != denuncia.CorreoUsuario)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultaDenunciaModel denunciaModel = new ConsultaDenunciaModel()
            {
                Id_denuncia = denuncia.Id_denuncia,
                NombreComuna = db.Comunas.Find(denuncia.Id_Comuna).Nombre,
                CorreoUsuario = denuncia.CorreoUsuario,
                Descripcion = denuncia.Descripcion,
                Estado = db.EstadoDenuncias.Find(denuncia.Id_Estado).Nombre_Estado,
                FechaIngreso = denuncia.Fecha_Ingreso
            };

            if (denuncia == null)
            {
                return HttpNotFound();
            }
            return View(denunciaModel);
        }       
        
    }
}
