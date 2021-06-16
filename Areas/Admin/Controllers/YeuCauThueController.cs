using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
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
        public ActionResult XoaYeuCauThue(int idYeuCauThue)
        {
            YEUCAUTHUE yeuCauThue = db.YEUCAUTHUEs.Find(idYeuCauThue);
            db.YEUCAUTHUEs.Remove(yeuCauThue);

            db.SaveChanges();

            return RedirectToAction("Index");
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
            thue.TongTien = 0;
            thue.GhiChu = yeuCauThue.YeuCauKhac;
            thue.TinhTrangThue = "Chưa TT";
            thue.IDLoaiXe = yeuCauThue.IDLoaiXe;
            thue.IDHieuXe = yeuCauThue.IDHieuXe;

            db.SOTHUEXEs.Add(thue);
            db.YEUCAUTHUEs.Remove(db.YEUCAUTHUEs.Find(yeuCauThue.IDYeuCau));
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult XacNhanEmail(string emailKhach)
        {
            MailMessage mm = new MailMessage("huy98796543@gmail.com", emailKhach);
            mm.Subject = "Xác nhận yêu cầu thuê xe";
            mm.Body = "Vui lòng click vào đường link này để xác nhận yêu cầu thuê của bạn: ";
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("tai98796543@gmail.com	", "nguyentai4$");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Gửi mail thành công";

            return RedirectToAction("Index");
        }
    }
}