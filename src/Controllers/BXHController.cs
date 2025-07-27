using MusicViet.DataModel;
using MusicViet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class BXHController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        //
        // GET: /BXH/
        public ActionResult BXH()
        {
            ViewBag.GetBHX = (from song in db.Songs
                              join sing in db.Singers on song.SingerId equals sing.SingerId
                              select new ListSong
                              {
                                  SongTitle = song.SongTitle,
                                  SingerName = sing.SingerName,
                                  Views = song.Views,
                                  PathMusic = song.PathMusic,
                                  PathSinger = sing.SingerPic,
                                  SingerId = sing.SingerId,
                                  Id = song.SongId
                              }).OrderByDescending(x => x.Views).ToList();
            return View();
        }
	}
}