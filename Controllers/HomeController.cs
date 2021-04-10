using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Controllers
{
    public class HomeController : Controller
    {
        List<LoaiXe> listLoaiXe = new List<LoaiXe>();
        public ActionResult Index()
        {
            listLoaiXe.Add(new LoaiXe() { tenLoaiXe = "Xe 4 chỗ", linkImgLoaiXe = "https://oky.vn/wp-content/uploads/2018/10/cho-thue-xe-toyota-vios.jpg" });
            listLoaiXe.Add(new LoaiXe() { tenLoaiXe = "Xe 7 chỗ", linkImgLoaiXe = "https://storage.googleapis.com/f1-cms/2019/07/ba0e57dd-20190731_034037.jpg" });
            listLoaiXe.Add(new LoaiXe() { tenLoaiXe = "Xe 16 chỗ", linkImgLoaiXe = "https://nhatranghottour.com/wp-content/uploads/2019/01/xe-16-cho-can-tho.jpg" });
            listLoaiXe.Add(new LoaiXe() { tenLoaiXe = "Xe 29 chỗ", linkImgLoaiXe = "https://kenhxehyundai.vn/wp-content/uploads/2014/05/county-do-thanh-2016.jpg" });
            listLoaiXe.Add(new LoaiXe() { tenLoaiXe = "Xe 45 chỗ", linkImgLoaiXe = "https://storage.googleapis.com/f1-cms/2019/07/ba0e57dd-20190731_034037.jpg" });
            listLoaiXe.Add(new LoaiXe() { tenLoaiXe = "Xe đám cưới", linkImgLoaiXe = "https://chothuexegiare.com.vn/wp-content/uploads/2019/03/cho-thue-xe-35-cho-isuzu-samco-thaco-truong-hai-gia-re-tai-ha-noi-1.jpg" });
            ViewBag.listXe = listLoaiXe;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}