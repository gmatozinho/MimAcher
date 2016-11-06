using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class Campus : Page
    {
        //Declaração dos Gestores        
        public GestorDeCampus GestorDeCampus { get; set; }

        public Campus()
        {
            //Inicialização dos Gestores            
            GestorDeCampus = new GestorDeCampus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreCampusId.DataSource = GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
                StoreCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            CampusWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreCampusId.DataSource = GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
            StoreCampusId.DataBind();
        }

        //Lista os campuss do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreCampusId.DataSource = GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
            StoreCampusId.DataBind();
        }

        //Lista os campuss do banco de dados na grid
        protected void List()
        {
            GestorDeCampus = new GestorDeCampus();
            StoreCampusId.DataSource = GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
            StoreCampusId.DataBind();
        }

        //Cadastro do campus no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_CAMPUS campus = new MA_CAMPUS();

            campus.local = localId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_campusId.Text == "")
            {
                GestorDeCampus.InserirCampus(campus);
                CampusWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                campus.cod_campus = Int32.Parse(cod_campusId.Text);
                GestorDeCampus.AtualizarCampus(campus);
                CampusWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            CampusWindowId.Show();
        }

        //Exclui determinado campus do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {            
            MA_CAMPUS campus = GestorDeCampus.ObterCampusPorId(Int32.Parse(cod_campusId.Text));
            GestorDeCampus.RemoverCampus(campus);
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