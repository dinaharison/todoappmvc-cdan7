using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using todoappmvc_cdan7.Models;

namespace todoappmvc_cdan7.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: Utilisateur
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Utilisateur user)
        {
            ViewBag.Info = "";
            if (DBConnection.IsUserInDB(user))
            {
                Session["utilisateur"] = user.NomUtilisateur;
                return RedirectToRoute("ListeTache");
            }
            else
            {
                ViewBag.Info = "Cet utilisateur n'existe pas, veuillez créer un compte";
            }
            return View();
        }

        public ActionResult Deconnection()
        {
            Session["utilisateur"]=null;
            return RedirectToAction("Login");
        }
    }
}