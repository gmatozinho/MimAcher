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
using MimAcher.SourceCode;

namespace MimAcher
{
    [Activity(Label = "GostosActivity", Theme = "@style/Theme.Splash")]
    public class GostosActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Bundle b = Intent.GetBundleExtra("aluno");
            Aluno aluno = AlunoFactory.criarAluno(b);          

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Gostos);

            // Create your application here

            //Checkbox Variables
            CheckBox rock = FindViewById<CheckBox>(Resource.Id.rock);
            CheckBox games = FindViewById<CheckBox>(Resource.Id.games);
            CheckBox futebol = FindViewById<CheckBox>(Resource.Id.futebol);
            CheckBox pop = FindViewById<CheckBox>(Resource.Id.pop);
            CheckBox programacao = FindViewById<CheckBox>(Resource.Id.programacao);
            CheckBox empreender = FindViewById<CheckBox>(Resource.Id.empreender);
            CheckBox viajar = FindViewById<CheckBox>(Resource.Id.viajar);
            CheckBox analise_sistemas = FindViewById<CheckBox>(Resource.Id.analise_sistemas);

            //Buttons
            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            Button ok = FindViewById<Button>(Resource.Id.ok);

            //Change button text
            nome_user.Text = aluno.Nome;
            
            


            //Button name to perfil
            nome_user.Click += delegate {
                var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                //só falta atualizar
                editaractivity.PutExtra("aluno", b);
                StartActivity(editaractivity);
            };

            //Button ok to nextpage
            ok.Click += delegate {
                Dictionary<string, bool> Gostos = criarDicionarioGostos();
                preencherGostosAluno(Gostos, aluno);
                aluno.commit();

                var queroaprenderactivity = new Intent(this, typeof(QueroAprenderActivity));
                //mudar para trabalhar com objeto do banco
                queroaprenderactivity.PutExtra("aluno", b);
                StartActivity(queroaprenderactivity);
            };

        }

        private Dictionary<string, bool> criarDicionarioGostos()
        {
            Dictionary<string, bool> Gostos = new Dictionary<string, bool>();
            CheckBox rock = FindViewById<CheckBox>(Resource.Id.rock);
            CheckBox games = FindViewById<CheckBox>(Resource.Id.games);
            CheckBox futebol = FindViewById<CheckBox>(Resource.Id.futebol);
            CheckBox pop = FindViewById<CheckBox>(Resource.Id.pop);
            CheckBox programacao = FindViewById<CheckBox>(Resource.Id.programacao);
            CheckBox empreender = FindViewById<CheckBox>(Resource.Id.empreender);
            CheckBox viajar = FindViewById<CheckBox>(Resource.Id.viajar);
            CheckBox analise_sistemas = FindViewById<CheckBox>(Resource.Id.analise_sistemas);

            Gostos.Add(rock.Text, rock.Checked);
            Gostos.Add(games.Text, games.Checked);
            Gostos.Add(futebol.Text, futebol.Checked);
            Gostos.Add(pop.Text, pop.Checked);
            Gostos.Add(programacao.Text, programacao.Checked);
            Gostos.Add(empreender.Text, empreender.Checked);
            Gostos.Add(viajar.Text, viajar.Checked);
            Gostos.Add(analise_sistemas.Text, analise_sistemas.Checked);

            return Gostos;
        }

        private void preencherGostosAluno(Dictionary<string, bool> Gostos, Aluno aluno)
        {
            foreach (String strKey in Gostos.Keys)
            {
                if (Gostos[strKey])
                {
                    aluno.adicionarGosto(strKey);
                }
            }
        }
    }
}