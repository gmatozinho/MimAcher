using System;
using System.Collections.Generic;
using System.Diagnostics;
using Android.App;
using Android.Net;
using Android.OS;
using Android.Widget;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;
using MimAcher.Mobile.com.Utilitarios;
using MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "MimAcher", Theme = "@style/Theme.Splash", NoHistory = true)]
    public class MainActivity : FabricaTelasNormaisSemProcedimento
    {
        
        //Variaveis globais
        //até comunicar com o banco informações hipotéticas
        private string _codigoParticipante;
        private string _emailInserido;
        private string _senhaInserida;
        private TelaENomeParaLoading _telaENome;
        Stopwatch stopwatch = new Stopwatch();


        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Main);

            //chamando o serviço de conexao a internet, necessário fazer na activity
            var connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            //pra verificar o tempo de checagem de conexao com o servidor
            
            stopwatch.Start();
            ChecagemConexao.ChecarConexão(this, connectivityManager);
            stopwatch.Stop();
            var tempoIniciarMain = stopwatch;
            EnviarErro.EnviandoTempoIniciarMain(tempoIniciarMain);

            //Iniciando as variaveis do contexto
            var campoEmail = FindViewById<EditText>(Resource.Id.email);
            var campoSenha = FindViewById<EditText>(Resource.Id.senha);
            var entrar = FindViewById<Button>(Resource.Id.entrar);
            var inscrevase = FindViewById<Button>(Resource.Id.inscrevase);

            //Funcionalidades
            //Resgatando o que foi digitado nos EditText
            campoEmail.TextChanged += (sender, texto) => _emailInserido = texto.Text.ToString();
            campoSenha.TextChanged += (sender, texto) => _senhaInserida = texto.Text.ToString();


            entrar.Click += BotaoEntrarClique;
            
            inscrevase.Click += BotaoInscreverClique; 
            
        }

        private void BotaoInscreverClique(object sender, EventArgs e)
        {
            stopwatch.Restart();
            _telaENome = new TelaENomeParaLoading(this,"IniciarInscrever");
            Loading.MyButtonClicked(_telaENome);
            OverridePendingTransition(0, Android.Resource.Animation.FadeIn);
            stopwatch.Stop();
            var tempoIniciarInscrever = stopwatch;
            EnviarErro.EnviandoTempoIniciarInscrever(tempoIniciarInscrever);
        }

        private void BotaoEntrarClique(object sender, EventArgs e)
        {
            stopwatch.Restart();
            _telaENome = new TelaENomeParaLoading(this, "Entrar");
            Loading.MyButtonClicked(_telaENome);
            OverridePendingTransition(0, 0);
            stopwatch.Stop();
            var tempoLogar = stopwatch;
            EnviarErro.EnviandoTempoIniciarEntrar(tempoLogar);
        }

        private Dictionary<string, string> MontarDicionarioLogin()
        {
            return new Dictionary<string, string>
            {
                ["senha"] = _senhaInserida,
                ["email"] = _emailInserido
            };
        }

        public void EventoEntrar(IFabricaTelas tela,ProgressDialog progressDialog)
        {
            _codigoParticipante = Usuario.Login(this, MontarDicionarioLogin());
            progressDialog.Dismiss();
            if (_codigoParticipante == "-1")
            {
                Mensagens.MensagemErroLogin(this);
                return;
            }
            if (_codigoParticipante == "-2")
            {
                return;
            }
            var participante = CursorBd.ObterDadosParticipante(Convert.ToInt32(_codigoParticipante));
            tela.IniciarHome((Activity)tela, participante);
        }

    }
}

