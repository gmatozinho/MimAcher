using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class ParticipanteHobbieController : Controller
    {
        public GestorDeHobbieDeParticipante GestorDeHobbieDeParticipante { get; set; }

        public ParticipanteHobbieController()
        {
            GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
        }

        // GET: ParticipanteHobbie
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE_HOBBIE> listaparticipantehobbieoriginal = GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            List<ParticipanteHobbie> listaparticipantehobbie = new List<ParticipanteHobbie>();

            foreach (MA_PARTICIPANTE_HOBBIE pe in listaparticipantehobbieoriginal)
            {
                ParticipanteHobbie participantehobbie = new ParticipanteHobbie();

                participantehobbie.cod_p_hobbie = pe.cod_p_hobbie;
                participantehobbie.cod_participante = pe.cod_participante;
                participantehobbie.cod_item = pe.cod_item;

                listaparticipantehobbie.Add(participantehobbie);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipantehobbie
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
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
                MA_PARTICIPANTE_HOBBIE participantehobbie = new MA_PARTICIPANTE_HOBBIE();

                participantehobbie.cod_participante = listaparticipantehobbie[0].cod_participante;
                participantehobbie.cod_item = listaparticipantehobbie[0].cod_item;

                //Informa que a relação estará ativa
                participantehobbie.cod_s_relacao = 1;

                try
                {
                    Boolean resultado = GestorDeHobbieDeParticipante.InserirNovoParticipanteHobbieComRetorno(participantehobbie);

                    if (resultado)
                    {
                        jsonResult = Json(new
                        {
                            codigo = participantehobbie.cod_p_hobbie
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
        public ActionResult Update(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeHobbieDeParticipante.VerificarSeExisteRelacaoUsuarioHobbiePorIdDaRelacao(listaparticipantehobbie[0].cod_p_hobbie))
                {
                    MA_PARTICIPANTE_HOBBIE participantehobbie = this.GestorDeHobbieDeParticipante.ObterHobbieDoParticipantePorId(listaparticipantehobbie[0].cod_p_hobbie);

                    participantehobbie.cod_p_hobbie = listaparticipantehobbie[0].cod_p_hobbie;
                    participantehobbie.cod_participante = listaparticipantehobbie[0].cod_participante;
                    participantehobbie.cod_item = listaparticipantehobbie[0].cod_item;
                    //Permanece a relação como ativa
                    participantehobbie.cod_s_relacao = 1;

                    try
                    {
                        Boolean resultado = this.GestorDeHobbieDeParticipante.AtualizarHobbieDoParticipanteComRetorno(participantehobbie);

                        if (resultado)
                        {
                            jsonResult = Json(new
                            {
                                codigo = participantehobbie.cod_p_hobbie
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

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Delete(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeHobbieDeParticipante.VerificarSeExisteRelacaoUsuarioHobbiePorIdDaRelacao(listaparticipantehobbie[0].cod_p_hobbie))
                {
                    try
                    {
                        MA_PARTICIPANTE_HOBBIE participantehobbie = this.GestorDeHobbieDeParticipante.ObterHobbieDoParticipantePorId(listaparticipantehobbie[0].cod_p_hobbie);

                        if (participantehobbie.cod_s_relacao == 1)
                        {
                            participantehobbie.cod_p_hobbie = listaparticipantehobbie[0].cod_p_hobbie;
                            participantehobbie.cod_participante = listaparticipantehobbie[0].cod_participante;
                            participantehobbie.cod_item = listaparticipantehobbie[0].cod_item;
                            //Marca a relação como inativa
                            participantehobbie.cod_s_relacao = 2;

                            try
                            {
                                Boolean resultado = this.GestorDeHobbieDeParticipante.AtualizarHobbieDoParticipanteComRetorno(participantehobbie);

                                if (resultado)
                                {
                                    jsonResult = Json(new
                                    {
                                        codigo = participantehobbie.cod_p_hobbie
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
                            catch (Exception e)
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
        public ActionResult Match(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
            {
                jsonResult = Json(new
                {
                    listaparticipantehobbie = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeHobbieDeParticipante.VerificarSeExisteHobbieDeParticipantePorIdDeItem(listaparticipantehobbie[0].cod_item))
                {                    
                    List<MA_PARTICIPANTE_HOBBIE> listaphobbie = this.GestorDeHobbieDeParticipante.ObterHobbiesDeParticipantePorIdDeItem(listaparticipantehobbie[0].cod_item);

                    //Reinicia lista de aprendizado de participante
                    listaparticipantehobbie = new List<ParticipanteHobbie>();

                    foreach (MA_PARTICIPANTE_HOBBIE mapa in listaphobbie)
                    {
                        ParticipanteHobbie pa = new ParticipanteHobbie();

                        pa.cod_p_hobbie = mapa.cod_p_hobbie;
                        pa.cod_item = mapa.cod_item;
                        pa.cod_participante = mapa.cod_participante;

                        listaparticipantehobbie.Add(pa);
                    }

                    jsonResult = Json(new
                    {
                        listaparticipantehobbie = listaparticipantehobbie
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    jsonResult = Json(new
                    {
                        listaparticipantehobbie = ""
                    }, JsonRequestBehavior.AllowGet);
                }

            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}