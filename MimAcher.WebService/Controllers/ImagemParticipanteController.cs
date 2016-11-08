using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.WebService.Controllers
{
    public class ImagemParticipanteController : Controller
    {
        public GestorDeImagemDeParticipante GestorDeImagemDeParticipante { get; set; }

        public ImagemParticipanteController()
        {
            GestorDeImagemDeParticipante = new GestorDeImagemDeParticipante();
        }

        // GET: ImagemUsuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_IMAGEM_PARTICIPANTE> listaimagemparticipante = GestorDeImagemDeParticipante.ObterTodosOsImagens();

            JsonResult jsonResult = Json(new
            {
                data = listaimagemparticipante
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}