﻿using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class ParticipanteEnsinarController : Controller
    {
        public GestorDeParticipanteEnsinar GestorDeParticipanteEnsinar { get; set; }

        public ParticipanteEnsinarController()
        {
            GestorDeParticipanteEnsinar = new GestorDeParticipanteEnsinar();
        }

        // GET: ParticipanteEnsinar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE_ENSINAR> listaparticipanteensinaroriginal = GestorDeParticipanteEnsinar.ObterTodosOsRegistrosAtivos();
            List<ParticipanteEnsinar> listaparticipanteensinar = new List<ParticipanteEnsinar>();

            foreach (MA_PARTICIPANTE_ENSINAR pe in listaparticipanteensinaroriginal)
            {
                ParticipanteEnsinar participanteensinar = new ParticipanteEnsinar();

                participanteensinar.CodPEnsinar = pe.cod_p_ensinar;
                participanteensinar.CodParticipante = pe.cod_participante;
                participanteensinar.CodItem = pe.cod_item;

                listaparticipanteensinar.Add(participanteensinar);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipanteensinar
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<ParticipanteEnsinar> listaparticipanteensinar)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteensinar == null)
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
                MA_PARTICIPANTE_ENSINAR participanteensinar = new MA_PARTICIPANTE_ENSINAR();

                participanteensinar.cod_participante = listaparticipanteensinar[0].CodParticipante;
                participanteensinar.cod_item = listaparticipanteensinar[0].CodItem;

                //Informa que a relação estará ativa
                participanteensinar.cod_status = 1;

                try
                {
                    //if

                    Boolean resultado = GestorDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipanteComRetorno(participanteensinar);

                    if (resultado)
                    {
                        jsonResult = Json(new
                        {
                            codigo = participanteensinar.cod_p_ensinar
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
        
        [HttpPost]
        public ActionResult Delete(List<ParticipanteEnsinar> listaparticipanteensinar)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteensinar == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeParticipanteEnsinar.VerificarSeExisteRelacaoUsuarioEnsinarPorItemEParticipante(listaparticipanteensinar[0].CodItem, listaparticipanteensinar[0].CodParticipante))
                {
                    try
                    {
                        MA_PARTICIPANTE_ENSINAR participanteensinar = this.GestorDeParticipanteEnsinar.ObterEnsinoDeParticipantePorItemEParticipante(listaparticipanteensinar[0].CodItem, listaparticipanteensinar[0].CodParticipante);

                        if (participanteensinar.cod_status == 1)
                        {
                            MA_PARTICIPANTE_ENSINAR participanteensinarmodificado = new MA_PARTICIPANTE_ENSINAR();

                            participanteensinarmodificado.cod_p_ensinar = participanteensinar.cod_p_ensinar;
                            participanteensinarmodificado.cod_participante = participanteensinar.cod_participante;
                            participanteensinarmodificado.cod_item = participanteensinar.cod_item;

                            //Marca a relação como inativa
                            participanteensinarmodificado.cod_status = 2;

                            try
                            {
                                Boolean resultado = this.GestorDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipanteComRetorno(participanteensinarmodificado);

                                if (resultado)
                                {
                                    jsonResult = Json(new
                                    {
                                        codigo = participanteensinarmodificado.cod_p_ensinar
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
                else
                {
                    jsonResult = Json(new
                    {
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }

            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Match(List<ParticipanteEnsinar> listaparticipanteensinar)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteensinar == null)
            {
                jsonResult = Json(new
                {
                    listaparticipanteensinar = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeParticipanteEnsinar.VerificarSeExisteAprendizadoDeParticipantePorIdDeItem(listaparticipanteensinar[0].CodItem))
                {
                    try
                    {
                        List<MA_PARTICIPANTE_ENSINAR> listapensinar = this.GestorDeParticipanteEnsinar.ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(listaparticipanteensinar[0].CodItem);

                        //Reinicia lista de aprendizado de participante
                        listaparticipanteensinar = new List<ParticipanteEnsinar>();

                        foreach (MA_PARTICIPANTE_ENSINAR mapa in listapensinar)
                        {
                            ParticipanteEnsinar pa = new ParticipanteEnsinar();

                            pa.CodPEnsinar = mapa.cod_p_ensinar;
                            pa.CodItem = mapa.cod_item;
                            pa.CodParticipante = mapa.cod_participante;

                            listaparticipanteensinar.Add(pa);
                        }

                        jsonResult = Json(new
                        {
                            listaparticipanteensinar = listaparticipanteensinar
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch(Exception e)
                    {
                        jsonResult = Json(new
                        {
                            erro = e.InnerException.ToString(),
                            listaparticipanteensinar = ""
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    jsonResult = Json(new
                    {
                        listaparticipanteensinar = ""
                    }, JsonRequestBehavior.AllowGet);
                }

            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}