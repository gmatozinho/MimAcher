using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Infra;
using MimAcher.Aplicacao;
    

namespace MimAcher.Apresentacao.App
{
    public partial class ImagemUsuarioUsuario : System.Web.UI.Page
    {

        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeImagemDeParticipante GestorDeImagemDeUsuario { get; set; }

        public ImagemUsuarioUsuario()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeImagemDeUsuario = new GestorDeImagemDeParticipante();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.login);
                this.StoreUsuarioId.DataBind();

                this.StoreImagemUsuarioId.DataSource = this.GestorDeImagemDeUsuario.ObterTodosOsImagens().OrderBy(l => l.MA_USUARIO.login);
                this.StoreImagemUsuarioId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ImagemUsuarioWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreImagemUsuarioId.DataSource = this.GestorDeImagemDeUsuario.ObterTodosOsImagens().OrderBy(l => l.MA_USUARIO.login);
            this.StoreImagemUsuarioId.DataBind();
        }

        //Lista os imagems do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreImagemUsuarioId.DataSource = this.GestorDeImagemDeUsuario.ObterTodosOsImagens().OrderBy(l => l.MA_USUARIO.login);
            this.StoreImagemUsuarioId.DataBind();
        }

        //Lista os imagems do banco de dados na grid
        protected void List()
        {
            this.GestorDeImagemDeUsuario = new GestorDeImagemDeParticipante();
            this.StoreImagemUsuarioId.DataSource = this.GestorDeImagemDeUsuario.ObterTodosOsImagens().OrderBy(l => l.MA_USUARIO.login);
            this.StoreImagemUsuarioId.DataBind();
        }

        //Cadastro do imagem no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_IMAGEM_USUARIO imagem = new MA_IMAGEM_USUARIO();
                        
            imagem.cod_us = Int32.Parse(this.cod_usId.SelectedItem.Value);
            
            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_iId.Text == "")
            {
                GestorDeImagemDeUsuario.InserirImagem(imagem);
                this.ImagemUsuarioWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                imagem.cod_i = Int32.Parse(this.cod_iId.Text);
                GestorDeImagemDeUsuario.AtualizarImagem(imagem);
                this.ImagemUsuarioWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoimagem = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.ImagemUsuarioWindowId.Show();
        }

        //Exclui determinado imagem do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_IMAGEM_USUARIO imagem = new MA_IMAGEM_USUARIO();
            imagem = GestorDeImagemDeUsuario.ObterImagemDeUsuarioPorId(Int32.Parse(this.cod_iId.Text));
            GestorDeImagemDeUsuario.RemoverImagem(imagem);
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
