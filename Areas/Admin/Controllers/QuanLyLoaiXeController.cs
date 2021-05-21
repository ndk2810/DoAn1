using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class QuanLyLoaiXeController : Controller
    {
        // GET: Admin/QuanLyLoaiXe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTietLoaiXe()
        {
            return View();
        }
    }
}