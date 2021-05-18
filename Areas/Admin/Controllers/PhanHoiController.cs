using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class PhanHoiController : Controller
    {
        THUEXEEntities db = new THUEXEEntities();
        // GET: Admin/PhanHoi
        public ActionResult Index()
        {
            List<PHANHOI> dsPhanHoi = db.PHANHOIs.ToList();
            ViewBag.dsPhanHoi = dsPhanHoi;
            return View();
        }
        public ActionResult ChiTietPhanHoi(int idPhanHoi)
        {
            PHANHOI phanHoi = db.PHANHOIs.Find(idPhanHoi);
            ViewBag.phanHoi = phanHoi;
            return View();
        }
    }
}