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
    public class MusicGenresController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: /Admin/MusicGenres/
        public ActionResult Index()
        {
            return View(db.MusicGenres.ToList());
        }

        // GET: /Admin/MusicGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicGenres musicgenres = db.MusicGenres.Find(id);
            if (musicgenres == null)
            {
                return HttpNotFound();
            }
            return View(musicgenres);
        }

        // GET: /Admin/MusicGenres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/MusicGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MusicGenresName,DesMusicGenres")] MusicGenres musicgenres, HttpPostedFileBase Image)
        {


            try
            {
                if (Image.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(Server.MapPath("~/ImageUpload/"), filename);
                    Image.SaveAs(path);
                    musicgenres.MusicGenresPic = "~/ImageUpload/" + filename;
                    db.MusicGenres.Add(musicgenres);
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

        // GET: /Admin/MusicGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicGenres musicgenres = db.MusicGenres.Find(id);
            if (musicgenres == null)
            {
                return HttpNotFound();
            }
            return View(musicgenres);
        }

        // POST: /Admin/MusicGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MusicGenresId,MusicGenresName,MusicGenresPic,DesMusicGenres")] MusicGenres musicgenres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musicgenres).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musicgenres);
        }

        // GET: /Admin/MusicGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicGenres musicgenres = db.MusicGenres.Find(id);
            if (musicgenres == null)
            {
                return HttpNotFound();
            }
            return View(musicgenres);
        }

        // POST: /Admin/MusicGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MusicGenres musicgenres = db.MusicGenres.Find(id);
            db.MusicGenres.Remove(musicgenres);
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
