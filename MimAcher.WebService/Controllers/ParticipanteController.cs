﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.WebService.Models
{
    public class ParticipanteController : Controller
    {
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeAplicacao GestorDeAplicacao { get; set; }

        public ParticipanteController()
        {
            GestorDeParticipante = new GestorDeParticipante();
            GestorDeAplicacao = new GestorDeAplicacao();
        }

        // GET: Participante
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE> listaparticipanteoriginal = GestorDeParticipante.ObterTodosOsParticipantes();
            List<Participante> listaparticipante = new List<Participante>();

            foreach (MA_PARTICIPANTE pt in listaparticipanteoriginal)
            {
                Participante participante = new Participante();

                participante.cod_participante = pt.cod_participante;
                participante.cod_usuario = pt.cod_usuario;
                participante.cod_campus = pt.cod_participante;
                participante.nome = pt.nome;
                participante.telefone = pt.telefone;
                participante.dt_nascimento = pt.dt_nascimento;
                participante.latitude = pt.geolocalizacao.Latitude;
                participante.longitude = pt.geolocalizacao.Longitude;

                listaparticipante.Add(participante);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipante
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<Participante> listaparticipante)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipante == null)
            {
                jsonResult = Json(new
                {   
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (Participante pt in listaparticipante)
            {
                MA_PARTICIPANTE participante = new MA_PARTICIPANTE();

                participante.cod_usuario = pt.cod_usuario;
                participante.cod_campus = pt.cod_participante;
                participante.nome = pt.nome;
                participante.telefone = pt.telefone;
                participante.dt_nascimento = (DateTime) pt.dt_nascimento;                    
                participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(pt.latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(pt.longitude.ToString()) + ")");

                GestorDeParticipante.InserirParticipante(participante);
            }

            jsonResult = Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Update(List<Participante> listaparticipante)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipante == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (Participante pt in listaparticipante)
            {
                MA_PARTICIPANTE participante = new MA_PARTICIPANTE();

                participante.cod_participante = pt.cod_participante;
                participante.cod_usuario = pt.cod_usuario;
                participante.cod_campus = pt.cod_campus;
                participante.nome = pt.nome;
                participante.telefone = pt.telefone;
                participante.dt_nascimento = (DateTime)pt.dt_nascimento;
                participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(pt.latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(pt.longitude.ToString()) + ")");

                GestorDeParticipante.AtualizarParticipante(participante);
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