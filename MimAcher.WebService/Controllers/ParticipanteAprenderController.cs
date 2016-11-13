using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class ParticipanteAprenderController : Controller
    {
        public GestorDeParticipanteAprender GestorDeParticipanteAprender { get; set; }

        public ParticipanteAprenderController()
        {
            GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
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
                participanteaprender.cod_s_relacao = pe.cod_s_relacao;

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
            foreach (ParticipanteAprender pe in listaparticipanteaprender)
            {
                MA_PARTICIPANTE_APRENDER participanteaprender = new MA_PARTICIPANTE_APRENDER();
                participanteaprender.cod_participante = pe.cod_participante;
                participanteaprender.cod_item = pe.cod_item;
                participanteaprender.cod_s_relacao = pe.cod_s_relacao;

                GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipante(participanteaprender);
            }

            jsonResult = Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Update(List<ParticipanteAprender> listaparticipanteaprender)
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
            foreach (ParticipanteAprender pe in listaparticipanteaprender)
            {
                MA_PARTICIPANTE_APRENDER participanteaprender = new MA_PARTICIPANTE_APRENDER();
                participanteaprender.cod_p_aprender = pe.cod_p_aprender;
                participanteaprender.cod_participante = pe.cod_participante;
                participanteaprender.cod_item = pe.cod_item;
                participanteaprender.cod_s_relacao = pe.cod_s_relacao;

                GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipante(participanteaprender);
            }

            jsonResult = Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Delete(List<ParticipanteAprender> listaparticipanteaprender)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipanteaprender == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                foreach (ParticipanteAprender pa in listaparticipanteaprender)
                {
                    if (pa.cod_s_relacao == 2)
                    {
                        MA_PARTICIPANTE_APRENDER participanteaprender = new MA_PARTICIPANTE_APRENDER();

                        participanteaprender.cod_p_aprender = pa.cod_p_aprender;
                        participanteaprender.cod_participante = pa.cod_participante;
                        participanteaprender.cod_item = pa.cod_item;
                        participanteaprender.cod_s_relacao = pe.cod_s_relacao;

                        this.GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipante(participanteaprender);

                        jsonResult = Json(new
                        {
                            codigo = participanteaprender.cod_p_aprender
                        }, JsonRequestBehavior.AllowGet);

                        jsonResult.MaxJsonLength = int.MaxValue;
                        return jsonResult;
                    }
                }

                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }
    }
}