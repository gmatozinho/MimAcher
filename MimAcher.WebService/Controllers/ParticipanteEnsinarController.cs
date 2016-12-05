using System.Collections.Generic;
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
            List<MA_PARTICIPANTE_ENSINAR> listaparticipanteensinaroriginal = GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            List<ParticipanteEnsinar> listaparticipanteensinar = new List<ParticipanteEnsinar>();

            foreach (MA_PARTICIPANTE_ENSINAR pe in listaparticipanteensinaroriginal)
            {
                ParticipanteEnsinar participanteensinar = new ParticipanteEnsinar();

                participanteensinar.cod_p_ensinar = pe.cod_p_ensinar;
                participanteensinar.cod_participante = pe.cod_participante;
                participanteensinar.cod_item = pe.cod_item;

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

                participanteensinar.cod_participante = listaparticipanteensinar[0].cod_participante;
                participanteensinar.cod_item = listaparticipanteensinar[0].cod_item;

                //Informa que a relação estará ativa
                participanteensinar.cod_s_relacao = 1;

                try
                {
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
        public ActionResult Update(List<ParticipanteEnsinar> listaparticipanteensinar)
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
                if (this.GestorDeParticipanteEnsinar.VerificarSeExisteRelacaoUsuarioEnsinarPorIdDaRelacao(listaparticipanteensinar[0].cod_p_ensinar))
                {
                    MA_PARTICIPANTE_ENSINAR participanteensinar = this.GestorDeParticipanteEnsinar.ObterRelacaoDoQueOParticipanteEnsinaPorId(listaparticipanteensinar[0].cod_p_ensinar);

                    participanteensinar.cod_p_ensinar = listaparticipanteensinar[0].cod_p_ensinar;
                    participanteensinar.cod_participante = listaparticipanteensinar[0].cod_participante;
                    participanteensinar.cod_item = listaparticipanteensinar[0].cod_item;
                    //Permanece a relação como ativa
                    participanteensinar.cod_s_relacao = 1;

                    if (this.GestorDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipanteComRetorno(participanteensinar))
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
                if (this.GestorDeParticipanteEnsinar.VerificarSeExisteRelacaoUsuarioEnsinarPorIdDaRelacao(listaparticipanteensinar[0].cod_p_ensinar))
                {
                    MA_PARTICIPANTE_ENSINAR participanteensinar = this.GestorDeParticipanteEnsinar.ObterRelacaoDoQueOParticipanteEnsinaPorId(listaparticipanteensinar[0].cod_p_ensinar);

                    if (participanteensinar.cod_s_relacao == 1)
                    {
                        participanteensinar.cod_p_ensinar = listaparticipanteensinar[0].cod_p_ensinar;
                        participanteensinar.cod_participante = listaparticipanteensinar[0].cod_participante;
                        participanteensinar.cod_item = listaparticipanteensinar[0].cod_item;
                        //Marca a relação como inativa
                        participanteensinar.cod_s_relacao = 2;

                        this.GestorDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipante(participanteensinar);

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
                if (this.GestorDeParticipanteEnsinar.VerificarSeExisteAprendizadoDeParticipantePorIdDeItem(listaparticipanteensinar[0].cod_item))
                {
                    List<MA_PARTICIPANTE_ENSINAR> listapensinar = this.GestorDeParticipanteEnsinar.ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(listaparticipanteensinar[0].cod_item);

                    //Reinicia lista de aprendizado de participante
                    listaparticipanteensinar = new List<ParticipanteEnsinar>();

                    foreach (MA_PARTICIPANTE_ENSINAR mapa in listapensinar)
                    {
                        ParticipanteEnsinar pa = new ParticipanteEnsinar();

                        pa.cod_p_ensinar = mapa.cod_p_ensinar;
                        pa.cod_item = mapa.cod_item;
                        pa.cod_participante = mapa.cod_participante;

                        listaparticipanteensinar.Add(pa);
                    }

                    jsonResult = Json(new
                    {
                        listaparticipanteensinar = listaparticipanteensinar
                    }, JsonRequestBehavior.AllowGet);
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