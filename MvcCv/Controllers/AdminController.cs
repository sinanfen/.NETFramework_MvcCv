using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            p.Durum = true;
            repo.TAdd(p);       
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var admin = repo.Find(x => x.ID == id);
            admin.Durum = false;
            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminGetir(TblAdmin par)
        {
            TblAdmin t = repo.Find(x => x.ID == par.ID);
            t.KullaniciAdi = par.KullaniciAdi;
            t.Sifre = par.Sifre;
            t.Durum = true;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}