using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbCvEntities1 db = new DbCvEntities1();
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda tblHakkimda)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = tblHakkimda.Ad;
            t.Soyad = tblHakkimda.Soyad;
            t.Adres = tblHakkimda.Adres;
            t.Mail = tblHakkimda.Mail;
            t.Telefon = tblHakkimda.Telefon;
            t.Aciklama = tblHakkimda.Aciklama;
            t.Aciklama2 = tblHakkimda.Aciklama2;
            t.Adres = tblHakkimda.Adres;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}