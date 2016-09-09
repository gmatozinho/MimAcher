using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MimAcher
{
    [Activity(Label = "MimAcher", Theme = "@style/Theme.Splash")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Iniciando váriaveis
            String user = "Fulano";
            String password = null;
            EditText usuario = FindViewById<EditText>(Resource.Id.usuario);
            EditText senha = FindViewById<EditText>(Resource.Id.senha);

            // Resgatando o que foi digitado nos EditText
            usuario.TextChanged += (object sender, Android.Text.TextChangedEventArgs u) => {
                user = u.Text.ToString();
            };

            senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs p) => {
                password = p.Text.ToString();
            };


            //Initializing button from layout
            Button entrar = FindViewById<Button>(Resource.Id.entrar);
            Button inscrevase = FindViewById<Button>(Resource.Id.inscrevase);

            //Login button click action, e passando o nome do usuário para próxima activity
            entrar.Click += delegate {
                var resultadoActivity = new Intent(this, typeof(ResultadoActivity));
                resultadoActivity.PutExtra("user",user);
                StartActivity(resultadoActivity);
            };
            //Tenho que fazer a autenticação no banco de dados
            //Ideia é buscar usuario no banco, se existir retorna true e checa senha, se nao retorna usuario inexistente
            //Busca senha neste mesmo usuario, se for igual retorna true se nao retorna senha invalida

            inscrevase.Click += delegate {
                StartActivity(typeof(InscreverActivity));
            };
            
        }
    }
}

