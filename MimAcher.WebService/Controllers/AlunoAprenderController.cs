using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.WebService.Controllers
{
    public class AlunoAprenderController : Controller
    {
        public GestorDeAprendizadoDeAluno GestorDeAprendizadoDeAluno { get; set; }

        public AlunoAprenderController()
        {
            this.GestorDeAprendizadoDeAluno = new GestorDeAprendizadoDeAluno();
        }

        // GET: AlunoAprender
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ALUNO_APRENDER> listaalunoaprendizado = GestorDeAprendizadoDeAluno.ObterTodosOsRegistros();

            JsonResult jsonResult = Json(new
            {
                data = listaalunoaprendizado
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}