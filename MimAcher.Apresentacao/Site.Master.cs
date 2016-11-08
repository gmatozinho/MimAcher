using System;
using System.Web.UI;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao
{
    public partial class SiteMaster : MasterPage
    {
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeNAC GestorDeNAC { get; set; }

        public SiteMaster()
        {
            GestorDeUsuario = new GestorDeUsuario();
            GestorDeParticipante = new GestorDeParticipante();
            GestorDeNAC = new GestorDeNAC();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((MA_USUARIO)Session["usuario"] != null)
            {
                MA_USUARIO usuario = (MA_USUARIO)Session["usuario"];
                                
                //Coloca a informação com o email do usuário logado no cabeçalho
                labelUsuarioEmail.Text = usuario.e_mail;

                if (GestorDeParticipante.VerificarSeUsuarioJaTemVinculoComAlgumParticipante(usuario.cod_usuario))
                {
                    //Coloca a informação com o nome do Participante no cabeçalho
                    labelParticipanteNome.Text = GestorDeParticipante.ObterParticipantePorIdDeUsuario(usuario.cod_usuario).nome;
                    labelParticipanteNome.Hidden = false;
                }

                if (GestorDeNAC.VerificarSeNACTemAlgumParticipanteComMesmoUsuario(usuario.cod_usuario))
                {
                    //Coloca a informação com o nome do representante do NAC no cabeçalho
                    labelNACNomeRepresentante.Text = GestorDeNAC.ObterNACPorIdDeUsuario(usuario.cod_usuario).nome_representante;
                    labelNACNomeRepresentante.Hidden = false;
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