using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Dominio;
using MimAcher.Aplicacao;
using MimAcher.Dominio.Model;
using Microsoft.Reporting.WebForms;
using System.IO;
using MimAcher.Apresentacao.Impressao;

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
            erro.incidencia = Int32.Parse(this.incidenciaId.Text);
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

        //Imprimir Lista de Erros diretamente em um PDF utilizando o Report View
        protected void Imprimir(object sender, DirectEventArgs e)
        {
            List<ErroImpressao> listaimpressaopersonalizada = new List<ErroImpressao>();
            
            List<MA_ERRO> listaerros = GestorDeErro.ObterTodosOsErros();

            foreach(MA_ERRO erro in listaerros)
            {
                ErroImpressao erroimpressao = new ErroImpressao();

                erroimpressao.tipo = erro.tipo;
                erroimpressao.aconteceu = erro.aconteceu;
                erroimpressao.incidencia = erro.incidencia.ToString();
                erroimpressao.dt_acontecimento = erro.dt_acontecimento.ToString();

                listaimpressaopersonalizada.Add(erroimpressao);
            }
            
            //Define que que o tipo de processamento do Report será local
            ReportViewerErro.ProcessingMode = ProcessingMode.Local;

            //Informa o caminho de onde está o arquivo do relatório
            ReportViewerErro.LocalReport.ReportPath = Server.MapPath("~/Impressao/ErroReport.rdlc");

            //Adiciona as listas a determinados Report Data Sources
            ReportDataSource datasource1 = new ReportDataSource("DataSetErroReport", listaimpressaopersonalizada);

            //Limpa qualquer vestígio em memória contido no Report Local
            ReportViewerErro.LocalReport.DataSources.Clear();

            //Adiciona ao Report View os data sources declarados acima
            ReportViewerErro.LocalReport.DataSources.Add(datasource1);

            ReportViewerErro.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = ReportViewerErro.LocalReport.Render(
            "Pdf", null, out mimeType, out encoding,
             out extension,
            out streamids, out warnings);

            Session.Add("NomeArquivo", bytes);

            X.Js.AddScript("window.open('ImpressaoErro.aspx','_blank');");
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