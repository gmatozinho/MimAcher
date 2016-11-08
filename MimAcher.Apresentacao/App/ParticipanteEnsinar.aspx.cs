using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class ParticipanteEnsinar : Page
    {
        //Declaração dos Gestores        
        public GestorDeParticipanteEnsinar GestorDeParticipanteEnsinar { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeItem GestorDeItem { get; set; }

        public ParticipanteEnsinar()
        {
            //Inicialização dos Gestores            
            GestorDeParticipanteEnsinar = new GestorDeParticipanteEnsinar();
            GestorDeParticipante = new GestorDeParticipante();
            GestorDeItem = new GestorDeItem();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreParticipanteEnsinarId.DataSource = GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
                StoreParticipanteEnsinarId.DataBind();

                StoreParticipanteId.DataSource = GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                StoreParticipanteId.DataBind();

                StoreItemId.DataSource = GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                StoreItemId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de ensinar de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            ParticipanteEnsinarWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreParticipanteEnsinarId.DataSource = GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            StoreParticipanteEnsinarId.DataBind();
        }

        //Lista os ensinars de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreParticipanteEnsinarId.DataSource = GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            StoreParticipanteEnsinarId.DataBind();
        }

        //Lista os ensinars de participantes do banco de dados na grid
        protected void List()
        {
            GestorDeParticipanteEnsinar = new GestorDeParticipanteEnsinar();
            StoreParticipanteEnsinarId.DataSource = GestorDeParticipanteEnsinar.ObterTodosOsRegistros();
            StoreParticipanteEnsinarId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_ENSINAR ensinarparticipante = new MA_PARTICIPANTE_ENSINAR();

            ensinarparticipante.cod_participante = Int32.Parse(cod_participanteId.SelectedItem.Value);
            ensinarparticipante.cod_item = Int32.Parse(cod_itemId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo ensinar de participante
            if (cod_p_ensinarId.Text == "")
            {
                GestorDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(ensinarparticipante);
                ParticipanteEnsinarWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                ensinarparticipante.cod_p_ensinar = Int32.Parse(cod_p_ensinarId.Text);
                GestorDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipante(ensinarparticipante);
                ParticipanteEnsinarWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            ParticipanteEnsinarWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_ENSINAR ensinarparticipante = GestorDeParticipanteEnsinar.ObterRelacaoDoQueOParticipanteEnsinaPorId(Int32.Parse(cod_p_ensinarId.Text));
            GestorDeParticipanteEnsinar.RemoverEnsinamentoDeParticipante(ensinarparticipante);
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