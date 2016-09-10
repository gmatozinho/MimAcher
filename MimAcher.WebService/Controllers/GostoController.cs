using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.WebService.Controllers
{
    public class GostoController : Controller
    {
        public GestorDeGosto GestorDeGosto { get; set; }

        // GET: Gosto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_GOSTO> listagosto = GestorDeGosto.ObterTodosOsGostos();

            JsonResult jsonResult = Json(new
            {
                data = listagosto
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}