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
using MimAcher.Activities;

namespace MimAcher
{
    [Activity(Label = "EditarPerfilActivity", Theme = "@style/Theme.Splash")]
    public class EditarPerfilActivity : Activity
    {
        public Bundle participante_bundle;
        string email;
        string nascimento;
        string telefone;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            participante_bundle = Intent.GetBundleExtra("member");
            Participante participante = Participante.BundleToParticipante(participante_bundle);

            // Create your application here
            SetContentView(Resource.Layout.EditarPerfil);

            Button salvar = FindViewById<Button>(Resource.Id.salvar);
            TextView alterar_senha = FindViewById<TextView>(Resource.Id.alterar_senha);
            EditText telefone_info_user = FindViewById<EditText>(Resource.Id.tel_number_user);
            EditText email_info_user = FindViewById<EditText>(Resource.Id.email_info_user);
            EditText dt_nascimento_info_user = FindViewById<EditText>(Resource.Id.dt_nascimento_info_user);

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = participante.Nome;
            ActionBar.SetLogo(Resource.Drawable.ic_account_circle_white_36dp);

            telefone_info_user.Hint = participante.Telefone;
            email_info_user.Hint = participante.Email;
            dt_nascimento_info_user.Hint = participante.Nascimento;

            //Para alterar
            email = participante.Email;
            telefone = participante.Telefone;
            nascimento = participante.Nascimento;

            //Pegar as informações inseridas
            email_info_user.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
                email = e.Text.ToString();
            };

            dt_nascimento_info_user.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) =>
            {
                nascimento = n.Text.ToString();
            };

            telefone_info_user.TextChanged += (object sender, Android.Text.TextChangedEventArgs t) =>
            {
                telefone = t.Text.ToString();
            };


            alterar_senha.Click += delegate
            {
                var alterarsenhaactivity = new Intent(this, typeof(AlterarSenhaActivity));
                //mudar para trabalhar com objeto do banco
                alterarsenhaactivity.PutExtra("member", participante_bundle);
                StartActivity(alterarsenhaactivity);
            };

            salvar.Click += delegate
            {
                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //mudar para trabalhar com objeto do banco
                //deverá rolar um commit para salvar alterações no banco
                AlterarParticipante(participante);
                resultadoactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(resultadoactivity);
            };
        }

            //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_nosearch, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        //Define as funcionalidades destes menus
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_home:
                    //do something
                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    //mudar para trabalhar com objeto do banco
                    resultadoctivity.PutExtra("member", participante_bundle);
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    //do something
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

         
        private void AlterarParticipante(Participante participante)
        {
            participante.Email = email;
            participante.Telefone = telefone;
            participante.Nascimento = nascimento;
        }
    }
}