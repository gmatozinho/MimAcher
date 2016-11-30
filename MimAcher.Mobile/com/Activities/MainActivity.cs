using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
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
        private readonly string _campus = "Serra";
        private readonly string _senha = null;
        private readonly string _nome = "Gustavo";
        private readonly string _email = null;
        private readonly string _nascimento = "09/10/1995";
        private readonly string _telefone = "00000000";
        private readonly string _localizacao = null;
        private string _emailInserido;
        private string _senhaInserida;
        private TelaENomeParaLoading _telaENome;
        

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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            ChecagemConexao.ChecarConexão(this, connectivityManager);
            stopwatch.Stop();
            var tempoIniciarMain = stopwatch.ToString();



            //Iniciando as variaveis do contexto
            var campoEmail = FindViewById<EditText>(Resource.Id.email);
            var campoSenha = FindViewById<EditText>(Resource.Id.senha);
            var entrar = FindViewById<Button>(Resource.Id.entrar);
            var inscrevase = FindViewById<Button>(Resource.Id.inscrevase);

            //Funcionalidades
            //Resgatando o que foi digitado nos EditText
            campoEmail.TextChanged += (sender, texto) => _emailInserido = texto.Text.ToString();
            campoSenha.TextChanged += (sender, texto) => _senhaInserida = texto.Text.ToString();

            stopwatch.Restart();
            entrar.Click += BotaoEntrarClique;
            stopwatch.Stop();
            var tempoLogar = stopwatch.ToString();

            //Tenho que fazer a autenticação no banco de dados
            //Ideia é buscar usuario no banco, se existir retorna true e checa senha, se nao retorna usuario inexistente
            //Busca senha neste mesmo usuario, se for igual retorna true se nao retorna senha invalida

            stopwatch.Restart();
            inscrevase.Click += BotaoInscreverClique;
            stopwatch.Stop();
            var tempoIniciarInscrever = stopwatch.ToString();
        }

        
        //função temporaria
        //deve pegar o usuario no banco
        private Dictionary<string, string> MontarUsuário()
        {
            var informacoes = new Dictionary<string, string>
            {
                ["codigo"] = _codigoParticipante,
                ["campus"] = _campus,
                ["senha"] = _senha,
                ["email"] = _email,
                ["nome"] = _nome,
                ["telefone"] = _telefone,
                ["nascimento"] = _nascimento,
                ["localizacao"] = _localizacao
            };

            return informacoes;
        }

        private void BotaoInscreverClique(object sender, EventArgs e)
        {
            _telaENome = new TelaENomeParaLoading(this,"Inscrever");
            Loading.MyButtonClicked(_telaENome,null);
            OverridePendingTransition(0, Android.Resource.Animation.FadeIn);
        }

        private void BotaoEntrarClique(object sender, EventArgs e)
        {

            //TODO montar o parcipante com as informações inseridas
            //E enviar esse participante montado para a próxima activity
            _telaENome = new TelaENomeParaLoading(this, "Entrar");
            MyButtonClicked(_telaENome);
            //participante = new Participante(MontarUsuário());
            //participante.Codigo = _codigoParticipante;
            
            //Loading.MyButtonClicked(_telaENome, participante);
            OverridePendingTransition(0, 0);
        }

        private Dictionary<string, string> MontarDicionarioLogin()
        {
            return new Dictionary<string, string>
            {
                ["senha"] = _senhaInserida,
                ["email"] = _emailInserido
            };
        }

        public void MyButtonClicked(TelaENomeParaLoading telaENome)
        {
            var activity = telaENome.Tela;
            var progressDialog = ProgressDialog.Show(activity, "", "Comunicando com o servidor...",true);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            //progressDialog.Show();
            new Thread(new ThreadStart(async delegate
            {
                //ThreadStart thSt = delegate { ); };
                //var mythread = new Thread(thSt);
                //mythread.Start();

                for (var i = 0; i < 100; i++)
                    {
                        await Task.Delay(50);
                    }
                progressDialog.Dismiss();
                RunOnUiThread(async () =>
                {
                    await MyMethod(telaENome, progressDialog);
                });




            })).Start();
            
        }


        private Task MyMethod(TelaENomeParaLoading telaENome,ProgressDialog progressDialog)
        {
            //Thread.Sleep(5000); //take 5 secs to do it's job
            var tela = (IFabricaTelas)telaENome.Tela;
            var nometela = telaENome.NomeTela;
            if (nometela == "Inscrever") return tela.IniciarInscrever();
            if (nometela == "Entrar") return EventoEntrar(tela,progressDialog);
            return Task.CompletedTask;
            

        }
         

        private Task EventoEntrar(IFabricaTelas tela,ProgressDialog progressDialog)
        {
            _codigoParticipante = Usuario.Login(this, MontarDicionarioLogin());
            if (_codigoParticipante == "-1")
            {
                progressDialog.Dismiss();
                Mensagens.MensagemErroLogin(this);
                return Task.CompletedTask;
            }
            if (_codigoParticipante == "-2")
            {
                return Task.CompletedTask;
            }
            var participante = new Participante(MontarUsuário()) {Codigo = _codigoParticipante};
            tela.IniciarHome((Activity)tela, participante);
            return Task.CompletedTask;
        }



    }
}

