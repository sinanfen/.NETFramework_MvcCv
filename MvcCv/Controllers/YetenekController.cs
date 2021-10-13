using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek    

        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();

        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);         
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim t)
        {
            var deger = repo.Find(x => x.ID == t.ID);
            deger.Yetenek = t.Yetenek;
            deger.Oran = t.Oran;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}