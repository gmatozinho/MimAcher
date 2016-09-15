using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
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

                usuario.cod_us = u.cod_us;
                usuario.identificador = u.identificador;
                usuario.login = u.login;
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
    }
}