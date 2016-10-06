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

namespace MimAcher.Activities
{
    [Activity(Label = "VinculoIfesActivity")]
    public class VinculoIfesActivity : Activity
    {
        //Initializing variables from layout
        string usuario = null;
        string senha = null;
        string nome = "Fulano";
        string email = null;
        string nascimento = null;
        string telefone = null;

        View line_fim_curso;
        EditText campo_dt_fim_curso;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your application here
            SetContentView(Resource.Layout.VinculoIfes);

            Button botao_avançar = FindViewById<Button>(Resource.Id.avançar);
            Spinner tipo_usuario = FindViewById<Spinner>(Resource.Id.user_type);
            Spinner campus = FindViewById<Spinner>(Resource.Id.campus);
            campo_dt_fim_curso = FindViewById<EditText>(Resource.Id.dt_fimcurso);
            line_fim_curso = FindViewById<View>(Resource.Id.conclusão_curso_line);

            //Escolhendo o Campus
            var opcoes_campus = new List<string>() { "Serra", "Vitória", "Vila Velha" };
            var adapter_campus = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoes_campus);
            adapter_campus.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            campus.Adapter = adapter_campus;
            var escolha_campus = campus.SelectedItem;
            campus.ItemSelected += spinner_ItemSelected_campus;

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            //ActionBar.SetLogo(Resource.Drawable.icone_actionbar);


            //Escolhendo tipo de usuário
            var opcoes_tipo_usuario = new List<string>() { "Aluno", "Ex-Aluno", "Servidor" };
            var adapter_tipo_usuario = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoes_tipo_usuario);
            adapter_tipo_usuario.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            tipo_usuario.Adapter = adapter_tipo_usuario;
            tipo_usuario.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected_tipo_usuario);

            botao_avançar.Click += delegate {
                Participante participante = CriarParticipante();
                participante.Commit();

                var inscreveractivity = new Intent(this, typeof(InscreverActivity));
                inscreveractivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(inscreveractivity);
            };
            
        }

        private void spinner_ItemSelected_campus(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner campus = (Spinner)sender;

            //string toast = string.Format("Campus selecionado: {0}", campus.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();

        }


        private void spinner_ItemSelected_tipo_usuario(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner tipo_usuario = (Spinner)sender;

            //string toast = string.Format("Tipo Usuário selecionado: {0}", tipo_usuario.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();

            var escolha_tipo_usuario = tipo_usuario.SelectedItem;
            if (escolha_tipo_usuario.ToString() == "Aluno")
            {
                campo_dt_fim_curso.Visibility = ViewStates.Visible;
                line_fim_curso.Visibility = ViewStates.Visible;
            }
            else
            {
                campo_dt_fim_curso.Visibility = ViewStates.Invisible;
                line_fim_curso.Visibility = ViewStates.Invisible;
            }
        }

        
        private Participante CriarParticipante()
        {
            Dictionary<string, string> informacoes = new Dictionary<string, string>();
            informacoes["id"] = usuario;
            informacoes["senha"] = senha;
            informacoes["email"] = email;
            informacoes["nome"] = nome;
            informacoes["telefone"] = telefone;
            informacoes["nascimento"] = nascimento;

            Participante participante = new Participante(informacoes);

            return participante;
        }
    }
}