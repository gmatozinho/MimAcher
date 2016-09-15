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
    public class EnsinarController : Controller
    {
        public GestorDeEnsinar GestorDeEnsinar { get; set; }

        public EnsinarController()
        {
            this.GestorDeEnsinar = new GestorDeEnsinar();
        }

        // GET: Ensinar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_ENSINAR> listaensinooriginal = GestorDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado();
            List<Ensinar> listaensinar = new List<Ensinar>();

            foreach(MA_ENSINAR e in listaensinooriginal)
            {
                Ensinar ensinar = new Ensinar();

                ensinar.cod_e = e.cod_e;
                ensinar.nome = e.nome;

                listaensinar.Add(ensinar);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaensinar
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}