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
    public class AlunoEnsinarController : Controller
    {
        public GestorDeParticipanteEnsinar GestorDeEnsinoDeAluno { get; set; }

        public AlunoEnsinarController()
        {
            this.GestorDeEnsinoDeAluno = new GestorDeParticipanteEnsinar();
        }

        // GET: AlunoEnsinar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ALUNO_ENSINAR> listaalunoensinooriginal = GestorDeEnsinoDeAluno.ObterTodosOsRegistros();
            List<AlunoEnsinar> listaalunoensinar = new List<AlunoEnsinar>();

            foreach(MA_ALUNO_ENSINAR ae in listaalunoensinooriginal)
            {
                AlunoEnsinar alunoensinar = new AlunoEnsinar();

                alunoensinar.cod_ae = ae.cod_ae;
                alunoensinar.cod_al = ae.cod_al;
                alunoensinar.cod_e = ae.cod_e;

                listaalunoensinar.Add(alunoensinar);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaalunoensinar
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}