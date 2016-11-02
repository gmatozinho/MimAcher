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
    public partial class NACAreaAtuacao : System.Web.UI.Page
    {
        //Declaração dos Gestores        
        public GestorDeNACAreaDeAtuacao GestorDeNACAreaDeAtuacao { get; set; }
        public GestorDeNAC GestorDeNAC { get; set; }
        public GestorDeAreaDeAtuacao GestorDeAreaDeAtuacao { get; set; }

        public NACAreaAtuacao()
        {
            //Inicialização dos Gestores            
            this.GestorDeNACAreaDeAtuacao = new GestorDeNACAreaDeAtuacao();
            this.GestorDeNAC = new GestorDeNAC();
            this.GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreNACAreaAtuacaoId.DataSource = this.GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
                this.StoreNACAreaAtuacaoId.DataBind();

                this.StoreNACId.DataSource = this.GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
                this.StoreNACId.DataBind();

                this.StoreAreaAtuacaoId.DataSource = this.GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
                this.StoreAreaAtuacaoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de aprender de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            this.NACAreaAtuacaoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreNACAreaAtuacaoId.DataSource = this.GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
            this.StoreNACAreaAtuacaoId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreNACAreaAtuacaoId.DataSource = this.GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
            this.StoreNACAreaAtuacaoId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeNACAreaDeAtuacao = new GestorDeNACAreaDeAtuacao();
            this.StoreNACAreaAtuacaoId.DataSource = this.GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
            this.StoreNACAreaAtuacaoId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_NAC_AREA_ATUACAO nacareaatuacao = new MA_NAC_AREA_ATUACAO();

            nacareaatuacao.cod_nac = Int32.Parse(this.cod_nacId.SelectedItem.Value);
            nacareaatuacao.cod_area_atuacao = Int32.Parse(this.cod_area_atuacaoId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo aprender de participante
            if (this.cod_nac_area_atuacaoId.Text == "")
            {
                GestorDeNACAreaDeAtuacao.InserirNACAreaDeAtuacao(nacareaatuacao);
                this.NACAreaAtuacaoWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                nacareaatuacao.cod_nac_area_atuacao = Int32.Parse(this.cod_nac_area_atuacaoId.Text);
                GestorDeNACAreaDeAtuacao.AtualizarNACAreaDeAtuacao(nacareaatuacao);
                this.NACAreaAtuacaoWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            int codigonacareaatuacao = Int32.Parse(e.ExtraParams["RecordGrid"]);

            this.NACAreaAtuacaoWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_NAC_AREA_ATUACAO nacareaatuacao = new MA_NAC_AREA_ATUACAO();
            nacareaatuacao = GestorDeNACAreaDeAtuacao.ObterNACAreaDeAtuacaoPorId(Int32.Parse(this.cod_nac_area_atuacaoId.Text));
            GestorDeNACAreaDeAtuacao.RemoverNACAreaDeAtuacao(nacareaatuacao);
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