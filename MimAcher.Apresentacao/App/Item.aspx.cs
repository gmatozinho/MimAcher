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
    public partial class Item : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeItem GestorDeItem { get; set; }

        public Item()
        {
            //Inicialização dos Gestores            
            this.GestorDeItem = new GestorDeItem();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                this.StoreItemId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ItemWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
            this.StoreItemId.DataBind();
        }

        //Lista os items do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
            this.StoreItemId.DataBind();
        }

        //Lista os items do banco de dados na grid
        protected void List()
        {
            this.GestorDeItem = new GestorDeItem();
            this.StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
            this.StoreItemId.DataBind();
        }

        //Cadastro do item no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ITEM item = new MA_ITEM();

            item.nome = this.nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_itemId.Text == "")
            {
                GestorDeItem.InserirItem(item);
                this.ItemWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                item.cod_item = Int32.Parse(this.cod_itemId.Text);
                GestorDeItem.AtualizarItem(item);
                this.ItemWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            this.ItemWindowId.Show();
        }

        //Exclui determinado item do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ITEM item = GestorDeItem.ObterItemPorId(Int32.Parse(this.cod_itemId.Text));
            GestorDeItem.RemoverItem(item);
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