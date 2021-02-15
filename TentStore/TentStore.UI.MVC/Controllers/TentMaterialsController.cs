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
    public class TentMaterialsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: TentMaterials
        public ActionResult Index()
        {
            return View(db.TentMaterials.ToList());
        }

        // GET: TentMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TentMaterial tentMaterial = db.TentMaterials.Find(id);
            if (tentMaterial == null)
            {
                return HttpNotFound();
            }
            return View(tentMaterial);
        }

        // GET: TentMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TentMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TentMaterialID,TentMaterial1")] TentMaterial tentMaterial)
        {
            if (ModelState.IsValid)
            {
                db.TentMaterials.Add(tentMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tentMaterial);
        }

        // GET: TentMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TentMaterial tentMaterial = db.TentMaterials.Find(id);
            if (tentMaterial == null)
            {
                return HttpNotFound();
            }
            return View(tentMaterial);
        }

        // POST: TentMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TentMaterialID,TentMaterial1")] TentMaterial tentMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tentMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tentMaterial);
        }

        // GET: TentMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TentMaterial tentMaterial = db.TentMaterials.Find(id);
            if (tentMaterial == null)
            {
                return HttpNotFound();
            }
            return View(tentMaterial);
        }

        // POST: TentMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TentMaterial tentMaterial = db.TentMaterials.Find(id);
            db.TentMaterials.Remove(tentMaterial);
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
