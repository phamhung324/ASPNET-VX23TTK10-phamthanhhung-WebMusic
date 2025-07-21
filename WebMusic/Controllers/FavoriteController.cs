using MusicViet.DataModel;
using MusicViet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class FavoriteController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        //
        // GET: /Favorite/
        public ActionResult Favorite()
        {
            if (Session["userId"]!=null)
            {
                var userid = Convert.ToInt32(Session["userId"]);
                ViewBag.MyFavorite = (from ac in db.Accounts
                                      join fav in db.Favorites on ac.UserId equals fav.UserId
                                      join song in db.Songs on fav.SongId equals song.SongId
                                      where ac.UserId == userid
                                      select new ListSong
                                      {
                                      
                                          SongTitle = song.SongTitle,
                                          Views = song.Views,
                                          PathMusic = song.PathMusic,
                                          Id = song.SongId
                                      }).ToList();
                return View();
            }
            return RedirectToAction("/");   
        }
	}
}