using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Infra;

namespace MimAcher.Apresentacao.App
{
    public partial class Usuario : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public Usuario()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                //this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.login);
                //this.StoreUsuarioId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.UsuarioWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.login);
            this.StoreUsuarioId.DataBind();
        }

        //Lista os usuários do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.login);
            this.StoreUsuarioId.DataBind();
        }

        //Lista os usuários do banco de dados na grid
        protected void List()
        {
            this.GestorDeUsuario = new GestorDeUsuario();
            this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.login);
            this.StoreUsuarioId.DataBind();
        }

        //Cadastro do usuário no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            Usuario usuario = new Usuario();
            
            //Caso o form não possui código, será inserido um novo usuário
            /*if (this.cd_usuarioId.Text == "")
            {
                GestorDeUsuario.InserirUsuario(usuario);
                this.UsuarioWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                //usuario.cd_usuario = Int32.Parse(this.cd_usuarioId.Text);
                GestorDeUsuario.AtualizarUsuario(usuario);
                this.UsuarioWindowId.Close();
                this.LimpaForm();
            }*/
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            //var tipousuario = JSON.Deserialize(e.ExtraParams["RecordGrid"]);
            var tipousuario = Int32.Parse(e.ExtraParams["RecordGrid"]);
            

            this.UsuarioWindowId.Show();
        }

        //Exclui determinado usuário do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            Usuario usuario = new Usuario();
            //usuario = GestorDeUsuario.ObterUsuarioPorId(Int32.Parse(this.cd_usuarioId.Text));
            //GestorDeUsuario.RemoverUsuario(usuario);
            this.LimpaForm();
        }

        //Limpa o formulário
        protected void LimpaForm()
        {
            this.EditButtonId.Disable(true);
            this.DeleteButtonId.Disable(true);
            this.List();
        }
    }
}