using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class ParticipanteAprender : Page
    {
        //Declaração dos Gestores        
        public GestorDeParticipanteAprender GestorDeParticipanteAprender { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeItem GestorDeItem { get; set; }
        public GestorDeStatusDeRelacao GestorDeStatusDeRelacao { get; set; }

        public ParticipanteAprender()
        {
            //Inicialização dos Gestores            
            this.GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeItem = new GestorDeItem();
            this.GestorDeStatusDeRelacao = new GestorDeStatusDeRelacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
                StoreParticipanteAprenderId.DataBind();

                StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                StoreParticipanteId.DataBind();

                StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                StoreItemId.DataBind();

                StoreStatusRelacaoId.DataSource = this.GestorDeStatusDeRelacao.ObterTodosOsStatusDeRelacao();
                StoreStatusRelacaoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de aprender de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            ParticipanteAprenderWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
            StoreParticipanteAprenderId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
            StoreParticipanteAprenderId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List()
        {
            GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
            StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
            StoreParticipanteAprenderId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_APRENDER aprenderparticipante = new MA_PARTICIPANTE_APRENDER();

            aprenderparticipante.cod_participante = Int32.Parse(cod_participanteId.SelectedItem.Value);
            aprenderparticipante.cod_item = Int32.Parse(cod_itemId.SelectedItem.Value);
            aprenderparticipante.cod_s_relacao = Int32.Parse(cod_s_relacaoId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo aprender de participante
            if (cod_p_aprenderId.Text == "")
            {
                this.GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipante(aprenderparticipante);
                ParticipanteAprenderWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                aprenderparticipante.cod_p_aprender = Int32.Parse(cod_p_aprenderId.Text);
                this.GestorDeParticipanteAprender.AtualizarAprendizadoDeParticipante(aprenderparticipante);
                ParticipanteAprenderWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            ParticipanteAprenderWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_APRENDER aprenderparticipante = this.GestorDeParticipanteAprender.ObterAprendizadoDoParticipantePorId(Int32.Parse(cod_p_aprenderId.Text));
            this.GestorDeParticipanteAprender.RemoverAprendizadoDeParticipante(aprenderparticipante);
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