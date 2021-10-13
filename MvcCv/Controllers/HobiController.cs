using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
       
        [HttpGet]
        public ActionResult HobiGetir(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(hobi);
        }

        [HttpPost]
        public ActionResult HobiGetir(TblHobilerim t)
        {
            var hobi = repo.Find(x => x.ID == t.ID);
            hobi.Aciklama1 = t.Aciklama1;
            hobi.Aciklama2 = t.Aciklama2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
    }
}