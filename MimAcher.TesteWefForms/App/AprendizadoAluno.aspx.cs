using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.TesteWefForms.App
{
    public partial class AprendizadoAluno : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeAprendizadoDeAluno GestorDeAprendizadoDeAluno { get; set; }
        public GestorDeAluno GestorDeAluno { get; set; }
        public GestorDeAprender GestorDeAprender { get; set; }

        public AprendizadoAluno()
        {
            //Inicialização dos Gestores
            this.GestorDeAprendizadoDeAluno = new GestorDeAprendizadoDeAluno();
            this.GestorDeAluno = new GestorDeAluno();
            this.GestorDeAprender = new GestorDeAprender();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreAprendizadoAlunoId.DataSource = this.GestorDeAprendizadoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_APRENDER.nome);
                this.StoreAprendizadoAlunoId.DataBind();

                this.StoreAlunoId.DataSource = this.GestorDeAluno.ObterTodosOsAlunos().OrderBy(l => l.nome);
                this.StoreAlunoId.DataBind();

                this.StoreAprendizadoId.DataSource = this.GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender().OrderBy(l => l.nome);
                this.StoreAprendizadoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.AprendizadoAlunoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreAprendizadoAlunoId.DataSource = this.GestorDeAprendizadoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_APRENDER.nome);
            this.StoreAprendizadoAlunoId.DataBind();
        }

        //Lista os Aprendizados de Alunos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreAprendizadoAlunoId.DataSource = this.GestorDeAprendizadoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_APRENDER.nome);
            this.StoreAprendizadoAlunoId.DataBind();
        }

        //Lista os Aprendizados de Alunos do banco de dados na grid
        protected void List()
        {
            this.GestorDeAprendizadoDeAluno = new GestorDeAprendizadoDeAluno();
            this.StoreAprendizadoAlunoId.DataSource = this.GestorDeAprendizadoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_APRENDER.nome);
            this.StoreAprendizadoAlunoId.DataBind();
        }

        //Cadastro do Aprendizados de Alunos no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ALUNO_APRENDER alunoaprender = new MA_ALUNO_APRENDER();

            
            alunoaprender.cod_al = Int32.Parse(this.cod_alId.SelectedItem.Value);
            alunoaprender.cod_a = Int32.Parse(this.cod_aId.SelectedItem.Value);
            
            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_aaId.Text == "")
            {
                GestorDeAprendizadoDeAluno.InserirNovoAprendizadoDeAluno(alunoaprender);
                this.AprendizadoAlunoWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                alunoaprender.cod_aa = Int32.Parse(this.cod_aaId.Text);
                GestorDeAprendizadoDeAluno.AtualizarAprendizadoDeAluno(alunoaprender);
                this.AprendizadoAlunoWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoalunoaprender = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.AprendizadoAlunoWindowId.Show();
        }

        //Exclui determinado aprendizado de aluno do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ALUNO_APRENDER alunoaprender = new MA_ALUNO_APRENDER();
            alunoaprender = GestorDeAprendizadoDeAluno.ObterAprendizadoDoAlunoPorId(Int32.Parse(this.cod_aaId.Text));
            GestorDeAprendizadoDeAluno.RemoverAprendizadoDeAluno(alunoaprender);
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