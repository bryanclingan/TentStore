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
    public class BrandsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();
        #region Ajax Operations

        #region AjaxDelete
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            
            Brand brand = db.Brands.Find(id);
            
            db.Brands.Remove(brand);
            
            db.SaveChanges();
            
            var message = $"Deleted the following Brand from the database: {brand.BrandName}";
            
            return Json(new
            {
                id = id,
                message = message
            });
        }


        #endregion

        #region AjaxDetails

        [HttpGet]
        public PartialViewResult BrandDetails(int id)
        {
            
            Brand brand = db.Brands.Find(id);
            
            return PartialView(brand);
            


        }
        #endregion       

        #region AjaxCreate
        

        public JsonResult AjaxCreate(Brand brand)
        {
            

            db.Brands.Add(brand);
            db.SaveChanges();
            return Json(brand);
        }


        #endregion

        #region AjaxEdit[Get]
        public PartialViewResult BrandEdit(int id)
        {
            
            Brand brand = db.Brands.Find(id);
            return PartialView(brand);
        }
        #endregion

        #region AjaxEdit[Post]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(Brand brand)
        {
            db.Entry(brand).State = EntityState.Modified;
            db.SaveChanges();
            return Json(brand);
        }

        #endregion

        #endregion
        // GET: Brands
        public ActionResult Index()
        {            
            return View(db.Brands.ToList());
        }

        // GET: Brands/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Brand brand = db.Brands.Find(id);
        //    if (brand == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(brand);
        //}

        //// GET: Brands/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Brands/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BrandID,BrandName")] Brand brand)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Brands.Add(brand);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(brand);
        //}

        //// GET: Brands/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Brand brand = db.Brands.Find(id);
        //    if (brand == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(brand);
        //}

        //// POST: Brands/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BrandID,BrandName")] Brand brand)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(brand).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(brand);
        //}

        //// GET: Brands/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Brand brand = db.Brands.Find(id);
        //    if (brand == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(brand);
        //}

        //// POST: Brands/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Brand brand = db.Brands.Find(id);
        //    db.Brands.Remove(brand);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
