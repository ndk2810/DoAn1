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
            return View();
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
            string queryUpdateLuotThue = "UPDATE LOAIXE SET SoLuotThue = " + soLuotThue + " WHERE IDLoaiXe = " + xe.IDLoaiXe + ";";
            ExecuteQuery(queryUpdateTongTien);
            ExecuteQuery(queryUpdateLuotThue);

            return View();
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