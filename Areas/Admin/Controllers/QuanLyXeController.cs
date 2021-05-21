using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class QuanLyXeController : Controller
    {
        THUEXEEntities db = new THUEXEEntities();
        // GET: Admin/QuanLyXe
        public ActionResult Index()
        {
            List<XE> dsXe = db.XEs.ToList();
            ViewBag.dsXe = dsXe;
            return View();
        }
        public ActionResult ThemXe()
        {
            ViewBag.dsLoaiXe = db.LOAIXEs.ToList();
            ViewBag.dsHieuXe = db.HIEUXEs.ToList();
            return View();
        }
        public ActionResult ChiTietXe(int idXe)
        {
            XE xe = db.XEs.Find(idXe);
            ViewBag.xe = xe;
            ViewBag.dsLoaiXe = db.LOAIXEs.ToList();
            ViewBag.dsHieuXe = db.HIEUXEs.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult ThemXe(XE xe)
        {
            db.XEs.Add(xe);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SuaXe(XE xe)
        {
            string querySuaXe = "UPDATE XE SET IDLoaiXe = "+xe.IDLoaiXe+", IDHieuXe = "+xe.IDHieuXe+", TenXe = N'"+xe.TenXe+"', BienSoXe = '"+xe.BienSoXe+"' WHERE IDXe = "+xe.IDXe+"; ";
            SoThueXeController.ExecuteQuery(querySuaXe);

            return RedirectToAction("Index");
        }
    }
}