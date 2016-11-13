using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Dominio;
using MimAcher.Aplicacao;

namespace MimAcher.Apresentacao.App
{
    public partial class Campus : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeCampus GestorDeCampus { get; set; }

        public Campus()
        {
            //Inicialização dos Gestores            
            this.GestorDeCampus = new GestorDeCampus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
                this.StoreCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.CampusWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
            this.StoreCampusId.DataBind();
        }

        //Lista os campuss do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
            this.StoreCampusId.DataBind();
        }

        //Lista os campuss do banco de dados na grid
        protected void List()
        {
            this.GestorDeCampus = new GestorDeCampus();
            this.StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
            this.StoreCampusId.DataBind();
        }

        //Cadastro do campus no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_CAMPUS campus = new MA_CAMPUS();

            campus.local = this.localId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_campusId.Text == "")
            {
                GestorDeCampus.InserirCampus(campus);
                this.CampusWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                campus.cod_campus = Int32.Parse(this.cod_campusId.Text);
                GestorDeCampus.AtualizarCampus(campus);
                this.CampusWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            this.CampusWindowId.Show();
        }

        //Exclui determinado campus do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {            
            MA_CAMPUS campus = GestorDeCampus.ObterCampusPorId(Int32.Parse(this.cod_campusId.Text));
            GestorDeCampus.RemoverCampus(campus);
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