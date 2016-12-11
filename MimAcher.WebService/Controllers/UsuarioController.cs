using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class UsuarioController : Controller
    {
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public UsuarioController()
        {
            this.GestorDeUsuario = new GestorDeUsuario();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_USUARIO> listausuariooriginal = this.GestorDeUsuario.ObterTodosOsUsuarios();
            List<Usuario> listausuario = new List<Usuario>();

            foreach (MA_USUARIO u in listausuariooriginal)
            {
                Usuario usuario = new Usuario();

                usuario.cod_usuario = u.cod_usuario;
                usuario.e_mail = u.e_mail;
                usuario.senha = u.senha;
                
                listausuario.Add(usuario);
            }

            JsonResult jsonResult = Json(new
            {
                data = listausuario
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult Add(List<Usuario> listausuario)
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
                MA_USUARIO usuario = new MA_USUARIO();

                usuario.e_mail = listausuario[0].e_mail;
                usuario.senha = listausuario[0].senha;

                //Parametriza o usuário com nivel de acesso web e código de status 1
                usuario.cod_acesso = 1;
                usuario.cod_status = 1;

                try
                {
                    if (GestorDeUsuario.VerificarExistenciaDeUsuarioPorEmail(usuario.e_mail))
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Boolean resultado = this.GestorDeUsuario.InserirUsuarioComRetorno(usuario);

                        if (resultado)
                        {
                            jsonResult = Json(new
                            {
                                codigo = usuario.cod_usuario
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

        public ActionResult Update(List<Usuario> listausuario)
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
                MA_USUARIO usuario = new MA_USUARIO();

                usuario.cod_usuario = listausuario[0].cod_usuario;
                usuario.e_mail = listausuario[0].e_mail;
                usuario.senha = listausuario[0].senha;
                usuario.cod_acesso = 1;
                usuario.cod_status = 1;

                try
                {
                    Boolean resultado = this.GestorDeUsuario.AtualizarUsuarioComRetorno(usuario);

                    if (resultado)
                    {
                        jsonResult = Json(new
                        {
                            codigo = usuario.cod_usuario
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