using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using w16_1.Models;

namespace w16_1.Controllers
{     [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private Model1 db = new Model1();
   
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //Create
        public ActionResult CreateProdotti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProdotti(Pizze p, HttpPostedFileBase Foto)
        {
            if(Foto.ContentLength > 0)
            {
                string nameFile=Foto.FileName;
                string path = Path.Combine(Server.MapPath("~/Content/Img"), nameFile);
                Foto.SaveAs(path);
            }
            p.Foto = Foto.FileName;
            Pizze ordini = db.Pizze.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //Edit
        public ActionResult EditPizza(int id)
        {
            Pizze p = db.Pizze.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult EditPizza(Pizze p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete
        public ActionResult DeletePizza(int id)
        {
            Pizze p = db.Pizze.Find(id);
            db.Pizze.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Select
        public ActionResult DettagliPizza(int Id)
        {
            if (Id == 0)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Pizze p = db.Pizze.Find(Id);
            return View(p);
        }
        [AllowAnonymous]
        public ActionResult SelectProdotti()
        {
            return View(db.Pizze.ToList());
        }


    }
}