using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class QuanLyLoaiXeController : Controller
    {
        THUEXEEntities db = new THUEXEEntities();
        // GET: Admin/QuanLyLoaiXe
        public ActionResult Index()
        {
            List<LOAIXE> dsLoaiXe = db.LOAIXEs.ToList();
            ViewBag.dsLoaiXe = dsLoaiXe;
            return View();
        }
        public ActionResult ChiTietLoaiXe(int idLoaiXe)
        {
            LOAIXE loaiXe = db.LOAIXEs.Find(idLoaiXe);
            ViewBag.loaiXe = loaiXe;

            return View();
        }
        public ActionResult ThemLoaiXe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemLoaiXe(LOAIXE loaiXe)
        {
            loaiXe.SoLuotThue = 0;
            db.LOAIXEs.Add(loaiXe);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SuaLoaiXe(LOAIXE loaiXe)
        {
            string querySuaXe = "UPDATE LOAIXE SET TenLoaiXe = N'" + loaiXe.TenLoaiXe + "', TomTat = N'" + loaiXe.TomTat + "', GiaTheoNgay = " + loaiXe.GiaTheoNgay + " WHERE IDLoaiXe = " + loaiXe.IDLoaiXe + "; ";
            SoThueXeController.ExecuteQuery(querySuaXe);

            return RedirectToAction("Index");
        }
    }
}