using MusicViet.DataModel;
using MusicViet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class DetailArtistController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        //
        // GET: /DetailArtist/
        public ActionResult Detail(int id, string artist)
        {
            
            Artist art = new Artist();
            if (artist == "singer")
            {
                var NameArtist = db.Singers.SingleOrDefault(x=>x.SingerId == id).SingerName;
                var PathArtist = db.Singers.SingleOrDefault(x => x.SingerId == id).SingerPic;
                var story = db.Singers.SingleOrDefault(x => x.SingerId == id).SingerStory;
                var SongOfArtist = db.Songs.Where(x => x.SingerId == id).ToList();
                art.Story = story;
               art.NameArtist = NameArtist;
               art.PathArtist = PathArtist;
               art.listSong = SongOfArtist;
              
            }
            if (artist == "musician")
            {
                var Artist = db.Musicians.SingleOrDefault(x => x.MusicianId == id).MusicianName;
                var PathArtist = db.Musicians.SingleOrDefault(x => x.MusicianId == id).MusicianPic;
                var story = db.Musicians.SingleOrDefault(x => x.MusicianId == id).MusicianStory;
                var SongOfArtist = db.Songs.Where(x => x.MusicianId == id).ToList();
                art.NameArtist = Artist[1].ToString();
                art.PathArtist = Artist[2].ToString();
                art.listSong = SongOfArtist;
                art.Story = story;
            }
            ViewBag.Artist = art;
            return View();
        }
	}
}