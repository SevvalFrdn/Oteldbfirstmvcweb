using Oteldbfirstmvcweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oteldbfirstmvcweb.Controllers
{
    public class MusteriHesapController : Controller
    {
        // GET: MusteriHesap
        OtelEntities db = new OtelEntities();
        public ActionResult Index()
        {
            return View(db.MusteriHesabis.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(MusteriHesabi ekle)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    db.MusteriHesabis.Add(ekle);
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
                return View(db.MusteriHesabis.Where(x => x.İslemNo == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Duzenle(int id, MusteriHesabi duzenle)
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
                return View(db.MusteriHesabis.Where(x => x.İslemNo == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(int id, MusteriHesabi sil)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    sil = db.MusteriHesabis.Where(x => x.İslemNo == id).FirstOrDefault();
                    db.MusteriHesabis.Remove(sil);
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