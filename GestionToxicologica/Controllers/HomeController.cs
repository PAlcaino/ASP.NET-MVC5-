using GestionToxicologica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionToxicologica.Controllers
{
    
    public class HomeController : Controller
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }
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
        public ActionResult DenunciaEstado(EstadoDenuncia model)
        {
            //int id = GetDenuncia(model.Id_Estado);
            return View();
    }

        [HttpPost]
        public  ActionResult Denuncia(Denuncia model)
        {

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            model.CorreoUsuario = user.Email;
            model.Fecha_Ingreso = DateTime.Now;
            model.Id_Estado = 1;
            model.Fecha_Cierre = model.Fecha_Ingreso.AddDays(8);

            int id = AddDenuncia(model);
            if ( id > 0)
            {
                model.Id_denuncia = id;
                return View("Gracias", model);
            }

            return View(model);

        }
       

        public int AddDenuncia(Denuncia model)
        {

            connection();
            SqlCommand com = new SqlCommand("ins_denuncia", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@correo_usuario", model.CorreoUsuario);
            com.Parameters.AddWithValue("@id_estado", model.Id_Estado);
            com.Parameters.AddWithValue("@fecha_ingreso", model.Fecha_Ingreso);
            com.Parameters.AddWithValue("@descripcion_caso", model.Descripcion);
            com.Parameters.AddWithValue("@fecha_cierre", model.Fecha_Cierre);
            com.Parameters.AddWithValue("@id_comuna", model.Id_Comuna);
            con.Open();
            int i = Convert.ToInt32( com.ExecuteScalar());
            con.Close();
            return i;
        }

        public Denuncia GetDenuncia(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("sel_denuncia", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Denuncia denuncia = PopulateDenuncia(dr);
                    return denuncia;
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            con.Close();
            return null;
        }

        private Denuncia PopulateDenuncia(IDataRecord dr)
        {
            new Denuncia()
            {
                Id_denuncia = (int)dr["Id_Denuncia"],
                Comuna = new Comuna
                    {
                        Id_Comuna = (int)dr["Id_Comuna"],
                        Nombre = (string)dr["Nombre"]
                    },
                Descripcion = (string)dr["Descripcion"],
                Estado = new EstadoDenuncia
                    {
                        Id_Estado = (int)dr["Id_Estado"],
                        Nombre_Estado = (string)dr["Nombre"]
                    },
                Fecha_Ingreso = (DateTime)dr["fecha_ingreso"],
                Fecha_Cierre = (DateTime)dr["fecha_cierre"],
                CorreoUsuario = (string)dr["Email"]
            };
            return new Denuncia();
        }
        
    }
}
