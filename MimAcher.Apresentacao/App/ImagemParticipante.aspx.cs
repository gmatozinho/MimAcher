using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Dominio;
using MimAcher.Aplicacao;
using Ext.Net;

namespace MimAcher.Apresentacao.App
{
    public partial class ImagemParticipante : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeImagemDeParticipante GestorDeImagemDeParticipante { get; set; }

        public ImagemParticipante()
        {
            //Inicialização dos Gestores
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeImagemDeParticipante = new GestorDeImagemDeParticipante();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {                
                this.StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
                this.StoreImagemParticipanteId.DataBind();

                this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                this.StoreParticipanteId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ImagemParticipanteWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
            this.StoreImagemParticipanteId.DataBind();
        }

        //Lista os imagems do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
            this.StoreImagemParticipanteId.DataBind();
        }

        //Lista os imagems do banco de dados na grid
        protected void List()
        {
            this.GestorDeImagemDeParticipante = new GestorDeImagemDeParticipante();
            this.StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
            this.StoreImagemParticipanteId.DataBind();
        }

        //Cadastro do imagem no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_IMAGEM_PARTICIPANTE imagem = new MA_IMAGEM_PARTICIPANTE();

            imagem.cod_participante = Int32.Parse(this.cod_participanteId.SelectedItem.Value);

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_imagemId.Text == "")
            {
                GestorDeImagemDeParticipante.InserirImagem(imagem);
                this.ImagemParticipanteWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                imagem.cod_imagem = Int32.Parse(this.cod_imagemId.Text);
                GestorDeImagemDeParticipante.AtualizarImagem(imagem);
                this.ImagemParticipanteWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            this.ImagemParticipanteWindowId.Show();
        }

        //Exclui determinado imagem do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {            
            MA_IMAGEM_PARTICIPANTE  imagem = GestorDeImagemDeParticipante.ObterImagemDeParticipantePorId(Int32.Parse(this.cod_imagemId.Text));
            GestorDeImagemDeParticipante.RemoverImagem(imagem);
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