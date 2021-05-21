using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using HeThongThueXe.Models;

namespace HeThongThueXe.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HeThongThueXe.Models.gmail model)
        {
            MailMessage mm = new MailMessage("huy98796543@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
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
            return View();
        }
    }
}