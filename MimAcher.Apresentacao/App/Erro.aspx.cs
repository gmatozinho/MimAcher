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
    public partial class Erro : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeErro GestorDeErro { get; set; }

        public Erro()
        {
            //Inicialização dos Gestores            
            this.GestorDeErro = new GestorDeErro();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreErroId.DataSource = this.GestorDeErro.ObterTodosOsErros().OrderBy(l => l.tipo);
                this.StoreErroId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ErroWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreErroId.DataSource = this.GestorDeErro.ObterTodosOsErros().OrderBy(l => l.tipo);
            this.StoreErroId.DataBind();
        }

        //Lista os erros do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreErroId.DataSource = this.GestorDeErro.ObterTodosOsErros().OrderBy(l => l.tipo);
            this.StoreErroId.DataBind();
        }

        //Lista os erros do banco de dados na grid
        protected void List()
        {
            this.GestorDeErro = new GestorDeErro();
            this.StoreErroId.DataSource = this.GestorDeErro.ObterTodosOsErros().OrderBy(l => l.tipo);
            this.StoreErroId.DataBind();
        }

        //Cadastro do erro no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ERRO erro = new MA_ERRO();

            erro.tipo = this.tipoId.Text;
            erro.aconteceu = this.aconteceuId.Text;
            erro.incidencia = Int32.Parse(this.aconteceuId.Text);
            erro.dt_acontecimento = (DateTime)this.dt_acontecimentoId.Value;

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_erroId.Text == "")
            {
                this.GestorDeErro.InserirErro(erro);
                this.ErroWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                erro.cod_erro = Int32.Parse(this.cod_erroId.Text);
                this.GestorDeErro.AtualizarErro(erro);
                this.ErroWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            this.ErroWindowId.Show();
        }

        //Exclui determinado erro do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ERRO erro = this.GestorDeErro.ObterErroPorId(Int32.Parse(cod_erroId.Text));
            this.GestorDeErro.RemoverErro(erro);
            LimpaForm();
        }

        //Limpa o formulário
        protected void LimpaForm()
        {
            this.EditButtonId.Disable(true);
            this.DeleteButtonId.Disable(true);
            List();
        }
    }
}