using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using w16_1.Models;

namespace w16_1.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //Auth
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Username, Password")] Utenti u)
        {
            Utenti user = db.Utenti.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login() {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="Username, Password")] Utenti u)
        {
          Utenti user = db.Utenti.Find(u.IdUtente);
                if (user == null)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    return RedirectToAction("Index");
                }
             
            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //Create 
        public ActionResult CreateCliente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente( Clienti c )
        {
            Clienti cliente = db.Clienti.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CreateOrdine()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOrdine([Bind(Include = "IdOrdine, Allergie,IdCliente,Evaso")]Ordini o)
        {
            Ordini ordini = db.Ordini.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CreateAggiunte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAggiunte(Aggiunte a)
        {
            Aggiunte aggiunte = db.Aggiunte.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CreatePizzeScelte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePizzeScelte(Ordini o)
        {
            Ordini ordini = db.Ordini.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
