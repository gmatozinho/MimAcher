using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class LoginController : Controller
    {
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }

        public LoginController()
        {
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeParticipante = new GestorDeParticipante();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(List<Usuario> listausuario)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuario == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                if(GestorDeUsuario.VerificarExistenciaDeUsuarioPorEmailESenha(listausuario[0].e_mail, listausuario[0].senha))
                {
                    MA_USUARIO usuario = GestorDeUsuario.ObterUsuarioPorEmailESenha(listausuario[0].e_mail, listausuario[0].senha);

                    //Verifica se o usuário está ativo
                    if(usuario.cod_status == 1)
                    {
                        if (GestorDeParticipante.VerificarSeUsuarioJaTemVinculoComAlgumParticipante(usuario.cod_usuario))
                        {
                            jsonResult = Json(new
                            {
                                codigo = GestorDeParticipante.ObterParticipantePorIdDeUsuario(usuario.cod_usuario).cod_participante
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
    }
}