using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class PhanHoiController : Controller
    {
        // GET: Admin/PhanHoi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTietPhanHoi()
        {
            return View();
        }
    }
}