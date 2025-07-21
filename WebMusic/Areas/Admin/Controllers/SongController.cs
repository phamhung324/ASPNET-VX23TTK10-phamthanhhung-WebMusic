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
    public class SongController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: /Admin/Song/
        public ActionResult Index()
        {
            var songs = db.Songs.Include(s => s.Album).Include(s => s.MusicGenres).Include(s => s.Musicians).Include(s => s.Singer);
            return View(songs.ToList());
        }

        // GET: /Admin/Song/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: /Admin/Song/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumTitle");
            ViewBag.MusicGenresId = new SelectList(db.MusicGenres, "MusicGenresId", "MusicGenresName");
            ViewBag.MusicianId = new SelectList(db.Musicians, "MusicianId", "MusicianName");
            ViewBag.SingerId = new SelectList(db.Singers, "SingerId", "SingerName");
            return View();
        }

        // POST: /Admin/Song/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongTitle,MusicianId,SingerId,AlbumId,MusicGenresId,PathMusic")] Song song, HttpPostedFileBase Music)
        {
            try
            {
                if (Music.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Music.FileName);
                    string path = Path.Combine(Server.MapPath("~/UploadMusic/"), filename);
                    Music.SaveAs(path);
                    song.PathMusic = "~/UploadMusic/" + filename;
                    song.WhoUp = "Admin";
                    song.Views = 0;
                    song.DateUpload = DateTime.Today.Date;
                    db.Songs.Add(song);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Loi upload File";
                return View();
            }


            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumTitle", song.AlbumId);
            ViewBag.MusicGenresId = new SelectList(db.MusicGenres, "MusicGenresId", "MusicGenresName", song.MusicGenresId);
            ViewBag.MusicianId = new SelectList(db.Musicians, "MusicianId", "MusicianName", song.MusicianId);
            ViewBag.SingerId = new SelectList(db.Singers, "SingerId", "SingerName", song.SingerId);
            return View(song);
        }

        // GET: /Admin/Song/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumTitle", song.AlbumId);
            ViewBag.MusicGenresId = new SelectList(db.MusicGenres, "MusicGenresId", "MusicGenresName", song.MusicGenresId);
            ViewBag.MusicianId = new SelectList(db.Musicians, "MusicianId", "MusicianName", song.MusicianId);
            ViewBag.SingerId = new SelectList(db.Singers, "SingerId", "SingerName", song.SingerId);
            return View(song);
        }

        // POST: /Admin/Song/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongId,SongTitle,MusicianId,SingerId,AlbumId,MusicGenresId,PathMusic,DateUpload,Views,WhoUp")] Song song)
        {
            if (ModelState.IsValid)
            {
                db.Entry(song).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "AlbumTitle", song.AlbumId);
            ViewBag.MusicGenresId = new SelectList(db.MusicGenres, "MusicGenresId", "MusicGenresName", song.MusicGenresId);
            ViewBag.MusicianId = new SelectList(db.Musicians, "MusicianId", "MusicianName", song.MusicianId);
            ViewBag.SingerId = new SelectList(db.Singers, "SingerId", "SingerName", song.SingerId);
            return View(song);
        }

        // GET: /Admin/Song/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: /Admin/Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Song song = db.Songs.Find(id);
            db.Songs.Remove(song);
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
