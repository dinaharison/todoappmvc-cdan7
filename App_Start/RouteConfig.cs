using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace todoappmvc_cdan7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Utilisateur", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name:"ListeTache",
                url:"Tache/ListeTache/{utilisateur}",
                defaults:new {controller = "Tache", action="ListeTache", utilisateur = UrlParameter.Optional}
                );

            routes.MapRoute(
                name:"AjouterTache",
                url:"Tache/AjouterTache"
                );

            routes.MapRoute(
                name:"SupprimerTache",
                url:"Tache/SupprimerTache/{id}"
                );

            routes.MapRoute(
                name:"Deconnection",
                url:"Utilisateur/Deconnection"
                );
        }
    }
}
