using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class QuanLyXeController : Controller
    {
        // GET: Admin/QuanLyXe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTietXe()
        {
            return View();
        }
    }
}