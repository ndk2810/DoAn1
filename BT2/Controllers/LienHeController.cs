using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BT2.Models;

namespace BT2.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult AddorEdit(int id=0)
        {
            LienHe userModel = new LienHe();
            return View();
        }
        [HttpPost]
        public ActionResult AddorEdit(LienHe lienheModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                dbModel.LienHes.Add(lienheModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Gửi phản hồi thành công";
            return View("AddOrEdit", new LienHe());
        }
    }
}