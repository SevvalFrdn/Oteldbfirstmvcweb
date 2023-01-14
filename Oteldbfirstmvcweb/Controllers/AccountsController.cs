using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // bunları ekledik
using Oteldbfirstmvcweb.Models;
using Microsoft.SqlServer.Server;
namespace Oteldbfirstmvcweb.Controllers
{
    [AllowAnonymous] //bütün sayfalardan buraya gelmesini sağlıyorum.
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (OtelEntities db = new OtelEntities()) //ramı temizler using
            {
                var result = db.UserMasters.Where(x => x.UserId == user.Username && x.Password1 == user.Password1);
                if (result.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Admin"); //kalıcı olmasını istemediğimden false yaptık.

                }
                else
                {
                    TempData["msg"] = "hatalı"; //controller arasında 
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut(); //form oturum sayfalarını kapat
            return View("Login");
        }
    }
}