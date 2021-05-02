using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeThongThueXe.Models;

namespace HeThongThueXe.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult AddOrEdit(int id = 0)
        {
            LIENHE userModel = new LIENHE();
            return View();
        }

        [HttpPost]
        public ActionResult AddorEdit(LIENHE lienheModel)
        {
            using (THUEXEEntities1 dbModel = new THUEXEEntities1())
            {
                dbModel.LIENHEs.Add(lienheModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Gửi phản hồi thành công";
            return View("AddOrEdit", new LIENHE());
        }
    }
}
