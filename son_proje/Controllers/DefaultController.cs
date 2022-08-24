using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using son_proje.Models;


namespace son_proje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        hallederiz_dbEntities db = new hallederiz_dbEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult Takim()
        {
            return View();
        }

      
        public ActionResult Afisolustur()
        {

           
            return View();
        }
 [HttpGet]
        public ActionResult Afisler()
        { List<SelectListItem> kategoriler = (from i in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.kateadi,
                                                    Value = i.kateid.ToString()
                                                }).ToList();
            ViewBag.ktg = kategoriler;
            return View();
        }

        [HttpPost]
        public ActionResult Afisler(FormCollection form)
        {
            hallederiz_dbEntities db = new hallederiz_dbEntities();
            Afisler afis = new Afisler();
            afis.Baslik = form["Baslik"].Trim();
            afis.Kategori = form["Kategori"].Length;
            afis.Aciklama = form["Aciklama"].Trim();
            afis.Fotograf = form["Fotograf"].Trim();
            afis.Wplink = form["Wplink"].Trim();
            db.Afisler.Add(afis);
            db.SaveChanges();


            return View();
        }
       
        public ActionResult iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult iletisim(FormCollection form)
        {

            Response.Write("deneme123");
            hallederiz_dbEntities db = new hallederiz_dbEntities();
            uyekayit uye = new uyekayit();
            uye.kullaniciadi = form["kullaniciadi"].Trim();
            uye.sifre = form["sifre"].Trim();
            uye.isim = form["isim"].Trim();
            uye.soyisim = form["soyisim"].Trim();
            uye.email = form["email"].Trim();
            uye.telefon = form["telefon"].Trim();
            uye.il = form["il"].Trim();
            uye.ilce = form["ilce"].Trim();
            db.uyekayit.Add(uye);
            db.SaveChanges();
            return RedirectToAction("index");
        }


            //[HttpPost]
            //public ActionResult iletisim(uyekayit p1)
            //{
            //    db.uyekayit.Add(p1);
            //    db.SaveChanges();
            //    return View();

            //}

            public ActionResult Uyekayit()
        {
            return View();
        }
      

        public ActionResult girisyap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult girisyap(uyekayit uye)
        {
            var uyeid = db.uyekayit.FirstOrDefault(x => x.kullaniciadi == uye.kullaniciadi &&
              x.sifre == uye.sifre);
            if (uyeid != null)
            {
                FormsAuthentication.SetAuthCookie(uye.kullaniciadi, false);
                return View();
            }
            else
            {
                ViewBag.Mesaj = "gerçersiz kullanıcı kullanıcı adı ya da şifre hatalı";

                return View();
            }
        }
    }
}