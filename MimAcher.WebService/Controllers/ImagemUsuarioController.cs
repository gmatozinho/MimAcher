using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.WebService.Controllers
{
    public class ImagemUsuarioController : Controller
    {
        public GestorDeImagemDeParticipante GestorDeImagemDeUsuario { get; set; }

        public ImagemUsuarioController()
        {
            this.GestorDeImagemDeUsuario = new GestorDeImagemDeParticipante();
        }

        // GET: ImagemUsuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_IMAGEM_USUARIO> listaimagemusuario = GestorDeImagemDeUsuario.ObterTodosOsImagens();

            JsonResult jsonResult = Json(new
            {
                data = listaimagemusuario
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}