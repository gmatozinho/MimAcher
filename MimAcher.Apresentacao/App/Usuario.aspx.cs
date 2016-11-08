using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class Usuario : Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public Usuario()
        {
            //Inicialização dos Gestores
            GestorDeUsuario = new GestorDeUsuario();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreUsuarioId.DataSource = GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
                StoreUsuarioId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            UsuarioWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreUsuarioId.DataSource = GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
            StoreUsuarioId.DataBind();
        }

        //Lista os usuários do banco de dados na grid
        protected void List()
        {
            GestorDeUsuario = new GestorDeUsuario();
            StoreUsuarioId.DataSource = GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
            StoreUsuarioId.DataBind();
        }

        //Cadastro do usuário no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_USUARIO usuario = new MA_USUARIO();

            usuario.e_mail = e_mailId.Text;
            usuario.senha = senhaId.Text;
            
            //Caso o form não possui código, será inserido um novo usuário
            if (cod_usuarioId.Text == "")
            {
                GestorDeUsuario.InserirUsuario(usuario);
                UsuarioWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                usuario.cod_usuario = Int32.Parse(cod_usuarioId.Text);
                GestorDeUsuario.AtualizarUsuario(usuario);
                UsuarioWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            UsuarioWindowId.Show();
        }

        //Exclui determinado usuário do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_USUARIO usuario = GestorDeUsuario.ObterUsuarioPorId(Int32.Parse(cod_usuarioId.Text));
            GestorDeUsuario.RemoverUsuario(usuario);
            LimpaForm();
        }

        //Limpa o formulário
        protected void LimpaForm()
        {
            EditButtonId.Disable(true);
            DeleteButtonId.Disable(true);
            List();
        }
    }
}