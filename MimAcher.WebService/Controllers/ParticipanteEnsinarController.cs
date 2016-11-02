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
    public class ParticipanteEnsinarController : Controller
    {
        public GestorDeParticipanteEnsinar GestorDeParticipanteEnsinar { get; set; }

        public ParticipanteEnsinarController()
        {
            this.GestorDeParticipanteEnsinar = new GestorDeParticipanteEnsinar();
        }

        // GET: ParticipanteEnsinar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE_ENSINAR> listaparticipanteensinaroriginal = GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            List<ParticipanteEnsinar> listaparticipanteensinar = new List<ParticipanteEnsinar>();

            foreach (MA_PARTICIPANTE_ENSINAR pe in listaparticipanteensinaroriginal)
            {
                ParticipanteEnsinar participanteensinar = new ParticipanteEnsinar();

                participanteensinar.cod_p_ensinar = pe.cod_p_ensinar;
                participanteensinar.cod_participante = pe.cod_participante;
                participanteensinar.cod_item = pe.cod_item;

                listaparticipanteensinar.Add(participanteensinar);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipanteensinar
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<ParticipanteEnsinar> listaparticipanteensinar)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteensinar == null)
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
                foreach (ParticipanteEnsinar pe in listaparticipanteensinar)
                {
                    MA_PARTICIPANTE_ENSINAR participanteensinar = new MA_PARTICIPANTE_ENSINAR();
                    participanteensinar.cod_participante = pe.cod_participante;
                    participanteensinar.cod_item = pe.cod_item;

                    GestorDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(participanteensinar);
                }

                jsonResult = Json(new
                {
                    success = true
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }

        [HttpPost]
        public ActionResult Update(List<ParticipanteEnsinar> listaparticipanteensinar)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteensinar == null)
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
                foreach (ParticipanteEnsinar pe in listaparticipanteensinar)
                {
                    MA_PARTICIPANTE_ENSINAR participanteensinar = new MA_PARTICIPANTE_ENSINAR();
                    participanteensinar.cod_p_ensinar = pe.cod_p_ensinar;
                    participanteensinar.cod_participante = pe.cod_participante;
                    participanteensinar.cod_item = pe.cod_item;

                    GestorDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(participanteensinar);
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