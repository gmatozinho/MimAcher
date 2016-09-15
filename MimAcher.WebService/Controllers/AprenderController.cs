using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;
using MimAcher.WebService.Models;

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
            List<MA_APRENDER> listaaprenderoriginal = GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender();
            List<Aprender> listaaprender = new List<Aprender>();

            foreach(MA_APRENDER a in listaaprenderoriginal)
            {
                Aprender aprender = new Aprender();

                aprender.cod_a = a.cod_a;
                aprender.nome = a.nome;

                listaaprender.Add(aprender);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaaprender
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}