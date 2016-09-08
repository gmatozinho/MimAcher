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

namespace MimAcher
{
    [Activity(Label = "InscreverActivity", Theme = "@style/Theme.Splash")]
    public class InscreverActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Inscrever);
            //Initializing button and variables from layout
            String user = "Fulano";
            String password = null;
            String name = null;
            String email = null;
            String age = null;
            String phone = null;

            //Resgatando o que foi digitado nos EditText
            Button avançar = FindViewById<Button>(Resource.Id.avançar);
            EditText usuario = FindViewById<EditText>(Resource.Id.usuario);
            EditText senha = FindViewById<EditText>(Resource.Id.senha);
            EditText nome = FindViewById<EditText>(Resource.Id.nome);
            EditText e_mail = FindViewById<EditText>(Resource.Id.email);
            EditText idade = FindViewById<EditText>(Resource.Id.idade);
            EditText telefone = FindViewById<EditText>(Resource.Id.telefone);

            //Pegar as informações inseridas
            usuario.TextChanged += (object sender, Android.Text.TextChangedEventArgs u) => {
                user = u.Text.ToString();
            };

            senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs p) => {
                password = p.Text.ToString();
            };

            nome.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) => {
                name = n.Text.ToString();
            };

            e_mail.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                email = e.Text.ToString();
            };

            idade.TextChanged += (object sender, Android.Text.TextChangedEventArgs a) => {
                age = a.Text.ToString();
            };

            telefone.TextChanged += (object sender, Android.Text.TextChangedEventArgs p) => {
                phone = p.Text.ToString();
            };

            //Inserir informações no banco, porém antes checar persistência
            //trabalhar com envio do objeto
            

            //Choose Picture button click action
            avançar.Click += delegate {
                var escolherfotoactivity = new Intent(this, typeof(EscolherFotoActivity));
                escolherfotoactivity.PutExtra("user", user);
                StartActivity(escolherfotoactivity);
            };

            //TODO Configurar recepção das informações nos campos
        }
    }
}


