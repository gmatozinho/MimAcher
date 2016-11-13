using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class ParticipanteHobbieController : Controller
    {
        public GestorDeHobbieDeParticipante GestorDeHobbieDeParticipante { get; set; }

        public ParticipanteHobbieController()
        {
            this.GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
        }

        // GET: ParticipanteHobbie
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE_HOBBIE> listaparticipantehobbieoriginal = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            List<ParticipanteHobbie> listaparticipantehobbie = new List<ParticipanteHobbie>();

            foreach (MA_PARTICIPANTE_HOBBIE pe in listaparticipantehobbieoriginal)
            {
                ParticipanteHobbie participantehobbie = new ParticipanteHobbie();

                participantehobbie.cod_p_hobbie = pe.cod_p_hobbie;
                participantehobbie.cod_participante = pe.cod_participante;
                participantehobbie.cod_item = pe.cod_item;
                participantehobbie.cod_s_relacao = pe.cod_s_relacao;

                listaparticipantehobbie.Add(participantehobbie);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipantehobbie
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (ParticipanteHobbie pe in listaparticipantehobbie)
            {
                MA_PARTICIPANTE_HOBBIE participantehobbie = new MA_PARTICIPANTE_HOBBIE();
                participantehobbie.cod_participante = pe.cod_participante;
                participantehobbie.cod_item = pe.cod_item;
                participantehobbie.cod_s_relacao = pe.cod_s_relacao;

                this.GestorDeHobbieDeParticipante.InserirNovoParticipanteHobbie(participantehobbie);
            }

            jsonResult = Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Update(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (ParticipanteHobbie pe in listaparticipantehobbie)
            {
                MA_PARTICIPANTE_HOBBIE participantehobbie = new MA_PARTICIPANTE_HOBBIE();
                participantehobbie.cod_p_hobbie = pe.cod_p_hobbie;
                participantehobbie.cod_participante = pe.cod_participante;
                participantehobbie.cod_item = pe.cod_item;
                participantehobbie.cod_s_relacao = pe.cod_s_relacao;

                this.GestorDeHobbieDeParticipante.InserirNovoParticipanteHobbie(participantehobbie);
            }

            jsonResult = Json(new
            {
                success = true
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Delete(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
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
                foreach (ParticipanteHobbie pe in listaparticipantehobbie)
                {
                    if (pe.cod_s_relacao == 2)
                    {
                        MA_PARTICIPANTE_HOBBIE participantehobbie = new MA_PARTICIPANTE_HOBBIE();

                        participantehobbie.cod_p_hobbie = pe.cod_p_hobbie;
                        participantehobbie.cod_participante = pe.cod_participante;
                        participantehobbie.cod_item = pe.cod_item;
                        participantehobbie.cod_s_relacao = pe.cod_s_relacao;

                        this.GestorDeHobbieDeParticipante.InserirNovoParticipanteHobbie(participantehobbie);
                        
                        jsonResult = Json(new
                        {
                            codigo = participantehobbie.cod_p_hobbie
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