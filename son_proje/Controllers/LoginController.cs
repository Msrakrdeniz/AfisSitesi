using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace son_proje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult girisyap()
        {
            return View();
        }
    }
}