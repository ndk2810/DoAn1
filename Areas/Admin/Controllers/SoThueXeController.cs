using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using HeThongThueXe.Models;
using System.Web.Configuration;
using System.Data.Entity.Core.EntityClient;

namespace HeThongThueXe.Areas.Admin.Controllers
{
    public class SoThueXeController : Controller
    {
        THUEXEEntities db = new THUEXEEntities();
        // GET: Admin/SoThueXe
        public ActionResult Index()
        {
            List<SOTHUEXE> dsThue = db.SOTHUEXEs.ToList();
            ViewBag.dsThue = dsThue;
            return View();
        }
        public ActionResult ChiTietSoThueXe(int idThue)
        {
            SOTHUEXE thue = db.SOTHUEXEs.Find(idThue);

            ViewBag.thue = thue;
            ViewBag.khach = db.KHACHes.Find(thue.IDKhach);
            return View();
        }
        public ActionResult XoaThue(int idThue)
        {
            var lstDeleteThueCT = from thueCT in db.THUECTs where thueCT.IDThue == idThue select thueCT;

            foreach(var thueCT in lstDeleteThueCT)
            {
                db.THUECTs.Remove(thueCT);
            }
            db.SaveChanges();

            db.SOTHUEXEs.Remove(db.SOTHUEXEs.Find(idThue));
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult ThueChiTiet(int idThue)
        {
            ViewBag.thueCT = db.THUECTs.Where(m => m.IDThue == idThue);
            SOTHUEXE thue = db.SOTHUEXEs.Find(idThue);

            ViewBag.idThue = idThue;
            ViewBag.dsXe = db.XEs.ToList();
            ViewBag.dsLoaiXe = db.LOAIXEs.ToList();
            ViewBag.dsHieuXe = db.HIEUXEs.ToList();

            return View();
        }
        public ActionResult FormThanhToan(int idThue)
        {
            SOTHUEXE thue = db.SOTHUEXEs.Find(idThue);

            ViewBag.khach = db.KHACHes.Find(thue.IDKhach);
            ViewBag.thue = thue;
            return View();
        }
        public ActionResult HopDong(int idThue)
        {
            SOTHUEXE thue = db.SOTHUEXEs.Find(idThue);

            ViewBag.khach = db.KHACHes.Find(thue.IDKhach);
            ViewBag.thueCT = db.THUECTs.Where(m => m.IDThue == idThue);
            ViewBag.thue = thue;
            return View();
        }
        [HttpPost]
        public ActionResult ThanhToan(SOTHUEXE thue)
        {
            HOADON hoaDon = new HOADON();

            hoaDon.IDThue = thue.IDThue;
            hoaDon.IDKhach = thue.IDKhach;
            hoaDon.NgayTao = thue.NgayTao;
            hoaDon.ThoiGianThue = thue.ThoiGianThue;
            hoaDon.ThoiGianTra = thue.ThoiGianTra;
            hoaDon.TongTien = thue.TongTien;
            hoaDon.TongGiam = thue.TongGiam;
            hoaDon.GhiChu = thue.GhiChu;

            db.HOADONs.Add(hoaDon);
            db.SaveChanges();

            var lstDeleteThueCT = from thueCT in db.THUECTs where thueCT.IDThue == thue.IDThue select thueCT;

            foreach (var thueCT in lstDeleteThueCT)
            {
                HOADONCT hdCT = new HOADONCT();

                hdCT.IDHoaDon = hoaDon.IDHoaDon;
                hdCT.IDXe = thueCT.IDXe;
                hdCT.Gia = thueCT.Gia;
                db.HOADONCTs.Add(hdCT);

                db.THUECTs.Remove(thueCT);
            }
            db.SaveChanges();

            db.SOTHUEXEs.Remove(db.SOTHUEXEs.Find(thue.IDThue));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void XoaXeKhoiHD(int idThue, int idThueCT)
        {
            db.THUECTs.Remove(db.THUECTs.Find(idThueCT));
            db.SaveChanges();
        }
        public List<XE> ReloadListXe(int idLoaiXe, int idHieuXe)
        {
            List<XE> lstXE = db.XEs.ToList();

            return lstXE;
        }
        [HttpPost]
        public ActionResult ThemXeVaoHD(THUECT thueCT)
        {
            XE xe = db.XEs.Find(thueCT.IDXe);
            LOAIXE loaiXe = db.LOAIXEs.Find(xe.IDLoaiXe);
            SOTHUEXE thue = db.SOTHUEXEs.Find(thueCT.IDThue);

            string soNgayThue = ((TimeSpan)(thue.ThoiGianTra - thue.ThoiGianThue)).TotalDays.ToString();
            thueCT.Gia = loaiXe.GiaTheoNgay * decimal.Parse(soNgayThue);

            int? soLuotThue = loaiXe.SoLuotThue++;

            db.THUECTs.Add(thueCT);
            db.SaveChanges();

            string queryUpdateTongTien = "UPDATE SOTHUEXE SET TongTien = (SELECT SUM(Gia) as TongHoaDon FROM THUECT WHERE IDThue = " + thueCT.IDThue + ") WHERE IDThue = " + thueCT.IDThue + ";";
            string queryUpdateLuotThueLoaiXe = "UPDATE LOAIXE SET SoLuotThue = " + soLuotThue + " WHERE IDLoaiXe = " + xe.IDLoaiXe + ";";
            string queryUpdateLuotThueHieuXe = "UPDATE HIEUXE SET SoLuotThue = " + soLuotThue + " WHERE IDHieuXe = " + xe.IDHieuXe + ";";
            ExecuteQuery(queryUpdateTongTien);
            ExecuteQuery(queryUpdateLuotThueLoaiXe);
            ExecuteQuery(queryUpdateLuotThueHieuXe);

            return RedirectToAction("Index");
        }
        public static void ExecuteQuery(string queryString)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["THUEXEEntities"].ConnectionString;
            string providerConnectionString = new EntityConnectionStringBuilder(connectionString).ProviderConnectionString;
            using (SqlConnection connection = new SqlConnection(providerConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}