using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.Entidades;
using Android.Telephony;

[assembly: UsesPermission(Android.Manifest.Permission.ReadPhoneState)]
namespace MimAcher
{
    
    [Activity(Label = "InscreverActivity", Theme = "@style/Theme.Splash")]
    public class InscreverActivity : Activity
    {
        public Bundle participante_bundle;

        //Initializing variables from layout
        
        string senha = null;
        string nome = "Fulano";
        string email = null;
        string nascimento = null;
        string telefone = null;
        string campus = null;
        string confirmar_senha;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Inscrever);

            Spinner spinner_campus = FindViewById<Spinner>(Resource.Id.campus);
            Button botao_avançar = FindViewById<Button>(Resource.Id.avançar);
            EditText campo_senha = FindViewById<EditText>(Resource.Id.senha);
            EditText campo_confirmar_senha = FindViewById<EditText>(Resource.Id.confirmar_senha);
            EditText campo_nome = FindViewById<EditText>(Resource.Id.nome);
            EditText campo_e_mail = FindViewById<EditText>(Resource.Id.email);
            EditText campo_dt_nascimento = FindViewById<EditText>(Resource.Id.dt_nascimento);
            EditText campo_telefone = FindViewById<EditText>(Resource.Id.telefone);

            //Escolhendo o Campus
            var opcoes_campus = new List<string>() { "Serra", "Vitória", "Vila Velha" };
            var adapter_campus = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoes_campus);
            adapter_campus.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            spinner_campus.Adapter = adapter_campus;
            var escolha_campus = spinner_campus.SelectedItem;
            campus = escolha_campus.ToString();

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar

            //Capturar telefone
            var telephonyManager = (TelephonyManager)GetSystemService(TelephonyService);
            var tel = telephonyManager.Line1Number;

            if (tel != null)
            {
                campo_telefone.Text = tel;
            }

            

            //Pegar as informações inseridas

            campo_nome.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) => {
                nome = n.Text.ToString();
            };

            campo_e_mail.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                email = e.Text.ToString();
            };

            campo_senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs s) => {
                senha = s.Text.ToString();
            };

            campo_confirmar_senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs c_s) => {
                confirmar_senha = c_s.Text.ToString();
            };

            campo_dt_nascimento.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) => {
                nascimento = n.Text.ToString();
            };

            campo_telefone.TextChanged += (object sender, Android.Text.TextChangedEventArgs t) => {
                telefone = t.Text.ToString();
            };

            botao_avançar.Click += delegate {
                ValidarCadastro();                
            };

        }

        private void ValidarCadastro()
        {
            if (confirmar_senha == senha && email != null)
            {
                string toast = ("Usuário Criado");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                //checar confirmar senha e usar validador
                Participante participante = new Participante(CriarDicionarioDeInformacoes());
                participante.Commit();

                var escolherfotoactivity = new Intent(this, typeof(EscolherFotoActivity));
                escolherfotoactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(escolherfotoactivity);
            }
            else
            {
                string toast = ("Informações inválidas");
                Toast.MakeText(this, toast, ToastLength.Long).Show();

                var inscreveractivity = new Intent(this, typeof(InscreverActivity));
                StartActivity(inscreveractivity);
            }

        }

        
        private Dictionary<string, string> CriarDicionarioDeInformacoes()
        {
            Dictionary<string, string> informacoes = new Dictionary<string, string>();
            informacoes["campus"] = campus;
            informacoes["senha"] = senha;
            informacoes["email"] = email;
            informacoes["nome"] = nome;
            informacoes["telefone"] = telefone;
            informacoes["nascimento"] = nascimento;

            return informacoes;
        }
    }
}


