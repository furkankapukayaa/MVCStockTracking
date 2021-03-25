using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokMVC.Models.Entity;

namespace StokMVC.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        dbStokMVCEntities db = new dbStokMVCEntities();
        public ActionResult Index()
        {
            //var degerler = from d in db.TBLMUSTERILER select d;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            //}
            //return View(degerler.ToList());
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteriler = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mstr = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mstr);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var ktgr = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            ktgr.MUSTERIAD = p1.MUSTERIAD;
            ktgr.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}