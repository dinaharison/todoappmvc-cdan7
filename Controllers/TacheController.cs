using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using todoappmvc_cdan7.Models;

namespace todoappmvc_cdan7.Controllers
{
    public class TacheController : Controller
    {
        // GET: Tache
        public ActionResult ListeTache()
        {
            if (Session["utilisateur"] == null)
            {
                return RedirectToRoute("Default");
            }
            else
            {
                ViewBag.Info = Session["utilisateur"].ToString();
                return View(DBConnection.GetTaches(Session["utilisateur"].ToString()));
            }
        }

        public ActionResult AjouterTache(bool etatInput)
        {
            if (!(Request.Form["idInput"].Equals(string.Empty)))
            {
                DBConnection.ModifierTache(new Tache(
                        int.Parse(Request.Form["idInput"]),
                        Request.Form["tacheInput"],
                        etatInput,
                        Session["utilisateur"].ToString()
                    ));
            }
            else
            {
                DBConnection.InsertTache(new Tache(Request.Form["tacheInput"], Session["utilisateur"].ToString()));
            }
            return RedirectToAction("ListeTache");
        }

        public ActionResult SupprimerTache(int id)
        {
            
            DBConnection.SupprimerTache(id);
            return RedirectToAction("ListeTache");
        }
    }
}