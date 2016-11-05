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
    public partial class AreaAtuacao : System.Web.UI.Page
    {
        //Declaração dos Gestores        }
        public GestorDeAreaDeAtuacao GestorDeAreaDeAtuacao { get; set; }

        public AreaAtuacao()
        {
            //Inicialização dos Gestores            
            this.GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreAreaAtuacaoId.DataSource = this.GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
                this.StoreAreaAtuacaoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.AreaAtuacaoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreAreaAtuacaoId.DataSource = this.GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
            this.StoreAreaAtuacaoId.DataBind();
        }

        //Lista os area_atuacaos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreAreaAtuacaoId.DataSource = this.GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
            this.StoreAreaAtuacaoId.DataBind();
        }

        //Lista os area_atuacaos do banco de dados na grid
        protected void List()
        {
            this.GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
            this.StoreAreaAtuacaoId.DataSource = this.GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
            this.StoreAreaAtuacaoId.DataBind();
        }

        //Cadastro do area_atuacao no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_AREA_ATUACAO area_atuacao = new MA_AREA_ATUACAO();

            area_atuacao.nome = this.nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_area_atuacaoId.Text == "")
            {
                GestorDeAreaDeAtuacao.InserirAreaDeAtuacao(area_atuacao);
                this.AreaAtuacaoWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                area_atuacao.cod_area_atuacao = Int32.Parse(this.cod_area_atuacaoId.Text);
                GestorDeAreaDeAtuacao.AtualizarAreaDeAtuacao(area_atuacao);
                this.AreaAtuacaoWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoarea_atuacao = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.AreaAtuacaoWindowId.Show();
        }

        //Exclui determinado area_atuacao do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_AREA_ATUACAO area_atuacao = new MA_AREA_ATUACAO();
            area_atuacao = GestorDeAreaDeAtuacao.ObterAreaDeAtuacaoPorId(Int32.Parse(this.cod_area_atuacaoId.Text));
            GestorDeAreaDeAtuacao.RemoverAreaDeAtuacao(area_atuacao);
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