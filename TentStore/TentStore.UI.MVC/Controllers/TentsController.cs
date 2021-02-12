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
    public class TentsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Tents
        public ActionResult Index()
        {
            var tents = db.Tents.Include(t => t.Brand).Include(t => t.Capacity).Include(t => t.Dimension).Include(t => t.Manufacturer).Include(t => t.PoleMaterial).Include(t => t.Season).Include(t => t.StatusID1).Include(t => t.TentMaterial);
            return View(tents.ToList());
        }
        public ActionResult IndexOrgin()
        {
            var tents = db.Tents.Include(t => t.Brand).Include(t => t.Capacity).Include(t => t.Dimension).Include(t => t.Manufacturer).Include(t => t.PoleMaterial).Include(t => t.Season).Include(t => t.StatusID1).Include(t => t.TentMaterial);
            return View(tents.ToList());
        }

        // GET: Tents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tent tent = db.Tents.Find(id);
            if (tent == null)
            {
                return HttpNotFound();
            }
            return View(tent);
        }

        // GET: Tents/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.CapacityID = new SelectList(db.Capacities, "CapacityID", "Capacity1");
            ViewBag.DimensionsID = new SelectList(db.Dimensions, "DimensionID", "DimensionRange");
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName");
            ViewBag.PoleMaterialID = new SelectList(db.PoleMaterials, "PoleMaterialID", "PoleMaterial1");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1");
            ViewBag.StatusID = new SelectList(db.StatusIDs, "StatusID1", "Status");
            ViewBag.TentMaterialID = new SelectList(db.TentMaterials, "TentMaterialID", "TentMaterial1");
            return View();
        }

        // POST: Tents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TentID,Name,BrandID,StatusID,ManufacturerID,DimensionsID,CapacityID,TentMaterialID,PoleMaterialID,Price,SeasonID,Weight,isWaterProof,isDiscontinued,Description,ImageURL")] Tent tent,HttpPostedFileBase imageURL)
        {
            if (ModelState.IsValid)
            {
                #region Image Upload
                string imageName = "Placeholder.png";
                if (imageURL !=null)
                {
                    imageName = imageURL.FileName;

                    string ext = imageName.Substring(imageName.LastIndexOf("."));
                    string[] exts = new string[] { ".jpeg", ".jpg", ".png" };
                    if (exts.Contains(ext.ToLower()))
                    {
                        imageName = Guid.NewGuid() + ext;
                        imageURL.SaveAs(Server.MapPath("~/Content/img/"+imageName));
                    }
                    else
                    {
                        imageName = "Placeholder.png";
                    }
                }
                tent.ImageURL = imageName;
                #endregion
                db.Tents.Add(tent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", tent.BrandID);
            ViewBag.CapacityID = new SelectList(db.Capacities, "CapacityID", "Capacity1", tent.CapacityID);
            ViewBag.DimensionsID = new SelectList(db.Dimensions, "DimensionID", "DimensionRange", tent.DimensionsID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", tent.ManufacturerID);
            ViewBag.PoleMaterialID = new SelectList(db.PoleMaterials, "PoleMaterialID", "PoleMaterial1", tent.PoleMaterialID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", tent.SeasonID);
            ViewBag.StatusID = new SelectList(db.StatusIDs, "StatusID1", "Status", tent.StatusID);
            ViewBag.TentMaterialID = new SelectList(db.TentMaterials, "TentMaterialID", "TentMaterial1", tent.TentMaterialID);
            return View(tent);
        }

        // GET: Tents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tent tent = db.Tents.Find(id);
            if (tent == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", tent.BrandID);
            ViewBag.CapacityID = new SelectList(db.Capacities, "CapacityID", "Capacity1", tent.CapacityID);
            ViewBag.DimensionsID = new SelectList(db.Dimensions, "DimensionID", "DimensionRange", tent.DimensionsID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", tent.ManufacturerID);
            ViewBag.PoleMaterialID = new SelectList(db.PoleMaterials, "PoleMaterialID", "PoleMaterial1", tent.PoleMaterialID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", tent.SeasonID);
            ViewBag.StatusID = new SelectList(db.StatusIDs, "StatusID1", "Status", tent.StatusID);
            ViewBag.TentMaterialID = new SelectList(db.TentMaterials, "TentMaterialID", "TentMaterial1", tent.TentMaterialID);
            return View(tent);
        }

        // POST: Tents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TentID,Name,BrandID,StatusID,ManufacturerID,DimensionsID,CapacityID,TentMaterialID,PoleMaterialID,Price,SeasonID,Weight,isWaterProof,isDiscontinued,Description,ImageURL")] Tent tent,HttpPostedFileBase imageURL)
        {
            if (ModelState.IsValid)
            {
                #region Image Upload
                
                if (imageURL != null)
                {
                    string imageName = imageURL.FileName;

                    string ext = imageName.Substring(imageName.LastIndexOf("."));
                    string[] exts = new string[] { ".jpeg", ".jpg", ".png" };
                    if (exts.Contains(ext.ToLower()))
                    {
                        imageName = Guid.NewGuid() + ext;
                        imageURL.SaveAs(Server.MapPath("~/Content/img/" + imageName));
                        string currentImage = Request.Params["ImageURL"];
                        if (currentImage != "Placeholder.png" && currentImage != null)
                        {
                            System.IO.File.Delete(Server.MapPath("~/Content/img/" + currentImage));
                        }
                        tent.ImageURL = imageName;
                    }
                    
                }
                
                #endregion
                db.Entry(tent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", tent.BrandID);
            ViewBag.CapacityID = new SelectList(db.Capacities, "CapacityID", "Capacity1", tent.CapacityID);
            ViewBag.DimensionsID = new SelectList(db.Dimensions, "DimensionID", "DimensionRange", tent.DimensionsID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "ManufacturerName", tent.ManufacturerID);
            ViewBag.PoleMaterialID = new SelectList(db.PoleMaterials, "PoleMaterialID", "PoleMaterial1", tent.PoleMaterialID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "Season1", tent.SeasonID);
            ViewBag.StatusID = new SelectList(db.StatusIDs, "StatusID1", "Status", tent.StatusID);
            ViewBag.TentMaterialID = new SelectList(db.TentMaterials, "TentMaterialID", "TentMaterial1", tent.TentMaterialID);
            return View(tent);
        }

        // GET: Tents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tent tent = db.Tents.Find(id);
            if (tent == null)
            {
                return HttpNotFound();
            }
            return View(tent);
        }

        // POST: Tents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tent tent = db.Tents.Find(id);
            db.Tents.Remove(tent);
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
