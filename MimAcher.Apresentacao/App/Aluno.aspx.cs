using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Infra;
using MimAcher.Aplicacao;
using System.Data.Entity.Spatial;

namespace MimAcher.Apresentacao.App
{
    public partial class Aluno : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeAluno GestorDeAluno { get; set; }
        
        public Aluno()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeAluno = new GestorDeAluno();            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.login);
                this.StoreUsuarioId.DataBind();

                this.StoreAlunoId.DataSource = this.GestorDeAluno.ObterTodosOsAlunos().OrderBy(l => l.nome);
                this.StoreAlunoId.DataBind();                
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.AlunoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreAlunoId.DataSource = this.GestorDeAluno.ObterTodosOsAlunos().OrderBy(l => l.nome);
            this.StoreAlunoId.DataBind();
        }

        //Lista os alunos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreAlunoId.DataSource = this.GestorDeAluno.ObterTodosOsAlunos().OrderBy(l => l.nome);
            this.StoreAlunoId.DataBind();
        }

        //Lista os alunos do banco de dados na grid
        protected void List()
        {
            this.GestorDeAluno = new GestorDeAluno();
            this.StoreAlunoId.DataSource = this.GestorDeAluno.ObterTodosOsAlunos().OrderBy(l => l.nome);
            this.StoreAlunoId.DataBind();
        }

        //Cadastro do aluno no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ALUNO aluno = new MA_ALUNO();

            aluno.nome = this.nomeId.Text;
            aluno.dt_nascimento = (DateTime) this.dt_nascimentoId.Value;
            aluno.telefone = Int32.Parse(this.telefoneId.Text);
            aluno.e_mail = this.e_mailId.Text;
            aluno.cod_us = Int32.Parse(this.cod_usId.SelectedItem.Value);
            aluno.geolocalizacao = DbGeography.FromText("POINT(" + longitudeId.Value + "  " + latitudeId.Value + ")");
            
            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_alId.Text == "")
            {
                GestorDeAluno.InserirAluno(aluno);
                this.AlunoWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                aluno.cod_al = Int32.Parse(this.cod_alId.Text);
                GestorDeAluno.AtualizarAluno(aluno);                
                this.AlunoWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {   
            int codigoaluno = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.AlunoWindowId.Show();            
        }

        //Exclui determinado aluno do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ALUNO aluno = new MA_ALUNO();
            aluno = GestorDeAluno.ObterAlunoPorId(Int32.Parse(this.cod_alId.Text));
            GestorDeAluno.RemoverAluno(aluno);
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