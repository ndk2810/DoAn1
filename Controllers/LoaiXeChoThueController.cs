using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Controllers
{
    public class LoaiXeChoThueController : Controller
    {
        private THUEXEEntities db = new THUEXEEntities();
        // GET: ThueXe4Cho
        public ActionResult Index(int idHieuXe)
        {
            HIEUXE HieuXe = db.HIEUXEs.Find(idHieuXe);
            ViewBag.HieuXe = HieuXe;
            return View();
        }
    }
}