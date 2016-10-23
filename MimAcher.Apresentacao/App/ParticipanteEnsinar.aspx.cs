using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Infra;
using MimAcher.Aplicacao;
using Ext.Net;

namespace MimAcher.Apresentacao.App
{
    public partial class ParticipanteEnsinar : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeParticipanteEnsinar GestorDeParticipanteEnsinar { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeItem GestorDeItem { get; set; }

        public ParticipanteEnsinar()
        {
            //Inicialização dos Gestores            
            this.GestorDeParticipanteEnsinar = new GestorDeParticipanteEnsinar();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeItem = new GestorDeItem();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreParticipanteEnsinarId.DataSource = this.GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
                this.StoreParticipanteEnsinarId.DataBind();

                this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                this.StoreParticipanteId.DataBind();

                this.StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                this.StoreItemId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de ensinar de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ParticipanteEnsinarWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreParticipanteEnsinarId.DataSource = this.GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            this.StoreParticipanteEnsinarId.DataBind();
        }

        //Lista os ensinars de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreParticipanteEnsinarId.DataSource = this.GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            this.StoreParticipanteEnsinarId.DataBind();
        }

        //Lista os ensinars de participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeParticipanteEnsinar = new GestorDeParticipanteEnsinar();
            this.StoreParticipanteEnsinarId.DataSource = this.GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            this.StoreParticipanteEnsinarId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_ENSINAR ensinarparticipante = new MA_PARTICIPANTE_ENSINAR();

            ensinarparticipante.cod_participante = Int32.Parse(this.cod_participanteId.SelectedItem.Value);
            ensinarparticipante.cod_item = Int32.Parse(this.cod_itemId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo ensinar de participante
            if (this.cod_p_ensinarId.Text == "")
            {
                GestorDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(ensinarparticipante);
                this.ParticipanteEnsinarWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                ensinarparticipante.cod_p_ensinar = Int32.Parse(this.cod_p_ensinarId.Text);
                GestorDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipante(ensinarparticipante);
                this.ParticipanteEnsinarWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoensinarparticipante = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.ParticipanteEnsinarWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_ENSINAR ensinarparticipante = new MA_PARTICIPANTE_ENSINAR();
            ensinarparticipante = GestorDeParticipanteEnsinar.ObterRelacaoDoQueOParticipanteEnsinaPorId(Int32.Parse(this.cod_p_ensinarId.Text));
            GestorDeParticipanteEnsinar.RemoverEnsinamentoDeParticipante(ensinarparticipante);
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