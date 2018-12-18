using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionToxicologica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GestionToxicologica.Controllers
{
    public class ListDenunciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListDenuncias
        public ActionResult Index()
        {
            return View(db.Denuncias.ToList());
        }

        // GET: ListDenuncias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncias.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            return View(denuncia);
        }

        // GET: ListDenuncias/Create
        public ActionResult Create()
        {
            var model = new CrearDenunciaViewModel();
            model.Comunas = db.Comunas.ToList();
            return View(model);
        }

        // POST: ListDenuncias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comuna,Id_Comuna,Descripcion")] Denuncia denuncia)
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var CurrentUser = UserManager.FindById(User.Identity.GetUserId());
            denuncia.CorreoUsuario = CurrentUser.Email;
            denuncia.Fecha_Cierre = DateTime.Now.AddDays(10);
            denuncia.Fecha_Ingreso = DateTime.Now;
            denuncia.Id_Estado = 1;
            
            if (ModelState.IsValid)
            {
                db.Denuncias.Add(denuncia);
                db.SaveChanges();

                if (User.IsInRole("User"))
                {
                    return View("Gracias", denuncia);
                }
                               
                return RedirectToAction("Index");
            }

            return View(denuncia);
        }

        // GET: ListDenuncias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncias.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            var model = new EditDenunciaViewModel()
            {
                Id_Comuna = denuncia.Id_Comuna,
                Id_Estado = denuncia.Id_Estado,
                Descripcion = denuncia.Descripcion,
                Fecha_Cierre = denuncia.Fecha_Cierre,
                Comunas = db.Comunas.ToList(),
                Estados = db.EstadoDenuncias.ToList()
            };


            return View(model);
        }

        // POST: ListDenuncias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_denuncia,Comuna,Id_Comuna,Estado,Id_Estado,Fecha_Ingreso,Fecha_Cierre,Descripcion,CorreoUsuario")] Denuncia denuncia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(denuncia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(denuncia);
        }

        // GET: ListDenuncias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denuncia denuncia = db.Denuncias.Find(id);
            if (denuncia == null)
            {
                return HttpNotFound();
            }
            return View(denuncia);
        }

        // POST: ListDenuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Denuncia denuncia = db.Denuncias.Find(id);
            db.Denuncias.Remove(denuncia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
