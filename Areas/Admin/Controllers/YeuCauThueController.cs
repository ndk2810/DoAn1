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
        public ActionResult ChiTietYeuCauThue(int idYeuCauThue)
        {
            YEUCAUTHUE yeuCauThue = db.YEUCAUTHUEs.Find(idYeuCauThue);
            yeuCauThue.TrangThai = true;
            ViewBag.yeuCauThueLoaiXe = db.LOAIXEs.Find(yeuCauThue.IDHieuXe);
            ViewBag.yeuCauThueHieuXe = db.HIEUXEs.Find(yeuCauThue.IDLoaiXe);
            ViewBag.yeuCauThue = yeuCauThue;

            db.SaveChanges();
            return View();
        }
        public string XoaYeuCauThue(int idYeuCauThue)
        {
            YEUCAUTHUE yeuCauThue = db.YEUCAUTHUEs.Find(idYeuCauThue);
            db.YEUCAUTHUEs.Remove(yeuCauThue);

            db.SaveChanges();

            return "Xoá yêu cầu thuê thành công";
        }
    }
}