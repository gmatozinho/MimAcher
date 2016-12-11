using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class ParticipanteHobbie : Page
    {
        //Declaração dos this.Gestores        
        public GestorDeHobbieDeParticipante GestorDeHobbieDeParticipante { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeItem GestorDeItem { get; set; }
        public GestorDeStatus GestorDeStatus { get; set; }

        public ParticipanteHobbie()
        {
            //Inicialização dos this.Gestores            
            this.GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeItem = new GestorDeItem();
            this.GestorDeStatus = new GestorDeStatus();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
                StoreParticipanteHobbieId.DataBind();

                StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                StoreParticipanteId.DataBind();

                StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                StoreItemId.DataBind();

                StoreStatusId.DataSource = this.GestorDeStatus.ObterTodosOsStatus();
                StoreStatusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de hobbie de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            ParticipanteHobbieWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            StoreParticipanteHobbieId.DataBind();
        }

        //Lista os hobbies de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            StoreParticipanteHobbieId.DataBind();
        }

        //Lista os hobbies de participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
            StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            StoreParticipanteHobbieId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_HOBBIE hobbieparticipante = new MA_PARTICIPANTE_HOBBIE();

            hobbieparticipante.cod_participante = Int32.Parse(cod_participanteId.SelectedItem.Value);
            hobbieparticipante.cod_item = Int32.Parse(cod_itemId.SelectedItem.Value);
            hobbieparticipante.cod_status = Int32.Parse(cod_statusId.SelectedItem.Value);

            //Caso o form não possui código, será inserido um novo hobbie de participante
            if (cod_p_hobbieId.Text == "")
            {
                this.GestorDeHobbieDeParticipante.InserirNovoParticipanteHobbie(hobbieparticipante);
                ParticipanteHobbieWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                hobbieparticipante.cod_p_hobbie = Int32.Parse(cod_p_hobbieId.Text);
                this.GestorDeHobbieDeParticipante.AtualizarHobbieDoParticipante(hobbieparticipante);
                ParticipanteHobbieWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            ParticipanteHobbieWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_HOBBIE hobbieparticipante = this.GestorDeHobbieDeParticipante.ObterHobbieDoParticipantePorId(Int32.Parse(cod_p_hobbieId.Text));
            this.GestorDeHobbieDeParticipante.RemoverHobbieDoParticipante(hobbieparticipante);
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