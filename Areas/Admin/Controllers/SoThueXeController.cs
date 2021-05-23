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

            ViewBag.idThue = idThue;
            ViewBag.dsXe = db.XEs.ToList();
            ViewBag.dsLoaiXe = db.LOAIXEs.ToList();
            ViewBag.dsHieuXe = db.HIEUXEs.ToList();

            return View();
        }
        public void XoaXeKhoiHD(int idThue, int idThueCT)
        {
            db.THUECTs.Remove(db.THUECTs.Find(idThueCT));
            db.SaveChanges();
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