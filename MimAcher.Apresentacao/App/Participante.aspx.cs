using System;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using MimAcher.Aplicacao;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class Participante : Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeCampus GestorDeCampus { get; set; }
        public GestorDeAplicacao GestorDeAplicacao { get; set; }

        public Participante()
        {
            //Inicialização dos Gestores
            GestorDeUsuario = new GestorDeUsuario();
            GestorDeParticipante = new GestorDeParticipante();
            GestorDeCampus = new GestorDeCampus();
            GestorDeAplicacao = new GestorDeAplicacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                StoreUsuarioId.DataSource = GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
                StoreUsuarioId.DataBind();

                StoreParticipanteId.DataSource = GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                StoreParticipanteId.DataBind();

                StoreCampusId.DataSource = GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
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
            StoreParticipanteId.DataSource = GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            StoreParticipanteId.DataBind();
        }

        //Lista os participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            StoreParticipanteId.DataSource = GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            StoreParticipanteId.DataBind();
        }

        //Lista os participantes do banco de dados na grid
        protected void List()
        {
            GestorDeParticipante = new GestorDeParticipante();
            StoreParticipanteId.DataSource = GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            StoreParticipanteId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE participante = new MA_PARTICIPANTE();
            String latitude = GestorDeAplicacao.RetornaDadoSemVigurla(latitudeId.Text);
            String longitude = GestorDeAplicacao.RetornaDadoSemVigurla(longitudeId.Text);

            participante.nome = nomeId.Text;
            participante.dt_nascimento = (DateTime)dt_nascimentoId.Value;
            participante.telefone = Int32.Parse(telefoneId.Text);
            participante.cod_campus = Int32.Parse(cod_campusId.SelectedItem.Value);
            participante.cod_usuario = Int32.Parse(cod_usuarioId.SelectedItem.Value);
            participante.geolocalizacao = DbGeography.FromText("POINT(" + longitude + "  " + latitude + ")");

            //Caso o form não possui código, será inserido um novo usuário
            if (cod_participanteId.Text == "")
            {
                GestorDeParticipante.InserirParticipante(participante);
                ParticipanteWindowId.Close();
                LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                participante.cod_participante = Int32.Parse(cod_participanteId.Text);
                GestorDeParticipante.AtualizarParticipante(participante);
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
            MA_PARTICIPANTE participante = GestorDeParticipante.ObterParticipantePorId(Int32.Parse(cod_participanteId.Text));
            GestorDeParticipante.RemoverParticipante(participante);
            LimpaForm();
        }

        protected void CarregarPontoNoMapa(object sender, DirectEventArgs e)
        {            
            int codigoparticipante = Int32.Parse(e.ExtraParams["RecordGridMap"]);
                        
            MA_PARTICIPANTE participante = GestorDeParticipante.ObterParticipantePorId(codigoparticipante);

         
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

        //Limpa o formulário
        protected void LimpaForm()
        {
            EditButtonId.Disable(true);
            DeleteButtonId.Disable(true);
            List();
        }
    }
}