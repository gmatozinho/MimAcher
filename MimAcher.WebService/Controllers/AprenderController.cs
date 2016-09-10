using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.WebService.Controllers
{
    public class AprenderController : Controller
    {
        public GestorDeAprender GestorDeAprender { get; set; }

        public AprenderController()
        {
            this.GestorDeAprender = new GestorDeAprender();
        }

        // GET: Aprender
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_APRENDER> listaaprender = GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender();

            JsonResult jsonResult = Json(new
            {
                data = listaaprender
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}