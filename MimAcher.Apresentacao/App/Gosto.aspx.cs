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
    public partial class Gosto : System.Web.UI.Page
    {
        //Declaração dos Gestores        }
        public GestorDeGosto GestorDeGosto { get; set; }

        public Gosto()
        {
            //Inicialização dos Gestores            
            this.GestorDeGosto = new GestorDeGosto();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreGostoId.DataSource = this.GestorDeGosto.ObterTodosOsGostos().OrderBy(l => l.nome);
                this.StoreGostoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.GostoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreGostoId.DataSource = this.GestorDeGosto.ObterTodosOsGostos().OrderBy(l => l.nome);
            this.StoreGostoId.DataBind();
        }

        //Lista os gostos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreGostoId.DataSource = this.GestorDeGosto.ObterTodosOsGostos().OrderBy(l => l.nome);
            this.StoreGostoId.DataBind();
        }

        //Lista os gostos do banco de dados na grid
        protected void List()
        {
            this.GestorDeGosto = new GestorDeGosto();
            this.StoreGostoId.DataSource = this.GestorDeGosto.ObterTodosOsGostos().OrderBy(l => l.nome);
            this.StoreGostoId.DataBind();
        }

        //Cadastro do gosto no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_GOSTO gosto = new MA_GOSTO();

            gosto.nome = this.nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_gId.Text == "")
            {
                GestorDeGosto.InserirNovoGosto(gosto);
                this.GostoWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                gosto.cod_g = Int32.Parse(this.cod_gId.Text);
                GestorDeGosto.AtualizarGosto(gosto);
                this.GostoWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigogosto = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.GostoWindowId.Show();
        }

        //Exclui determinado gosto do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_GOSTO gosto = new MA_GOSTO();
            gosto = GestorDeGosto.ObterGostoPorId(Int32.Parse(this.cod_gId.Text));
            GestorDeGosto.RemoverGosto(gosto);
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