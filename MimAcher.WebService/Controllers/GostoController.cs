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
    public class GostoController : Controller
    {
        public GestorDeGosto GestorDeGosto { get; set; }

        public GostoController()
        {
            this.GestorDeGosto = new GestorDeGosto();
        }

        // GET: Gosto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_GOSTO> listagostooriginal = GestorDeGosto.ObterTodosOsGostos();
            List<Gosto> listagosto = new List<Gosto>();

            foreach(MA_GOSTO g in listagostooriginal)
            {
                Gosto gosto = new Gosto();

                gosto.cod_g = g.cod_g;
                gosto.nome = g.nome;

                listagosto.Add(gosto);
            }

            JsonResult jsonResult = Json(new
            {
                data = listagosto
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<Gosto> gosto)
        {
            JsonResult jsonResult;
            
            MA_GOSTO ma_gosto = new MA_GOSTO();

            ma_gosto.nome = gosto[0].nome;

            if(gosto[0].nome == null)
            {
                jsonResult = Json(new
                {
                    data = "Valor Incorreto"
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }

            GestorDeGosto.InserirNovoGosto(ma_gosto);


            jsonResult = Json(new
            {
                data = ma_gosto
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}