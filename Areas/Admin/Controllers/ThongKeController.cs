using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        THUEXEEntities db = new THUEXEEntities();
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            LOAIXE loaiXeThueNN = db.LOAIXEs.OrderByDescending(m => m.SoLuotThue).First();

            DateTime today = DateTime.Now;

            var listHoaDon = db.HOADONs.Where(m => m.NgayTao.Value.Year == today.Year && m.NgayTao.Value.Month == today.Month);
            int countListHoaDon = listHoaDon.Count();

            var listKhach = db.KHACHes.ToList();
            int countListKhach = listKhach.Count();

            var sumHoaDon = db.HOADONs.Where(m => m.NgayTao.Value.Year == today.Year && m.NgayTao.Value.Month == today.Month);
            var sum = sumHoaDon.Sum(m => m.TongTien);

            ViewBag.countListHoaDon = countListHoaDon;
            ViewBag.countListKhach = countListKhach;
            ViewBag.loaiXeThueNN = loaiXeThueNN;
            ViewBag.sum = sum;

            return View();
        }
        public JsonResult customThongKe(int thang, int nam)
        {
            GetThongKe result = new GetThongKe();
            var listHoaDon = db.HOADONs.Where(m => m.NgayTao.Value.Year == nam && m.NgayTao.Value.Month == thang);
            result.countListHoaDon = listHoaDon.Count();

            var sumHoaDon = db.HOADONs.Where(m => m.NgayTao.Value.Year == nam && m.NgayTao.Value.Month == thang);
            result.sum = sumHoaDon.Sum(m => m.TongTien);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}