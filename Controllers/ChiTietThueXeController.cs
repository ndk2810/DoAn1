using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;
using System.ComponentModel.DataAnnotations;

namespace HeThongThueXe.Controllers
{
    public class ChiTietThueXeController : Controller
    {
        private THUEXEEntities db = new THUEXEEntities();

        // GET: ThueXe4Cho
        public ActionResult Index(int idLoaiXe)
        {
            LOAIXE LoaiXe = db.LOAIXEs.Find(idLoaiXe);
            ViewBag.LoaiXe = LoaiXe;
            return View();
        }

        [HttpPost]
        public ActionResult ThemYeuCau(YeuCauThueCLASS yeuCauThue)
        {
            YEUCAUTHUE newYeuCauThue = new YEUCAUTHUE();

            newYeuCauThue.TenKhach = yeuCauThue.TenKhach;
            newYeuCauThue.DiaChi = yeuCauThue.DiaChi;
            newYeuCauThue.Email = yeuCauThue.Email;
            newYeuCauThue.SDT = yeuCauThue.DienThoai;
            newYeuCauThue.IDHieuXe = yeuCauThue.IDHieuXe;
            newYeuCauThue.IDLoaiXe = yeuCauThue.IDLoaiXe;
            newYeuCauThue.NgayTao = DateTime.Now;
            newYeuCauThue.ThoiGianThue = yeuCauThue.ThoiGianThue;
            newYeuCauThue.ThoiGianTra = yeuCauThue.ThoiGianTra;
            newYeuCauThue.YeuCauKhac = yeuCauThue.YeuCauKhac;
            newYeuCauThue.TrangThai = false;

            db.YEUCAUTHUEs.Add(newYeuCauThue);
            db.SaveChanges();

            ViewBag.YCT = yeuCauThue;

            return View();
        }
    }
}