using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;
using MimAcher.Mobile.com.Utilitarios;
using MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador;

[assembly: UsesPermission(Manifest.Permission.ReadPhoneState)]
namespace MimAcher.Mobile.com.Activities
{

    [Activity(Label = "InscreverActivity", Theme = "@style/Theme.Splash")]
    public class InscreverActivity : FabricaTelasNormaisSemProcedimento
    {
        //Variaveis globais
        private string _senha;
        private string _nome ;
        private string _email;
        private string _nascimento;
        private string _telefone;
        private string _campus;
        private string _confirmarSenha;
        private const string Localizacao = "0.0/0.0";
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private Dictionary<int, string> _campusComCod;
        private Spinner _spinnerCampus;
        private ArrayAdapter<string> _adapterCampus;
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Inscrever);

            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            _spinnerCampus = FindViewById<Spinner>(Resource.Id.campus);
            var campoSenha = FindViewById<EditText>(Resource.Id.senha);
            var campoConfirmarSenha = FindViewById<EditText>(Resource.Id.confirmar_senha);
            var campoNome = FindViewById<EditText>(Resource.Id.nome);
            var campoEmail = FindViewById<EditText>(Resource.Id.email);
            var campoDtNascimento = FindViewById<EditText>(Resource.Id.dt_nascimento);
            var campoTelefone = FindViewById<EditText>(Resource.Id.telefone);
            //pegar lista de campus do banco
            _campusComCod = CursorBd.ObterCampi();
            var opcoesCampus = CriarListaCampi(_campusComCod);
            _adapterCampus = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoesCampus);

            //captar telefone caso possivel
            var telephonyManager = (TelephonyManager)GetSystemService(TelephonyService);
            var tel = telephonyManager.Line1Number;

            SetActionBar(toolbar);

            _stopwatch.Start();

            //Funcionalidades
            //Escolhendo o Campus
            _adapterCampus.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            _spinnerCampus.Adapter = _adapterCampus;

            //Mascara para telefone e nascimento
            campoTelefone.AddTextChangedListener(new Mascara(campoTelefone, "## #####-####"));
            campoDtNascimento.AddTextChangedListener(new Mascara(campoDtNascimento, "##/##/####"));

            //Captando a escolha do campus
            
            
            //Capturar telefone do sistema
            if (tel != null)
            {
                campoTelefone.Text = tel;
            }
            
            ActionBar.Title = GetString(Resource.String.TitleCadastrar);
            ActionBar.Subtitle = GetString(Resource.String.SubtitleCadastrar);
            
            //Pegar as informa��es inseridas
            campoNome.TextChanged += (sender, n) => _nome = n.Text.ToString();
            campoEmail.TextChanged += (sender, e) => _email = e.Text.ToString();
            campoSenha.TextChanged += (sender, s) => _senha = s.Text.ToString();
            campoConfirmarSenha.TextChanged += (sender, cS) => _confirmarSenha = cS.Text.ToString();
            campoDtNascimento.TextChanged += (sender, n) => _nascimento = n.Text.ToString();
            campoTelefone.TextChanged += (sender, t) => _telefone = t.Text.ToString();
            
        }

        //captar a key do campus escolhido
        private static int PegarChaveDoCampus(string campus, Dictionary<int,string> dicionarioCampus )
        {
            if (dicionarioCampus.ContainsValue(campus))
            {
                return (from chave in dicionarioCampus where chave.Value == campus select chave.Key).FirstOrDefault();
            }
            return 0;
        }

        //Define as funcionalidades deste menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_done:
                    GetCampus();
                    InscreverParticipante(this);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }


        private void InscreverParticipante(Context activity)
        {
            var informacoesInseridas = InformacoesParaValidar();

            if (Validacao.ValidarCadastroParticipante(activity,informacoesInseridas))
            {
                var participante = new Participante(CriarDicionarioParaMontarParticipante());
                var x = participante.Inscrever();
                IniciarEscolherFoto(this, participante);
                _stopwatch.Stop();
                //TODO enviar stopwatch
                const string toast = ("Usu�rio Criado");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                Finish();
            }
        }

        //capturar o campus no atual momento de execu��o
        private void GetCampus()
        {
            var escolhaCampus = _spinnerCampus.SelectedItem;
            var campus = escolhaCampus.ToString();
            _campus = PegarChaveDoCampus(campus, _campusComCod).ToString();
        }


        //Cria o menu de op��es
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_inscrever, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        
        //Cria participante
        private Dictionary<string, string> CriarDicionarioParaMontarParticipante()
        {
            _telefone = TrataNumeroTelefone(_telefone);
            _nascimento = TrataData(_nascimento);
            var informacoes = new Dictionary<string, string>
            {
                ["campus"] = _campus,
                ["senha"] = _senha,
                ["email"] = _email,
                ["nome"] = _nome,
                ["telefone"] = _telefone,
                ["nascimento"] = _nascimento,
                ["localizacao"] = Localizacao
            };

            return informacoes;
        }

        //retornar s� lista do campi
        private static List<string> CriarListaCampi(Dictionary<int, string> dicCampi)
        {
            return dicCampi.Select(info => info.Value).ToList();
        }

        private static string TrataNumeroTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone)) return telefone;
            return telefone.Length > 13 ? telefone.Remove(13) : telefone;
        }

        private static string TrataData(string data)
        {
            if (string.IsNullOrEmpty(data)) return data;
            return data.Length > 10 ? data.Remove(10) : data;
        }

        private Dictionary<string, string> InformacoesParaValidar()
        {
            return new Dictionary<string, string>
            {
                ["email"] = _email,
                ["nome"] = _nome,
                ["nascimento"] = _nascimento,
                ["telefone"] = _telefone,
                ["senha"] = _senha,
                ["confirmarSenha"] = _confirmarSenha
            };
        }

    }
}


