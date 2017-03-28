using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using Ext.Net;

namespace MimAcher.Apresentacao.App
{
    public partial class Status : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeStatus GestorDeStatus { get; set; }

        public Status()
        {
            //Inicialização dos Gestores            
            this.GestorDeStatus = new GestorDeStatus();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreStatusId.DataSource = this.GestorDeStatus.ObterTodosOsStatus().OrderBy(l => l.nome);
                StoreStatusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            StatusWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreStatusId.DataSource = this.GestorDeStatus.ObterTodosOsStatus().OrderBy(l => l.nome);
            StoreStatusId.DataBind();
        }

        //Lista os status_relacaos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreStatusId.DataSource = this.GestorDeStatus.ObterTodosOsStatus().OrderBy(l => l.nome);
            StoreStatusId.DataBind();
        }

        //Lista os status_relacaos do banco de dados na grid
        protected void List()
        {
            this.GestorDeStatus = new GestorDeStatus();
            StoreStatusId.DataSource = this.GestorDeStatus.ObterTodosOsStatus().OrderBy(l => l.nome);
            StoreStatusId.DataBind();
        }

        //Cadastro do status_relacao no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_STATUS statusRelacao = new MA_STATUS();

            statusRelacao.nome = nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_statusId.Text == "")
            {
                this.GestorDeStatus.InserirStatus(statusRelacao);
                StatusWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                statusRelacao.cod_status = Int32.Parse(cod_statusId.Text);
                this.GestorDeStatus.AtualizarStatus(statusRelacao);
                StatusWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            StatusWindowId.Show();
        }

        //Exclui determinado status_relacao do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_STATUS statusRelacao = this.GestorDeStatus.ObterStatusPorId(Int32.Parse(cod_statusId.Text));
            this.GestorDeStatus.RemoverStatus(statusRelacao);
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