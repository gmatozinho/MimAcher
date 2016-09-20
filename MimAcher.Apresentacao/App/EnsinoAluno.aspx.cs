using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.Apresentacao.App
{
    public partial class EnsinoAluno : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeEnsinoDeAluno GestorDeEnsinoDeAluno { get; set; }
        public GestorDeAluno GestorDeAluno { get; set; }
        public GestorDeEnsinar GestorDeEnsinar { get; set; }

        public EnsinoAluno()
        {
            //Inicialização dos Gestores
            this.GestorDeEnsinoDeAluno = new GestorDeEnsinoDeAluno();
            this.GestorDeAluno = new GestorDeAluno();
            this.GestorDeEnsinar = new GestorDeEnsinar();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreEnsinoAlunoId.DataSource = this.GestorDeEnsinoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_ENSINAR.nome);
                this.StoreEnsinoAlunoId.DataBind();

                this.StoreAlunoId.DataSource = this.GestorDeAluno.ObterTodosOsAlunos().OrderBy(l => l.nome);
                this.StoreAlunoId.DataBind();

                this.StoreEnsinoId.DataSource = this.GestorDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado().OrderBy(l => l.nome);
                this.StoreEnsinoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.EnsinoAlunoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreEnsinoAlunoId.DataSource = this.GestorDeEnsinoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_ENSINAR.nome);
            this.StoreEnsinoAlunoId.DataBind();
        }

        //Lista os Ensinos de Alunos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreEnsinoAlunoId.DataSource = this.GestorDeEnsinoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_ENSINAR.nome);
            this.StoreEnsinoAlunoId.DataBind();
        }

        //Lista os Ensinos de Alunos do banco de dados na grid
        protected void List()
        {
            this.GestorDeEnsinoDeAluno = new GestorDeEnsinoDeAluno();
            this.StoreEnsinoAlunoId.DataSource = this.GestorDeEnsinoDeAluno.ObterTodosOsRegistros().OrderBy(l => l.MA_ENSINAR.nome);
            this.StoreEnsinoAlunoId.DataBind();
        }

        //Cadastro do Aprendizados de Alunos no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ALUNO_ENSINAR alunoensinar = new MA_ALUNO_ENSINAR();


            alunoensinar.cod_al = Int32.Parse(this.cod_alId.SelectedItem.Value);
            alunoensinar.cod_e = Int32.Parse(this.cod_eId.SelectedItem.Value);

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_aeId.Text == "")
            {
                GestorDeEnsinoDeAluno.InserirNovoEnsinamentoDeAluno(alunoensinar);
                this.EnsinoAlunoWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                alunoensinar.cod_ae = Int32.Parse(this.cod_aeId.Text);
                GestorDeEnsinoDeAluno.AtualizarEnsinamentoDeAluno(alunoensinar);
                this.EnsinoAlunoWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoalunoensinar = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.EnsinoAlunoWindowId.Show();
        }

        //Exclui determinado aprendizado de aluno do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ALUNO_ENSINAR alunoensinar = new MA_ALUNO_ENSINAR();
            alunoensinar = GestorDeEnsinoDeAluno.ObterRelacaoDoQueOAlunoEnsinaPorId(Int32.Parse(this.cod_aeId.Text));
            GestorDeEnsinoDeAluno.RemoverEnsinamentoDeAluno(alunoensinar);
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