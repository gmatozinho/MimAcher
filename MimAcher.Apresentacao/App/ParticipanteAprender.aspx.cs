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
    public partial class ParticipanteAprender : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeParticipanteAprender GestorDeParticipanteAprender { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeItem GestorDeItem { get; set; }

        public ParticipanteAprender()
        {
            //Inicialização dos Gestores            
            this.GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeItem = new GestorDeItem();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
                this.StoreParticipanteAprenderId.DataBind();

                this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                this.StoreParticipanteId.DataBind();

                this.StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                this.StoreItemId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de aprender de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ParticipanteAprenderWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
            this.StoreParticipanteAprenderId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
            this.StoreParticipanteAprenderId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
            this.StoreParticipanteAprenderId.DataSource = this.GestorDeParticipanteAprender.ObterTodosOsRegistros();
            this.StoreParticipanteAprenderId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_APRENDER aprenderparticipante = new MA_PARTICIPANTE_APRENDER();

            aprenderparticipante.cod_participante = Int32.Parse(this.cod_participanteId.SelectedItem.Value);
            aprenderparticipante.cod_item = Int32.Parse(this.cod_itemId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo aprender de participante
            if (this.cod_p_aprenderId.Text == "")
            {
                GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipante(aprenderparticipante);
                this.ParticipanteAprenderWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                aprenderparticipante.cod_p_aprender = Int32.Parse(this.cod_p_aprenderId.Text);
                GestorDeParticipanteAprender.AtualizarAprendizadoDeParticipante(aprenderparticipante);
                this.ParticipanteAprenderWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            this.ParticipanteAprenderWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_APRENDER aprenderparticipante = GestorDeParticipanteAprender.ObterAprendizadoDoParticipantePorId(Int32.Parse(this.cod_p_aprenderId.Text));
            GestorDeParticipanteAprender.RemoverAprendizadoDeParticipante(aprenderparticipante);
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