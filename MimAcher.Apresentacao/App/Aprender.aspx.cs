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
    public partial class Aprender : System.Web.UI.Page
    {
        //Declaração dos Gestores        }
        public GestorDeAprender GestorDeAprender { get; set; }

        public Aprender()
        {
            //Inicialização dos Gestores            
            this.GestorDeAprender = new GestorDeAprender();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreAprenderId.DataSource = this.GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender().OrderBy(l => l.nome);
                this.StoreAprenderId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.AprenderWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreAprenderId.DataSource = this.GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender().OrderBy(l => l.nome);
            this.StoreAprenderId.DataBind();
        }

        //Lista os aprenders do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreAprenderId.DataSource = this.GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender().OrderBy(l => l.nome);
            this.StoreAprenderId.DataBind();
        }

        //Lista os aprenders do banco de dados na grid
        protected void List()
        {
            this.GestorDeAprender = new GestorDeAprender();
            this.StoreAprenderId.DataSource = this.GestorDeAprender.ObterTodosOsRegistrosDoQueSePodeAprender().OrderBy(l => l.nome);
            this.StoreAprenderId.DataBind();
        }

        //Cadastro do aprender no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_APRENDER aprender = new MA_APRENDER();

            aprender.nome = this.nomeId.Text;            
            
            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_aId.Text == "")
            {
                GestorDeAprender.InserirNovoAprendizado(aprender);
                this.AprenderWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                aprender.cod_a = Int32.Parse(this.cod_aId.Text);
                GestorDeAprender.AtualizarAprendizado(aprender);
                this.AprenderWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoaprender = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.AprenderWindowId.Show();
        }

        //Exclui determinado aprender do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_APRENDER aprender = new MA_APRENDER();
            aprender = GestorDeAprender.ObterAprendizadoPorId(Int32.Parse(this.cod_aId.Text));
            GestorDeAprender.RemoverAprendizado(aprender);
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