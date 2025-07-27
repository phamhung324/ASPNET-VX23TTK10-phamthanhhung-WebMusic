using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class NotFoundController : Controller
    {
        //
        // GET: /Error/
        public ActionResult NotFound()
        {
            return View();
        }
	}
}