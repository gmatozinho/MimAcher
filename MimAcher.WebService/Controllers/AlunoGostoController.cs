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
            List<MA_ALUNO_GOSTO> listagostoalunooriginal = GestorDeGostoDeAluno.ObterTodosOsRegistros();
            List<AlunoGosto> listaalunogosto = new List<AlunoGosto>();

            foreach(MA_ALUNO_GOSTO ag in listagostoalunooriginal)
            {
                AlunoGosto alunogosto = new AlunoGosto();

                alunogosto.cod_ag = ag.cod_ag;
                alunogosto.cod_al = ag.cod_al;
                alunogosto.cod_g = ag.cod_g;

                listaalunogosto.Add(alunogosto);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaalunogosto
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}
