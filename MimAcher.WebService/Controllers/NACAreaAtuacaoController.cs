using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class NacAreaAtuacaoController : Controller
    {
        public GestorDeNacAreaDeAtuacao GestorDeNacAreaDeAtuacao { get; set; }

        public NacAreaAtuacaoController()
        {
            this.GestorDeNacAreaDeAtuacao = new GestorDeNacAreaDeAtuacao();
        }

        // GET: NacAreaAtuacao
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_NAC_AREA_ATUACAO> listanacareaatuacaooriginal = this.GestorDeNacAreaDeAtuacao.ObterTodasAsNacAreasDeAtuacao();
            List<NacAreaAtuacao> listanacareaatuacao = new List<NacAreaAtuacao>();

            foreach (MA_NAC_AREA_ATUACAO na in listanacareaatuacaooriginal)
            {
                NacAreaAtuacao nacareaatuacao = new NacAreaAtuacao();

                nacareaatuacao.CodNacAreaAtuacao = na.cod_nac_area_atuacao;
                nacareaatuacao.CodAreaAtuacao = na.cod_area_atuacao;
                nacareaatuacao.CodNac = na.cod_nac;

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
        public ActionResult Add(List<NacAreaAtuacao> listanacareaatuacao)
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
            foreach (NacAreaAtuacao na in listanacareaatuacao)
            {
                MA_NAC_AREA_ATUACAO nacareaatuacao = new MA_NAC_AREA_ATUACAO();

                nacareaatuacao.cod_area_atuacao = na.CodAreaAtuacao;
                nacareaatuacao.cod_nac = na.CodNac;

                this.GestorDeNacAreaDeAtuacao.InserirNacAreaDeAtuacao(nacareaatuacao);
            }

            jsonResult = Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Update(List<NacAreaAtuacao> listanacareaatuacao)
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
            foreach (NacAreaAtuacao na in listanacareaatuacao)
            {
                MA_NAC_AREA_ATUACAO nacareaatuacao = new MA_NAC_AREA_ATUACAO();
                nacareaatuacao.cod_nac_area_atuacao = na.CodNacAreaAtuacao;
                nacareaatuacao.cod_area_atuacao = na.CodAreaAtuacao;
                nacareaatuacao.cod_nac = na.CodNac;

                this.GestorDeNacAreaDeAtuacao.InserirNacAreaDeAtuacao(nacareaatuacao);
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