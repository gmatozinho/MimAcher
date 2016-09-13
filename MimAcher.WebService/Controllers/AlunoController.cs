using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Infra;

namespace MimAcher.WebService.Controllers
{
    public class AlunoController : Controller
    {
        public GestorDeAluno GestorDeAluno { get; set; }

        public AlunoController()
        {
            this.GestorDeAluno = new GestorDeAluno();
        }

        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ALUNO> listaaluno = GestorDeAluno.ObterTodosOsAlunos();

            JsonResult jsonResult = Json(new
            {
                data = listaaluno
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}