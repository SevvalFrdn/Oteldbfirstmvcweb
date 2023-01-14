using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oteldbfirstmvcweb.Models;

namespace Oteldbfirstmvcweb.Controllers
{
    public class MusteriKayitController : Controller
    {
        // GET: MusteriKayit
        OtelEntities db = new OtelEntities();
        public ActionResult Index()
        {
            return View(db.MusteriKayits.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(MusteriKayit ekle)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    db.MusteriKayits.Add(ekle);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult Duzenle(int id)
        {
            using (OtelEntities db = new OtelEntities())
            {
                return View(db.MusteriKayits.Where(x => x.MNo == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Duzenle(int id, MusteriKayit duzenle)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    db.Entry(duzenle).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            using (OtelEntities db = new OtelEntities())
            {
                return View(db.MusteriKayits.Where(x => x.MNo == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(int id, MusteriKayit sil)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    sil = db.MusteriKayits.Where(x => x.MNo == id).FirstOrDefault();
                    db.MusteriKayits.Remove(sil);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}