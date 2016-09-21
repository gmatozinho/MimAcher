using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Infra;
using MimAcher.Aplicacao;

namespace MimAcher.TesteWefForms.App
{
    public partial class Ensinar : System.Web.UI.Page
    {
        //Declaração dos Gestores        }
        public GestorDeEnsinar GestorDeEnsinar { get; set; }

        public Ensinar()
        {
            //Inicialização dos Gestores            
            this.GestorDeEnsinar = new GestorDeEnsinar();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreEnsinarId.DataSource = this.GestorDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado().OrderBy(l => l.nome);
                this.StoreEnsinarId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.EnsinarWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreEnsinarId.DataSource = this.GestorDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado().OrderBy(l => l.nome);
            this.StoreEnsinarId.DataBind();
        }

        //Lista os ensinars do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreEnsinarId.DataSource = this.GestorDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado().OrderBy(l => l.nome);
            this.StoreEnsinarId.DataBind();
        }

        //Lista os ensinars do banco de dados na grid
        protected void List()
        {
            this.GestorDeEnsinar = new GestorDeEnsinar();
            this.StoreEnsinarId.DataSource = this.GestorDeEnsinar.ObterTodosOsRegistrosDoQueSePodeEnsinado().OrderBy(l => l.nome);
            this.StoreEnsinarId.DataBind();
        }

        //Cadastro do ensinar no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_ENSINAR ensinar = new MA_ENSINAR();

            ensinar.nome = this.nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_eId.Text == "")
            {
                GestorDeEnsinar.InserirNovoEnsino(ensinar);
                this.EnsinarWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                ensinar.cod_e = Int32.Parse(this.cod_eId.Text);
                GestorDeEnsinar.AtualizarEnsino(ensinar);
                this.EnsinarWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigoensinar = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.EnsinarWindowId.Show();
        }

        //Exclui determinado ensinar do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_ENSINAR ensinar = new MA_ENSINAR();
            ensinar = GestorDeEnsinar.ObterTipoDeEnsinoPorId(Int32.Parse(this.cod_eId.Text));
            GestorDeEnsinar.RemoverEnsino(ensinar);
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