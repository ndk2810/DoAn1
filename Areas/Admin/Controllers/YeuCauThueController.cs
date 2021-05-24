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
            ViewBag.yeuCauThueLoaiXe = db.LOAIXEs.Find(yeuCauThue.IDLoaiXe);
            ViewBag.yeuCauThueHieuXe = db.HIEUXEs.Find(yeuCauThue.IDHieuXe);
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
        [HttpPost]
        public ActionResult ThemVaoSoThue(YEUCAUTHUE yeuCauThue)
        {
            KHACH khach = new KHACH();
            khach.TenKhach = yeuCauThue.TenKhach;
            khach.SDT = yeuCauThue.SDT;
            khach.DiaChi = yeuCauThue.DiaChi;
            khach.Email = yeuCauThue.Email;

            db.KHACHes.Add(khach);
            db.SaveChanges();

            KHACH getKhach = db.KHACHes.Where(m => m.SDT == yeuCauThue.SDT).FirstOrDefault();

            SOTHUEXE thue = new SOTHUEXE();
            thue.IDKhach = getKhach.IDKhach;
            thue.NgayTao = yeuCauThue.NgayTao;
            thue.ThoiGianThue = yeuCauThue.ThoiGianThue;
            thue.ThoiGianTra = yeuCauThue.ThoiGianTra;
            thue.GhiChu = yeuCauThue.YeuCauKhac;
            thue.TinhTrangThue = "Chưa TT";

            db.SOTHUEXEs.Add(thue);
            db.SaveChanges();

            return View();
        }
    }
}