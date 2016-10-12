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
    public class AlunoAprenderController : Controller
    {
        public GestorDeParticipanteAprender GestorDeAprendizadoDeAluno { get; set; }

        public AlunoAprenderController()
        {
            this.GestorDeAprendizadoDeAluno = new GestorDeParticipanteAprender();
        }

        // GET: AlunoAprender
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ALUNO_APRENDER> listaalunoaprendizadooriginal = GestorDeAprendizadoDeAluno.ObterTodosOsRegistros();
            List<AlunoAprender> listaalunoaprender = new List<AlunoAprender>();

            foreach(MA_ALUNO_APRENDER ap in listaalunoaprendizadooriginal)
            {
                AlunoAprender alunoaprender = new AlunoAprender();

                alunoaprender.cod_a = ap.cod_a;
                alunoaprender.cod_aa = ap.cod_aa;
                alunoaprender.cod_al = ap.cod_al;

                listaalunoaprender.Add(alunoaprender);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaalunoaprender
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}