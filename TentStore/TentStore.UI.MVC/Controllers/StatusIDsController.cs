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
    public class StatusIDsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: StatusIDs
        public ActionResult Index()
        {
            return View(db.StatusIDs.ToList());
        }

        // GET: StatusIDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusID statusID = db.StatusIDs.Find(id);
            if (statusID == null)
            {
                return HttpNotFound();
            }
            return View(statusID);
        }

        // GET: StatusIDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID1,Status")] StatusID statusID)
        {
            if (ModelState.IsValid)
            {
                db.StatusIDs.Add(statusID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusID);
        }

        // GET: StatusIDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusID statusID = db.StatusIDs.Find(id);
            if (statusID == null)
            {
                return HttpNotFound();
            }
            return View(statusID);
        }

        // POST: StatusIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID1,Status")] StatusID statusID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusID);
        }

        // GET: StatusIDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusID statusID = db.StatusIDs.Find(id);
            if (statusID == null)
            {
                return HttpNotFound();
            }
            return View(statusID);
        }

        // POST: StatusIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusID statusID = db.StatusIDs.Find(id);
            db.StatusIDs.Remove(statusID);
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
