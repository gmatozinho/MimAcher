using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

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
            List<MA_USUARIO> listausuario = GestorDeUsuario.ObterTodosOsUsuarios();

            JsonResult jsonResult = Json(new
            {
                data = listausuario
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}