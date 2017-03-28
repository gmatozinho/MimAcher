using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class AreaAtuacaoController : Controller
    {
        public GestorDeAreaDeAtuacao GestorDeAreaDeAtuacao { get; set; }

        public AreaAtuacaoController()
        {
            this.GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
        }

        // GET: AreaAtuacao
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_AREA_ATUACAO> listaareaatuacaooriginal = this.GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao();
            List<AreaAtuacao> listaareaatuacao = new List<AreaAtuacao>();

            foreach (MA_AREA_ATUACAO aa in listaareaatuacaooriginal)
            {
                AreaAtuacao areaatuacao = new AreaAtuacao();

                areaatuacao.CodAreaAtuacao = aa.cod_area_atuacao;
                areaatuacao.Nome = aa.nome;

                listaareaatuacao.Add(areaatuacao);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaareaatuacao
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<AreaAtuacao> listaareaatuacao)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaareaatuacao == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                int codigocadastrado = -1;

                foreach (AreaAtuacao aa in listaareaatuacao)
                {
                    MA_AREA_ATUACAO areaatuacao = new MA_AREA_ATUACAO();

                    areaatuacao.nome = aa.Nome;

                    this.GestorDeAreaDeAtuacao.InserirAreaDeAtuacao(areaatuacao);

                    codigocadastrado = areaatuacao.cod_area_atuacao;
                }

                jsonResult = Json(new
                {
                    codigo = codigocadastrado
                }, JsonRequestBehavior.AllowGet);
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        } 

        [HttpPost]
        public ActionResult Update(List<AreaAtuacao> listaareaatuacao)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaareaatuacao == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                int codigocadastrado = -1;

                foreach (AreaAtuacao aa in listaareaatuacao)
                {
                    MA_AREA_ATUACAO areaatuacao = new MA_AREA_ATUACAO();

                    areaatuacao.nome = aa.Nome;

                    this.GestorDeAreaDeAtuacao.AtualizarAreaDeAtuacao(areaatuacao);

                    codigocadastrado = areaatuacao.cod_area_atuacao;
                }

                jsonResult = Json(new
                {
                    codigo = codigocadastrado
                }, JsonRequestBehavior.AllowGet);
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}