using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Infra;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class AlunoController : Controller
    {
        public GestorDeParticipante GestorDeAluno { get; set; }

        public AlunoController()
        {
            this.GestorDeAluno = new GestorDeParticipante();
        }

        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ALUNO> listaalunooriginal = GestorDeAluno.ObterTodosOsAlunos();
            List<Aluno> listaaluno = new List<Aluno>();

            foreach(MA_ALUNO al in listaalunooriginal)
            {
                Aluno aluno = new Aluno();

                aluno.cod_al = al.cod_al;
                aluno.cod_us = al.cod_us;
                aluno.dt_nascimento = al.dt_nascimento.ToString();
                aluno.e_mail = al.e_mail;
                aluno.nome = al.nome;
                aluno.telefone = al.telefone;
                aluno.latitude = al.geolocalizacao.Latitude;
                aluno.longitude = al.geolocalizacao.Longitude;

                listaaluno.Add(aluno);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaaluno
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

    }
}