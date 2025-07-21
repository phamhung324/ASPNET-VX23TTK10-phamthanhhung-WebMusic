using MusicViet.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        MusicDbContext db = new MusicDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;
            Session["userId"] = null;
            string passwordMD5 = BcryptUser.EncryptMd5(username + password);
            var user = db.Accounts.SingleOrDefault(x => x.Username == username && x.Password == password && x.IsAdmin == 1);
            if (user != null)
            {
                Session["userid"] = user.UserId;
                Session["username"] = user.Username;
                Session["fullname"] = user.Fullname;
                Session["avatar"] = user.Avatar;
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Đăng nhập sai hoặc bạn có quyền này";
            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;
            return View("Login");
        }
    }
}