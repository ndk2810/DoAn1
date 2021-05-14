using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class SoThueXeController : Controller
    {
        // GET: Admin/SoThueXe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTietSoThueXe()
        {
            return View();
        }
    }
}