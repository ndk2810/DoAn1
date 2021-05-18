using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

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
    }
}