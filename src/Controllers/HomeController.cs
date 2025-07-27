using MusicViet.DataModel;
using MusicViet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicViet.Controllers
{
    public class HomeController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        public ActionResult Index()
        {
            ViewBag.listSong = (from song in db.Songs
                                join sing in db.Singers on song.SingerId equals sing.SingerId
                                select new ListSong
                                {
                                    Id = song.SongId,
                                    SongTitle = song.SongTitle,
                                    SingerName = sing.SingerName,
                                    Views = song.Views,
                                    PathMusic = song.PathMusic,
                                    SingerId = song.SingerId
                                }).OrderByDescending(x => x.Views).Take(7).ToList();

            ViewBag.listNewSong = (from song in db.Songs
                                   join sing in db.Singers on song.SingerId equals sing.SingerId
                                   select new ListNewSong
                                   {
                                       id = song.SongId,
                                       SongTitle = song.SongTitle,
                                       SingerName = sing.SingerName,
                                       SingerId = sing.SingerId,
                                       DateUpload = song.DateUpload

                                   }).OrderBy(x => x.DateUpload).Take(7).ToList();
            ViewBag.listAblum = db.Albums.ToList();
            ViewBag.listMusician = db.Musicians.ToList();
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(String username, String fullname, String email, String password, String cfpassword)
        {

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(cfpassword)||String.IsNullOrEmpty(fullname))
            {
                ViewBag.Error = "Thông tin không được để trống";
                return View();
            }
            if (!password.Equals(password))
            {
                ViewBag.Error = "Mật khẩu phải trùng nhau";
                return View();
            }
            if (password.Length < 6)
            {
                ViewBag.Error = "Mật khẩu có độ dài lớn hơn 6 ký tự";
                return View();
            }
            var nameuser = db.Accounts.Where(x => x.Username == username).ToList();
            if (nameuser.Count>0)
            {
                ViewBag.Error = "Ten da co trong he thong";
                return View();
            }
            Account account = new Account();
            account.Username = username;
            account.Fullname = fullname;
            account.Email = email;
            account.Password = password;
            account.IsAdmin = 0;
            db.Accounts.Add(account);
            db.SaveChanges();
            ViewBag.TB = "Dang ky thanh cong";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            Session["userId"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;
            Session["userId"] = null;

            var user = db.Accounts.SingleOrDefault(x => x.Username == username && x.Password == password && x.IsAdmin == 0);
            if (user != null)
            {
                Session["userId"] = user.UserId;
                Session["username"] = user.Username;
                Session["fullname"] = user.Fullname;
                Session["avatar"] = user.Avatar;
                return RedirectToAction("/");
            }
            ViewBag.Error = "Đăng nhập không thành công";
            return View();
        }
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(string username, string email)
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["userId"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;
            return RedirectToAction("/");
        }
        public ActionResult AddFavorite(int id)
        {
            if (Session["userId"] != null)
            {
                int userId = Convert.ToInt32(Session["userId"]);
                var check = db.Favorites.Where(x => x.SongId == id).Where(x => x.UserId == userId).ToList();
                if (check.Count==0)
                {
                    Favorite fav = new Favorite();
                    fav.UserId = userId;
                    fav.SongId = id;
                    db.Favorites.Add(fav);
                    db.SaveChanges();
                }

            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}