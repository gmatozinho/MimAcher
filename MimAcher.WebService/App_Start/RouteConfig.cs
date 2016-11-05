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
               name: "ParticipanteAprender",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "ParticipanteAprender", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Participante",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Participante", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ParticipanteEnsinar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ParticipanteEnsinar", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ParticipanteHobbie",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ParticipanteHobbie", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Usuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NAC",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NAC", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Campus",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Campus", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Item",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Item", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AreaAtuacao",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AreaAtuacao", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NACAreaAtuacao",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "NACAreaAtuacao", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ImagemParticipante",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ImagemParticipante", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
