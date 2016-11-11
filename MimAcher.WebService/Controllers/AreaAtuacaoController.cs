﻿using System.Collections.Generic;
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
            GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
        }

        // GET: AreaAtuacao
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_AREA_ATUACAO> listaareaatuacaooriginal = GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao();
            List<AreaAtuacao> listaareaatuacao = new List<AreaAtuacao>();

            foreach (MA_AREA_ATUACAO aa in listaareaatuacaooriginal)
            {
                AreaAtuacao areaatuacao = new AreaAtuacao();

                areaatuacao.cod_area_atuacao = aa.cod_area_atuacao;
                areaatuacao.nome = aa.nome;

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
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (AreaAtuacao aa in listaareaatuacao)
            {
                MA_AREA_ATUACAO areaatuacao = new MA_AREA_ATUACAO();

                areaatuacao.nome = aa.nome;

                GestorDeAreaDeAtuacao.InserirAreaDeAtuacao(areaatuacao);
            }

            jsonResult = Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);

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
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (AreaAtuacao aa in listaareaatuacao)
            {
                MA_AREA_ATUACAO areaatuacao = new MA_AREA_ATUACAO();

                areaatuacao.cod_area_atuacao = aa.cod_area_atuacao;
                areaatuacao.nome = aa.nome;

                GestorDeAreaDeAtuacao.InserirAreaDeAtuacao(areaatuacao);
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