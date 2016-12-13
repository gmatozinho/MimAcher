using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class Nac : Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeNac GestorDeNac { get; set; }
        public GestorDeCampus GestorDeCampus { get; set; }

        public Nac()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeNac = new GestorDeNac();
            this.GestorDeCampus = new GestorDeCampus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
                StoreUsuarioId.DataBind();

                StoreNacId.DataSource = this.GestorDeNac.ObterTodosOsNac().OrderBy(l => l.nome_representante);
                StoreNacId.DataBind();

                StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
                StoreCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            NacWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreNacId.DataSource = this.GestorDeNac.ObterTodosOsNac().OrderBy(l => l.nome_representante);
            StoreNacId.DataBind();
        }

        //Lista os nacs do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreNacId.DataSource = this.GestorDeNac.ObterTodosOsNac().OrderBy(l => l.nome_representante);
            StoreNacId.DataBind();
        }

        //Lista os nacs do banco de dados na grid
        protected void List()
        {
            this.GestorDeNac = new GestorDeNac();
            StoreNacId.DataSource = this.GestorDeNac.ObterTodosOsNac().OrderBy(l => l.nome_representante);
            StoreNacId.DataBind();
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
                GestorDeNac.InserirNac(nac);
                NacWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                nac.cod_nac = Int32.Parse(cod_nacId.Text);
                GestorDeNac.AtualizarNac(nac);
                NacWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            NacWindowId.Show();
        }

        //Exclui determinado nac do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_NAC nac = this.GestorDeNac.ObterNacPorId(Int32.Parse(cod_nacId.Text));
            this.GestorDeNac.RemoverNac(nac);
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