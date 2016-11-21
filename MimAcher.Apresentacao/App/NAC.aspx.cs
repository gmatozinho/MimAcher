using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class NAC : Page
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
                StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
                StoreUsuarioId.DataBind();

                StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
                StoreNACId.DataBind();

                StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
                StoreCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            NACWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
            StoreNACId.DataBind();
        }

        //Lista os nacs do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
            StoreNACId.DataBind();
        }

        //Lista os nacs do banco de dados na grid
        protected void List()
        {
            this.GestorDeNAC = new GestorDeNAC();
            StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
            StoreNACId.DataBind();
        }

        //Cadastro do nac no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_NAC nac = new MA_NAC();

            nac.nome_representante = nome_representanteId.Text;
            nac.telefone = Int32.Parse(telefoneId.Text);
            nac.cod_campus = Int32.Parse(cod_campusId.SelectedItem.Value);
            nac.cod_usuario = Int32.Parse(cod_usuarioId.SelectedItem.Value);

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_nacId.Text == "")
            {
                GestorDeNAC.InserirNAC(nac);
                NACWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                nac.cod_nac = Int32.Parse(cod_nacId.Text);
                GestorDeNAC.AtualizarNAC(nac);
                NACWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            NACWindowId.Show();
        }

        //Exclui determinado nac do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_NAC nac = this.GestorDeNAC.ObterNACPorId(Int32.Parse(cod_nacId.Text));
            this.GestorDeNAC.RemoverNAC(nac);
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