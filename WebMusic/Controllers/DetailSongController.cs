using MusicViet.DataModel;
using MusicViet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class DetailSongController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        //
        // GET: /DetailSong/
        public ActionResult Detail(int id)
        {
            Song song1 = new Song();
            // Lay bai hat tu cdsl
            song1 = db.Songs.Where(s => s.SongId == id).FirstOrDefault<Song>();
            // Lay so luot view cho bai hat va tang view len 1
            var views = (from song in db.Songs
                         join sing in db.Singers on song.SingerId equals sing.SingerId
                         select new ListSong
                         {
                             Id = song.SongId,
                             SongTitle = song.SongTitle,
                             SingerName = sing.SingerName,
                             Views = song.Views,
                             PathMusic = song.PathMusic
                         }).SingleOrDefault(x => x.Id == id).Views;
            
            song1.Views = views + 1;

            ViewBag.SongTitle = db.Songs.SingleOrDefault(x => x.SongId == id).SongTitle;
            ViewBag.PathMusic = db.Songs.SingleOrDefault(x => x.SongId == id).PathMusic;
            ViewBag.SingerName = (from song in db.Songs
                                  join sing in db.Singers on song.SingerId equals sing.SingerId
                                  select new ListSong
                                  {
                                      Id = song.SongId,
                                      SongTitle = song.SongTitle,
                                      SingerName = sing.SingerName,
                                      Views = song.Views,
                                      PathMusic = song.PathMusic
                                  }).SingleOrDefault(x => x.Id == id).SingerName;
            // Cap nhat luot view vao CSDL
            ViewBag.Views = views + 1;

            db.Entry(song1).State = EntityState.Modified;

            db.SaveChanges();


            return View();
        }
    }
}