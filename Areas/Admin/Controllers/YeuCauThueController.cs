using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class YeuCauThueController : Controller
    {
        // GET: Admin/YeuCauThue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTietYeuCauThue()
        {
            return View();
        }
    }
}