using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.WebService.Controllers
{
    public class AlunoGostoController : Controller
    {
        public GestorDeGostoDeAluno GestorDeGostoDeAluno { get; set; }

        public AlunoGostoController()
        {
            this.GestorDeGostoDeAluno = new GestorDeGostoDeAluno();
        }

        // GET: AlunoGosto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ALUNO_GOSTO> listagostoaluno = GestorDeGostoDeAluno.ObterTodosOsRegistros();

            JsonResult jsonResult = Json(new
            {
                data = listagostoaluno
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}