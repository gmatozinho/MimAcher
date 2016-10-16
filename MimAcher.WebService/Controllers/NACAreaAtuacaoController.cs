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
    public class NACAreaAtuacaoController : Controller
    {
        public GestorDeNACAreaDeAtuacao GestorDeNACAreaDeAtuacao { get; set; }

        public NACAreaAtuacaoController()
        {
            this.GestorDeNACAreaDeAtuacao = new GestorDeNACAreaDeAtuacao();
        }

        // GET: NACAreaAtuacao
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_NAC_AREA_ATUACAO> listanacareaatuacaooriginal = GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
            List<NACAreaAtuacao> listanacareaatuacao = new List<NACAreaAtuacao>();

            foreach (MA_NAC_AREA_ATUACAO na in listanacareaatuacaooriginal)
            {
                NACAreaAtuacao nacareaatuacao = new NACAreaAtuacao();

                nacareaatuacao.cod_nac_area_atuacao = na.cod_nac_area_atuacao;
                nacareaatuacao.cod_area_atuacao = na.cod_area_atuacao;
                nacareaatuacao.cod_nac = na.cod_nac;

                listanacareaatuacao.Add(nacareaatuacao);
            }

            JsonResult jsonResult = Json(new
            {
                data = listanacareaatuacao
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<NACAreaAtuacao> listanacareaatuacao)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listanacareaatuacao == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                foreach (NACAreaAtuacao na in listanacareaatuacao)
                {
                    MA_NAC_AREA_ATUACAO nacareaatuacao = new MA_NAC_AREA_ATUACAO();

                    nacareaatuacao.cod_area_atuacao = na.cod_area_atuacao;
                    nacareaatuacao.cod_nac = na.cod_nac;
                }

                jsonResult = Json(new
                {
                    success = true
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }
    }
}