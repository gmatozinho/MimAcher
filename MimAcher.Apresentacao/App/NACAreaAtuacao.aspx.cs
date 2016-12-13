using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class NacAreaAtuacao : Page
    {
        //Declaração dos Gestores        
        public GestorDeNacAreaDeAtuacao GestorDeNacAreaDeAtuacao { get; set; }
        public GestorDeNac GestorDeNac { get; set; }
        public GestorDeAreaDeAtuacao GestorDeAreaDeAtuacao { get; set; }

        public NacAreaAtuacao()
        {
            //Inicialização dos Gestores            
            this.GestorDeNacAreaDeAtuacao = new GestorDeNacAreaDeAtuacao();
            this.GestorDeNac = new GestorDeNac();
            this.GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreNacAreaAtuacaoId.DataSource = this.GestorDeNacAreaDeAtuacao.ObterTodasAsNacAreasDeAtuacao();
                StoreNacAreaAtuacaoId.DataBind();

                StoreNacId.DataSource = this.GestorDeNac.ObterTodosOsNac().OrderBy(l => l.nome_representante);
                StoreNacId.DataBind();

                StoreAreaAtuacaoId.DataSource = this.GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
                StoreAreaAtuacaoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de aprender de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            NacAreaAtuacaoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreNacAreaAtuacaoId.DataSource = this.GestorDeNacAreaDeAtuacao.ObterTodasAsNacAreasDeAtuacao();
            StoreNacAreaAtuacaoId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreNacAreaAtuacaoId.DataSource = this.GestorDeNacAreaDeAtuacao.ObterTodasAsNacAreasDeAtuacao();
            StoreNacAreaAtuacaoId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeNacAreaDeAtuacao = new GestorDeNacAreaDeAtuacao();
            StoreNacAreaAtuacaoId.DataSource = this.GestorDeNacAreaDeAtuacao.ObterTodasAsNacAreasDeAtuacao();
            StoreNacAreaAtuacaoId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_NAC_AREA_ATUACAO nacareaatuacao = new MA_NAC_AREA_ATUACAO();

            nacareaatuacao.cod_nac = Int32.Parse(cod_nacId.SelectedItem.Value);
            nacareaatuacao.cod_area_atuacao = Int32.Parse(cod_area_atuacaoId.SelectedItem.Value);


            //Caso o form não possui código, será inserido um novo aprender de participante
            if (cod_nac_area_atuacaoId.Text == "")
            {
                this.GestorDeNacAreaDeAtuacao.InserirNacAreaDeAtuacao(nacareaatuacao);
                NacAreaAtuacaoWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                nacareaatuacao.cod_nac_area_atuacao = Int32.Parse(cod_nac_area_atuacaoId.Text);
                this.GestorDeNacAreaDeAtuacao.AtualizarNacAreaDeAtuacao(nacareaatuacao);
                NacAreaAtuacaoWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            NacAreaAtuacaoWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_NAC_AREA_ATUACAO nacareaatuacao = this.GestorDeNacAreaDeAtuacao.ObterNacAreaDeAtuacaoPorId(Int32.Parse(cod_nac_area_atuacaoId.Text));
            this.GestorDeNacAreaDeAtuacao.RemoverNacAreaDeAtuacao(nacareaatuacao);
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