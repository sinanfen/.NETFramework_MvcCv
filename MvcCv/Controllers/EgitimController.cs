using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim

        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim egt)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(egt);

            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index"); ;
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x=>x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim egt)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }          
            var egitim = repo.Find(x => x.ID == egt.ID);
            egitim.Baslik = egt.Baslik;
            egitim.AltBaslik1 = egt.AltBaslik1;
            egitim.AltBaslik2 = egt.AltBaslik2;
            egitim.Tarih = egt.Tarih;
            egitim.GenelNotOrtalamasi = egt.GenelNotOrtalamasi;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}