using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Aplicacao;
using MimAcher.Infra;
using Ext.Net;

namespace MimAcher.Apresentacao.App
{
    public partial class NAC : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeNAC GestorDeNAC { get; set; }
        public GestorDeCampus GestorDeCampus { get; set; }

        public NAC()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeNAC = new GestorDeNAC();
            this.GestorDeCampus = new GestorDeCampus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
                this.StoreUsuarioId.DataBind();

                this.StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
                this.StoreNACId.DataBind();

                this.StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
                this.StoreCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.NACWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
            this.StoreNACId.DataBind();
        }

        //Lista os nacs do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
            this.StoreNACId.DataBind();
        }

        //Lista os nacs do banco de dados na grid
        protected void List()
        {
            this.GestorDeNAC = new GestorDeNAC();
            this.StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
            this.StoreNACId.DataBind();
        }

        //Cadastro do nac no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_NAC nac = new MA_NAC();

            nac.nome_representante = this.nome_representanteId.Text;
            nac.telefone = Int32.Parse(this.telefoneId.Text);
            nac.cod_campus = Int32.Parse(this.cod_campusId.SelectedItem.Value);
            nac.cod_usuario = Int32.Parse(this.cod_usuarioId.SelectedItem.Value);

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_nacId.Text == "")
            {
                GestorDeNAC.InserirNAC(nac);
                this.NACWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                nac.cod_nac = Int32.Parse(this.cod_nacId.Text);
                GestorDeNAC.AtualizarNAC(nac);
                this.NACWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigonac = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.NACWindowId.Show();
        }

        //Exclui determinado nac do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_NAC nac = new MA_NAC();
            nac = GestorDeNAC.ObterNACPorId(Int32.Parse(this.cod_nacId.Text));
            GestorDeNAC.RemoverNAC(nac);
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