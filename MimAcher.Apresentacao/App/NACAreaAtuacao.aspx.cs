using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class NACAreaAtuacao : Page
    {
        //Declaração dos Gestores        
        public GestorDeNACAreaDeAtuacao GestorDeNACAreaDeAtuacao { get; set; }
        public GestorDeNAC GestorDeNAC { get; set; }
        public GestorDeAreaDeAtuacao GestorDeAreaDeAtuacao { get; set; }

        public NACAreaAtuacao()
        {
            //Inicialização dos Gestores            
            GestorDeNACAreaDeAtuacao = new GestorDeNACAreaDeAtuacao();
            GestorDeNAC = new GestorDeNAC();
            GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreNACAreaAtuacaoId.DataSource = GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
                StoreNACAreaAtuacaoId.DataBind();

                StoreNACId.DataSource = GestorDeNAC.ObterTodosOsNAC().OrderBy(l => l.nome_representante);
                StoreNACId.DataBind();

                StoreAreaAtuacaoId.DataSource = GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
                StoreAreaAtuacaoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de aprender de participante
        protected void Add(object sender, DirectEventArgs e)
        {
            NACAreaAtuacaoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreNACAreaAtuacaoId.DataSource = GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
            StoreNACAreaAtuacaoId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreNACAreaAtuacaoId.DataSource = GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
            StoreNACAreaAtuacaoId.DataBind();
        }

        //Lista os aprenders de participantes do banco de dados na grid
        protected void List()
        {
            GestorDeNACAreaDeAtuacao = new GestorDeNACAreaDeAtuacao();
            StoreNACAreaAtuacaoId.DataSource = GestorDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
            StoreNACAreaAtuacaoId.DataBind();
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
                GestorDeNACAreaDeAtuacao.InserirNACAreaDeAtuacao(nacareaatuacao);
                NACAreaAtuacaoWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                nacareaatuacao.cod_nac_area_atuacao = Int32.Parse(cod_nac_area_atuacaoId.Text);
                GestorDeNACAreaDeAtuacao.AtualizarNACAreaDeAtuacao(nacareaatuacao);
                NACAreaAtuacaoWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            NACAreaAtuacaoWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_NAC_AREA_ATUACAO nacareaatuacao = GestorDeNACAreaDeAtuacao.ObterNACAreaDeAtuacaoPorId(Int32.Parse(cod_nac_area_atuacaoId.Text));
            GestorDeNACAreaDeAtuacao.RemoverNACAreaDeAtuacao(nacareaatuacao);
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