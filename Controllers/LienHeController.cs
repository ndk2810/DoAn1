using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Controllers
{
    public class LienHeController : Controller
    {
        private THUEXEEntities db = new THUEXEEntities();
        // GET: LienHe
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemLienHe(PHANHOI phanHoi)
        {
            phanHoi.DaXuLy = false;
            phanHoi.ThoiGianPhanHoi = DateTime.Now;

            db.PHANHOIs.Add(phanHoi);
            db.SaveChanges();

            return View();
        }
    }
}