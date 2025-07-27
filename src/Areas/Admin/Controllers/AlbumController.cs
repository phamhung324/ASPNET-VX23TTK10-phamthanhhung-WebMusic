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
    public class AlbumController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: /Admin/Album/
        public ActionResult Index()
        {
            return View(db.Albums.ToList());
        }

        // GET: /Admin/Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: /Admin/Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,AlbumTitle,AblumPhoto,DesAlbum")] Album album, HttpPostedFileBase Image)
        {
            try
            {
                if (Image.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(Server.MapPath("~/ImageUpload/"), filename);
                    Image.SaveAs(path);
                    album.AblumPhoto = "~/ImageUpload/" + filename;
                    db.Albums.Add(album);
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

        // GET: /Admin/Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: /Admin/Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,AlbumTitle,AblumPhoto,DesAlbum")] Album album)
        {


            if (ModelState.IsValid)
            {
                db.Entry(album).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: /Admin/Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: /Admin/Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
