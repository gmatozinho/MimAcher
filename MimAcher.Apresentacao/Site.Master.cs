using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao
{
    public partial class SiteMaster : MasterPage
    {
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeNac GestorDeNAC { get; set; }

        public SiteMaster()
        {
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeNAC = new GestorDeNac();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((MA_USUARIO)Session["usuario"] != null)
            {
                MA_USUARIO usuario = (MA_USUARIO)Session["usuario"];
                                
                //Coloca a informação com o email do usuário logado no cabeçalho
                this.labelUsuarioEmail.Text = usuario.e_mail;
                this.labelAcesso.Text = usuario.MA_ACESSO.nome;

                if (GestorDeParticipante.VerificarSeUsuarioJaTemVinculoComAlgumParticipante(usuario.cod_usuario))
                {
                    //Coloca a informação com o nome do Participante no cabeçalho
                    this.labelParticipanteNome.Text = GestorDeParticipante.ObterParticipantePorIdDeUsuario(usuario.cod_usuario).nome;
                    this.labelParticipanteNome.Hidden = false;
                }

                if (GestorDeNAC.VerificarSeNacTemAlgumParticipanteComMesmoUsuario(usuario.cod_usuario))
                {
                    //Coloca a informação com o nome do representante do NAC no cabeçalho
                    this.labelNACNomeRepresentante.Text = GestorDeNAC.ObterNacPorIdDeUsuario(usuario.cod_usuario).nome_representante;
                    this.labelNACNomeRepresentante.Hidden = false;
                }
                
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void Sair(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}