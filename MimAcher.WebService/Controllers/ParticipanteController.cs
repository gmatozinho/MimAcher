using System;
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
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public ParticipanteController()
        {
            GestorDeParticipante = new GestorDeParticipante();
            GestorDeAplicacao = new GestorDeAplicacao();
            GestorDeUsuario = new GestorDeUsuario();
        }

        // GET: Participante
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE> listaparticipanteoriginal = GestorDeParticipante.ObterTodosOsParticipantesDeUsuariosAtivos();
            List<Participante> listaparticipante = new List<Participante>();

            foreach (MA_PARTICIPANTE pt in listaparticipanteoriginal)
            {
                Participante participante = new Participante();

                participante.CodParticipante = pt.cod_participante;
                participante.CodUsuario = pt.cod_usuario;
                participante.CodCampus = pt.cod_campus;
                participante.Nome = pt.nome;
                participante.Telefone = pt.telefone;
                participante.DtNascimento = pt.dt_nascimento;
                participante.Latitude = pt.geolocalizacao.Latitude;
                participante.Longitude = pt.geolocalizacao.Longitude;

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

                participante.cod_usuario = listaparticipante[0].CodUsuario;
                participante.cod_campus = listaparticipante[0].CodParticipante;
                participante.nome = listaparticipante[0].Nome;
                participante.telefone = listaparticipante[0].Telefone;
                participante.dt_nascimento = (DateTime)listaparticipante[0].DtNascimento;
                participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].Latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].Longitude.ToString()) + ")");

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

                participante.cod_participante = listaparticipante[0].CodParticipante;
                participante.cod_usuario = listaparticipante[0].CodUsuario;
                participante.cod_campus = listaparticipante[0].CodCampus;
                participante.nome = listaparticipante[0].Nome;
                participante.telefone = listaparticipante[0].Telefone;
                participante.dt_nascimento = (DateTime)listaparticipante[0].DtNascimento;
                participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].Latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(listaparticipante[0].Longitude.ToString()) + ")");

                try
                {
                    Boolean resultado = GestorDeParticipante.AtualizarParticipanteComRetorno(participante);

                    if (resultado)
                    {
                        jsonResult = Json(new
                        {
                            codigo = participante.cod_participante
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
        public ActionResult Get(List<Participante> listaparticipante)
        {
            JsonResult jsonResult;
            List<ParticipanteGet> listaparticipanteretorno = new List<ParticipanteGet>();

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
                if (GestorDeParticipante.VerificarSeParticipanteExiste(listaparticipante[0].CodParticipante))
                {
                    try
                    {
                        MA_PARTICIPANTE participante = GestorDeParticipante.ObterParticipantePorId(listaparticipante[0].CodParticipante);

                        ParticipanteGet pg = new ParticipanteGet();

                        pg.CodParticipante = participante.cod_participante;
                        pg.NomeParticipante = participante.nome;
                        pg.CodCampus = participante.cod_campus;
                        pg.NomeCampus = participante.MA_CAMPUS.local;
                        pg.CodUsuario = participante.cod_usuario;
                        pg.EMail = participante.MA_USUARIO.e_mail;                        
                        pg.Telefone = participante.telefone;
                        pg.DtNascimento = participante.dt_nascimento.ToString();
                        pg.Latitude = participante.geolocalizacao.Latitude.ToString();
                        pg.Longitude = participante.geolocalizacao.Longitude.ToString();
                                                
                        listaparticipanteretorno.Add(pg);

                        jsonResult = Json(new
                        {
                            participante = listaparticipanteretorno
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch(Exception e)
                    {
                        jsonResult = Json(new
                        {
                            erro = e.InnerException.ToString(),
                            participante = ""
                        }, JsonRequestBehavior.AllowGet);
                    }
                    
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

        [HttpPost]
        public ActionResult Delete(List<Participante> listaparticipante)
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

                participante.cod_participante = listaparticipante[0].CodParticipante;                

                try
                {
                    if (GestorDeParticipante.VerificarSeExisteParticipantePorId(participante.cod_participante))
                    {
                        participante = GestorDeParticipante.ObterParticipantePorId(participante.cod_participante);

                        MA_USUARIO usuario = GestorDeUsuario.ObterUsuarioPorId(participante.cod_usuario);

                        //Inativa o usuário associado a este Participante
                        usuario.cod_status = 2;

                        Boolean resultado = GestorDeUsuario.AtualizarUsuarioComRetorno(usuario);
                        
                        if (resultado)
                        {
                            jsonResult = Json(new
                            {
                                codigo = participante.cod_participante
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
                catch (Exception e)
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