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
    public class SingerController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: /Admin/Singer/
        public ActionResult Index()
        {
            return View(db.Singers.ToList());
        }

        // GET: /Admin/Singer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singer = db.Singers.Find(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }

        // GET: /Admin/Singer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Singer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SingerName,SingerStory")] Singer singer, HttpPostedFileBase Image)
        {
            try
            {
                if (Image.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Image.FileName);
                    string path = Path.Combine(Server.MapPath("~/ImageUpload/"), filename);
                    Image.SaveAs(path);
                    singer.SingerPic = "~/ImageUpload/" + filename;
                    db.Singers.Add(singer);
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

        // GET: /Admin/Singer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singer = db.Singers.Find(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }

        // POST: /Admin/Singer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SingerId,SingerName,SingerPic,SingerStory")] Singer singer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(singer);
        }

        // GET: /Admin/Singer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singer = db.Singers.Find(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }

        // POST: /Admin/Singer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Singer singer = db.Singers.Find(id);
            db.Singers.Remove(singer);
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
