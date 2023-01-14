using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oteldbfirstmvcweb.Models;
namespace Oteldbfirstmvcweb.Controllers
{
    public class ServislerController : Controller
    {
        // GET: Servisler
        OtelEntities db = new OtelEntities();
        public ActionResult Index()
        {
            return View(db.Servislers.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Yeni(Servisler ekle)
        {
            try
            {
                using (OtelEntities db = new OtelEntities()) 
                {
                    db.Servislers.Add(ekle);   
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
                return View(db.Servislers.Where(x => x.ServisNo == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Duzenle(int id, Servisler duzenle)
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
                return View(db.Servislers.Where(x => x.ServisNo == id).FirstOrDefault());
            }

        }
        [HttpPost]
        public ActionResult Delete(int id, Servisler sil)
        {
            try
            {
                using (OtelEntities db = new OtelEntities())
                {
                    sil = db.Servislers.Where(x => x.ServisNo == id).FirstOrDefault();
                    db.Servislers.Remove(sil);
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