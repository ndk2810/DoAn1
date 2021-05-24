using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class QuanLyHieuXeController : Controller
    {
        THUEXEEntities db = new THUEXEEntities();
        // GET: Admin/QuanLyHieuXe
        public ActionResult Index()
        {
            List<HIEUXE> dsHieuXe = db.HIEUXEs.ToList();
            ViewBag.dsHieuXe = dsHieuXe;
            return View();
        }
        public ActionResult ChiTietHieuXe(int idHieuXe)
        {
            HIEUXE hieuXe = db.HIEUXEs.Find(idHieuXe);
            ViewBag.hieuXe = hieuXe;

            return View();
        }
    }
}