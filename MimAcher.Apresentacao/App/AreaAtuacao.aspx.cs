using System;
using System.Linq;
using System.Web.UI;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class AreaAtuacao : Page
    {
        //Declaração dos Gestores        
        public GestorDeAreaDeAtuacao GestorDeAreaDeAtuacao { get; set; }

        public AreaAtuacao()
        {
            //Inicialização dos Gestores            
            GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreAreaAtuacaoId.DataSource = GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
                StoreAreaAtuacaoId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            AreaAtuacaoWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreAreaAtuacaoId.DataSource = GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
            StoreAreaAtuacaoId.DataBind();
        }

        //Lista os area_atuacaos do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreAreaAtuacaoId.DataSource = GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
            StoreAreaAtuacaoId.DataBind();
        }

        //Lista os area_atuacaos do banco de dados na grid
        protected void List()
        {
            GestorDeAreaDeAtuacao = new GestorDeAreaDeAtuacao();
            StoreAreaAtuacaoId.DataSource = GestorDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao().OrderBy(l => l.nome);
            StoreAreaAtuacaoId.DataBind();
        }

        //Cadastro do area_atuacao no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_AREA_ATUACAO area_atuacao = new MA_AREA_ATUACAO();

            area_atuacao.nome = nomeId.Text;

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_area_atuacaoId.Text == "")
            {
                GestorDeAreaDeAtuacao.InserirAreaDeAtuacao(area_atuacao);
                AreaAtuacaoWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                area_atuacao.cod_area_atuacao = Int32.Parse(cod_area_atuacaoId.Text);
                GestorDeAreaDeAtuacao.AtualizarAreaDeAtuacao(area_atuacao);
                AreaAtuacaoWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            AreaAtuacaoWindowId.Show();
        }

        //Exclui determinado area_atuacao do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {   
            MA_AREA_ATUACAO area_atuacao = GestorDeAreaDeAtuacao.ObterAreaDeAtuacaoPorId(Int32.Parse(cod_area_atuacaoId.Text));
            GestorDeAreaDeAtuacao.RemoverAreaDeAtuacao(area_atuacao);
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