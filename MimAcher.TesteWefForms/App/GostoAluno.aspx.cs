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
    public partial class GostoAluno : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeGostoDeAluno GestorDeGostoDeAluno { get; set; }
        public GestorDeAluno GestorDeAluno { get; set; }
        public GestorDeAprender GestorDeAprender { get; set; }

        public GostoAluno()
        {
            //Inicialização dos Gestores
            this.GestorDeGostoDeAluno = new GestorDeGostoDeAluno();
            this.GestorDeAluno = new GestorDeAluno();
            this.GestorDeAprender = new GestorDeAprender();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreGostoAlunoId.DataSource = this.GestorDeGostoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_GOSTO.nome);
                this.StoreGostoAlunoId.DataBind();

                this.StoreAlunoId.DataSource = this.GestorDeAluno.ObterTodosOsAlunos().OrderBy(l => l.nome);
                this.StoreAlunoId.DataBind();

                this.StoreGostoId.DataSource = this.GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender().OrderBy(l => l.nome);
                this.StoreGostoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.GostoAlunoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreGostoAlunoId.DataSource = this.GestorDeGostoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_GOSTO.nome);
            this.StoreGostoAlunoId.DataBind();
        }

        //Lista os Gostos de Alunos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreGostoAlunoId.DataSource = this.GestorDeGostoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_GOSTO.nome);
            this.StoreGostoAlunoId.DataBind();
        }

        //Lista os Gostos de Alunos do banco de dados na grid
        protected void List()
        {
            this.GestorDeGostoDeAluno = new GestorDeGostoDeAluno();
            this.StoreGostoAlunoId.DataSource = this.GestorDeGostoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_GOSTO.nome);
            this.StoreGostoAlunoId.DataBind();
        }

        //Cadastro do Aprendizados de Alunos no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ALUNO_GOSTO alunogosto = new MA_ALUNO_GOSTO();
            
            alunogosto.cod_al = Int32.Parse(this.cod_alId.SelectedItem.Value);
            alunogosto.cod_g = Int32.Parse(this.cod_gId.SelectedItem.Value);

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_alId.Text == "")
            {
                GestorDeGostoDeAluno.InserirNovoGostoDeAluno(alunogosto);
                this.GostoAlunoWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                alunogosto.cod_ag = Int32.Parse(this.cod_agId.Text);
                GestorDeGostoDeAluno.AtualizarGostoDeAluno(alunogosto);
                this.GostoAlunoWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoalunogosto = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.GostoAlunoWindowId.Show();
        }

        //Exclui determinado aprendizado de aluno do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ALUNO_GOSTO alunogosto = new MA_ALUNO_GOSTO();
            alunogosto = GestorDeGostoDeAluno.ObterGostoDoAlunoPorId(Int32.Parse(this.cod_agId.Text));
            GestorDeGostoDeAluno.RemoverGostoDeAluno(alunogosto);
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