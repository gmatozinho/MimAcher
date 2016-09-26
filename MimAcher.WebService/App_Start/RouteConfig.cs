using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MimAcher.WebService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "AlunoAprender",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "AlunoAprender", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Aluno",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Aluno", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AlunoEnsinar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AlunoEnsinar", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AlunoGosto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AlunoGosto", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Usuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NACCampus",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NACCampus", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Gosto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Gosto", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Ensinar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ensinar", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Aprender",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Aprender", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ImagemUsuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ImagemUsuario", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
