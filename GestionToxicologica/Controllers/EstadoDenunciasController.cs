using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionToxicologica.Models;

namespace GestionToxicologica.Controllers
{
    public class EstadoDenunciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EstadoDenuncias
        public ActionResult Index()
        {
            return View(db.EstadoDenuncias.ToList());
        }

        // GET: EstadoDenuncias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoDenuncia estadoDenuncia = db.EstadoDenuncias.Find(id);
            if (estadoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(estadoDenuncia);
        }

        // GET: EstadoDenuncias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoDenuncias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estado,Nombre_Estado")] EstadoDenuncia estadoDenuncia)
        {
            if (ModelState.IsValid)
            {
                db.EstadoDenuncias.Add(estadoDenuncia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoDenuncia);
        }

        // GET: EstadoDenuncias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoDenuncia estadoDenuncia = db.EstadoDenuncias.Find(id);
            if (estadoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(estadoDenuncia);
        }

        // POST: EstadoDenuncias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estado,Nombre_Estado")] EstadoDenuncia estadoDenuncia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoDenuncia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoDenuncia);
        }

        // GET: EstadoDenuncias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoDenuncia estadoDenuncia = db.EstadoDenuncias.Find(id);
            if (estadoDenuncia == null)
            {
                return HttpNotFound();
            }
            return View(estadoDenuncia);
        }

        // POST: EstadoDenuncias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoDenuncia estadoDenuncia = db.EstadoDenuncias.Find(id);
            db.EstadoDenuncias.Remove(estadoDenuncia);
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
