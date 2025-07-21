using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class GenresController : Controller
    {
        //
        // GET: /Genres/
        public ActionResult TheLoai()
        {
            return View();
        }
        public ActionResult TheLoai(string name)
        {
            return View();
        }
	}
}