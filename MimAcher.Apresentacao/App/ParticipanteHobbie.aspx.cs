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
    public partial class ParticipanteHobbie : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeHobbieDeParticipante GestorDeHobbieDeParticipante { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeItem GestorDeItem { get; set; }

        public ParticipanteHobbie()
        {
            //Inicialização dos Gestores            
            this.GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeItem = new GestorDeItem();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
                this.StoreParticipanteHobbieId.DataBind();

                this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                this.StoreParticipanteId.DataBind();

                this.StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                this.StoreItemId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de hobbie de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ParticipanteHobbieWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            this.StoreParticipanteHobbieId.DataBind();
        }

        //Lista os hobbies de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            this.StoreParticipanteHobbieId.DataBind();
        }

        //Lista os hobbies de participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
            this.StoreParticipanteHobbieId.DataSource = this.GestorDeHobbieDeParticipante.ObterTodosOsRegistros();
            this.StoreParticipanteHobbieId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_HOBBIE hobbieparticipante = new MA_PARTICIPANTE_HOBBIE();
                        
            hobbieparticipante.cod_participante = Int32.Parse(this.cod_participanteId.SelectedItem.Value);
            hobbieparticipante.cod_item = Int32.Parse(this.cod_itemId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo hobbie de participante
            if (this.cod_p_hobbieId.Text == "")
            {
                GestorDeHobbieDeParticipante.InserirNovoParticipanteHobbie(hobbieparticipante);
                this.ParticipanteHobbieWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                hobbieparticipante.cod_p_hobbie = Int32.Parse(this.cod_p_hobbieId.Text);
                GestorDeHobbieDeParticipante.AtualizarHobbieDoParticipante(hobbieparticipante);
                this.ParticipanteHobbieWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigohobbieparticipante = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.ParticipanteHobbieWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE_HOBBIE hobbieparticipante = new MA_PARTICIPANTE_HOBBIE();
            hobbieparticipante = GestorDeHobbieDeParticipante.ObterHobbieDoParticipantePorId(Int32.Parse(this.cod_p_hobbieId.Text));
            GestorDeHobbieDeParticipante.RemoverHobbieDoParticipante(hobbieparticipante);
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