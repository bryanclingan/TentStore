using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TentStore.DATA.EF;

namespace TentStore.UI.MVC.Controllers
{
    public class PoleMaterialsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: PoleMaterials
        public ActionResult Index()
        {
            return View(db.PoleMaterials.ToList());
        }

        // GET: PoleMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoleMaterial poleMaterial = db.PoleMaterials.Find(id);
            if (poleMaterial == null)
            {
                return HttpNotFound();
            }
            return View(poleMaterial);
        }

        // GET: PoleMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoleMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoleMaterialID,PoleMaterial1")] PoleMaterial poleMaterial)
        {
            if (ModelState.IsValid)
            {
                db.PoleMaterials.Add(poleMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poleMaterial);
        }

        // GET: PoleMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoleMaterial poleMaterial = db.PoleMaterials.Find(id);
            if (poleMaterial == null)
            {
                return HttpNotFound();
            }
            return View(poleMaterial);
        }

        // POST: PoleMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoleMaterialID,PoleMaterial1")] PoleMaterial poleMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poleMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poleMaterial);
        }

        // GET: PoleMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoleMaterial poleMaterial = db.PoleMaterials.Find(id);
            if (poleMaterial == null)
            {
                return HttpNotFound();
            }
            return View(poleMaterial);
        }

        // POST: PoleMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoleMaterial poleMaterial = db.PoleMaterials.Find(id);
            db.PoleMaterials.Remove(poleMaterial);
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
