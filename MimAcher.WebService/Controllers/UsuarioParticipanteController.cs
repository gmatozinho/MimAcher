using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class UsuarioParticipanteController : Controller
    {
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeAplicacao GestorDeAplicacao { get; set; }

        public UsuarioParticipanteController()
        {
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeAplicacao = new GestorDeAplicacao();
        }

        // GET: UsuarioParticipante
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(List<UsuarioParticipante> listausuarioparticipante)
        {
            int codigodoparticipante = 0;
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuarioparticipante == null)
            {
                jsonResult = Json(new
                {
                   codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            foreach (UsuarioParticipante up in listausuarioparticipante)
            {
                MA_PARTICIPANTE participante = new MA_PARTICIPANTE();
                MA_USUARIO usuario = new MA_USUARIO();

                usuario.e_mail = up.e_mail;
                usuario.senha = up.senha;

                this.GestorDeUsuario.InserirUsuario(usuario);

                participante.cod_usuario = usuario.cod_usuario;
                participante.cod_campus = up.cod_participante;
                participante.nome = up.nome;
                participante.telefone = up.telefone;
                participante.dt_nascimento = (DateTime)up.dt_nascimento;                    
                participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(up.latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(up.longitude.ToString()) + ")");

                this.GestorDeParticipante.InserirParticipante(participante);

                codigodoparticipante = participante.cod_participante;
            }

            jsonResult = Json(new
            {
                codigo = codigodoparticipante
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}