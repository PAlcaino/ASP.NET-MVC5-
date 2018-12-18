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
    public class ComunasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comunas
        public ActionResult Index()
        {
            return View(db.Comunas.ToList());
        }

        // GET: Comunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuna comuna = db.Comunas.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // GET: Comunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Comuna,Nombre")] Comuna comuna)
        {
            if (ModelState.IsValid)
            {
                db.Comunas.Add(comuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comuna);
        }

        // GET: Comunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuna comuna = db.Comunas.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // POST: Comunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Comuna,Nombre")] Comuna comuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comuna);
        }

        // GET: Comunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuna comuna = db.Comunas.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // POST: Comunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comuna comuna = db.Comunas.Find(id);
            db.Comunas.Remove(comuna);
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
