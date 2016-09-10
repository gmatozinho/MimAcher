using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.WebService.Controllers
{
    public class EnsinarController : Controller
    {
        public GestorDeEnsinar GestorDeEnsinar { get; set; }

        public EnsinarController()
        {
            this.GestorDeEnsinar = new GestorDeEnsinar();
        }

        // GET: Ensinar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ENSINAR> listaensino = GestorDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado();

            JsonResult jsonResult = Json(new
            {
                data = listaensino
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}