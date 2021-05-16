using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class YeuCauThueController : Controller
    {
        THUEXEEntities db = new THUEXEEntities();
        // GET: Admin/YeuCauThue
        public ActionResult Index()
        {
            List<YEUCAUTHUE> dsYeuCauThue = db.YEUCAUTHUEs.ToList();
            ViewBag.dsYeuCauThue = dsYeuCauThue;
            return View();
        }
        public ActionResult ChiTietYeuCauThue()
        {
            return View();
        }
    }
}