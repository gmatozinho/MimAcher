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
    public partial class Acesso : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeAcesso GestorDeAcesso { get; set; }

        public Acesso()
        {
            //Inicialização dos Gestores            
            this.GestorDeAcesso = new GestorDeAcesso();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreAcessoId.DataSource = this.GestorDeAcesso.ObterTodosOsAcessos().OrderBy(l => l.nome);
                StoreAcessoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            AcessoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreAcessoId.DataSource = this.GestorDeAcesso.ObterTodosOsAcessos().OrderBy(l => l.nome);
            StoreAcessoId.DataBind();
        }

        //Lista os acessos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreAcessoId.DataSource = this.GestorDeAcesso.ObterTodosOsAcessos().OrderBy(l => l.nome);
            StoreAcessoId.DataBind();
        }

        //Lista os acessos do banco de dados na grid
        protected void List()
        {
            this.GestorDeAcesso = new GestorDeAcesso();
            StoreAcessoId.DataSource = this.GestorDeAcesso.ObterTodosOsAcessos().OrderBy(l => l.nome);
            StoreAcessoId.DataBind();
        }

        //Cadastro do acesso no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ACESSO acesso = new MA_ACESSO();

            acesso.nome = nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_acessoId.Text == "")
            {
                this.GestorDeAcesso.InserirAcesso(acesso);
                AcessoWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                acesso.cod_acesso = Int32.Parse(cod_acessoId.Text);
                this.GestorDeAcesso.AtualizarAcesso(acesso);
                AcessoWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            AcessoWindowId.Show();
        }

        //Exclui determinado acesso do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ACESSO acesso = this.GestorDeAcesso.ObterAcessoPorId(Int32.Parse(cod_acessoId.Text));
            GestorDeAcesso.RemoverAcesso(acesso);
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