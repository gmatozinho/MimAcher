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
    public class ParticipanteAprenderController : Controller
    {
        public GestorDeParticipanteAprender GestorDeParticipanteAprender { get; set; }

        public ParticipanteAprenderController()
        {
            this.GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
        }

        // GET: ParticipanteAprender
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE_APRENDER> listaparticipanteaprenderoriginal = GestorDeParticipanteAprender.ObterTodosOsRegistros();
            List<ParticipanteAprender> listaparticipanteaprender = new List<ParticipanteAprender>();

            foreach (MA_PARTICIPANTE_APRENDER pe in listaparticipanteaprenderoriginal)
            {
                ParticipanteAprender participanteaprender = new ParticipanteAprender();

                participanteaprender.cod_p_aprender = pe.cod_p_aprender;
                participanteaprender.cod_participante = pe.cod_participante;
                participanteaprender.cod_item = pe.cod_item;

                listaparticipanteaprender.Add(participanteaprender);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipanteaprender
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<ParticipanteAprender> listaparticipanteaprender)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteaprender == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                foreach (ParticipanteAprender pe in listaparticipanteaprender)
                {
                    MA_PARTICIPANTE_APRENDER participanteaprender = new MA_PARTICIPANTE_APRENDER();
                    participanteaprender.cod_participante = pe.cod_participante;
                    participanteaprender.cod_item = pe.cod_item;

                    GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipante(participanteaprender);
                }

                jsonResult = Json(new
                {
                    success = true
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }
    }
}