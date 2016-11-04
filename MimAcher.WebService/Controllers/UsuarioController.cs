using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Dominio;
using MimAcher.Aplicacao;
using MimAcher.WebService.Models;

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
            List<MA_USUARIO> listausuariooriginal = GestorDeUsuario.ObterTodosOsUsuarios();
            List<Usuario> listausuario = new List<Usuario>();

            foreach(MA_USUARIO u in listausuariooriginal)
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
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                foreach (Usuario us in listausuario)
                {
                    MA_USUARIO usuario = new MA_USUARIO();
                    usuario.e_mail = us.e_mail;
                    usuario.senha = us.senha;

                    GestorDeUsuario.InserirUsuario(usuario);
                }

                jsonResult = Json(new
                {
                    success = true
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }

        public ActionResult Update(List<Usuario> listausuario)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuario == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                foreach (Usuario us in listausuario)
                {
                    MA_USUARIO usuario = new MA_USUARIO();
                    usuario.cod_usuario = us.cod_usuario;
                    usuario.e_mail = us.e_mail;
                    usuario.senha = us.senha;

                    GestorDeUsuario.AtualizarUsuario(usuario);
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
}