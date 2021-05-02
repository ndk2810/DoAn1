using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Controllers
{
    public class HomeController : Controller
    {
        private THUEXEEntities1 db = new THUEXEEntities1();
        public ActionResult Index()
        {
            List<LOAIXE> dsLoaiXe = db.LOAIXEs.ToList();
            List<HIEUXE> dsHieuXe = db.HIEUXEs.ToList();
            ViewBag.dsLoaiXe = dsLoaiXe;
            ViewBag.dsHieuXe = dsHieuXe;
            return View();
        }
    }
}