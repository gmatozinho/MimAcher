using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class ParticipanteAprenderController : Controller
    {
        public GestorDeParticipanteAprender GestorDeParticipanteAprender { get; set; }

        public ParticipanteAprenderController()
        {
            GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
        }

        // GET: ParticipanteAprender
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE_APRENDER> listaparticipanteaprenderoriginal = GestorDeParticipanteAprender.ObterTodosOsRegistrosAtivos();
            List<ParticipanteAprender> listaparticipanteaprender = new List<ParticipanteAprender>();

            foreach (MA_PARTICIPANTE_APRENDER pe in listaparticipanteaprenderoriginal)
            {
                ParticipanteAprender participanteaprender = new ParticipanteAprender();

                participanteaprender.CodPAprender = pe.cod_p_aprender;
                participanteaprender.CodParticipante = pe.cod_participante;
                participanteaprender.CodItem = pe.cod_item;
                
                listaparticipanteaprender.Add(participanteaprender);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipanteaprender
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<ParticipanteAprender> listaparticipanteaprender)
        {
            JsonResult jsonResult;
            
            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteaprender == null)
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
                MA_PARTICIPANTE_APRENDER participanteaprender = new MA_PARTICIPANTE_APRENDER();

                participanteaprender.cod_participante = listaparticipanteaprender[0].CodParticipante;
                participanteaprender.cod_item = listaparticipanteaprender[0].CodItem;

                //Informa que a relação estará ativa
                participanteaprender.cod_status = 1;

                try
                {
                    Boolean resultado = GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipanteComRetorno(participanteaprender);

                    if (resultado)
                    {
                        jsonResult = Json(new
                        {
                            codigo = participanteaprender.cod_participante
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
        public ActionResult Delete(List<ParticipanteAprender> listaparticipanteaprender)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteaprender == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);                
            }
            else
            {
                if (this.GestorDeParticipanteAprender.VerificarSeExisteRelacaoUsuarioPorItemEParticipante(listaparticipanteaprender[0].CodItem, listaparticipanteaprender[0].CodParticipante))
                {
                    try
                    {
                        MA_PARTICIPANTE_APRENDER participanteaprender = this.GestorDeParticipanteAprender.ObterAprendizadoDeParticipantePorItemEParticipante(listaparticipanteaprender[0].CodItem, listaparticipanteaprender[0].CodParticipante);

                        if (participanteaprender.cod_status == 1)
                        {
                            MA_PARTICIPANTE_APRENDER participanteaprendermodificado = new MA_PARTICIPANTE_APRENDER();

                            participanteaprendermodificado.cod_p_aprender = participanteaprender.cod_p_aprender;
                            participanteaprendermodificado.cod_participante = participanteaprender.cod_participante;
                            participanteaprendermodificado.cod_item = participanteaprender.cod_item;

                            //Marca a relação como inativa
                            participanteaprendermodificado.cod_status = 2;
                            
                            try
                            {
                                Boolean resultado = this.GestorDeParticipanteAprender.AtualizarAprendizadoDeParticipanteComRetorno(participanteaprendermodificado);

                                if (resultado)
                                {
                                    jsonResult = Json(new
                                    {
                                        codigo = participanteaprendermodificado.cod_p_aprender
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
        public ActionResult Match(List<ParticipanteAprender> listaparticipanteaprender)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteaprender == null)
            {
                jsonResult = Json(new
                {
                    listaparticipanteaprender = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeParticipanteAprender.VerificarSeExisteAprendizadoDeParticipantePorIdDeItem(listaparticipanteaprender[0].CodItem))
                {
                    try
                    {
                        List<MA_PARTICIPANTE_APRENDER> listapaprender = this.GestorDeParticipanteAprender.ObterTodosOsAprendizadoDeParticipantePorPorItemPaginadosPorVinteRegistros(listaparticipanteaprender[0].CodItem);

                        //Reinicia lista de aprendizado de participante
                        listaparticipanteaprender = new List<ParticipanteAprender>();

                        foreach (MA_PARTICIPANTE_APRENDER mapa in listapaprender)
                        {
                            ParticipanteAprender pa = new ParticipanteAprender();

                            pa.CodPAprender = mapa.cod_p_aprender;
                            pa.CodItem = mapa.cod_item;
                            pa.CodParticipante = mapa.cod_participante;

                            listaparticipanteaprender.Add(pa);
                        }

                        jsonResult = Json(new
                        {
                            listaparticipanteaprender = listaparticipanteaprender
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch(Exception e)
                    {
                        jsonResult = Json(new
                        {
                            erro = e.InnerException.ToString(),
                            listaparticipanteaprender = ""
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    jsonResult = Json(new
                    {
                        listaparticipanteaprender = ""
                    }, JsonRequestBehavior.AllowGet);
                }

            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}