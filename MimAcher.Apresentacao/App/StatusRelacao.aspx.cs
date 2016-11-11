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
    public partial class StatusRelacao : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeStatusDeRelacao GestorDeStatusDeRelacao { get; set; }

        public StatusRelacao()
        {
            //Inicialização dos Gestores            
            GestorDeStatusDeRelacao = new GestorDeStatusDeRelacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreStatusRelacaoId.DataSource = GestorDeStatusDeRelacao.ObterTodosOsStatusDeRelacao().OrderBy(l => l.nome);
                StoreStatusRelacaoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            StatusRelacaoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreStatusRelacaoId.DataSource = GestorDeStatusDeRelacao.ObterTodosOsStatusDeRelacao().OrderBy(l => l.nome);
            StoreStatusRelacaoId.DataBind();
        }

        //Lista os status_relacaos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreStatusRelacaoId.DataSource = GestorDeStatusDeRelacao.ObterTodosOsStatusDeRelacao().OrderBy(l => l.nome);
            StoreStatusRelacaoId.DataBind();
        }

        //Lista os status_relacaos do banco de dados na grid
        protected void List()
        {
            GestorDeStatusDeRelacao = new GestorDeStatusDeRelacao();
            StoreStatusRelacaoId.DataSource = GestorDeStatusDeRelacao.ObterTodosOsStatusDeRelacao().OrderBy(l => l.nome);
            StoreStatusRelacaoId.DataBind();
        }

        //Cadastro do status_relacao no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_STATUS_RELACAO status_relacao = new MA_STATUS_RELACAO();

            status_relacao.nome = nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_status_relacaoId.Text == "")
            {
                GestorDeStatusDeRelacao.InserirStatusDeRelacao(status_relacao);
                StatusRelacaoWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                status_relacao.cod_s_relacao = Int32.Parse(cod_status_relacaoId.Text);
                GestorDeStatusDeRelacao.AtualizarStatusDeRelacao(status_relacao);
                StatusRelacaoWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            StatusRelacaoWindowId.Show();
        }

        //Exclui determinado status_relacao do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_STATUS_RELACAO status_relacao = GestorDeStatusDeRelacao.ObterStatusDeRelacaoPorId(Int32.Parse(cod_status_relacaoId.Text));
            GestorDeStatusDeRelacao.RemoverStatusDeRelacao(status_relacao);
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