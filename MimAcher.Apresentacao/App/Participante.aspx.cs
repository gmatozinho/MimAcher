using System;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using Microsoft.Reporting.WebForms;
using MimAcher.Apresentacao.Impressao;
using System.IO;
using MimAcher.Dominio.Model;
using System.Collections.Generic;

namespace MimAcher.Apresentacao.App
{
    public partial class Participante : Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeCampus GestorDeCampus { get; set; }
        public GestorDeAplicacao GestorDeAplicacao { get; set; }
        public GestorDeHobbieDeParticipante GestorDeHobbieDeParticipante { get; set; }
        public GestorDeParticipanteAprender GestorDeParticipanteAprender { get; set; }
        public GestorDeParticipanteEnsinar GestorDeParticipanteEnsinar { get; set; }

        public Participante()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeCampus = new GestorDeCampus();
            this.GestorDeAplicacao = new GestorDeAplicacao();
            this.GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
            this.GestorDeParticipanteAprender = new GestorDeParticipanteAprender();
            this.GestorDeParticipanteEnsinar = new GestorDeParticipanteEnsinar();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
                StoreUsuarioId.DataBind();

                StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                StoreParticipanteId.DataBind();

                StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
                StoreCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            ParticipanteWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            StoreParticipanteId.DataBind();
        }

        //Lista os participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            StoreParticipanteId.DataBind();
        }

        //Lista os participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeParticipante = new GestorDeParticipante();
            StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            StoreParticipanteId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE participante = new MA_PARTICIPANTE();
            String latitude = this.GestorDeAplicacao.RetornaDadoSemVigurla(latitudeId.Text);
            String longitude = this.GestorDeAplicacao.RetornaDadoSemVigurla(longitudeId.Text);

            participante.nome = nomeId.Text;
            participante.dt_nascimento = (DateTime)this.dt_nascimentoId.Value;
            participante.telefone = this.telefoneId.Text;
            participante.cod_campus = Int32.Parse(this.cod_campusId.SelectedItem.Value);
            participante.cod_usuario = Int32.Parse(this.cod_usuarioId.SelectedItem.Value);
            participante.geolocalizacao = DbGeography.FromText("POINT(" + longitude + "  " + latitude + ")");

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_participanteId.Text == "")
            {
                this.GestorDeParticipante.InserirParticipante(participante);
                ParticipanteWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                participante.cod_participante = Int32.Parse(cod_participanteId.Text);
                this.GestorDeParticipante.AtualizarParticipante(participante);
                ParticipanteWindowId.Close();
                LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            ParticipanteWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE participante = this.GestorDeParticipante.ObterParticipantePorId(Int32.Parse(cod_participanteId.Text));
            this.GestorDeParticipante.RemoverParticipante(participante);
            LimpaForm();
        }

        protected void CarregarPontoNoMapa(object sender, DirectEventArgs e)
        {
            int codigoparticipante = Int32.Parse(e.ExtraParams["RecordGridMap"]);

            MA_PARTICIPANTE participante = this.GestorDeParticipante.ObterParticipantePorId(codigoparticipante);


            Window win = new Window();
            win.ID = "wmId";
            win.Width = Unit.Pixel(1185);
            win.Height = Unit.Pixel(650);
            win.Modal = true;
            win.Loader = new ComponentLoader();
            win.Loader.Url = "~/App/Mapa/PontoMapa.aspx";
            win.Loader.Mode = LoadMode.Frame;
            win.Loader.LoadMask.ShowMask = true;

            win.Render(this);

            Session.Add("participante", participante);
        }

        //Imprimir Lista de Relação de Matchs Participantes diretamente em um PDF utilizando o Report View
        protected void Imprimir(object sender, DirectEventArgs e)
        {
            List<RelacaoImpressao> listaimpressaopersonalizada = new List<RelacaoImpressao>();

            //List<MA_ERRO> listaerros = GestorDeErro.ObterTodosOsErros();
            
            //Define que que o tipo de processamento do Report será local
            ReportViewerRelacao.ProcessingMode = ProcessingMode.Local;

            //Informa o caminho de onde está o arquivo do relatório
            ReportViewerRelacao.LocalReport.ReportPath = Server.MapPath("~/Impressao/RelacaoReport.rdlc");

            //Adiciona as listas a determinados Report Data Sources
            ReportDataSource datasource1 = new ReportDataSource("DataSetRelacaoReport", listaimpressaopersonalizada);

            //Limpa qualquer vestígio em memória contido no Report Local
            ReportViewerRelacao.LocalReport.DataSources.Clear();

            //Adiciona ao Report View os data sources declarados acima
            ReportViewerRelacao.LocalReport.DataSources.Add(datasource1);

            ReportViewerRelacao.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = ReportViewerRelacao.LocalReport.Render(
            "Pdf", null, out mimeType, out encoding,
             out extension,
            out streamids, out warnings);

            Session.Add("NomeArquivo", bytes);

            X.Js.AddScript("window.open('ImpressaoRelacao.aspx','_blank');");
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