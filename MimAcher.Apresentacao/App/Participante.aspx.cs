﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Aplicacao;
using System.Data.Entity.Spatial;
using Ext.Net;
using MimAcher.Dominio;

namespace MimAcher.Apresentacao.App
{
    public partial class Participante : System.Web.UI.Page
    {
        //Declaração dos Gestores
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeCampus GestorDeCampus { get; set; }
        public GestorDeAplicacao GestorDeAplicacao { get; set; }

        public Participante()
        {
            //Inicialização dos Gestores
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeCampus = new GestorDeCampus();
            this.GestorDeAplicacao = new GestorDeAplicacao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.StoreUsuarioId.DataSource = this.GestorDeUsuario.ObterTodosOsUsuarios().OrderBy(l => l.e_mail);
                this.StoreUsuarioId.DataBind();

                this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
                this.StoreParticipanteId.DataBind();

                this.StoreCampusId.DataSource = this.GestorDeCampus.ObterTodosOsCampus().OrderBy(l => l.local);
                this.StoreCampusId.DataBind();
            }
        }

        //Inicializa a tela de cadastro de usuário
        protected void Add(object sender, DirectEventArgs e)
        {
            this.ParticipanteWindowId.Show();
        }

        //Faz a sobrecarga de List para a paginação
        protected void List(object sender, EventArgs e)
        {
            this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            this.StoreParticipanteId.DataBind();
        }

        //Lista os participantes do banco de dados na grid
        protected void List(object sender, DirectEventArgs e)
        {
            this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            this.StoreParticipanteId.DataBind();
        }

        //Lista os participantes do banco de dados na grid
        protected void List()
        {
            this.GestorDeParticipante = new GestorDeParticipante();
            this.StoreParticipanteId.DataSource = this.GestorDeParticipante.ObterTodosOsParticipantes().OrderBy(l => l.nome);
            this.StoreParticipanteId.DataBind();
        }

        //Cadastro do participante no banco
        protected void Save(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE participante = new MA_PARTICIPANTE();
            String latitude = GestorDeAplicacao.RetornaDadoSemVigurla(this.latitudeId.Text);
            String longitude = GestorDeAplicacao.RetornaDadoSemVigurla(this.longitudeId.Text);

            participante.nome = this.nomeId.Text;
            participante.dt_nascimento = (DateTime)this.dt_nascimentoId.Value;
            participante.telefone = Int32.Parse(this.telefoneId.Text);
            participante.cod_campus = Int32.Parse(this.cod_campusId.SelectedItem.Value);
            participante.cod_usuario = Int32.Parse(this.cod_usuarioId.SelectedItem.Value);
            participante.geolocalizacao = DbGeography.FromText("POINT(" + longitude + "  " + latitude + ")");

            //Caso o form não possui código, será inserido um novo usuário
            if (this.cod_participanteId.Text == "")
            {
                GestorDeParticipante.InserirParticipante(participante);
                this.ParticipanteWindowId.Close();
                this.LimpaForm();
            }
            //Caso contrário, o form será atualizado
            else
            {
                participante.cod_participante = Int32.Parse(this.cod_participanteId.Text);
                GestorDeParticipante.AtualizarParticipante(participante);
                this.ParticipanteWindowId.Close();
                this.LimpaForm();
            }
        }

        //Abre a janela de edição
        protected void Edit(object sender, DirectEventArgs e)
        {
            this.ParticipanteWindowId.Show();
        }

        //Exclui determinado participante do banco de dados
        protected void Delete(object sender, DirectEventArgs e)
        {
            MA_PARTICIPANTE participante = GestorDeParticipante.ObterParticipantePorId(Int32.Parse(this.cod_participanteId.Text));
            GestorDeParticipante.RemoverParticipante(participante);
            this.LimpaForm();
        }

        protected void CarregarPontoNoMapa(object sender, DirectEventArgs e)
        {            
            int codigoparticipante = Int32.Parse(e.ExtraParams["RecordGridMap"]);
                        
            MA_PARTICIPANTE participante = GestorDeParticipante.ObterParticipantePorId(codigoparticipante);

         
            Ext.Net.Window win = new Ext.Net.Window();
            win.ID = "wmId";
            win.Width = Unit.Pixel(1185);
            win.Height = Unit.Pixel(650);
            win.Modal = true;
            win.Loader = new ComponentLoader();
            win.Loader.Url = "~/App/Mapa/PontoMapa.aspx";
            win.Loader.Mode = Ext.Net.LoadMode.Frame;
            win.Loader.LoadMask.ShowMask = true;

            win.Render(this);

            Session.Add("participante", participante);
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