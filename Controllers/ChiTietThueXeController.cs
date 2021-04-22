using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

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
    }
}