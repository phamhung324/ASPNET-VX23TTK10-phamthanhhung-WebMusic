using MusicViet.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class SearchController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        //
        // GET: /Search/
        public ActionResult Search(String strSearch)
        {

            if (String.IsNullOrEmpty(strSearch))
            {
                return Redirect("/");
            }
            else
            {
                ViewBag.Song = (from s in db.Songs select s).Where(x => x.SongTitle.Contains(strSearch)).ToList();
            }
            return View();
        }
	}
}