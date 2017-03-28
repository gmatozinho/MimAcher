using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Dominio;
using MimAcher.Aplicacao;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class ErroController : Controller
    {
        public GestorDeErro GestorDeErro { get; set; }

        public ErroController()
        {
            this.GestorDeErro = new GestorDeErro();
        }

        // GET: Erro
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ERRO> listaerrooriginal = this.GestorDeErro.ObterTodosOsErros();
            List<Erro> listaerro = new List<Erro>();

            foreach (MA_ERRO er in listaerrooriginal)
            {
                Erro erro = new Erro();

                erro.Tipo = er.tipo;
                erro.Aconteceu = er.aconteceu;
                erro.Incidencia = er.incidencia;
                erro.DtAcontecimento = er.dt_acontecimento.ToString();

                listaerro.Add(erro);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaerro
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<Erro> listaerro)
        {
            JsonResult jsonResult;
            
            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaerro == null)
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
                try
                {
                    MA_ERRO erro = new MA_ERRO();

                    erro.tipo = listaerro[0].Tipo;
                    erro.aconteceu = listaerro[0].Aconteceu;
                    erro.incidencia = listaerro[0].Incidencia;
                    erro.dt_acontecimento = DateTime.Now;

                    if (GestorDeErro.InserirErroComRetorno(erro))
                    {
                        jsonResult = Json(new
                        {
                            codigo = erro.cod_erro
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch(Exception e)
                {
                    jsonResult = Json(new
                    {
                        erro = e.InnerException.ToString(),
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}