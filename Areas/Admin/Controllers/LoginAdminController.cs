using HeThongThueXe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/LoginAdmin
        THUEXEEntities db = new THUEXEEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User _user)
        {
            var check = db.Users.Where(s => s.Username.Equals(_user.Username) && s.Password.Equals(_user.Password)).FirstOrDefault(); 
            if(check == null)
            {
                _user.LoginMessageError = "Ten dang nhap hoac mat khau khong dung";
                return View("Index");
            }
            else
            {
                Session["Id"] = _user.Id;
                Session["Username"] = _user.Username;
                return RedirectToAction("Index", "YeuCauThue");
            }
            
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginAdmin");
        }
    }
}