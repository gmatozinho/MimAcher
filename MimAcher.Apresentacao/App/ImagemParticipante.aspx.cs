using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class ImagemParticipante : Page
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
                StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
                StoreImagemParticipanteId.DataBind();

                StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                StoreParticipanteId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            ImagemParticipanteWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
            StoreImagemParticipanteId.DataBind();
        }

        //Lista os imagems do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
            StoreImagemParticipanteId.DataBind();
        }

        //Lista os imagems do banco de dados na grid
        protected void List()
        {
            this.GestorDeImagemDeParticipante = new GestorDeImagemDeParticipante();
            StoreImagemParticipanteId.DataSource = this.GestorDeImagemDeParticipante.ObterTodosOsImagens();
            StoreImagemParticipanteId.DataBind();
        }

        //Cadastro do imagem no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_IMAGEM_PARTICIPANTE imagem = new MA_IMAGEM_PARTICIPANTE();

            imagem.cod_participante = Int32.Parse(cod_participanteId.SelectedItem.Value);

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_imagemId.Text == "")
            {
                this.GestorDeImagemDeParticipante.InserirImagem(imagem);
                ImagemParticipanteWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                imagem.cod_imagem = Int32.Parse(cod_imagemId.Text);
                this.GestorDeImagemDeParticipante.AtualizarImagem(imagem);
                ImagemParticipanteWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            ImagemParticipanteWindowId.Show();
        }

        //Exclui determinado imagem do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_IMAGEM_PARTICIPANTE imagem = this.GestorDeImagemDeParticipante.ObterImagemDeParticipantePorId(Int32.Parse(cod_imagemId.Text));
            this.GestorDeImagemDeParticipante.RemoverImagem(imagem);
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