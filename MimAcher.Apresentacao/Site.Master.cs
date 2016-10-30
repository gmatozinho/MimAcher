using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Aplicacao;
using MimAcher.Infra;

namespace MimAcher.Apresentacao
{
    public partial class SiteMaster : MasterPage
    {
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }

        public SiteMaster()
        {
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeParticipante = new GestorDeParticipante();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((MA_USUARIO)Session["usuario"] != null)
            {
                MA_USUARIO usuario = (MA_USUARIO)Session["usuario"];

                
                //Coloca as informações do usuário logado no cabeçalho
                this.labelUsuarioEmail.Text = usuario.e_mail;
             
                if(GestorDeUsuario.VerificarSeUsuarioTemVinculoComParticipante(usuario))
                {
                    //this.labelParticipanteNome.Text = usuario.MA_PARTICIPANTE.;                    
                }


                //this.labelEntidade.Text = permissao.Entidade;
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