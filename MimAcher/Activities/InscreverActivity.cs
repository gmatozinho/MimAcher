using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using MimAcher.Entidades;

[assembly: UsesPermission(Manifest.Permission.ReadPhoneState)]
namespace MimAcher.Activities
{
    
    [Activity(Label = "InscreverActivity", Theme = "@style/Theme.Splash")]
    public class InscreverActivity : Activity
    {
        //Variaveis globais
        public Bundle ParticipanteBundle;
        private string _senha;
        private string _nome = "Fulano";
        private string _email;
        private string _nascimento;
        private string _telefone;
        private string _campus;
        private string _confirmarSenha;

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
            var campoEMail = FindViewById<EditText>(Resource.Id.email);
            var campoDtNascimento = FindViewById<EditText>(Resource.Id.dt_nascimento);
            var campoTelefone = FindViewById<EditText>(Resource.Id.telefone);
            var opcoesCampus = new List<string> { "Serra", "Vitória", "Vila Velha" };
            var adapterCampus = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoesCampus);
            var telephonyManager = (TelephonyManager)GetSystemService(TelephonyService);
            var tel = telephonyManager.Line1Number;

            SetActionBar(toolbar);

            //Funcionalidades
            //Escolhendo o Campus
            adapterCampus.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            spinnerCampus.Adapter = adapterCampus;
            var escolhaCampus = spinnerCampus.SelectedItem;
            _campus = escolhaCampus.ToString();
            
            //Capturar telefone do sistema
            if (tel != null)
            {
                campoTelefone.Text = tel;
            }
            ActionBar.Title = "Avançar";
            ActionBar.Subtitle = "Informações Básicas";


            //Pegar as informações inseridas
            campoNome.TextChanged += (sender, n) => _nome = n.Text.ToString();
            campoEMail.TextChanged += (sender, e) => _email = e.Text.ToString();
            campoSenha.TextChanged += (sender, s) => _senha = s.Text.ToString();
            campoConfirmarSenha.TextChanged += (sender, cS) => _confirmarSenha = cS.Text.ToString();
            campoDtNascimento.TextChanged += (sender, n) => _nascimento = n.Text.ToString();
            campoTelefone.TextChanged += (sender, t) => _telefone = t.Text.ToString();
            
        }

        //Botar as validações do cayo
        private void ValidarCadastro()
        {
            if (_senha != null && _confirmarSenha == _senha && _email != null)
            {
                const string toast = ("Usuário Criado");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                var participante = new Participante(CriarDicionarioDeInformacoes());
                participante.Commit();

                var escolherfotoactivity = new Intent(this, typeof(EscolherFotoActivity));
                escolherfotoactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(escolherfotoactivity);
            }
            else
            {
                const string toast = ("Informações inválidas");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                var inscreveractivity = new Intent(this, typeof(InscreverActivity));
                StartActivity(inscreveractivity);
            }

        }

        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_inscrever, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Define as funcionalidades deste menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_done:
                    ValidarCadastro();
                    return true;
                /*case Resource.Id.menu_preferences:
                    //do something
                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    //mudar para trabalhar com objeto do banco
                    editaractivity.PutExtra("member", participante_bundle);
                    StartActivity(editaractivity);
                    return true;*/
            }
            return base.OnOptionsItemSelected(item);
        }

        //Cria participante
        private Dictionary<string, string> CriarDicionarioDeInformacoes()
        {
            var informacoes = new Dictionary<string, string>
            {
                ["campus"] = _campus,
                ["senha"] = _senha,
                ["email"] = _email,
                ["nome"] = _nome,
                ["telefone"] = _telefone,
                ["nascimento"] = _nascimento
            };

            return informacoes;
        }
    }
}


