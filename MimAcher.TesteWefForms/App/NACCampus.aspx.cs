using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Infra;
using MimAcher.Aplicacao;
using Ext.Net;
using System.Data.Entity.Spatial;

namespace MimAcher.TesteWefForms.App
{
    public partial class NACCampus : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeNACCampus GestorDeNACCampus { get; set; }

        public NACCampus()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeNACCampus = new GestorDeNACCampus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.login);
                this.StoreUsuarioId.DataBind();

                this.StoreNACCampusId.DataSource = this.GestorDeNACCampus.ObterTodosOsNACCampus().OrderBy(l => l.nome_representante);
                this.StoreNACCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.NACCampusWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreNACCampusId.DataSource = this.GestorDeNACCampus.ObterTodosOsNACCampus().OrderBy(l => l.nome_representante);
            this.StoreNACCampusId.DataBind();
        }

        //Lista os naccampuss do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreNACCampusId.DataSource = this.GestorDeNACCampus.ObterTodosOsNACCampus().OrderBy(l => l.nome_representante);
            this.StoreNACCampusId.DataBind();
        }

        //Lista os naccampuss do banco de dados na grid
        protected void List()
        {
            this.GestorDeNACCampus = new GestorDeNACCampus();
            this.StoreNACCampusId.DataSource = this.GestorDeNACCampus.ObterTodosOsNACCampus().OrderBy(l => l.nome_representante);
            this.StoreNACCampusId.DataBind();
        }

        //Cadastro do naccampus no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_NAC_CAMPUS naccampus = new MA_NAC_CAMPUS();

            naccampus.nome_representante = this.nomerepresentanteId.Text;            
            naccampus.cod_us = Int32.Parse(this.cod_usId.SelectedItem.Value);
            naccampus.geolocalizacao = DbGeography.FromText("POINT(" + longitudeId.Value + "  " + latitudeId.Value + ")");

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_ncId.Text == "")
            {
                GestorDeNACCampus.InserirNACCampus(naccampus);
                this.NACCampusWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                naccampus.cod_nc = Int32.Parse(this.cod_ncId.Text);
                GestorDeNACCampus.AtualizarNACCampus(naccampus);
                this.NACCampusWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigonaccampus = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.NACCampusWindowId.Show();
        }

        //Exclui determinado naccampus do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_NAC_CAMPUS naccampus = new MA_NAC_CAMPUS();
            naccampus = GestorDeNACCampus.ObterNACCampusPorId(Int32.Parse(this.cod_ncId.Text));
            GestorDeNACCampus.RemoverNACCampus(naccampus);
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