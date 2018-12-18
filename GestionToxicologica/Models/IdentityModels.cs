using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GestionToxicologica.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name ="Nombre: ")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno: ")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno: ")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Sexo: ")]
        public int Id_Sex { get; set; }
        [Display(Name = "Fecha de Nacimimento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name= "Usuario Experto?")]
        public Boolean isExpert { get; set; }
        public List<string> Sexos { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<GestionToxicologica.Models.Denuncia> Denuncias { get; set; }

        public System.Data.Entity.DbSet<GestionToxicologica.Models.Comuna> Comunas { get; set; }

        public System.Data.Entity.DbSet<GestionToxicologica.Models.EstadoDenuncia> EstadoDenuncias { get; set; }
        public System.Data.Entity.DbSet<GestionToxicologica.Models.Sex> Sexes { get; set; }
    }

    public class Sex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Sex { get; set; }
        public string Type { get; set; }
    }
}