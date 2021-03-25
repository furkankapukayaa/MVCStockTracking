using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokMVC.Models.Entity;

namespace StokMVC.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        dbStokMVCEntities db = new dbStokMVCEntities();
        public ActionResult Index()

        {
            List<SelectListItem> degerler = (from i in db.TBLURUNLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.URUNAD,
                                                 Value = i.URUNID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            List<SelectListItem> degerler2 = (from i in db.TBLMUSTERILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MUSTERIAD+" "+i.MUSTERISOYAD,
                                                 Value = i.MUSTERIID.ToString()
                                             }).ToList();
            ViewBag.dgr2 = degerler2;
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p1)
        {
          //  var musteri = db.TBLMUSTERILER.Where(m => m.MUSTERIID == p1.TBLMUSTERILER.MUSTERIID).FirstOrDefault();
          //  p1.TBLMUSTERILER = musteri;
         //  var urun = db.TBLURUNLER.Where(m => m.URUNID == p1.TBLURUNLER.URUNID).FirstOrDefault();
         //   p1.TBLURUNLER = urun;
            db.TBLSATISLAR.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}