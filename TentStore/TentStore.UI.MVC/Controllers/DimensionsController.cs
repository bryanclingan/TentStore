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
    public class DimensionsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Dimensions
        public ActionResult Index()
        {
            return View(db.Dimensions.ToList());
        }

        // GET: Dimensions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimension dimension = db.Dimensions.Find(id);
            if (dimension == null)
            {
                return HttpNotFound();
            }
            return View(dimension);
        }

        // GET: Dimensions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dimensions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DimensionID,DimensionRange")] Dimension dimension)
        {
            if (ModelState.IsValid)
            {
                db.Dimensions.Add(dimension);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dimension);
        }

        // GET: Dimensions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimension dimension = db.Dimensions.Find(id);
            if (dimension == null)
            {
                return HttpNotFound();
            }
            return View(dimension);
        }

        // POST: Dimensions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DimensionID,DimensionRange")] Dimension dimension)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimension).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimension);
        }

        // GET: Dimensions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimension dimension = db.Dimensions.Find(id);
            if (dimension == null)
            {
                return HttpNotFound();
            }
            return View(dimension);
        }

        // POST: Dimensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dimension dimension = db.Dimensions.Find(id);
            db.Dimensions.Remove(dimension);
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
