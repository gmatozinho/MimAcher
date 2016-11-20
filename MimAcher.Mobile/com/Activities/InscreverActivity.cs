using System.Collections.Generic;
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

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Inscrever);

            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            var spinnerCampus = FindViewById<Spinner>(Resource.Id.campus);
            var campoSenha = FindViewById<EditText>(Resource.Id.senha);
            var campoConfirmarSenha = FindViewById<EditText>(Resource.Id.confirmar_senha);
            var campoNome = FindViewById<EditText>(Resource.Id.nome);
            var campoEmail = FindViewById<EditText>(Resource.Id.email);
            var campoDtNascimento = FindViewById<EditText>(Resource.Id.dt_nascimento);
            var campoTelefone = FindViewById<EditText>(Resource.Id.telefone);
            //pegar lista de campus do banco
            var campusComCod = CursorBD.ObterCampi();
            var opcoesCampus = CriarListaCampi(campusComCod);
            var adapterCampus = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoesCampus);

            //captar telefone caso possivel
            var telephonyManager = (TelephonyManager)GetSystemService(TelephonyService);
            var tel = telephonyManager.Line1Number;

            SetActionBar(toolbar);

            //Funcionalidades
            //Escolhendo o Campus
            adapterCampus.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            spinnerCampus.Adapter = adapterCampus;

            //Mascara para telefone e nascimento
            campoTelefone.AddTextChangedListener(new Mascara(campoTelefone, "## #####-####"));
            campoDtNascimento.AddTextChangedListener(new Mascara(campoDtNascimento, "##/##/####"));

            //Captando a escolha do campus
            var escolhaCampus = spinnerCampus.SelectedItem;
            var campus = escolhaCampus.ToString();
            _campus = PegarChaveDoCampus(campus, campusComCod).ToString();

            //Capturar telefone do sistema
            if (tel != null)
            {
                campoTelefone.Text = tel;
            }
            
            ActionBar.Title = GetString(Resource.String.TitleCadastrar);
            ActionBar.Subtitle = GetString(Resource.String.SubtitleCadastrar);
            
            //Pegar as informações inseridas
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
                    InscreverParticipante(this);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }


        private void InscreverParticipante(Context activity)
        {
            var participante = new Participante(CriarDicionarioParaMontarParticipante());

            if (Validador.ValidarCadastroParticipante(activity, participante, _confirmarSenha))
            {
                var x = participante.InscreverParticipante();
                IniciarEscolherFoto(this, participante);
                const string toast = ("Usuário Criado");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                Finish();
            }
        }

        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_inscrever, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        
        //Cria participante
        private Dictionary<string, string> CriarDicionarioParaMontarParticipante()
        {
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

        //retornar só lista do campi
        private static List<string> CriarListaCampi(Dictionary<int, string> dicCampi)
        {
            return dicCampi.Select(info => info.Value).ToList();
        }
        

    }
}


