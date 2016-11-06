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

        public ParticipanteAprender()
        {
            //Inicialização dos Gestores            
            GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
            GestorDeParticipante = new GestorDeParticipante();
            GestorDeItem = new GestorDeItem();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreParticipanteAprenderId.DataSource = GestorDeParticipanteAprender.ObterTodosOsRegistros();
                StoreParticipanteAprenderId.DataBind();

                StoreParticipanteId.DataSource = GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                StoreParticipanteId.DataBind();

                StoreItemId.DataSource = GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                StoreItemId.DataBind();
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
            StoreParticipanteAprenderId.DataSource = GestorDeParticipanteAprender.ObterTodosOsRegistros();
            StoreParticipanteAprenderId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreParticipanteAprenderId.DataSource = GestorDeParticipanteAprender.ObterTodosOsRegistros();
            StoreParticipanteAprenderId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List()
        {
            GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
            StoreParticipanteAprenderId.DataSource = GestorDeParticipanteAprender.ObterTodosOsRegistros();
            StoreParticipanteAprenderId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_APRENDER aprenderparticipante = new MA_PARTICIPANTE_APRENDER();

            aprenderparticipante.cod_participante = Int32.Parse(cod_participanteId.SelectedItem.Value);
            aprenderparticipante.cod_item = Int32.Parse(cod_itemId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo aprender de participante
            if (cod_p_aprenderId.Text == "")
            {
                GestorDeParticipanteAprender.InserirNovoAprendizadoDeParticipante(aprenderparticipante);
                ParticipanteAprenderWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                aprenderparticipante.cod_p_aprender = Int32.Parse(cod_p_aprenderId.Text);
                GestorDeParticipanteAprender.AtualizarAprendizadoDeParticipante(aprenderparticipante);
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
            MA_PARTICIPANTE_APRENDER aprenderparticipante = GestorDeParticipanteAprender.ObterAprendizadoDoParticipantePorId(Int32.Parse(cod_p_aprenderId.Text));
            GestorDeParticipanteAprender.RemoverAprendizadoDeParticipante(aprenderparticipante);
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