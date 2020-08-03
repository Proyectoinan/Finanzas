using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finanzas.Models;
using Microsoft.AspNet.Identity;

namespace Finanzas.Controllers
{
    public class CreditosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Creditos
        public ActionResult Index()
        {
            return View(db.Creditoes.ToList());
        }

        // GET: Creditos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credito credito = db.Creditoes.Find(id);
            if (credito == null)
            {
                return HttpNotFound();
            }
            return View(credito);
        }

        // GET: Creditos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Creditos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Fecha,Detalle,Monto,Plazo")] Credito credito)
        {
            credito.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.Creditoes.Add(credito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credito);
        }

        // GET: Creditos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credito credito = db.Creditoes.Find(id);
            if (credito == null)
            {
                return HttpNotFound();
            }
            return View(credito);
        }

        // POST: Creditos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Fecha,Detalle,Monto,Plazo")] Credito credito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credito);
        }

        // GET: Creditos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credito credito = db.Creditoes.Find(id);
            if (credito == null)
            {
                return HttpNotFound();
            }
            return View(credito);
        }

        // POST: Creditos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Credito credito = db.Creditoes.Find(id);
            db.Creditoes.Remove(credito);
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
