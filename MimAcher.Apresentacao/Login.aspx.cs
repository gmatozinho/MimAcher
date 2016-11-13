using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao
{
    public partial class Login : System.Web.UI.Page
    {
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public Login()
        {
            this.GestorDeUsuario = new GestorDeUsuario();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica se existe algum conteúdo na variável de sessão e sim, pula a página de login
            if ((MA_USUARIO)Session["usuario"] != null)
            {
                MA_USUARIO usuario = (MA_USUARIO)Session["usuario"];

                Session.Add("usuario", usuario);
                this.LoginWindowId.Close();                
                Response.Redirect("/App/Usuario.aspx");
            }
        }

        protected void Logar_Click(object sender, DirectEventArgs e)
        {
            //Captura o conteúdo das variáveis de login e senha
            string email = emailId.Text;
            string senha = senhaId.Text;

            //Se os campos de login e senha estiverem não preenchidos, emite um aviso
            if (String.IsNullOrEmpty(this.emailId.Text) || String.IsNullOrEmpty(this.senhaId.Text))
            {
                X.Msg.Alert("Erro", "Digite Email e Senha!").Show();
            }
            else
            {
                //Senão, verifica se o usuário e senha digitados são correspondentes a alguém do banco de dados
                if (GestorDeUsuario.VerificarExistenciaDeUsuarioPorEmailESenha(email, senha))
                {
                    MA_USUARIO usuario = GestorDeUsuario.ObterUsuarioPorEmailESenha(email, senha);

                    Session.Add("usuario", usuario);
                    this.LoginWindowId.Close();                    
                    Response.Redirect("/App/Usuario.aspx");
                }
                //Senão, informe que o usuário e senha está inválidos.
                else
                {
                    X.Msg.Alert("Erro", "Senha/Email inválidos... tente novamente...").Show();
                }
            }
        }
    }
}