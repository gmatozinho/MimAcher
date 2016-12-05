﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
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
                participante.cod_campus = pt.cod_campus;
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
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);                
            }
            else
            {                   
                MA_PARTICIPANTE participante = new MA_PARTICIPANTE();

                participante.cod_usuario = listaparticipante[0].cod_usuario;
                participante.cod_campus = listaparticipante[0].cod_participante;
                participante.nome = listaparticipante[0].nome;
                participante.telefone = listaparticipante[0].telefone;
                participante.dt_nascimento = (DateTime)listaparticipante[0].dt_nascimento;
                participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].longitude.ToString()) + ")");

                try
                {
                    Boolean resultado = GestorDeParticipante.InserirParticipanteComRetorno(participante);

                    jsonResult = Json(new
                    {
                        codigo = participante.cod_participante
                    }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Update(List<Participante> listaparticipante)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipante == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {   
                MA_PARTICIPANTE participante = new MA_PARTICIPANTE();

                participante.cod_participante = listaparticipante[0].cod_participante;
                participante.cod_usuario = listaparticipante[0].cod_usuario;
                participante.cod_campus = listaparticipante[0].cod_campus;
                participante.nome = listaparticipante[0].nome;
                participante.telefone = listaparticipante[0].telefone;
                participante.dt_nascimento = (DateTime)listaparticipante[0].dt_nascimento;
                participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].longitude.ToString()) + ")");

                Boolean resultado = GestorDeParticipante.AtualizarParticipanteC(participante);

                    codigo_participante = participante.cod_participante;
                

                jsonResult = Json(new
                {
                    codigo = codigo_participante
                }, JsonRequestBehavior.AllowGet);

            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Get(List<Participante> listaparticipante)
        {
            JsonResult jsonResult;
            List<Participante> listaparticipanteretorno = new List<Participante>();

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipante == null)
            {
                jsonResult = Json(new
                {
                    participante = listaparticipanteretorno
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (GestorDeParticipante.VerificarSeParticipanteExiste(listaparticipante[0].cod_participante))
                {
                    MA_PARTICIPANTE participante = GestorDeParticipante.ObterParticipantePorId(listaparticipante[0].cod_participante);

                    Participante pt = new Participante();

                    pt.cod_participante = participante.cod_participante;
                    pt.cod_campus = participante.cod_campus;
                    pt.cod_usuario = participante.cod_usuario;
                    pt.nome = participante.nome;
                    pt.telefone = participante.telefone;
                    pt.dt_nascimento = participante.dt_nascimento;
                    pt.latitude = participante.geolocalizacao.Latitude;
                    pt.longitude = participante.geolocalizacao.Longitude;

                    listaparticipanteretorno.Add(pt);

                    jsonResult = Json(new
                    {
                        participante = listaparticipanteretorno
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    jsonResult = Json(new
                    {
                        participante = listaparticipanteretorno
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}