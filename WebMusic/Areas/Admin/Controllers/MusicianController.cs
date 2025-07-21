using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicViet.DataModel;
using System.IO;

namespace MusicViet.Areas.Admin.Controllers
{
    public class MusicianController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: /Admin/Musician/
        public ActionResult Index()
        {
            return View(db.Musicians.ToList());
        }

        // GET: /Admin/Musician/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // GET: /Admin/Musician/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Musician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusicianName,MusicianStory")]Musician musician, HttpPostedFileBase upload)
        {
            try
            {
                if (upload.ContentLength > 0)
                {
                    string filename = Path.GetFileName(upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/ImageUpload/"), filename);
                    upload.SaveAs(path);
                    musician.MusicianPic = "~/ImageUpload/" + filename;
                    db.Musicians.Add(musician);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                   
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Loi upload File";
                return View();
            }
            return View();
        }

        // GET: /Admin/Musician/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // POST: /Admin/Musician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MusicianId,MusicianName,MusicianPic,MusicianStory")] Musician musician)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musician).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musician);
        }

        // GET: /Admin/Musician/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = db.Musicians.Find(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        // POST: /Admin/Musician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musician musician = db.Musicians.Find(id);
            db.Musicians.Remove(musician);
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
