using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class Item : Page
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
                StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
                StoreItemId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            ItemWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
            StoreItemId.DataBind();
        }

        //Lista os items do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
            StoreItemId.DataBind();
        }

        //Lista os items do banco de dados na grid
        protected void List()
        {
            this.GestorDeItem = new GestorDeItem();
            StoreItemId.DataSource = this.GestorDeItem.ObterTodosOsItems().OrderBy(l => l.nome);
            StoreItemId.DataBind();
        }

        //Cadastro do item no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ITEM item = new MA_ITEM();

            item.nome = nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_itemId.Text == "")
            {
                this.GestorDeItem.InserirItem(item);
                ItemWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                item.cod_item = Int32.Parse(cod_itemId.Text);
                this.GestorDeItem.AtualizarItem(item);
                ItemWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            ItemWindowId.Show();
        }

        //Exclui determinado item do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ITEM item = this.GestorDeItem.ObterItemPorId(Int32.Parse(cod_itemId.Text));
            GestorDeItem.RemoverItem(item);
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